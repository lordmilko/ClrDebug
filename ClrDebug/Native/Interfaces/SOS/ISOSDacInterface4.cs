using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("74B9D34C-A612-4B07-93DD-5462178FCE11")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSDacInterface4
    {
        [PreserveSig]
        HRESULT GetClrNotification(
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CLRDATA_ADDRESS[] arguments,
            [In] int count,
            [Out] out int pNeeded);
    }
}
