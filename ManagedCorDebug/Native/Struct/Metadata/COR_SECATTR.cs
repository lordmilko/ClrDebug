using System;

namespace ManagedCorDebug
{
    public struct COR_SECATTR
    {
        public uint tkCtor;
        public IntPtr pCustomAttribute;
        public uint cbCustomAttribute;
    }
}
