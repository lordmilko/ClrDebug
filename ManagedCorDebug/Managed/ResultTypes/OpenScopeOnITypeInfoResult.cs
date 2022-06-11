using System;

namespace ManagedCorDebug
{
    public struct OpenScopeOnITypeInfoResult
    {
        public Guid Riid { get; }

        public object PpIUnk { get; }

        public OpenScopeOnITypeInfoResult(Guid riid, object ppIUnk)
        {
            Riid = riid;
            PpIUnk = ppIUnk;
        }
    }
}