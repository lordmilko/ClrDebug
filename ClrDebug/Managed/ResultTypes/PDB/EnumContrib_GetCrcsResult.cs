namespace ClrDebug.PDB
{
    public struct EnumContrib_GetCrcsResult
    {
        public int pcrcData;
        public int pcrcReloc;

        public EnumContrib_GetCrcsResult(int pcrcData, int pcrcReloc)
        {
            this.pcrcData = pcrcData;
            this.pcrcReloc = pcrcReloc;
        }
    }
}
