using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4A168D3F-04D0-49C4-8F9A-7B5B3108C6C6")]
    [ComImport]
    public interface IDebugHostStatus2 : IDebugHostStatus
    {
        [PreserveSig]
        new HRESULT PollUserInterrupt(
            [Out, MarshalAs(UnmanagedType.U1)] out bool interruptRequested);
        
        [PreserveSig]
        HRESULT SetUserInterrupt();
        
        [PreserveSig]
        HRESULT ClearUserInterrupt();
    }
}
