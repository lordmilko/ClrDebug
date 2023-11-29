using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("2D95A079-42A1-4837-818F-0B97D7048E0E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataExceptionNotification
    {
        [PreserveSig]
        HRESULT OnCodeGenerated(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataMethodInstance method);

        [PreserveSig]
        HRESULT OnCodeDiscarded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataMethodInstance method);

        [PreserveSig]
        HRESULT OnProcessExecution(
            [In] int state);

        [PreserveSig]
        HRESULT OnTaskExecution(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTask task,
            [In] int state);

        [PreserveSig]
        HRESULT OnModuleLoaded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataModule mod);

        [PreserveSig]
        HRESULT OnModuleUnloaded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataModule mod);

        [PreserveSig]
        HRESULT OnTypeLoaded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeInstance typeInst);

        [PreserveSig]
        HRESULT OnTypeUnloaded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeInstance typeInst);
    }
}
