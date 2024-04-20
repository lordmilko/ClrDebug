using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("SectSmall = {SectSmall.ToString(),nq}, Reserved = {Reserved}, Clauses = {Clauses}")]
    public unsafe struct IMAGE_COR_ILMETHOD_SECT_EH_SMALL
    {
        public IMAGE_COR_ILMETHOD_SECT_SMALL SectSmall;
        public short Reserved;
        public fixed byte Clauses[1]; //IMAGE_COR_ILMETHOD_SECT_EH_CLAUSE_SMALL
    }
}
