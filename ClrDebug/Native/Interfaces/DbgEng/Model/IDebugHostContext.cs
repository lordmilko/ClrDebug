using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A68C70D8-5EC0-46E5-B775-3134A48EA2E3")]
    [ComImport]
    public interface IDebugHostContext
    {
        [PreserveSig]
        HRESULT IsEqualTo(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext pContext,
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsEqual);
    }
}
