using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FDD4EF98-93FD-4773-BCDF-AACFB87257A6")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugTargetCompositionComponent
    {
        /// <summary>
        /// Create a new instance of this component which is not yet bound to any service manager.
        /// </summary>
        [PreserveSig]
        HRESULT CreateInstance(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);
    }
}
