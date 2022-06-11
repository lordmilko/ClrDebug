using System;

namespace ManagedCorDebug
{
    public struct GetScopePropsResult
    {
        public string SzName { get; }

        public Guid Pmvid { get; }

        public GetScopePropsResult(string szName, Guid pmvid)
        {
            SzName = szName;
            Pmvid = pmvid;
        }
    }
}