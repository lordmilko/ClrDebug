using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("31201a94-4337-49b7-aef7-0c7550540920")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataExceptionNotification3
    {
        [PreserveSig]
        HRESULT OnGcEvent(
            [In] GcEvtArgs gcEvtArgs);
    }
}
