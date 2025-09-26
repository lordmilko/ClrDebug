namespace ClrDebug.PDB
{
    /// <summary>
    /// An array of all imports by import module.
    /// List all cross reference for a specific ID scope.
    /// Format of DEBUG_S_CROSSSCOPEIMPORTS subsection is 
    /// </summary>
    public unsafe struct CrossScopeReferences
    {
        /// <summary>
        /// Module of definition Scope.
        /// </summary>
        public PdbIdScope externalScope;

        /// <summary>
        /// Count of following array. 
        /// </summary>
        public int countOfCrossReferences;

        /// <summary>
        /// CV_ItemId in another compilation unit.
        /// </summary>
        public fixed int referenceIds[1]; //CV_ItemId
    }
}
