using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IDebugRegisters2Vtbl
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
        public readonly IntPtr GetDescriptionWide;
        public readonly IntPtr GetIndexByNameWide;
        public readonly IntPtr GetNumberPseudoRegisters;
        public readonly IntPtr GetPseudoDescription;
        public readonly IntPtr GetPseudoDescriptionWide;
        public readonly IntPtr GetPseudoIndexByName;
        public readonly IntPtr GetPseudoIndexByNameWide;
        public readonly IntPtr GetPseudoValues;
        public readonly IntPtr SetPseudoValues;
        public readonly IntPtr GetValues2;
        public readonly IntPtr SetValues2;
        public readonly IntPtr OutputRegisters2;
        public readonly IntPtr GetInstructionOffset2;
        public readonly IntPtr GetStackOffset2;
        public readonly IntPtr GetFrameOffset2;
    }
}
