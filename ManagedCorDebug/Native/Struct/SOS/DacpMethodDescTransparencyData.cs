﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("bHasCriticalTransparentInfo = {bHasCriticalTransparentInfo}, bIsCritical = {bIsCritical}, bIsTreatAsSafe = {bIsTreatAsSafe}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpMethodDescTransparencyData
    {
        public int bHasCriticalTransparentInfo;
        public int bIsCritical;
        public int bIsTreatAsSafe;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetMethodDescTransparencyData(addr, out this);
        }
    }
}