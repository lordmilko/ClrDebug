﻿using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3BFE56B0-390C-4863-9430-1F3D083B7684")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaInputAssemblyFile
    {
        [PreserveSig]
        HRESULT get_uniqueId(
            [Out] out int pRetVal);

        [PreserveSig]
        HRESULT get_index(
            [Out] out int pRetVal);

        [PreserveSig]
        HRESULT get_timeStamp(
            [Out] out int pRetVal);

        [PreserveSig]
        HRESULT get_pdbAvailableAtILMerge(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);

        [PreserveSig]
        HRESULT get_fileName(
#if !GENERATED_MARSHALLING
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))]
#else
            [MarshalUsing(typeof(DiaStringMarshaller))]
#endif
            out string pRetVal);

        [PreserveSig]
        HRESULT get_version(
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pbData);
    }
}
