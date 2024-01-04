using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F6B2366A-C094-4072-845D-A06E5C97F77F")]
    [ComImport]
    public interface ISvcSymbolSetRuntimeTypeInformation
    {
        [PreserveSig]
        HRESULT GetRuntimeType(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long staticObjectOffset,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbolType staticObjectType,
            [Out] out long runtimeObjectOffset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolType runtimeObjectType);
    }
}
