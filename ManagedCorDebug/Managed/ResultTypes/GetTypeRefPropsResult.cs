namespace ManagedCorDebug
{
    public struct GetTypeRefPropsResult
    {
        public mdToken PtkResolutionScope { get; }

        public string SzName { get; }

        public GetTypeRefPropsResult(mdToken ptkResolutionScope, string szName)
        {
            PtkResolutionScope = ptkResolutionScope;
            SzName = szName;
        }
    }
}