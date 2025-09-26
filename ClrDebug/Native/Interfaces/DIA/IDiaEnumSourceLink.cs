using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    [Guid("45CD1EB3-5C6C-43E3-B20A-A4D8035DE4E2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaEnumSourceLink
    {
        [PreserveSig]
        HRESULT Count(
            [Out] out int pRetVal);

        [PreserveSig]
        HRESULT SizeOfNext(
            [Out] out int pRetVal);

        [PreserveSig]
        HRESULT Next(
            [In] int cb,
            [Out] out int pcb,
            [In] IntPtr pb);

        [PreserveSig]
        HRESULT Skip(
            [In] int cnt);

        [PreserveSig]
        HRESULT Reset();

        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSourceLink ppenum);
    }
}
