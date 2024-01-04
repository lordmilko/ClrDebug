using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4F3E1CE2-86B2-4C7A-9C65-D0A9D0EECF44")]
    [ComImport]
    public interface IDebugHostStatus
    {
        [PreserveSig]
        HRESULT PollUserInterrupt(
            [Out, MarshalAs(UnmanagedType.U1)] out bool interruptRequested);
    }
}
