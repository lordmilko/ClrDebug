namespace ClrDebug.PDB
{
    //This is an anonymous enum and is not actually called TPIImpv; it doesn't have a name because I believe the original PDB
    //implementations only contained types (hence also why the TPI header is just called HDR)
    public enum TPIImpv
    {
        impv40 = 19950410,
        impv41 = 19951122,
        impv50Interim = 19960307,
        impv50 = 19961031,
        impv70 = 19990903,
        impv80 = 20040203,
        //curImpv = impv80,
    }
}
