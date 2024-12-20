using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Private bridge interface to symbol providers which return a legacy source indexing stream. This is intended to support certain providers which sit atop existing PDBs.<para/>
    /// New symbol provider interfaces should be defined for SourceLink v2 and symbol providers should utilize those for a URL mapping rather than implementing this interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E39AA759-5041-4b55-9650-550E4EA8172C")]
    [ComImport]
    public interface ISvcLegacySourceIndex
    {
        /// <summary>
        /// Returns the size of any legacy source indexing information. If no such information is present for a given set, *pDataSize will be set to zero and S_OK will be returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetLegacySourceIndexDataSize(
            [Out] out long pDataSize);

        /// <summary>
        /// If there is legacy source indexing data associated with a given symbol set, this will fill a provided buffer with such data.<para/>
        /// Callers should determine the size of any such data via a call to GetLegacySourceIndexDataSize prior to calling this method.
        /// </summary>
        [PreserveSig]
        HRESULT ReadLegacySourceIndexData(
            [In] long bufferSize,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] buffer,
            [Out] out long bytesWritten);
    }
}
