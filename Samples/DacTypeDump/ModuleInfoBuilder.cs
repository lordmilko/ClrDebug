using System;
using System.Collections.Generic;
using ClrDebug;

namespace DacTypeDump
{
    class ModuleInfoBuilder
    {
        private SOSDacInterface sosDacInterface;
        private XCLRDataModule clrDataModule;
        private MetaDataImport metaDataImport;

        public string AssemblyName { get; }

        public List<TypeMetaData> Types { get; } = new List<TypeMetaData>();

        private Exception exception;

        public ModuleInfoBuilder(string assemblyName, SOSDacInterface sosDacInterface, CLRDATA_ADDRESS moduleAddress)
        {
            AssemblyName = assemblyName;
            this.sosDacInterface = sosDacInterface;

            //Get a ClrDataModule
            clrDataModule = sosDacInterface.GetModule(moduleAddress);

            DacpGetModuleAddress data = new DacpGetModuleAddress();
            data.Request(clrDataModule.Raw);

            //ClrDataModule does not implement IMetaDataImport, but you can QueryInterface it in order to retrieve one
            metaDataImport = new MetaDataImport((IMetaDataImport)clrDataModule.Raw);

            //Some interesting data about the module. We don't actually need this data in this sample
            var moduleData = sosDacInterface.GetModuleData(moduleAddress);

            /* This method expects you to pass it the address of a module. Do not pass moduleData.Type{Def/Ref}ToMethodTableMap
             * to this function - while TraverseModuleMap does use these addresses, it gets them from the module itself, not from you.
             * ClrDataAccess::TraverseModuleMap does not provide a mechanism to abort its iterator beyond throwing an exception. */
            var hr = sosDacInterface.TryTraverseModuleMap(ModuleMapType.TypeDefToMethodTable, moduleAddress, TypeDefToModuleCallback, IntPtr.Zero);

            //If TypeDefToModuleCallback throws an exception, TraverseModuleMap will simply return E_FAIL. As such, we cache our exception so we can rethrow it afterwards
            if (hr != HRESULT.S_OK)
            {
                if (exception != null)
                    throw exception;

                hr.ThrowOnNotOK();
            }
        }

        private void TypeDefToModuleCallback(int index, CLRDATA_ADDRESS methodtable, IntPtr token)
        {
            try
            {
                /* According to SOS, the lower 2 bits of a method table can be used by GC to indicate that we are currently in mark phase, and these bits should be cleared
                 * before trying to use the methodtable. This can be seen in a variety of places, including !DumpMT */
                CLRDATA_ADDRESS correctedMT = methodtable & ~3;

                string name;

                //If the methodtable fails DacValidateMethodTable() this method will return E_INVALIDARG
                if (sosDacInterface.TryGetMethodTableName(correctedMT, out name) != HRESULT.S_OK)
                    name = "Invalid";

                /* Every type within an AppDomain is represented using a MethodTable. Get the mdTypeDef of this MethodTable so we can start analyzing its metadata.
                 * Some MethodTables may fail the check MethodTable::ValidateWithPossibleAV, resulting in E_INVALIDARG / COR_E_ARGUMENT being returned. Others may
                 * have a parent MethodTable that points to an invalid memory address. I don't know why these things happen */
                DacpMethodTableData data = new DacpMethodTableData();
                var hr = data.Request(sosDacInterface.Raw, correctedMT);

                Program.LogLevel = 1;
                Program.Log($"{correctedMT} | {name}", hr == HRESULT.S_OK ? ConsoleColor.Green : ConsoleColor.Red);

                if (hr != HRESULT.S_OK)
                    return;

                //Get the name of the type
                var typeInfo = metaDataImport.GetTypeDefProps(data.cl);

                var typeMetaData = new TypeMetaData(typeInfo.szTypeDef);

                //Now we'll simply iterate over all its members
                var members = metaDataImport.EnumMembers(data.cl);

                foreach (var member in members)
                {
                    switch (member.Type)
                    {
                        case CorTokenType.mdtMethodDef:
                            var methodInfo = metaDataImport.GetMethodProps((mdMethodDef) member);
                            typeMetaData.AddMethod(methodInfo);
                            break;

                        case CorTokenType.mdtFieldDef:
                            var fieldInfo = metaDataImport.GetFieldProps((mdFieldDef) member);
                            typeMetaData.AddField(fieldInfo);
                            break;

                        default:
                            throw new NotImplementedException($"Don't know how to handle a member of type '{member.Type}'.");
                    }
                }

                Types.Add(typeMetaData);
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
        }
    }
}
