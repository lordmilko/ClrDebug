using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9F6F05C0-FBF4-457c-92EF-CC9E782C286F")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugTargetCompositionFileActivator
    {
        /// <summary>
        /// Returns whether or not the given file is recognized as the type of file expected. At the time of this call, the service manager contains a file debug source and nothing else.<para/>
        /// The file debug source is also passed explicitly to the method.
        /// </summary>
        [PreserveSig]
        HRESULT IsRecognizedFile(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In] ISvcDebugSourceFile pFile,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pIsRecognized);

        /// <summary>
        /// For a file type which is recognized by this activator as the type of file expected (IsRecognizedFile returns true), this call is made to the activator to add the requisite set of services to the service manager in order to make the full target debuggable.
        /// </summary>
        [PreserveSig]
        HRESULT InitializeServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager);
    }
}
