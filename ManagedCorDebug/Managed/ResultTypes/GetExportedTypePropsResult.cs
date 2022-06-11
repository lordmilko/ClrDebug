namespace ManagedCorDebug
{
    public struct GetExportedTypePropsResult
    {
        public string SzName { get; }

        public uint PtkImplementation { get; }

        public mdTypeDef PtkTypeDef { get; }

        public CorTypeAttr PdwExportedTypeFlags { get; }

        public GetExportedTypePropsResult(string szName, uint ptkImplementation, mdTypeDef ptkTypeDef, CorTypeAttr pdwExportedTypeFlags)
        {
            SzName = szName;
            PtkImplementation = ptkImplementation;
            PtkTypeDef = ptkTypeDef;
            PdwExportedTypeFlags = pdwExportedTypeFlags;
        }
    }
}