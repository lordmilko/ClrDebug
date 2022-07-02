using System;
using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("tkCtor = {tkCtor.ToString(),nq}, pCustomAttribute = {pCustomAttribute.ToString(),nq}, cbCustomAttribute = {cbCustomAttribute}")]
    public struct COR_SECATTR
    {
        public mdMemberRef tkCtor;
        public IntPtr pCustomAttribute;
        public int cbCustomAttribute;
    }
}
