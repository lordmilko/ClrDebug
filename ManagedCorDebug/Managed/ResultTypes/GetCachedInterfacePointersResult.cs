namespace ManagedCorDebug
{
    public struct GetCachedInterfacePointersResult
    {
        public int PceltFetched { get; }

        public CORDB_ADDRESS[] Ptrs { get; }

        public GetCachedInterfacePointersResult(int pceltFetched, CORDB_ADDRESS[] ptrs)
        {
            PceltFetched = pceltFetched;
            Ptrs = ptrs;
        }
    }
}