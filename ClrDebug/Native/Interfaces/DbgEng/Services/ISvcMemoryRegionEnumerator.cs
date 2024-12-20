using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Enumerates address regions.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("66FF5B9F-A8D1-4A78-ADA9-4DFEDCC12C3A")]
    [ComImport]
    public interface ISvcMemoryRegionEnumerator
    {
        /// <summary>
        /// Resets the enumerator back to its initial creation state.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Gets the next memory region.
        /// </summary>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcMemoryRegion Region);
    }
}
