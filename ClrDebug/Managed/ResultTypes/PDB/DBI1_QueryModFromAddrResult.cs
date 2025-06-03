using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("ppmod = {ppmod}, pisect = {pisect}, poff = {poff}, pcb = {pcb}")]
    public struct DBI1_QueryModFromAddrResult
    {
        public Mod1 ppmod;
        public ushort pisect;
        public int poff;
        public int pcb;

        public DBI1_QueryModFromAddrResult(Mod1 ppmod, ushort pisect, int poff, int pcb)
        {
            this.ppmod = ppmod;
            this.pisect = pisect;
            this.poff = poff;
            this.pcb = pcb;
        }
    }
}
