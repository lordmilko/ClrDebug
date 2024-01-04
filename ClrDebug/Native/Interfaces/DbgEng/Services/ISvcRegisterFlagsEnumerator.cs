using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("55C7E6F4-D357-4209-ACF7-55D945AF3841")]
    [ComImport]
    public interface ISvcRegisterFlagsEnumerator
    {
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterFlagInformation flagInfo);
        
        [PreserveSig]
        HRESULT Reset();
    }
}
