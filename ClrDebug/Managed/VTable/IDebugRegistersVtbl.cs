using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugRegistersVtbl
    {
        public readonly IntPtr GetNumberRegisters;
        public readonly IntPtr GetDescription;
        public readonly IntPtr GetIndexByName;
        public readonly IntPtr GetValue;
        public readonly IntPtr SetValue;
        public readonly IntPtr GetValues;
        public readonly IntPtr SetValues;
        public readonly IntPtr OutputRegisters;
        public readonly IntPtr GetInstructionOffset;
        public readonly IntPtr GetStackOffset;
        public readonly IntPtr GetFrameOffset;
    }
}
