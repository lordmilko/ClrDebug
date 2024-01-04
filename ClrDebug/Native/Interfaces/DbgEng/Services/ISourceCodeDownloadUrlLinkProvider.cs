using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B497B0C9-9572-4257-A156-792D3AF03D94")]
    [ComImport]
    public interface ISourceCodeDownloadUrlLinkProvider
    {
        [PreserveSig]
        HRESULT ProvideSourceCodeFileUrlList(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string sourceCodeFileSpec,
            [In, MarshalAs(UnmanagedType.LPWStr)] string algorithmRetrievalName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string algorithmParameters,
            [SRI.Out, MarshalAs(UnmanagedType.SafeArray)] out object[] ppUrlList);
    }
}
