namespace ClrDebug
{
    public struct EnumThunk_GetResult
    {
        public ushort pisect { get; }

        public int poff { get; }

        public int pcb { get; }

        public EnumThunk_GetResult(ushort pisect, int poff, int pcb)
        {
            this.pisect = pisect;
            this.poff = poff;
            this.pcb = pcb;
        }
    }
}
