using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3C4B6ADD-80E1-4C2B-AFE1-9A1132586DD0")]
    [ComImport]
    public interface IDebugHostSymbolsTargetComposition
    {
        [PreserveSig]
        HRESULT GetTypeForServiceType(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbolType pType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType ppHostType);
    }
}
