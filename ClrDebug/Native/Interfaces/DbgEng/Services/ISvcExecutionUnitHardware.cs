using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F272C72D-E794-498F-B169-2F74B38A2DAE")]
    [ComImport]
    public interface ISvcExecutionUnitHardware
    {
        [PreserveSig]
        HRESULT GetSpecialContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext specialContext);
        
        [PreserveSig]
        long GetProcessorNumber();
    }
}
