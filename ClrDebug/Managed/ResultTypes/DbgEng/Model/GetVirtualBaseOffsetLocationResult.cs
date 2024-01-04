using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostBaseClass.VirtualBaseOffsetLocation"/> property.
    /// </summary>
    [DebuggerDisplay("pTableOffset = {pTableOffset}, pSlotOffset = {pSlotOffset}, pSlotSize = {pSlotSize}, pSlotIsSigned = {pSlotIsSigned}")]
    public struct GetVirtualBaseOffsetLocationResult
    {
        public long pTableOffset { get; }

        public long pSlotOffset { get; }

        public long pSlotSize { get; }

        public bool pSlotIsSigned { get; }

        public GetVirtualBaseOffsetLocationResult(long pTableOffset, long pSlotOffset, long pSlotSize, bool pSlotIsSigned)
        {
            this.pTableOffset = pTableOffset;
            this.pSlotOffset = pSlotOffset;
            this.pSlotSize = pSlotSize;
            this.pSlotIsSigned = pSlotIsSigned;
        }
    }
}
