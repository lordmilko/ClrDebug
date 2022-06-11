namespace ManagedCorDebug
{
    public struct GetManifestResourcePropsResult
    {
        public string SzName { get; }

        public uint PtkImplementation { get; }

        public uint PdwOffset { get; }

        public CorManifestResourceFlags PdwResourceFlags { get; }

        public GetManifestResourcePropsResult(string szName, uint ptkImplementation, uint pdwOffset, CorManifestResourceFlags pdwResourceFlags)
        {
            SzName = szName;
            PtkImplementation = ptkImplementation;
            PdwOffset = pdwOffset;
            PdwResourceFlags = pdwResourceFlags;
        }
    }
}