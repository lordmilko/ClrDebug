using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("pimod = {pimod}, pisect = {pisect}, poff = {poff}, pisectCoff = {pisectCoff}, pcb = {pcb}, pdwCharacteristics = {pdwCharacteristics}")]
    public struct EnumContrib_Get2Result
    {
        public short pimod;
        public short pisect;
        public int poff;
        public int pisectCoff;
        public int pcb;
        public int pdwCharacteristics;

        public EnumContrib_Get2Result(short pimod, short pisect, int poff, int pisectCoff, int pcb, int pdwCharacteristics)
        {
            this.pimod = pimod;
            this.pisect = pisect;
            this.poff = poff;
            this.pisectCoff = pisectCoff;
            this.pcb = pcb;
            this.pdwCharacteristics = pdwCharacteristics;
        }
    }
}
