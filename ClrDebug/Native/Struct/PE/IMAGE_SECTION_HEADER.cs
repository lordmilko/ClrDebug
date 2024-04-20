using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("Name = {Name}, VirtualSize = {VirtualSize}, VirtualAddress = {VirtualAddress}, SizeOfRawData = {SizeOfRawData}, PointerToRawData = {PointerToRawData}, PointerToRelocations = {PointerToRelocations}, PointerToLineNumbers = {PointerToLineNumbers}, NumberOfRelocations = {NumberOfRelocations}, NumberOfLineNumbers = {NumberOfLineNumbers}, Characteristics = {Characteristics.ToString(),nq}")]
    public unsafe struct IMAGE_SECTION_HEADER
    {
        private const int IMAGE_SIZEOF_SHORT_NAME = 8;
        public fixed byte Name[IMAGE_SIZEOF_SHORT_NAME];
        public int VirtualSize;
        public int VirtualAddress;
        public int SizeOfRawData;
        public int PointerToRawData;
        public int PointerToRelocations;
        public int PointerToLineNumbers;
        public short NumberOfRelocations;
        public short NumberOfLineNumbers;
        public IMAGE_SCN Characteristics;
    }
}
