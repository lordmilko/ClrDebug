using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B420FB55-5FEF-4d61-A762-B96BF9AF5EE7")]
    [ComImport]
    public interface IDebugTargetCompositionProtocolActivator
    {
        /// <summary>
        /// Returns whether or not the given protocol string is recognized as the type of protocol expected. At the time of this call, the service manager is empty.
        /// </summary>
        [PreserveSig]
        HRESULT IsRecognizedProtocol(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszProtocolString,
            [Out] out bool pIsRecognized);

        /// <summary>
        /// For a protocol which is recognized by this activator as the type of protocol expected (IsRecognizedProtocol returns true), this call is made to the activator to add the requisite set of services to the service manager in order to make the full target debuggable.
        /// </summary>
        [PreserveSig]
        HRESULT InitializeServices(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszProtocolString);
    }
}
