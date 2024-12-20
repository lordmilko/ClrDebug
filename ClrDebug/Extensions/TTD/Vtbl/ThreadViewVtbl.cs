using System;

namespace ClrDebug.TTD
{
#pragma warning disable CS0649
    internal struct ThreadViewVtbl
    {
        public IntPtr GetThreadInfo;
        public IntPtr GetTebAddress;
        public IntPtr GetPosition;
        public IntPtr GetPreviousPosition;
        public IntPtr GetProgramCounter;
        public IntPtr GetStackPointer;
        public IntPtr GetFramePointer;
        public IntPtr GetBasicReturnValue;
        public IntPtr GetCrossPlatformContext;
        public IntPtr GetAvxExtendedContext;
        public IntPtr QueryMemoryRange;
        public IntPtr QueryMemoryBuffer;
        public IntPtr QueryMemoryBufferWithRanges;
        public IntPtr scalar_deleting_destructor;
    }
#pragma warning restore CS0649
}
