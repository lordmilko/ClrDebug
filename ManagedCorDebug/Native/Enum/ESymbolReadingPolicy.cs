namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that set the policy for reading program database (PDB) files.
    /// </summary>
    /// <remarks>
    /// The <see cref="ESymbolReadingPolicy"/> enumeration is used with the <see cref="ICLRDebugManager.SetSymbolReadingPolicy"/> method.
    /// </remarks>
    public enum ESymbolReadingPolicy
    {
        /// <summary>
        /// Specifies that the debugger should never read PDB files.
        /// </summary>
        eSymbolReadingNever = 0,

        /// <summary>
        /// Specifies that the debugger should always read PDB files.
        /// </summary>
        eSymbolReadingAlways = 1,

        /// <summary>
        /// Specifies that the debugger should read only PDB files that are associated with full-trust assemblies.
        /// </summary>
        eSymbolReadingFullTrustOnly = 2
    }
}