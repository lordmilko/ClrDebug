using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides source server data for a module. Obtain this interface by calling QueryInterface on an object that implements the <see cref="ISymUnmanagedReader"/> interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("997DD0CC-A76F-4C82-8D79-EA87559D27AD")]
    [ComConversionLoss]
    [ComImport]
    public interface ISymUnmanagedSourceServerModule
    {
        /// <summary>
        /// Returns the source server data for the module. The caller must free resources by using CoTaskMemFree.
        /// </summary>
        /// <param name="pDataByteCount">[out] A pointer to a ULONG32 that receives the size, in bytes, of the source server data.</param>
        /// <param name="ppData">[out] A pointer to the returned pDataByteCount value.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSourceServerData([Out] out int pDataByteCount, [Out] IntPtr ppData);
    }
}