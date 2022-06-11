namespace ManagedCorDebug
{
    public struct GetVersionResult
    {
        public ushort PMajor { get; }

        public ushort PMinor { get; }

        public ushort PBuild { get; }

        public ushort PRevision { get; }

        public GetVersionResult(ushort pMajor, ushort pMinor, ushort pBuild, ushort pRevision)
        {
            PMajor = pMajor;
            PMinor = pMinor;
            PBuild = pBuild;
            PRevision = pRevision;
        }
    }
}