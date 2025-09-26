namespace ClrDebug.PDB
{
    /// <summary>
    /// An array of all exports in this module.
    /// Format of DEBUG_S_CROSSSCOPEEXPORTS subsection is 
    /// </summary>
    public struct LocalIdAndGlobalIdPair
    {
        /// <summary>
        /// local id inside the compile time PDB scope. 0 based
        /// </summary>
        public CV_ItemId localId;

        /// <summary>
        /// global id inside the link time PDB scope, if scope are different.
        /// </summary>
        public CV_ItemId globalId;
    }
}
