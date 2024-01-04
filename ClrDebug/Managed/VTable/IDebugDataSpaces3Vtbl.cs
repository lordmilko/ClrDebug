using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugDataSpaces3Vtbl
    {
        public readonly IntPtr ReadVirtual;
        public readonly IntPtr WriteVirtual;
        public readonly IntPtr SearchVirtual;
        public readonly IntPtr ReadVirtualUncached;
        public readonly IntPtr WriteVirtualUncached;
        public readonly IntPtr ReadPointersVirtual;
        public readonly IntPtr WritePointersVirtual;
        public readonly IntPtr ReadPhysical;
        public readonly IntPtr WritePhysical;
        public readonly IntPtr ReadControl;
        public readonly IntPtr WriteControl;
        public readonly IntPtr ReadIo;
        public readonly IntPtr WriteIo;
        public readonly IntPtr ReadMsr;
        public readonly IntPtr WriteMsr;
        public readonly IntPtr ReadBusData;
        public readonly IntPtr WriteBusData;
        public readonly IntPtr CheckLowMemory;
        public readonly IntPtr ReadDebuggerData;
        public readonly IntPtr ReadProcessorSystemData;
        public readonly IntPtr VirtualToPhysical;
        public readonly IntPtr GetVirtualTranslationPhysicalOffsets;
        public readonly IntPtr ReadHandleData;
        public readonly IntPtr FillVirtual;
        public readonly IntPtr FillPhysical;
        public readonly IntPtr QueryVirtual;
        public readonly IntPtr ReadImageNtHeaders;
        public readonly IntPtr ReadTagged;
        public readonly IntPtr StartEnumTagged;
        public readonly IntPtr GetNextTagged;
        public readonly IntPtr EndEnumTagged;
    }
}
