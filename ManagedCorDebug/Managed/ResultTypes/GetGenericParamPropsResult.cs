namespace ManagedCorDebug
{
    public struct GetGenericParamPropsResult
    {
        public uint PulParamSeq { get; }

        public CorGenericParamAttr PdwParamFlags { get; }

        public mdToken PtOwner { get; }

        public uint Reserved { get; }

        public string Wzname { get; }

        public GetGenericParamPropsResult(uint pulParamSeq, CorGenericParamAttr pdwParamFlags, mdToken ptOwner, uint reserved, string wzname)
        {
            PulParamSeq = pulParamSeq;
            PdwParamFlags = pdwParamFlags;
            PtOwner = ptOwner;
            Reserved = reserved;
            Wzname = wzname;
        }
    }
}