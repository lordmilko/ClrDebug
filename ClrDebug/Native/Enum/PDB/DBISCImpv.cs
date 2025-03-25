namespace ClrDebug.PDB
{
    // section contribution version, before V60 there was no section version
    public enum DBISCImpv : uint
    {
        DBISCImpvV60 = 0xeffe0000 + 19970605,
        //DBISCImpv = DBISCImpvV60,
        DBISCImpv2 = 0xeffe0000 + 20140516,
    }
}
