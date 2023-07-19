using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// An extension of <see cref="ICorDebugHeapValue"/> that provides support for common language runtime (CLR) handles.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E3AC4D6C-9CB7-43E6-96CC-B21540E5083C")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugHeapValue2
    {
        /// <summary>
        /// Creates a handle of the specified type for the heap value represented by this <see cref="ICorDebugHeapValue2"/> object.
        /// </summary>
        /// <param name="type">[in] A value of the <see cref="CorDebugHandleType"/> enumeration that specifies the type of handle to be created.</param>
        /// <param name="ppHandle">[out] A pointer to the address of an <see cref="ICorDebugHandleValue"/> object that represents the new handle for this heap value.</param>
        /// <remarks>
        /// The handle will be created in the application domain that is associated with the heap value, and will become invalid
        /// if the application domain gets unloaded. Multiple calls to this function for the same heap value will create multiple
        /// handles. Because handles affect the performance of the garbage collector, the debugger should limit itself to a
        /// relatively small number of handles (about 256) that are active at a time.
        /// </remarks>
        [PreserveSig]
        HRESULT CreateHandle(
            [In] CorDebugHandleType type,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugHandleValue ppHandle);
    }
}
