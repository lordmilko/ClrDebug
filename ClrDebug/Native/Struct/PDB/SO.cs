using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("off = {off}, isect = {isect}")]
    public struct SO
    {
        public int off;
        public ushort isect;
        public short pad;
    }
}
