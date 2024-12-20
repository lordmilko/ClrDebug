using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// ISvcLegacySourceV2Index Private bridge interface to symbol providers which return a legacy sourcelink V2 indexing stream.<para/>
    /// This is intended to support certain providers which sit atop existing PDBs. New symbol provider interfaces should be defined for SourceLink v2 and symbol providers should utilize those for a URL mapping rather than implementing this interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2946E095-F0D2-42D0-AE3E-8EEAFFC7EE39")]
    [ComImport]
    public interface ISvcLegacySourceLinkV2Index
    {
        /// <summary>
        /// Returns the number of streams in the legacy sourcelink v2 indexing information. If no such information is present for the given symbol set, then *pNumberOfStreams will be set to zero and S_OK will be returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetLegacySourceLinkV2NumberOfStreams(
            [Out] out int pNumberOfStreams);

        /// <summary>
        /// Returns the size of the requested stream index from the legacy sourcelink v2 indexing information. If no such information is present for a given symbol set, *pDataSize will be set to zero and S_OK will be returned.<para/>
        /// Callers should determine the number of streams via a call to GetLegacySourceLinkV2NumberOfStreams prior to calling this method.
        /// </summary>
        [PreserveSig]
        HRESULT GetLegacySourceLinkV2StreamDataSize(
            [In] int streamIndex,
            [Out] out long pDataSize);

        /// <summary>
        /// If there is legacy sourcelink v2 indexing data for the requested stream index associated with a given symbol set, this will fill a provided buffer with such data.<para/>
        /// Callers should determine the size of any such data via a call to GetLegacySourceLinkV2StreamDataSize prior to calling this method.
        /// </summary>
        [PreserveSig]
        HRESULT ReadLegacySourceLinkV2StreamData(
            [In] int streamIndex,
            [In] long bufferSize,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] buffer,
            [Out] out long bytesWritten);
    }
}
