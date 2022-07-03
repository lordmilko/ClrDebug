using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("8FA642BD-9F10-4799-9AA3-512AE78C77EE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSStackRefEnum : ISOSEnum
    {
        [PreserveSig]
        new HRESULT Skip(
            [In] int count);

        [PreserveSig]
        new HRESULT Reset();

        [PreserveSig]
        new HRESULT GetCount(
            [Out] out int pCount);

        [PreserveSig]
        HRESULT Next(
            [In] int count,
            [Out] out SOSStackRefData _ref,
            [Out] out int pFetched);

        [PreserveSig]
        HRESULT EnumerateErrors(
            [Out] out ISOSStackRefErrorEnum ppEnum);
    }
}
