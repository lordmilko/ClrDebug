using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("3E269830-4A2B-4301-8EE2-D6805B29B2FA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSHandleEnum : ISOSEnum
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
            [Out] out SOSHandleData handles,
            [Out] out int pNeeded);
    }
}
