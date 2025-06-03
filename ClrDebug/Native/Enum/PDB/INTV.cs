namespace ClrDebug.PDB
{
    //INTV is a typedef for ULONG and is an anonymous enum defined in the PDB interface
    public enum INTV
    {
        intvVC80 = PDBINTV.PDBIntv80,
        PDBIntv70 = PDBINTV.PDBIntv70,
        intvVC70Dep = PDBINTV.PDBIntv70Dep,
        intvVC2 = 920924, //Same value as PDBIntv41, but not defined as being equal
    }
}
