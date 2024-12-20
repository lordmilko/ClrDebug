using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a set of stack frames which can be linearly enumerated from a "top" to a "bottom" (typically retrieved from a stack walk).<para/>
    /// The set of frames can, however, represent some portion of a physical stack or a logical call chain which doesn't necessarily relate to a physical stack in memory.<para/>
    /// While a stack provider can return a stack walk as a single "frame set", it is entirely possible to have aggregate stack providers that compose an interleaved number of frame sets into a single frame set.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("81E83593-5AA9-43AA-8A5D-B964411E4B53")]
    [ComImport]
    public interface ISvcStackProviderFrameSetEnumerator
    {
        /// <summary>
        /// Gets the unwinder context which is associated with this frame set.
        /// </summary>
        [PreserveSig]
        HRESULT GetUnwindContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackUnwindContext unwindContext);

        /// <summary>
        /// ; Resets the enumerator back to the top of the set of frames which it represents.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Returns the current frame of the set. If there is no current frame, this will return E_BOUNDS.
        /// </summary>
        [PreserveSig]
        HRESULT GetCurrentFrame(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrame currentFrame);

        /// <summary>
        /// Moves the enumerator to the next frame. This will return E_BOUNDS at the end of enumeration.
        /// </summary>
        [PreserveSig]
        HRESULT MoveNext();
    }
}
