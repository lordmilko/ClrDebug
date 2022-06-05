using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides information about internal frames, including stack address and position in relation to ICorDebugFrame objects.
    /// </summary>
    /// <remarks>
    /// This interface extends the ICorDebugInternalFrame interface.
    /// </remarks>
    [Guid("C0815BDC-CFAB-447E-A779-C116B454EB5B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugInternalFrame2
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetAddress(out ulong pAddress);

        /// <summary>
        /// Checks whether the this internal frame is closer to the leaf than the specified ICorDebugFrame object.
        /// </summary>
        /// <param name="pFrameToCompare">[in] A pointer to the comparison ICorDebugFrame object.</param>
        /// <param name="pIsCloser">[out] true if the this internal frame is closer to the leaf than the frame specified by pFrameToCompare; otherwise, false.</param>
        /// <remarks>
        /// IsCloserToLeaf can be used to implement a policy for interleaving internal frames with other frames on the stack.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsCloserToLeaf([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrameToCompare, out int pIsCloser);
    }
}