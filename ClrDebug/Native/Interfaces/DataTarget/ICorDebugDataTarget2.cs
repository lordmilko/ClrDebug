using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Logically extends the <see cref="ICorDebugDataTarget"/>interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2EB364DA-605B-4E8D-B333-3394C4828D41")]
    [ComImport]
    public interface ICorDebugDataTarget2
    {
        /// <summary>
        /// Returns the module base address and size from an address in that module.
        /// </summary>
        /// <param name="addr">A <see cref="CORDB_ADDRESS"/> value that represents an address in a module.</param>
        /// <param name="pImageBase">[out] A <see cref="CORDB_ADDRESS"/> value that represents the module's base address.</param>
        /// <param name="pSize">A pointer to the module size.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetImageFromPointer([In] CORDB_ADDRESS addr, [Out] out CORDB_ADDRESS pImageBase, [Out] out int pSize);

        /// <summary>
        /// Returns the path of a module from the module's base address.
        /// </summary>
        /// <param name="baseAddress">[in] A <see cref="CORDB_ADDRESS"/> value that represents the module's base address.</param>
        /// <param name="cchName">[in] The number of characters in the buffer that is to receive the module path.</param>
        /// <param name="pcchName">[out] A pointer to the number of characters written to the szName buffer.</param>
        /// <param name="szName">[out] The path of the module.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetImageLocation(
            [In] CORDB_ADDRESS baseAddress,
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);

        /// <summary>
        /// Returns the symbol-provider for a module from the base address of that module.
        /// </summary>
        /// <param name="imageBaseAddress">[in] A <see cref="CORDB_ADDRESS"/> value that represents the base address of a module.</param>
        /// <param name="ppSymProvider">[out] A pointer to the address of an <see cref="ICorDebugSymbolProvider"/> object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSymbolProviderForImage(
            [In] CORDB_ADDRESS imageBaseAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugSymbolProvider ppSymProvider);

        /// <summary>
        /// Returns a list of active thread IDs.
        /// </summary>
        /// <param name="cThreadIds">[in] The maximum number of threads whose IDs can be returned.</param>
        /// <param name="pcThreadIds">[out] A pointer to a ULONG32 that indicates the actual number of thread IDs written to the pThreadIds array.</param>
        /// <param name="pThreadIds">An array of thread identifiers.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateThreadIDs([In] int cThreadIds, [Out] out int pcThreadIds, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] pThreadIds);

        /// <summary>
        /// Creates a new stack unwinder that starts unwinding from an initial context (which isn't necessarily the leaf of a thread).
        /// </summary>
        /// <param name="nativeThreadID">[in] The native thread ID of the thread whose stack is to be unwound.</param>
        /// <param name="contextFlags">[in] Flags that specify which parts of the context are defined in initialContext.</param>
        /// <param name="cbContext">[in] The size of initialContext.</param>
        /// <param name="initialContext">[in] The data in the context.</param>
        /// <param name="ppUnwinder">[out] A pointer to the address of an <see cref="ICorDebugVirtualUnwinder"/> interface object.</param>
        /// <returns>S_OK if successful. Any other <see cref="HRESULT"/> indicates failure. Any failing <see cref="HRESULT"/> received by mscordbi is considered fatal and causes <see cref="ICorDebug"/> methods to return CORDBG_E_DATA_TARGET_ERROR.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateVirtualUnwinder(
            [In] int nativeThreadID,
            [In] int contextFlags,
            [In] int cbContext,
            [In] IntPtr initialContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugVirtualUnwinder ppUnwinder);
    }
}