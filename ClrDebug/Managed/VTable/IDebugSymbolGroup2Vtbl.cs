using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IDebugSymbolGroup2Vtbl
    {
        public readonly IntPtr GetNumberSymbols;
        public readonly IntPtr AddSymbol;
        public readonly IntPtr RemoveSymbolByName;
        public readonly IntPtr RemoveSymbolsByIndex;
        public readonly IntPtr GetSymbolName;
        public readonly IntPtr GetSymbolParameters;
        public readonly IntPtr ExpandSymbol;
        public readonly IntPtr OutputSymbols;
        public readonly IntPtr WriteSymbol;
        public readonly IntPtr OutputAsType;
        public readonly IntPtr AddSymbolWide;
        public readonly IntPtr RemoveSymbolByNameWide;
        public readonly IntPtr GetSymbolNameWide;
        public readonly IntPtr WriteSymbolWide;
        public readonly IntPtr OutputAsTypeWide;
        public readonly IntPtr GetSymbolTypeName;
        public readonly IntPtr GetSymbolTypeNameWide;
        public readonly IntPtr GetSymbolSize;
        public readonly IntPtr GetSymbolOffset;
        public readonly IntPtr GetSymbolRegister;
        public readonly IntPtr GetSymbolValueText;
        public readonly IntPtr GetSymbolValueTextWide;
        public readonly IntPtr GetSymbolEntryInformation;
    }
}
