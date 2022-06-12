namespace ManagedCorDebug
{
    public struct GetGenericParamPropsResult
    {
        public int PulParamSeq { get; }

        public CorGenericParamAttr PdwParamFlags { get; }

        public mdToken PtOwner { get; }

        public int Reserved { get; }

        public string Wzname { get; }

        public GetGenericParamPropsResult(int pulParamSeq, CorGenericParamAttr pdwParamFlags, mdToken ptOwner, int reserved, string wzname)
        {
            PulParamSeq = pulParamSeq;
            PdwParamFlags = pdwParamFlags;
            PtOwner = ptOwner;
            Reserved = reserved;
            Wzname = wzname;
        }
    }
}