namespace ClrDebug.PDB
{
    public enum PDBIMPV
    {
        PDBImpvVC2 = 19941610,
        PDBImpvVC4 = 19950623,
        PDBImpvVC41 = 19950814,
        PDBImpvVC50 = 19960307,
        PDBImpvVC98 = 19970604,
        PDBImpvVC70 = 20000404,

        /// <summary>
        /// deprecated vc70 implementation version
        /// </summary>
        PDBImpvVC70Dep = 19990604,

        PDBImpvVC80 = 20030901,
        PDBImpvVC110 = 20091201,
        PDBImpvVC140 = 20140508,
        //PDBImpv = PDBImpvVC110,
    }
}
