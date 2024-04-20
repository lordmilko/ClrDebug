namespace ClrDebug.DbgEng
{
    public unsafe struct DEBUG_PROCESSOR_IDENTIFICATION_ARM
    {
        public int Model;
        public int Revision;
        public fixed byte VendorString[16];
    }
}