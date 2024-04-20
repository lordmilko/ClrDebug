namespace ClrDebug.DIA
{
    public class DiaInputAssemblyFile : ComObject<IDiaInputAssemblyFile>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaInputAssemblyFile"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaInputAssemblyFile(IDiaInputAssemblyFile raw) : base(raw)
        {
        }

        #region IDiaInputAssemblyFile
        #region UniqueId

        public int UniqueId
        {
            get
            {
                int pRetVal;
                TryGetUniqueId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetUniqueId(out int pRetVal)
        {
            /*HRESULT get_uniqueId(
            [Out] out int pRetVal);*/
            return Raw.get_uniqueId(out pRetVal);
        }

        #endregion
        #region Index

        public int Index
        {
            get
            {
                int pRetVal;
                TryGetIndex(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetIndex(out int pRetVal)
        {
            /*HRESULT get_index(
            [Out] out int pRetVal);*/
            return Raw.get_index(out pRetVal);
        }

        #endregion
        #region TimeStamp

        public int TimeStamp
        {
            get
            {
                int pRetVal;
                TryGetTimeStamp(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetTimeStamp(out int pRetVal)
        {
            /*HRESULT get_timeStamp(
            [Out] out int pRetVal);*/
            return Raw.get_timeStamp(out pRetVal);
        }

        #endregion
        #region PdbAvailableAtILMerge

        public bool PdbAvailableAtILMerge
        {
            get
            {
                bool pRetVal;
                TryGetPdbAvailableAtILMerge(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        public HRESULT TryGetPdbAvailableAtILMerge(out bool pRetVal)
        {
            /*HRESULT get_pdbAvailableAtILMerge(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_pdbAvailableAtILMerge(out pRetVal);
        }

        #endregion
        #region FileName

        public string FileName
        {
            get
            {
                string pRetVal;
                TryGetFileName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetFileName(out string pRetVal)
        {
            /*HRESULT get_fileName(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_fileName(out pRetVal);
        }

        #endregion
        #region Version

        public byte[] Version
        {
            get
            {
                byte[] pbData;
                TryGetVersion(out pbData).ThrowOnNotOK();

                return pbData;
            }
        }

        public HRESULT TryGetVersion(out byte[] pbData)
        {
            /*HRESULT get_version(
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pbData);*/
            int cbData = 0;
            int pcbData;
            pbData = null;
            HRESULT hr = Raw.get_version(cbData, out pcbData, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbData = pcbData;
            pbData = new byte[cbData];
            hr = Raw.get_version(cbData, out pcbData, pbData);
            fail:
            return hr;
        }

        #endregion
        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return FileName;
        }
    }
}
