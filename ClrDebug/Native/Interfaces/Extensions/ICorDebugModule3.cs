using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Creates a symbol reader for a dynamic module.
    /// </summary>
    /// <remarks>
    /// This interface logically extends the "ICorDebugModule" and "ICorDebugModule2" interfaces.
    /// </remarks>
    [Guid("86F012BF-FF15-4372-BD30-B6F11CAAE1DD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugModule3
    {
        /// <summary>
        /// Creates a debug symbol reader for a dynamic module.
        /// </summary>
        /// <param name="riid">[in] The IID of the COM interface to return. Typically, this is an <see cref="ISymUnmanagedReader"/>.</param>
        /// <param name="ppObj">[out] Pointer to a pointer to the returned interface.</param>
        /// <returns>
        /// * S_OK - Successfully created the reader.
        /// * CORDBG_E_MODULE_LOADED_FROM_DISK - The module is not an in-memory or dynamic module.
        /// * CORDBG_E_SYMBOLS_NOT_AVAILABLE - Symbols have not been supplied by the application or are not yet available.
        /// * E_FAIL (or other E_ return codes) - Unable to create the reader.
        /// </returns>
        /// <remarks>
        /// This method can also be used to create a symbol reader object for in-memory (non-dynamic) modules, but only after
        /// the symbols are first available (indicated by the <see cref="ICorDebugManagedCallback.UpdateModuleSymbols"/> callback).
        /// This method returns a new reader instance every time it is called (like CComPtrBase). Therefore, the debugger should
        /// cache the result and request a new instance only when the underlying data may have changed (that is, when a <see
        /// cref="ICorDebugManagedCallback.LoadClass"/> callback is received). Dynamic modules do not have any symbols available
        /// until the first type has been loaded (as indicated by the <see cref="ICorDebugManagedCallback.LoadClass"/> callback).
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateReaderForInMemorySymbols(
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.Interface), Out] out object ppObj);
    }
}