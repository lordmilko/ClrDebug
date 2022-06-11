namespace ManagedCorDebug
{
    public struct GetTypeDefPropsResult
    {
        public string SzTypeDef { get; }

        public CorTypeAttr PdwTypeDefFlags { get; }

        public mdToken PtkExtends { get; }

        public GetTypeDefPropsResult(string szTypeDef, CorTypeAttr pdwTypeDefFlags, mdToken ptkExtends)
        {
            SzTypeDef = szTypeDef;
            PdwTypeDefFlags = pdwTypeDefFlags;
            PtkExtends = ptkExtends;
        }
    }
}