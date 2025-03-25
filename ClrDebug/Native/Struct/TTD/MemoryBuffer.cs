using System;

namespace ClrDebug.TTD
{
    public struct MemoryBuffer
    {
        public GuestAddress address;
        public IntPtr data;
        public long size;
    }
}