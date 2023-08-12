using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    public delegate long CDSTranslateAddrCB(
        [MarshalAs(UnmanagedType.Interface)] IXCLRDisassemblySupport a,
        CLRDATA_ADDRESS b,
        [MarshalAs(UnmanagedType.LPWStr)] string c,
        long d);

    public delegate long CDSTranslateFixupCB(
        [MarshalAs(UnmanagedType.Interface)] IXCLRDisassemblySupport a,
        CLRDATA_ADDRESS b,
        long c,
        [MarshalAs(UnmanagedType.LPWStr)] string d,
        long e,
        long f);

    public delegate long CDSTranslateConstCB(
        [MarshalAs(UnmanagedType.Interface)] IXCLRDisassemblySupport a,
        int b,
        [MarshalAs(UnmanagedType.LPWStr)] string c,
        long d);

    public delegate long CDSTranslateRegrelCB(
        [MarshalAs(UnmanagedType.Interface)] IXCLRDisassemblySupport a,
        int b,
        CLRDATA_ADDRESS c,
        [MarshalAs(UnmanagedType.LPWStr)] string d,
        long e);

    [Guid("1F0F7134-D3F3-47DE-8E9B-C2FD358A2936")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDisassemblySupport
    {
        [PreserveSig]
        HRESULT SetTranslateAddrCallback(
            [In, MarshalAs(UnmanagedType.FunctionPtr)] CDSTranslateAddrCB cb);

        [PreserveSig]
        HRESULT PvClientSet(
            [In] IntPtr pv);

        [PreserveSig]
        long CbDisassemble(
            [In] CLRDATA_ADDRESS a,
            [In] IntPtr b,
            [In] long c);

        [PreserveSig]
        long Cinstruction();

        [PreserveSig]
        int FSelectInstruction(
            [In] long a);

        [PreserveSig]
        long CchFormatInstr(
            [In, MarshalAs(UnmanagedType.LPWStr)] string a,
            [In] long b);

        [PreserveSig]
        void PvClient();

        [PreserveSig]
        HRESULT SetTranslateFixupCallback(
            [In] CDSTranslateFixupCB cb);

        [PreserveSig]
        HRESULT SetTranslateConstCallback(
            [In] CDSTranslateConstCB cb);

        [PreserveSig]
        HRESULT SetTranslateRegrelCallback(
            [In] CDSTranslateRegrelCB cb);

        [PreserveSig]
        int TargetIsAddress();
    }
}
