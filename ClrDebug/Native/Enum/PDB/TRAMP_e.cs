namespace ClrDebug.PDB
{
    /// <summary>
    /// Trampoline subtype
    /// </summary>
    public enum TRAMP_e : short
    {
        /// <summary>
        /// incremental thunks
        /// </summary>
        trampIncremental,

        /// <summary>
        /// Branch island thunks
        /// </summary>
        trampBranchIsland
    }
}
