﻿using System;

namespace ManagedCorDebug
{
    public struct COR_SECATTR
    {
        public mdMemberRef tkCtor;
        public IntPtr pCustomAttribute;
        public uint cbCustomAttribute;
    }
}
