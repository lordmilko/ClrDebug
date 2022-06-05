using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Disposes of unmanaged resources.
    /// </summary>
    [Guid("969708D2-05E5-4861-A3B0-96E473CDF63F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedDispose
    {
        /// <summary>
        /// Causes the underlying object to release all internal references and return failure on any subsequent method calls.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Destroy();
    }
}