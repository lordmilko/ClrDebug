namespace ClrDebug.PDB
{
    /// <summary>
    /// Trampoline subtype
    /// </summary>
    public enum TRAMP_e
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
