using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// A description of a particular segment.
    /// </summary>
    [DebuggerDisplay("SizeOfDescription = {SizeOfDescription}, Flags = {Flags.ToString(),nq}, SegmentBase = {SegmentBase}, SegmentSize = {SegmentSize}, SegmentBitness = {SegmentBitness}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcSegmentDescription
    {
        /// <summary>
        /// Defines the size of this data structure.
        /// </summary>
        public int SizeOfDescription;

        /// <summary>
        /// Flags (as per SvcSegmentFlags -- undefined bits set to zero).
        /// </summary>
        public SvcSegmentFlags Flags;

        /// <summary>
        /// Linear address of the base of the segment.
        /// </summary>
        public long SegmentBase;

        /// <summary>
        /// Size/limit of the segment in bytes.
        /// </summary>
        public long SegmentSize;

        /// <summary>
        /// 16/32/64 -- indicates the bitness of the segment.
        /// </summary>
        public int SegmentBitness;
    }
}
