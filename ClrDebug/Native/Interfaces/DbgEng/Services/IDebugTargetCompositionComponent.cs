using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FDD4EF98-93FD-4773-BCDF-AACFB87257A6")]
    [ComImport]
    public interface IDebugTargetCompositionComponent
    {
        /// <summary>
        /// Create a new instance of this component which is not yet bound to any service manager.
        /// </summary>
        [PreserveSig]
        HRESULT CreateInstance(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer componentService);
    }
}
