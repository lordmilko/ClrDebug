﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("bServerMode = {bServerMode}, bGcStructuresValid = {bGcStructuresValid}, HeapCount = {HeapCount}, g_max_generation = {g_max_generation}")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DacpGcHeapData
    {
        public bool bServerMode;
        public bool bGcStructuresValid;
        public int HeapCount;
        public int g_max_generation;

        public HRESULT Request(ISOSDacInterface sos)
        {
            return sos.GetGCHeapData(out this);
        }
    }
}
