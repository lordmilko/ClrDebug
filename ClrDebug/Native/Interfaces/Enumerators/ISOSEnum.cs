using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("286CA186-E763-4F61-9760-487D43AE4341")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSEnum
    {
        [PreserveSig]
        HRESULT Skip(
            [In] int count);

        [PreserveSig]
        HRESULT Reset();

        [PreserveSig]
        HRESULT GetCount(
            [Out] out int pCount);
    }
}
