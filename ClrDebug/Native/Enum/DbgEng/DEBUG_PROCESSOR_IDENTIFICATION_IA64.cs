namespace ClrDebug.DbgEng
{
    public unsafe struct DEBUG_PROCESSOR_IDENTIFICATION_IA64
    {
        public int Model;
        public int Revision;
        public int Family;
        public int ArchRev;
        public fixed byte VendorString[16];
    }
}