namespace ManagedCorDebug
{
    public struct FindAssembliesByNameResult
    {
        public object[] PpIUnk { get; }

        public int PcAssemblies { get; }

        public FindAssembliesByNameResult(object[] ppIUnk, int pcAssemblies)
        {
            PpIUnk = ppIUnk;
            PcAssemblies = pcAssemblies;
        }
    }
}