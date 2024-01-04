using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D49EECE8-8D12-4CE1-AB73-E5B63DF4F9D3")]
    [ComImport]
    public interface IDebugHostSymbolSubstitutionEnumerator : IDebugHostSymbolEnumerator
    {
        /// <summary>
        /// Resets the enumerator to its initial state. A subsequent GetNext call will return the first symbol in the set in enumerator order.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT Reset();

        /// <summary>
        /// Moves the iterator forward and fetches the next symbol in the set. E_BOUNDS will be returned when the enumerator hits the end of the set.
        /// </summary>
        /// <param name="symbol">The next enumerated symbol will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol);
        
        [PreserveSig]
        HRESULT GetNextWithSubstitutionText(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol,
            [Out, MarshalAs(UnmanagedType.BStr)] out string symbolText);
    }
}
