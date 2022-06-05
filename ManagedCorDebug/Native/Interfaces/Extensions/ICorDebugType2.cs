using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Extends the ICorDebugType interface to retrieve the type identifier  of a base type or complex (user-defined) type.
    /// </summary>
    /// <remarks>
    /// This interface is a logical extension of the ICorDebugType interface.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E6E91D79-693D-48BC-B417-8284B4F10FB5")]
    [ComImport]
    public interface ICorDebugType2
    {
        /// <summary>
        /// Gets a <see cref="COR_TYPEID"/> for this type.
        /// </summary>
        /// <param name="id">[out] A pointer to the <see cref="COR_TYPEID"/> for this ICorDebugType.</param>
        /// <remarks>
        /// This method provides a mapping from the ICorDebugType, which represents a type that may or may not have been loaded
        /// into the runtime, to a <see cref="COR_TYPEID"/>, which serves as an opaque handle that identifies a type loaded
        /// into the runtime. When the type that the ICorDebugType represents has not yet been loaded, this method returns
        /// CORDBG_E_CLASS_NOT_LOADED. If the type is not supported, it returns CORDBG_E_UNSUPPORTED.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetTypeID(out COR_TYPEID id);
    }
}