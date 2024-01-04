using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator which runs through children of a symbol.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("28D96C86-10A3-4976-B14E-EAEF4790AA1F")]
    [ComImport]
    public interface IDebugHostSymbolEnumerator
    {
        /// <summary>
        /// Resets the enumerator to its initial state. A subsequent GetNext call will return the first symbol in the set in enumerator order.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Moves the iterator forward and fetches the next symbol in the set. E_BOUNDS will be returned when the enumerator hits the end of the set.
        /// </summary>
        /// <param name="symbol">The next enumerated symbol will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol);
    }
}
