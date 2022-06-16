using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("5c552ab6-fc09-4cb3-8e36-22fa03c798b8")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataProcess2
    {
        [PreserveSig]
        HRESULT GetGcNotification(
            [In, Out] ref GcEvtArgs gcEvtArgs);

        [PreserveSig]
        HRESULT SetGcNotification(
            [In] GcEvtArgs gcEvtArgs);
    }
}
