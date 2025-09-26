using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FD5D43CB-9A6D-418E-8804-4EDE27CFC3A4")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugDataModelScriptReference
    {
        [PreserveSig]
        HRESULT Populate(
            [MarshalAs(UnmanagedType.LPWStr), In] string contents);

        [PreserveSig]
        HRESULT Execute(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream executionResult);

        [PreserveSig]
        HRESULT Unlink();

        [PreserveSig]
        HRESULT InvokeMain(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream executionResult);

        [PreserveSig]
        HRESULT Rename(
            [MarshalAs(UnmanagedType.LPWStr), In] string name);
    }
}
