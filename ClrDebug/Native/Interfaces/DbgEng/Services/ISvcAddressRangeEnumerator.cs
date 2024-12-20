using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Enumerates a set of one or more address ranges.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A7DF185B-CBBF-4B0D-BBA6-C58D6F9240C0")]
    [ComImport]
    public interface ISvcAddressRangeEnumerator
    {
        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Gets the next address range from the enumerator.
        /// </summary>
        [PreserveSig]
        HRESULT GetNext(
            [Out] out SvcAddressRange pAddressRange);
    }
}
