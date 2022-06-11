namespace ManagedCorDebug
{
    public struct GetCachedInterfacePointersResult
    {
        public uint PceltFetched { get; }

        public CORDB_ADDRESS[] Ptrs { get; }

        public GetCachedInterfacePointersResult(uint pceltFetched, CORDB_ADDRESS[] ptrs)
        {
            PceltFetched = pceltFetched;
            Ptrs = ptrs;
        }
    }
}