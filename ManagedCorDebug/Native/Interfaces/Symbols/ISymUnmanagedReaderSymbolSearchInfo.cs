using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that get symbol search information. Obtain this interface by calling QueryInterface on an object that implements the <see cref="ISymUnmanagedReader"/> interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("20D9645D-03CD-4E34-9C11-9848A5B084F1")]
    [ComImport]
    public interface ISymUnmanagedReaderSymbolSearchInfo
    {
        /// <summary>
        /// Gets a count of symbol search information.
        /// </summary>
        /// <param name="pcSearchInfo">]out] A pointer to a ULONG32 that receives the size of the buffer required to contain the search information.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSymbolSearchInfoCount([Out] out int pcSearchInfo);

        /// <summary>
        /// Gets symbol search information.
        /// </summary>
        /// <param name="cSearchInfo">[in] A ULONG32 that indicates the size of rgpSearchInfo.</param>
        /// <param name="pcSearchInfo">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the search information.</param>
        /// <param name="rgpSearchInfo">[out] A pointer that is set to the returned <see cref="ISymUnmanagedSymbolSearchInfo"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSymbolSearchInfo(
            [In] int cSearchInfo,
            [Out] out int pcSearchInfo,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedSymbolSearchInfo rgpSearchInfo);
    }
}