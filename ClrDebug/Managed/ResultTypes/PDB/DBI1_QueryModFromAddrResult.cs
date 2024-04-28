using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("mod1 = {mod1}, pisect = {pisect}, poff = {poff}, pcb = {pcb}")]
    public struct DBI1_QueryModFromAddrResult
    {
        public Mod1 mod1;
        public short pisect;
        public int poff;
        public int pcb;

        public DBI1_QueryModFromAddrResult(Mod1 mod1, short pisect, int poff, int pcb)
        {
            this.mod1 = mod1;
            this.pisect = pisect;
            this.poff = poff;
            this.pcb = pcb;
        }
    }
}
