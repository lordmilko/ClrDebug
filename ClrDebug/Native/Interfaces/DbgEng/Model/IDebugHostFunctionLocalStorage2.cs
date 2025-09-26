using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("213B3725-36A2-45A0-9EA4-854D46D85195")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugHostFunctionLocalStorage2
    {
        [PreserveSig]
        HRESULT GetExtendedRegisterAddressInfo(
            [Out] out int registerId,
            [Out] out long offset,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isIndirectAccess,
            [Out] out int indirectOffset);
    }
}
