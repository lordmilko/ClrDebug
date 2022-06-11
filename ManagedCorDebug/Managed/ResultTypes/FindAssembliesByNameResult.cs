namespace ManagedCorDebug
{
    public struct FindAssembliesByNameResult
    {
        public object[] PpIUnk { get; }

        public uint PcAssemblies { get; }

        public FindAssembliesByNameResult(object[] ppIUnk, uint pcAssemblies)
        {
            PpIUnk = ppIUnk;
            PcAssemblies = pcAssemblies;
        }
    }
}