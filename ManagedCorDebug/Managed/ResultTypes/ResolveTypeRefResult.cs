namespace ManagedCorDebug
{
    public struct ResolveTypeRefResult
    {
        public object PpIScope { get; }

        public mdTypeDef Ptd { get; }

        public ResolveTypeRefResult(object ppIScope, mdTypeDef ptd)
        {
            PpIScope = ppIScope;
            Ptd = ptd;
        }
    }
}