using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct CorDebugGuidToTypeMapping
    {
        public Guid iid;
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugType pType;
    }
}