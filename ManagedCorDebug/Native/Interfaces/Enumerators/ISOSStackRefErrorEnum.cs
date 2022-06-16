using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("774F4E1B-FB7B-491B-976D-A8130FE355E9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSStackRefErrorEnum : ISOSEnum
    {
        [PreserveSig]
        HRESULT Next(
            [In] int count,
            [Out, MarshalAs(UnmanagedType.LPArray)] out SOSStackRefError _ref,
            [Out] out int pFetched);
    }
}
