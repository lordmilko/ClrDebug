using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugType"/> interface to retrieve the type identifier of a base type or complex (user-defined) type.
    /// </summary>
    /// <remarks>
    /// This interface is a logical extension of the <see cref="ICorDebugType"/> interface.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E6E91D79-693D-48BC-B417-8284B4F10FB5")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugType2
    {
        /// <summary>
        /// Gets a <see cref="COR_TYPEID"/> for this type.
        /// </summary>
        /// <param name="id">[out] A pointer to the <see cref="COR_TYPEID"/> for this <see cref="ICorDebugType"/>.</param>
        /// <returns>
        /// The return value is S_OK on success, or a failure HRESULT code on failure. The HRESULT codes include the following:
        /// 
        /// | Return code               | Description                                                                  |
        /// | ------------------------- | ---------------------------------------------------------------------------- |
        /// | S_OK                      | Method succeeded. The method has retrieved a valid <see cref="COR_TYPEID"/>. |
        /// | CORDBG_E_CLASS_NOT_LOADED | The type has not been loaded.                                                |
        /// | CORDBG_E_UNSUPPORTED      | The type is not supported.                                                   |
        /// </returns>
        /// <remarks>
        /// This method provides a mapping from the <see cref="ICorDebugType"/>, which represents a type that may or may not have been loaded
        /// into the runtime, to a <see cref="COR_TYPEID"/>, which serves as an opaque handle that identifies a type loaded
        /// into the runtime. When the type that the <see cref="ICorDebugType"/> represents has not yet been loaded, this method returns
        /// CORDBG_E_CLASS_NOT_LOADED. If the type is not supported, it returns CORDBG_E_UNSUPPORTED.
        /// </remarks>
        [PreserveSig]
        HRESULT GetTypeID(
            [Out] out COR_TYPEID id);
    }
}
