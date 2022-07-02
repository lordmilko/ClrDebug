using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for marking and filtering metadata tokens to avoid repeating actions that have already been taken.
    /// </summary>
    [Guid("D0E80DD1-12D4-11d3-B39D-00C04FF81795")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IMetaDataFilter
    {
        /// <summary>
        /// Removes the processing marks from all the tokens in the current metadata scope.
        /// </summary>
        [PreserveSig]
        HRESULT UnmarkAll();

        /// <summary>
        /// Sets a value indicating that the specified metadata token has been processed.
        /// </summary>
        /// <param name="tk">[in] The token to mark as processed.</param>
        [PreserveSig]
        HRESULT MarkToken([In] mdToken tk);

        /// <summary>
        /// Gets a value indicating whether the specified metadata token has been marked as processed.
        /// </summary>
        /// <param name="tk">[in] The token to examine for a processing mark.</param>
        /// <param name="pIsMarked">[out] A value that is true if tk has been processed; otherwise false.</param>
        [PreserveSig]
        HRESULT IsTokenMarked([In] mdToken tk, [Out] out int pIsMarked);
    }
}