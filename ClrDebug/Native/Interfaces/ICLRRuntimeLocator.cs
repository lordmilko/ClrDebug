using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B760BF44-9377-4597-8BE7-58083BDC5146")]
    [ComImport]
    public interface ICLRRuntimeLocator
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRuntimeBase(
            [Out] out CLRDATA_ADDRESS baseAddress);
    }
}