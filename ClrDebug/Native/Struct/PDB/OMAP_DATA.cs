using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("rva = {rva.ToString(\"X\"),nq}, rvaTo = {rvaTo.ToString(\"X\"),nq}")]
    public struct OMAP_DATA
    {
        public int rva;
        public int rvaTo;
    }
}
