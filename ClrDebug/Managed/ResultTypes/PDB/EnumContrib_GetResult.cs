using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("pimod = {pimod}, pisect = {pisect}, poff = {poff}, pcb = {pcb}, pdwCharacteristics = {pdwCharacteristics}")]
    public struct EnumContrib_GetResult
    {
        public short pimod;
        public short pisect;
        public int poff;
        public int pcb;
        public int pdwCharacteristics;

        public EnumContrib_GetResult(short pimod, short pisect, int poff, int pcb, int pdwCharacteristics)
        {
            this.pimod = pimod;
            this.pisect = pisect;
            this.poff = poff;
            this.pcb = pcb;
            this.pdwCharacteristics = pdwCharacteristics;
        }
    }
}
