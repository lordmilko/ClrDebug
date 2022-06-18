using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("C25E926E-5F09-4AA2-BBAD-B7FC7F10CFD7")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataExceptionNotification4
    {
        [PreserveSig]
        HRESULT ExceptionCatcherEnter(
            [In] IXCLRDataMethodInstance catchingMethod,
            [In] int catcherNativeOffset);
    }
}
