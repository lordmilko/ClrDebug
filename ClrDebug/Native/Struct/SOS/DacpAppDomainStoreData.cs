﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("sharedDomain = {sharedDomain.ToString(),nq}, systemDomain = {systemDomain.ToString(),nq}, DomainCount = {DomainCount}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpAppDomainStoreData
    {
        public CLRDATA_ADDRESS sharedDomain;
        public CLRDATA_ADDRESS systemDomain;
        public int DomainCount;

        public HRESULT Request(ISOSDacInterface sos)
        {
            return sos.GetAppDomainStoreData(out this);
        }
    }
}
