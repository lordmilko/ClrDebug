using System;
using System.Runtime.InteropServices;

namespace NativeSymbols
{
    public class SymbolInfo
    {
        public readonly int TypeIndex;   // Type Index of symbol
        public readonly int Index;
        public readonly int Size;
        public readonly ulong ModBase;     // Base Address of module containing this symbol
        public readonly SymbolInfoFlags Flags;
        public readonly ulong Value;       // Value of symbol, ValuePresent should be 1
        /// <summary>
        /// Address of symbol including base address of module
        /// </summary>
        public readonly ulong Address;
        public readonly int Register;    // register holding value or pointer to value
        public readonly int Scope;       // scope of the symbol
        public readonly SymTag Tag;         // pdb classification
        public readonly string Name;

        public readonly string ModuleName;
        public readonly string Type;
        public readonly string Member;

        internal SymbolInfo(IntPtr hProcess, IntPtr pNative, string moduleName)
        {
            SYMBOL_INFO native = (SYMBOL_INFO)Marshal.PtrToStructure(pNative, typeof(SYMBOL_INFO));

            if ((native.ModBase == 0) && (native.Address != 0))
            {
                //This is a workaround for when we're handed a SYMBOL_INFO with a null
                //ModBase but a non-zero Address. This can sometimes apparently happen when there aren't any symbols available
                native.ModBase = NativeMethods.SymGetModuleBase64(hProcess, native.Address);
            }

            TypeIndex = native.TypeIndex;
            Index = native.Index;
            Size = native.Size;
            ModBase = native.ModBase;
            Flags = native.Flags;
            Value = native.Value;
            Address = native.Address;
            Register = native.Register;
            Scope = native.Scope;
            Tag = native.Tag;

            pNative += 0x54;

            Name = Marshal.PtrToStringAnsi(pNative, (int)native.NameLen);
            ModuleName = moduleName;

            var lastColon = Name.LastIndexOf(':');

            if (lastColon != -1)
            {
                Type = Name.Substring(0, lastColon - 1);
                Member = Name.Substring(lastColon + 1);
            }
        }

        public override string ToString()
        {
            return $"{ModuleName}!{Name}";
        }
    }
}
