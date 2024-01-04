using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9d339be5-30cd-4403-92c3-57ea33799cb1")]
    [ComImport]
    public interface IDebugSettings
    {
        [PreserveSig]
        HRESULT LoadSettingsFromString(
            [MarshalAs(UnmanagedType.LPWStr), In] string contents);

        [PreserveSig]
        HRESULT StoreSettingsInStream(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream output);
    }
}
