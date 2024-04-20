using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("SectFat = {SectFat.ToString(),nq}, Clauses = {Clauses}")]
    public unsafe struct IMAGE_COR_ILMETHOD_SECT_EH_FAT
    {
        public IMAGE_COR_ILMETHOD_SECT_FAT SectFat;
        public fixed byte Clauses[1]; //IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_FAT
    }
}
