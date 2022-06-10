using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Logically extends the <see cref="ICorDebugAppDomain"/> interface to get a managed object from a COM callable wrapper.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FB99CC40-83BE-4724-AB3B-768E796EBAC2")]
    [ComImport]
    public interface ICorDebugAppDomain4
    {
        /// <summary>
        /// Gets a managed object from a COM callable wrapper (CCW) pointer.
        /// </summary>
        /// <param name="ccwPointer">[in] A COM callable wrapper (CCW) pointer.</param>
        /// <param name="ppManagedObject">[out] A pointer to the address of an "ICorDebugValue" object that represents the managed object that corresponds to the given CCW pointer.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetObjectForCCW([In] ulong ccwPointer,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppManagedObject);
    }
}