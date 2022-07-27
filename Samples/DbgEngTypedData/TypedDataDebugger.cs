using System;
using System.Text;
using System.Threading;
using ClrDebug.DbgEng;
using DbgEngConsole;
using DbgEngTypedData.Custom;

namespace DbgEngTypedData
{
    class TypedDataDebugger : Debugger
    {
        protected override void InputLoop()
        {
            //Demonstrate listing all of the loaded modules in a process from a PEB. Two demonstrations are provided as how to do this.

            //The Manual() method shows step by step the API calls required to retrieve this information via DbgEng.
            Manual();

            //The Custom() method gets a bit fancier and demonstrates how a whole entire object module can built on top of these APIs to allow easy exploration/analysis of typed data.
            Custom();

            Console.WriteLine(Environment.NewLine + "Sample completed");

            while (true)
                Thread.Sleep(1);
        }

        #region Manual

        private void Manual()
        {
            /* You can do GetTypeId by doing ntdll!_PEB and no base, but we're going to need the base for other methods anyway.
             * You can also get both the type ID and the module base at once using IDebugSymbols.GetSymbolTypeId() */
            var ntdll = Client.Symbols.GetModuleByModuleName("ntdll", 0);
            var pebTypeId = Client.Symbols.GetTypeId(ntdll.Base, "_PEB");

            //DbgEng will get the peb address via a NtQueryInformationProcess for PROCESS_BASIC_INFORMATION
            var pebAddress = Client.SystemObjects.CurrentProcessPeb;

            /* Ostensibly we could use ReadTypedDataVirtual<T> right now to create a struct out of the PEB; we won't do that however to highlight the following issue:
             * IDebugSymbols.ReadTypedDataVirtual will return S_FALSE if you attempt to read less than the full size of the actual structure. ClrDebug's
             * TryReadTypedDataVirtual<T>() extension will give you a partial response based on the struct fields you have specified (demonstrated below with LDR_DATA_TABLE_ENTRY;
             * it has a lot more members than we've defined!). Even if you do define all the members of each type, you're then still assuming the offsets of those members won't shift around
             * in future Windows versions.
             *
             * As such, the most robust way of interacting with typed data is to do so dynamically, by calculating the offsets of each desired field using symbols.
             * This is what is demonstrated in our non-Manual example below; for the purposes of the Manual sample, we'll demonstrate how the GetFieldOffset() method can be used for retrieving
             * the offset of a field.
             */
            var ldrOffset = Client.Symbols.GetFieldOffset(ntdll.Base, pebTypeId, "Ldr");

            /* The Ldr field is a pointer; therefore we need to read the address of the PEB_LDR_DATA before we try
             * and read the PEB_LDR_DATA itself */
            var ldrPtr = Client.DataSpaces.ReadVirtual<IntPtr>(pebAddress + ldrOffset);

            //PEB_LDR_DATA is at least a bit more stable than PEB is so we should be able to turn it into typed data
            var pebLdrDataTypeId = Client.Symbols.GetTypeId(ntdll.Base, "_PEB_LDR_DATA");

            /* As described above, use TryReadTypedDataVirtual() rather than ReadTypedDataVirtual() as the latter will throw on not S_OK but we're happy
             * to have a partial read with S_FALSE in our scenario */
            Client.Symbols.TryReadTypedDataVirtual<PEB_LDR_DATA>(ldrPtr.ToInt64(), ntdll.Base, pebLdrDataTypeId, out var ldr).ThrowDbgEngFailed();

            ListModules(ntdll.Base, ldr.InLoadOrderModuleList);
        }

        private void ListModules(long moduleBase, LIST_ENTRY inLoadOrderModuleList)
        {
            var ldrDataTableEntryTypeId = Client.Symbols.GetTypeId(moduleBase, "_LDR_DATA_TABLE_ENTRY");
            var listEntryTypeId = Client.Symbols.GetTypeId(moduleBase, "_LIST_ENTRY");

            //PEB.Ldr.InLoadOrderModuleList.Flink actually points to the InMemoryOrderLinks member halfway into a LDR_DATA_TABLE_ENTRY structure.
            //Let's get the start of that structure
            var inMemoryOrderLinksOffset = Client.Symbols.GetFieldOffset(moduleBase, ldrDataTableEntryTypeId, "InMemoryOrderLinks");

            var current = inLoadOrderModuleList;

            //Normally you would check to see whether an entry points to the list head to determine when you're at the end of the list. Because we used type data, our list head is a LIST_ENTRY instead of a LIST_ENTRY*
            //This is kind of problematic, but we can work around this by instead looking to see whether a LIST_ENTRY.Flink points to a LIST_ENTRY with the Flink of the list head - if so then we know we're at the end

            while (true)
            {
                var next = Client.Symbols.ReadTypedDataVirtual<LIST_ENTRY>(
                    current.Flink.ToInt64(),
                    moduleBase,
                    listEntryTypeId
                );

                //If the LIST_ENTRY that the current LIST_ENTRY points to is the head, we've reached the end of the list. Normally you would compare the two LIST_ENTRY*'s addresses, but since
                //we're using typed data we don't know the head entries' address, so we'll compare using its Flink instead
                //https://docs.microsoft.com/en-us/windows-hardware/drivers/kernel/singly-and-doubly-linked-lists
                if (next.Flink == inLoadOrderModuleList.Flink)
                    break;

                //Rewind a few bytes from the address Flink points to to the start of the actual structure
                var ldrDataTableEntryPtr = current.Flink - inMemoryOrderLinksOffset;

                Client.Symbols.TryReadTypedDataVirtual<LDR_DATA_TABLE_ENTRY>(
                    ldrDataTableEntryPtr.ToInt64(),
                    moduleBase,
                    ldrDataTableEntryTypeId,
                    out var ldrDataTableEntry
                ).ThrowDbgEngFailed();

                var name = ReadString(ldrDataTableEntry.BaseDllName);

                Console.WriteLine(name);

                current = next;
            }
        }

        private string ReadString(UNICODE_STRING unicodeString)
        {
            var bytes = Client.DataSpaces.ReadVirtual(unicodeString.Buffer.ToInt64(), unicodeString.Length);

            var str = Encoding.Unicode.GetString(bytes);

            return str;
        }

        #endregion

        private void Custom()
        {
            /* Our typed data object model defines the following types
             *
             * -DbgType            : encapsulates information about a type - its name, type ID (or "Type Index" in DbgHelp terms), module, tag (symbol type), the fields it has, etc
             * -DbgFieldInfo       : describes a field that exists on a DbgType
             * -DbgModule          : describes a module that a type belongs to. One would expect that any types referenced by a structure would all be embedded in the final executable,
             *                       so we'd say that any type referenced in a type hierarchy will exists within the same module
             *
             * -DbgObject          : describes an actual instance of a DbgType that exists at a specific address, as well as the actual fields the object contains and their actual values
             * -DbgField           : describes a field that exists on a DbgObject. In addition to the field's DbgFieldInfo, stores the value of the field (for simple types) or points to another DbgObject (for more complex types)
             * -DbgComplexField    : represents a field that points to another DbgObject, rather than a simple value (like an integer or boolean)
             *
             * -DbgListEntry       : a special type of DbgObject for providing an enumerator around LIST_ENTRY structures
             * -DbgUnicodeString   : a special type of DbgObject for providing access to the string that is contained in a UNICODE_STRING structure
             *
             * -DbgFieldCollection : container for storing DbgField objects that allows accessing fields via an indexer
             * -DbgState           : container around the common DbgEng state (our DebugClient, etc) that can be passed to our typed data objects
             */

            //DbgEng will get the peb address via a NtQueryInformationProcess for PROCESS_BASIC_INFORMATION
            var pebAddress = Client.SystemObjects.CurrentProcessPeb;

            //Interpret this address as a _PEB structure, which is defined as a UDT in ntdll
            var peb = new DbgObject(pebAddress, "ntdll!_PEB", Client);

            var moduleList = (DbgListEntryHead) peb.Fields["Ldr"]["InLoadOrderModuleList"];

            /* Each LIST_ENTRY points to the LIST_ENTRY InMemoryOrderLinks member of a _LDR_DATA_TABLE_ENTRY structure - the second member in this structure. As such,
             * we need to rewind a few bytes to get a pointer to the start of the _LDR_DATA_TABLE_ENTRY structure. Our enumerator will automatically take care of calculating
             * this offset for us */
            var list = moduleList.ToList("ntdll!_LDR_DATA_TABLE_ENTRY", "InMemoryOrderLinks");

            foreach (var module in list)
            {
                /* To access a DbgObject in a DbgField on a parent DbgObject, you would normally have to do
                 *     (DbgObject) parent.Field["Name"].Value
                 *
                 * This is very verbose, so our typed data API adds the following syntactic sugars:
                 * -Indexing the DbgObject is the same as indexing the Field member
                 * -DbgField objects are implicitly convertable to DbgObject
                 *
                 * As such, the above can be simplified to
                 *     DbgObject name = parent["Name"]
                 *
                 * If a DbgField actually contains a simple object value (an integer or a boolean) the implicit cast will fail and an exception will be thrown
                 */
                var dll = (DbgUnicodeString) module["BaseDllName"];

                Console.WriteLine(dll.String);
            }
        }
    }
}
