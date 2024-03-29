﻿using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("774F4E1B-FB7B-491B-976D-A8130FE355E9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSStackRefErrorEnum : ISOSEnum
    {
#if !GENERATED_MARSHALLING
        [PreserveSig]
        new HRESULT Skip(
            [In] int count);

        [PreserveSig]
        new HRESULT Reset();

        [PreserveSig]
        new HRESULT GetCount(
            [Out] out int pCount);
#endif

        [PreserveSig]
        HRESULT Next(
            [In] int count,
            [Out] out SOSStackRefError _ref,
            [Out] out int pFetched);
    }
}
