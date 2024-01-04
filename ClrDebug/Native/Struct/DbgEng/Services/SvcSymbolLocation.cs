using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Explicit)]
    public struct SvcSymbolLocation
    {
        [FieldOffset(0)]
        public SvcSymbolLocationKind Kind;

        [FieldOffset(4)]
        public long Offset;

        [FieldOffset(4)]
        public long Offsets; //int Pre / int Post

        [FieldOffset(4)]
        public long TableOffsets; //int TableOffset / int TableSlot:24 / int SlotSize:8

        [FieldOffset(4)]
        public long BitField; //int Offset / int FieldPosition:12 / int FieldSize: 12 / int Reserved:8

        [FieldOffset(12)]
        public SvcSymbolRegisterDescription RegInfo;
    }
}
