using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides a method that determines whether the module is loaded into memory in mapped/hydrated format.
    /// </summary>
    /// <remarks>
    /// This interface logically extends the 'ICorDebugModule', 'ICorDebugModule2', and 'ICoreDebugModule3' interfaces.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FF8B8EAF-25CD-4316-8859-84416DE4402E")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugModule4
    {
        /// <summary>
        /// Determines whether a module is loaded into memory in mapped/hydrated format.
        /// </summary>
        /// <param name="pIsMapped">[out] Pointer to a BOOL to store mapping information. TRUE represents mapped format while FALSE represents flat format.</param>
        /// <returns>
        /// * S_OK - Successfully created the reader.
        /// * S_FALSE - The layout couldn't be determined.
        /// </returns>
        /// <remarks>
        /// The pIsMapped value should only be interpreted as valid when this function returns S_OK. All other return values
        /// (includingS_FALSE) indicate that the layout couldn't be determined and pIsMapped should be ignored.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsMappedLayout(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pIsMapped);
    }
}
