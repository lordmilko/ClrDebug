using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("4eca42d8-7e7b-4c8a-a116-7bfbf6929267")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface9
    {
        [PreserveSig]
        HRESULT GetBreakingChangeVersion(
            [Out] out int pVersion);
    }
}
