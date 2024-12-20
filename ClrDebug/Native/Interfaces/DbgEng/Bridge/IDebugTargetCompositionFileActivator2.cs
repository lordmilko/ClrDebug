using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6FDAD5B0-6DB5-41B8-A9B5-A29B830FC056")]
    [ComImport]
    public interface IDebugTargetCompositionFileActivator2 : IDebugTargetCompositionFileActivator
    {
        [PreserveSig]
        new HRESULT IsRecognizedFile(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In] ISvcDebugSourceFile pFile,
            [Out] out bool pIsRecognized);

        [PreserveSig]
        new HRESULT InitializeServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager);

        /// <summary>
        /// Activators which want to serve a more complex query against file names than a singular extension or wildcard extension match may implement IDebugTargetCompositionFileActivator2 and IsRecognizedFileName.<para/>
        /// This method will be called *PRIOR* to any IsRecognizedFile call. If *pIsRecognized is set to false, no further calls will be made on the activator for the file in question.<para/>
        /// If *pIsRecognized is set to true, the activator will proceed to a further IsRecognizedFile check. NOTE: For files contained within compressed containers (e.g.: ZIP/CAB/etc...), this check on a given activator is made *PRIOR* to decompression.<para/>
        /// An *IsRecognizedFile* check is made *AFTER* decompression. An implementation of this method may legally return E_NOTIMPL.<para/>
        /// If such is returned, behavior is identical to returning *pIsRecognized of true. Further checks will be made on the activator.
        /// </summary>
        [PreserveSig]
        HRESULT IsRecognizedFileName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszFileName,
            [Out] out bool pIsRecognized);
    }
}
