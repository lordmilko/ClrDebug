namespace ManagedCorDebug
{
    public struct GetManifestResourcePropsResult
    {
        public string SzName { get; }

        public int PtkImplementation { get; }

        public int PdwOffset { get; }

        public CorManifestResourceFlags PdwResourceFlags { get; }

        public GetManifestResourcePropsResult(string szName, int ptkImplementation, int pdwOffset, CorManifestResourceFlags pdwResourceFlags)
        {
            SzName = szName;
            PtkImplementation = ptkImplementation;
            PdwOffset = pdwOffset;
            PdwResourceFlags = pdwResourceFlags;
        }
    }
}