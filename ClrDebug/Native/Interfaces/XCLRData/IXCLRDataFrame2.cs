using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("1C4D9A4B-702D-4CF6-B290-1DB6F43050D0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IXCLRDataFrame2
    {
        [PreserveSig]
        HRESULT GetExactGenericArgsToken(
            [Out] out IXCLRDataValue genericToken);
    }
}
