using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B497B0C9-9572-4257-A156-792D3AF03D94")]
    [ComImport]
    public interface ISourceCodeDownloadUrlLinkProvider
    {
        /// <summary>
        /// Retrieves the list of download URLs for the specified file. To the best knowledge of the provider this list is the location where the source file might be found.<para/>
        /// It is the responsibility of the caller to determine exactly where the source file is located (by trying to download the file from the provided url list).<para/>
        /// The returned list is a one dimentional SAFEARRAY where the type of the elements is VT_BSTR or VT_VARIANT of type VT_BSTR The URLs can be "full" URL - something like "http://...." or "https://www....", or can be a "partial/suffix" URL - something like name1/name2/name3, and the debugger will build the final "full" URL by adding the suffix to a URL.<para/>
        /// The method receives the following parameters - sourceCodeFileSpec - The file spacification of the file to be downloade (for ex:shell\osshell\accesory\notepad\notepad.cpp) The separator may be '\' or '/' character - algorithmRetrievalName - it may be something like "DebugInfoD", "srv", etc.<para/>
        /// - algorithmParameters - optional parameters needed for the regrieval alroithm.
        /// </summary>
        [PreserveSig]
        HRESULT ProvideSourceCodeFileUrlList(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.LPWStr)] string sourceCodeFileSpec,
            [In, MarshalAs(UnmanagedType.LPWStr)] string algorithmRetrievalName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string algorithmParameters,
            [SRI.Out, MarshalAs(UnmanagedType.SafeArray)] out object[] ppUrlList);
    }
}
