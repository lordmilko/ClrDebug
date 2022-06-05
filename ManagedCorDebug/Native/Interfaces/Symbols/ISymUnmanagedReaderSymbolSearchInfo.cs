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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSymbolSearchInfoCount(out uint pcSearchInfo);

        /// <summary>
        /// Gets symbol search information.
        /// </summary>
        /// <param name="cSearchInfo">[in] A ULONG32 that indicates the size of rgpSearchInfo.</param>
        /// <param name="pcSearchInfo">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the search information.</param>
        /// <param name="rgpSearchInfo">[out] A pointer that is set to the returned <see cref="ISymUnmanagedSymbolSearchInfo"/> interface.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSymbolSearchInfo(
            [In] uint cSearchInfo,
            out uint pcSearchInfo,
            [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedSymbolSearchInfo rgpSearchInfo);
    }
}