using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("890C0F06-D269-4BA6-B5BB-C8335D6EC8C2")]
    [ComImport]
    public interface ISvcSecurityConfiguration
    {
        [PreserveSig]
        HRESULT GetPointerAuthenticationMask(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [In] long ptr,
            [Out] out long pDataMask,
            [Out] out long pInstructionMask);
    }
}
