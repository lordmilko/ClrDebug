namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetTypeRefProps"/> method.
    /// </summary>
    public struct GetTypeRefPropsResult
    {
        /// <summary>
        /// [out] A pointer to the scope in which the reference is made. This value is an AssemblyRef or ModuleRef token.
        /// </summary>
        public mdToken ptkResolutionScope { get; }

        /// <summary>
        /// [out] A buffer containing the type name.
        /// </summary>
        public string szName { get; }

        public GetTypeRefPropsResult(mdToken ptkResolutionScope, string szName)
        {
            this.ptkResolutionScope = ptkResolutionScope;
            this.szName = szName;
        }
    }
}