using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes the location of a symbol in abstract terms. This does *NOT* correspond to definitions in the data model.
    /// </summary>
    [DebuggerDisplay("Kind = {Kind.ToString(),nq}, Offset = {Offset}, Offsets = {Offsets}, TableOffsets = {TableOffsets}, BitField = {BitField}, RegInfo = {RegInfo.ToString(),nq}")]
    [StructLayout(LayoutKind.Explicit)]
    public struct SvcSymbolLocation
    {
        /// <summary>
        /// Determines how the remainder of the fields are interpreted.
        /// </summary>
        [FieldOffset(0)]
        public SvcSymbolLocationKind Kind;

        /// <summary>
        /// This may be interpreted as a signed or unsigned offset.
        /// </summary>
        [FieldOffset(4)]
        public long Offset;

        [FieldOffset(4)]
        public long Offsets; //int Pre / int Post

        [FieldOffset(4)]
        public long TableOffsets; //int TableOffset / int TableSlot:24 / int SlotSize:8

        [FieldOffset(4)]
        public long BitField; //int Offset / int FieldPosition:12 / int FieldSize: 12 / int Reserved:8

        /// <summary>
        /// Information about the register that the location utilizes.
        /// </summary>
        [FieldOffset(12)]
        public SvcSymbolRegisterDescription RegInfo;
    }
}
