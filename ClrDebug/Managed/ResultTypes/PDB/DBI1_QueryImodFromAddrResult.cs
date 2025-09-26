using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("pimod = {pimod}, pisect = {pisect}, poff = {poff}, pcb = {pcb}, pdwCharacteristics = {pdwCharacteristics}")]
    public struct DBI1_QueryImodFromAddrResult
    {
        public ushort pimod;
        public ushort pisect;
        public int poff;
        public int pcb;
        public IMAGE_SCN pdwCharacteristics;

        public DBI1_QueryImodFromAddrResult(ushort pimod, ushort pisect, int poff, int pcb, IMAGE_SCN pdwCharacteristics)
        {
            this.pimod = pimod;
            this.pisect = pisect;
            this.poff = poff;
            this.pcb = pcb;
            this.pdwCharacteristics = pdwCharacteristics;
        }
    }
}
