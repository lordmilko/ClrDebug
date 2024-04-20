namespace ClrDebug.DbgEng
{
    public unsafe struct DEBUG_PROCESSOR_IDENTIFICATION_AMD64
    {
        public int Family;
        public int Model;
        public int Stepping;
        public fixed byte VendorString[16];
    }
}