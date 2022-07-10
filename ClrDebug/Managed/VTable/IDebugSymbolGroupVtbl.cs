using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IDebugSymbolGroupVtbl
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
    }
}
