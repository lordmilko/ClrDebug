using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcSegmentDescription
    {
        public int SizeOfDescription;
        public SvcSegmentFlags Flags;
        public long SegmentBase;
        public long SegmentSize;
        public int SegmentBitness;
    }
}
