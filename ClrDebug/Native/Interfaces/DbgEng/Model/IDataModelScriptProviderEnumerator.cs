using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator which returns a set of known script providers.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("95BA00E2-704A-4FE2-A8F1-A7E7D8FB0941")]
    [ComImport]
    public interface IDataModelScriptProviderEnumerator
    {
        /// <summary>
        /// Resets the enumerator to the first element.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// The GetNext method will move the enumerator forward one element and return the script provider which is at that element.<para/>
        /// When the enumerator hits the end of enumeration, E_BOUNDS will be returned. Calling the GetNext method after receiving this error will continue to return E_BOUNDS indefinitely.
        /// </summary>
        /// <param name="provider">The next script provider registered with the script manager will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptProvider provider);
    }
}
