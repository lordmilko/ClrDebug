using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides a method to indicate that a specified token will be processed.
    /// </summary>
    [Guid("D0E80DD3-12D4-11d3-B39D-00C04FF81795")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IHostFilter
    {
        /// <summary>
        /// Indicates that the specified metadata token will be processed.
        /// </summary>
        /// <param name="tk">[in] The metadata token to be processed.</param>
        /// <remarks>
        /// Typically, you want a token to be processed if it is in the metadata scope. The MarkToken method is passed to the
        /// metadata engine via the <see cref="IMetaDataEmit.SetHandler"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT MarkToken(
            [In] mdToken tk);
    }
}
