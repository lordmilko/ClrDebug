using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("Section = {Section.ToString(),nq}, Flags = {Flags.ToString(),nq}, Type = {Type.ToString(),nq}, EntrySize = {EntrySize}, Signatures = {Signatures}, AuxiliaryData = {AuxiliaryData}")]
    public struct READYTORUN_IMPORT_SECTION
    {
        public IMAGE_DATA_DIRECTORY Section; // Section containing values to be fixed up
        public ReadyToRunImportSectionFlags Flags; // One or more of ReadyToRunImportSectionFlags
        public ReadyToRunImportSectionType Type; // One of ReadyToRunImportSectionType
        public byte EntrySize;
        public int Signatures; // RVA of optional signature descriptors
        public int AuxiliaryData; // RVA of optional auxiliary data (typically GC info)
    }
}
