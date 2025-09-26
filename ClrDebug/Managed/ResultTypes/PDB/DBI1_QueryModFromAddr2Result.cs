using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("ppmod = {ppmod}, pisect = {pisect}, poff = {poff}, pcb = {pcb}, pdwCharacteristics = {pdwCharacteristics}")]
    public struct DBI1_QueryModFromAddr2Result
    {
        public Mod1 ppmod;
        public ushort pisect;
        public int poff;
        public int pcb;
        public IMAGE_SCN pdwCharacteristics;

        public DBI1_QueryModFromAddr2Result(Mod1 ppmod, ushort pisect, int poff, int pcb, IMAGE_SCN pdwCharacteristics)
        {
            this.ppmod = ppmod;
            this.pisect = pisect;
            this.poff = poff;
            this.pcb = pcb;
            this.pdwCharacteristics = pdwCharacteristics;
        }
    }
}
