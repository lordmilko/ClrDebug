using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    [Guid("136D8151-ADE7-4704-AF13-324080762E8F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumSourceLink2 : IDiaEnumSourceLink
    {
#if !GENERATED_MARSHALLING
        [PreserveSig]
        new HRESULT Count(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT SizeOfNext(
            [Out] out int pRetVal);

        [PreserveSig]
        new HRESULT Next(
            [In] int cb,
            [Out] out int pcb,
            [In] IntPtr pb);

        [PreserveSig]
        new HRESULT Skip(
            [In] int cnt);

        [PreserveSig]
        new HRESULT Reset();

        [PreserveSig]
        new HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSourceLink ppenum);
#endif

        [PreserveSig]
        HRESULT SizeOfNext2(
            [Out] out long pRetVal);

        [PreserveSig]
        HRESULT Next2(
            [In] long cb,
            [Out] out long pcb,
            [In] IntPtr pb);
    }
}
