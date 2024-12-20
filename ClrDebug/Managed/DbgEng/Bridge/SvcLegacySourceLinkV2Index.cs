namespace ClrDebug.DbgEng
{
    /// <summary>
    /// ISvcLegacySourceV2Index Private bridge interface to symbol providers which return a legacy sourcelink V2 indexing stream.<para/>
    /// This is intended to support certain providers which sit atop existing PDBs. New symbol provider interfaces should be defined for SourceLink v2 and symbol providers should utilize those for a URL mapping rather than implementing this interface.
    /// </summary>
    public class SvcLegacySourceLinkV2Index : ComObject<ISvcLegacySourceLinkV2Index>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcLegacySourceLinkV2Index"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcLegacySourceLinkV2Index(ISvcLegacySourceLinkV2Index raw) : base(raw)
        {
        }

        #region ISvcLegacySourceLinkV2Index
        #region LegacySourceLinkV2NumberOfStreams

        /// <summary>
        /// Returns the number of streams in the legacy sourcelink v2 indexing information. If no such information is present for the given symbol set, then *pNumberOfStreams will be set to zero and S_OK will be returned.
        /// </summary>
        public int LegacySourceLinkV2NumberOfStreams
        {
            get
            {
                int pNumberOfStreams;
                TryGetLegacySourceLinkV2NumberOfStreams(out pNumberOfStreams).ThrowDbgEngNotOK();

                return pNumberOfStreams;
            }
        }

        /// <summary>
        /// Returns the number of streams in the legacy sourcelink v2 indexing information. If no such information is present for the given symbol set, then *pNumberOfStreams will be set to zero and S_OK will be returned.
        /// </summary>
        public HRESULT TryGetLegacySourceLinkV2NumberOfStreams(out int pNumberOfStreams)
        {
            /*HRESULT GetLegacySourceLinkV2NumberOfStreams(
            [Out] out int pNumberOfStreams);*/
            return Raw.GetLegacySourceLinkV2NumberOfStreams(out pNumberOfStreams);
        }

        #endregion
        #region GetLegacySourceLinkV2StreamDataSize

        /// <summary>
        /// Returns the size of the requested stream index from the legacy sourcelink v2 indexing information. If no such information is present for a given symbol set, *pDataSize will be set to zero and S_OK will be returned.<para/>
        /// Callers should determine the number of streams via a call to GetLegacySourceLinkV2NumberOfStreams prior to calling this method.
        /// </summary>
        public long GetLegacySourceLinkV2StreamDataSize(int streamIndex)
        {
            long pDataSize;
            TryGetLegacySourceLinkV2StreamDataSize(streamIndex, out pDataSize).ThrowDbgEngNotOK();

            return pDataSize;
        }

        /// <summary>
        /// Returns the size of the requested stream index from the legacy sourcelink v2 indexing information. If no such information is present for a given symbol set, *pDataSize will be set to zero and S_OK will be returned.<para/>
        /// Callers should determine the number of streams via a call to GetLegacySourceLinkV2NumberOfStreams prior to calling this method.
        /// </summary>
        public HRESULT TryGetLegacySourceLinkV2StreamDataSize(int streamIndex, out long pDataSize)
        {
            /*HRESULT GetLegacySourceLinkV2StreamDataSize(
            [In] int streamIndex,
            [Out] out long pDataSize);*/
            return Raw.GetLegacySourceLinkV2StreamDataSize(streamIndex, out pDataSize);
        }

        #endregion
        #region ReadLegacySourceLinkV2StreamData

        /// <summary>
        /// If there is legacy sourcelink v2 indexing data for the requested stream index associated with a given symbol set, this will fill a provided buffer with such data.<para/>
        /// Callers should determine the size of any such data via a call to GetLegacySourceLinkV2StreamDataSize prior to calling this method.
        /// </summary>
        public long ReadLegacySourceLinkV2StreamData(int streamIndex, long bufferSize, byte[] buffer)
        {
            long bytesWritten;
            TryReadLegacySourceLinkV2StreamData(streamIndex, bufferSize, buffer, out bytesWritten).ThrowDbgEngNotOK();

            return bytesWritten;
        }

        /// <summary>
        /// If there is legacy sourcelink v2 indexing data for the requested stream index associated with a given symbol set, this will fill a provided buffer with such data.<para/>
        /// Callers should determine the size of any such data via a call to GetLegacySourceLinkV2StreamDataSize prior to calling this method.
        /// </summary>
        public HRESULT TryReadLegacySourceLinkV2StreamData(int streamIndex, long bufferSize, byte[] buffer, out long bytesWritten)
        {
            /*HRESULT ReadLegacySourceLinkV2StreamData(
            [In] int streamIndex,
            [In] long bufferSize,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] buffer,
            [Out] out long bytesWritten);*/
            return Raw.ReadLegacySourceLinkV2StreamData(streamIndex, bufferSize, buffer, out bytesWritten);
        }

        #endregion
        #endregion
    }
}
