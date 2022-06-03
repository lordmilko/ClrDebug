﻿using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct _COR_IL_MAP
    {
        public uint oldOffset;
        public uint newOffset;
        public int fAccurate;
    }
}