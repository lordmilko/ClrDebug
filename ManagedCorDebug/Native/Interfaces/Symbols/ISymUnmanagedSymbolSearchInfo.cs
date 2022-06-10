﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that get information about the search path. Obtain this interface by calling QueryInterface on an object that implements the <see cref="ISymUnmanagedReader"/> interface.
    /// </summary>
    [Guid("F8B3534A-A46B-4980-B520-BEC4ACEABA8F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedSymbolSearchInfo
    {
        /// <summary>
        /// Gets the search path length.
        /// </summary>
        /// <param name="pcchPath">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the search path length.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSearchPathLength(out uint pcchPath);

        /// <summary>
        /// Gets the search path.
        /// </summary>
        /// <param name="cchPath">[in] The number of characters in the buffer that is to receive the search path.</param>
        /// <param name="pcchPath">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the search path.</param>
        /// <param name="szPath">[out] A buffer to hold the search path.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSearchPath(
            [In] uint cchPath,
            out uint pcchPath,
            [Out] StringBuilder szPath);

        /// <summary>
        /// Gets the HRESULT.
        /// </summary>
        /// <param name="phr">[out] A pointer to the HRESULT.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHRESULT([MarshalAs(UnmanagedType.Error)] out HRESULT phr);
    }
}