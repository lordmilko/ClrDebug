using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("31E53A5A-01EE-4BBB-B899-4B46AE7D595C")]
    [ComImport]
    public interface IDebugHostModuleSignature
    {
        [PreserveSig]
        HRESULT IsMatch(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostModule pModule,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isMatch);
    }
}
