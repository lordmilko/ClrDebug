﻿namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Private bridge interface to symbol providers which return a legacy source indexing stream. This is intended to support certain providers which sit atop existing PDBs.<para/>
    /// New symbol provider interfaces should be defined for SourceLink v2 and symbol providers should utilize those for a URL mapping rather than implementing this interface.
    /// </summary>
    public class SvcLegacySourceIndex : ComObject<ISvcLegacySourceIndex>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcLegacySourceIndex"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcLegacySourceIndex(ISvcLegacySourceIndex raw) : base(raw)
        {
        }

        #region ISvcLegacySourceIndex
        #region LegacySourceIndexDataSize

        /// <summary>
        /// Returns the size of any legacy source indexing information. If no such information is present for a given set, *pDataSize will be set to zero and S_OK will be returned.
        /// </summary>
        public long LegacySourceIndexDataSize
        {
            get
            {
                long pDataSize;
                TryGetLegacySourceIndexDataSize(out pDataSize).ThrowDbgEngNotOK();

                return pDataSize;
            }
        }

        /// <summary>
        /// Returns the size of any legacy source indexing information. If no such information is present for a given set, *pDataSize will be set to zero and S_OK will be returned.
        /// </summary>
        public HRESULT TryGetLegacySourceIndexDataSize(out long pDataSize)
        {
            /*HRESULT GetLegacySourceIndexDataSize(
            [Out] out long pDataSize);*/
            return Raw.GetLegacySourceIndexDataSize(out pDataSize);
        }

        #endregion
        #region ReadLegacySourceIndexData

        /// <summary>
        /// If there is legacy source indexing data associated with a given symbol set, this will fill a provided buffer with such data.<para/>
        /// Callers should determine the size of any such data via a call to GetLegacySourceIndexDataSize prior to calling this method.
        /// </summary>
        public long ReadLegacySourceIndexData(long bufferSize, byte[] buffer)
        {
            long bytesWritten;
            TryReadLegacySourceIndexData(bufferSize, buffer, out bytesWritten).ThrowDbgEngNotOK();

            return bytesWritten;
        }

        /// <summary>
        /// If there is legacy source indexing data associated with a given symbol set, this will fill a provided buffer with such data.<para/>
        /// Callers should determine the size of any such data via a call to GetLegacySourceIndexDataSize prior to calling this method.
        /// </summary>
        public HRESULT TryReadLegacySourceIndexData(long bufferSize, byte[] buffer, out long bytesWritten)
        {
            /*HRESULT ReadLegacySourceIndexData(
            [In] long bufferSize,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] buffer,
            [Out] out long bytesWritten);*/
            return Raw.ReadLegacySourceIndexData(bufferSize, buffer, out bytesWritten);
        }

        #endregion
        #endregion
    }
}
