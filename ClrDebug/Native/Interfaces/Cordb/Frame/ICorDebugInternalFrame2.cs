using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides information about internal frames, including stack address and position in relation to <see cref="ICorDebugFrame"/> objects.
    /// </summary>
    /// <remarks>
    /// This interface extends the <see cref="ICorDebugInternalFrame"/> interface.
    /// </remarks>
    [Guid("C0815BDC-CFAB-447E-A779-C116B454EB5B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugInternalFrame2
    {
        /// <summary>
        /// Returns the stack address of the internal frame.
        /// </summary>
        /// <param name="pAddress">[out] Pointer to the <see cref="CORDB_ADDRESS"/> for the internal frame.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as <see cref="HRESULT"/> errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                                                  |
        /// | ------------ | ------------------------------------------------------------ |
        /// | S_OK         | The address of the internal frame was successfully returned. |
        /// | E_FAIL       | The address of the internal frame could not be returned.     |
        /// | E_INVALIDARG | pAddress is null.                                            |
        /// </returns>
        /// <remarks>
        /// The value returned in pAddress can be used to determine the location of the internal frame relative to other frames
        /// on the stack. Even on IA-64-based computers, the internal frame lives on the stack only, and there is no corresponding
        /// pointer to a backing store.
        /// </remarks>
        [PreserveSig]
        HRESULT GetAddress(
            [Out] out CORDB_ADDRESS pAddress);

        /// <summary>
        /// Checks whether the this internal frame is closer to the leaf than the specified <see cref="ICorDebugFrame"/> object.
        /// </summary>
        /// <param name="pFrameToCompare">[in] A pointer to the comparison <see cref="ICorDebugFrame"/> object.</param>
        /// <param name="pIsCloser">[out] true if the this internal frame is closer to the leaf than the frame specified by pFrameToCompare; otherwise, false.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                                |
        /// | ------------ | ------------------------------------------ |
        /// | S_OK         | The comparison was successfully performed. |
        /// | E_FAIL       | The comparison could not be performed.     |
        /// | E_INVALIDARG | pFrameToCompare or pIsCloser is null.      |
        /// </returns>
        /// <remarks>
        /// IsCloserToLeaf can be used to implement a policy for interleaving internal frames with other frames on the stack.
        /// </remarks>
        [PreserveSig]
        HRESULT IsCloserToLeaf(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugFrame pFrameToCompare,
            [Out] out int pIsCloser);
    }
}
