using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("18F73640-D265-4923-A552-A96B0040E4AD")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugTargetCompositionBridgeReparseCompletion
    {
        /// <summary>
        /// NotifyReparseCompletion When a reparse is complete *AND* the service manager has all requisite services added, this method will be called in reverse nested order (innermost to outermost) for any reparses done via IDebugTargetCompositionBridge4::ReparseActivation2 This is the *ONLY* way to modify the service container *AFTER* a ReparseActivation* call.<para/>
        /// Note that returning a failing status from this method will cause the service container (and hence target) to fail to initialize properly.
        /// </summary>
        [PreserveSig]
        HRESULT NotifyReparseCompletion(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In] IntPtr pData);
    }
}
