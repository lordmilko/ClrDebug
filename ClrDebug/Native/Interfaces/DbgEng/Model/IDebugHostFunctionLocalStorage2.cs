using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("213B3725-36A2-45A0-9EA4-854D46D85195")]
    [ComImport]
    public interface IDebugHostFunctionLocalStorage2
    {
        [PreserveSig]
        HRESULT GetExtendedRegisterAddressInfo(
            [Out] out int registerId,
            [Out] out long offset,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isIndirectAccess,
            [Out] out int indirectOffset);
    }
}
