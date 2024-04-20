namespace ClrDebug.DbgEng
{
    public unsafe struct DEBUG_PROCESSOR_IDENTIFICATION_X86
    {
        public int Family;
        public int Model;
        public int Stepping;
        public fixed byte VendorString[16];
    }
}