using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3D06878F-97AB-4C5B-955E-FA647D3B137C")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugHostContextTargetComposition
    {
        [PreserveSig]
        HRESULT GetServiceManager(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager ppServiceManager);
        
        [PreserveSig]
        HRESULT GetServiceProcess(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess ppProcess);
        
        [PreserveSig]
        HRESULT GetServiceThread(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcThread ppThread);
    }
}
