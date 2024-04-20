using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("SizeOfDescription = {SizeOfDescription}, Flags = {Flags.ToString(),nq}, SegmentBase = {SegmentBase}, SegmentSize = {SegmentSize}, SegmentBitness = {SegmentBitness}")]
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
