using System.Diagnostics;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("pimod = {pimod}, pisect = {pisect}, poff = {poff}, pisectCoff = {pisectCoff}, pcb = {pcb}, pdwCharacteristics = {pdwCharacteristics}")]
    public struct EnumContrib_Get2Result
    {
        public ushort pimod;
        public ushort pisect;
        public int poff;
        public int pisectCoff;
        public int pcb;
        public IMAGE_SCN pdwCharacteristics;

        public EnumContrib_Get2Result(ushort pimod, ushort pisect, int poff, int pisectCoff, int pcb, IMAGE_SCN pdwCharacteristics)
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
