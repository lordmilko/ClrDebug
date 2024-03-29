﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D682FD12-43DE-411C-811B-BE8404CEA126")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISymNGenWriter
    {
        [PreserveSig]
        HRESULT AddSymbol(
            [MarshalAs(UnmanagedType.BStr), In] string pSymbol,
            [In] ushort iSection,
            [In] long rva);

        [PreserveSig]
        HRESULT AddSection(
            [In] ushort iSection,
            [In] ushort flags,
            [In] int offset,
            [In] int cb);
    }
}
