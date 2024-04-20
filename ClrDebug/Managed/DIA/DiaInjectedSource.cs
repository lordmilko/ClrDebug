namespace ClrDebug.DIA
{
    /// <summary>
    /// Accesses injected source code stored in the DIA data source.
    /// </summary>
    /// <remarks>
    /// Injected source is text that is injected during compilation. This does not mean the preprocessor #include used
    /// in C++. Obtain this interface by calling the <see cref="DiaEnumInjectedSources.Item"/> or <see cref="DiaEnumInjectedSources.MoveNext"/>
    /// methods. See the <see cref="IDiaEnumInjectedSources"/> interface for an example of obtaining the IDiaInjectedSource
    /// interface.
    /// </remarks>
    public class DiaInjectedSource : ComObject<IDiaInjectedSource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaInjectedSource"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaInjectedSource(IDiaInjectedSource raw) : base(raw)
        {
        }

        #region IDiaInjectedSource
        #region Crc

        /// <summary>
        /// Retrieves a cyclic redundancy check (CRC) calculated from the bytes of the source code.
        /// </summary>
        public int Crc
        {
            get
            {
                int pRetVal;
                TryGetCrc(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a cyclic redundancy check (CRC) calculated from the bytes of the source code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the CRC calculated from the bytes of the source code.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetCrc(out int pRetVal)
        {
            /*HRESULT get_crc(
            [Out] out int pRetVal);*/
            return Raw.get_crc(out pRetVal);
        }

        #endregion
        #region Length

        /// <summary>
        /// Retrieves the number of bytes of code.
        /// </summary>
        public long Length
        {
            get
            {
                long pRetVal;
                TryGetLength(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of bytes of code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes of code.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is the length of the source code and is the same value as returned by the <see
        /// cref="Source"/> property.
        /// </remarks>
        public HRESULT TryGetLength(out long pRetVal)
        {
            /*HRESULT get_length(
            [Out] out long pRetVal);*/
            return Raw.get_length(out pRetVal);
        }

        #endregion
        #region FileName

        /// <summary>
        /// Retrieves the file name for the source.
        /// </summary>
        public string FileName
        {
            get
            {
                string pRetVal;
                TryGetFileName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the file name for the source.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the file name for the source.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetFileName(out string pRetVal)
        {
            /*HRESULT get_fileName(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_fileName(out pRetVal);
        }

        #endregion
        #region ObjectFileName

        /// <summary>
        /// Retrieves the object file name to which the source was compiled.
        /// </summary>
        public string ObjectFileName
        {
            get
            {
                string pRetVal;
                TryGetObjectFileName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the object file name to which the source was compiled.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the object file name to which the source was compiled.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetObjectFileName(out string pRetVal)
        {
            /*HRESULT get_objectFileName(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_objectFileName(out pRetVal);
        }

        #endregion
        #region VirtualFilename

        /// <summary>
        /// Retrieves the name given to non-file source code; that is, code that was injected.
        /// </summary>
        public string VirtualFilename
        {
            get
            {
                string pRetVal;
                TryGetVirtualFilename(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the name given to non-file source code; that is, code that was injected.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the name given to injected non-file source code.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetVirtualFilename(out string pRetVal)
        {
            /*HRESULT get_virtualFilename(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_virtualFilename(out pRetVal);
        }

        #endregion
        #region SourceCompression

        /// <summary>
        /// Retrieves the indicator of the source compression used.
        /// </summary>
        public int SourceCompression
        {
            get
            {
                int pRetVal;
                TryGetSourceCompression(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the indicator of the source compression used.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the indicator of the source compression used. A value of zero indicates that no source compression was used.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// The value returned by this method is specific to the compiler used. For example, a compiler might use Run-Length
        /// Encoding or Huffman-style compression.
        /// </remarks>
        public HRESULT TryGetSourceCompression(out int pRetVal)
        {
            /*HRESULT get_sourceCompression(
            [Out] out int pRetVal);*/
            return Raw.get_sourceCompression(out pRetVal);
        }

        #endregion
        #region Source

        /// <summary>
        /// Retrieves the source code bytes.
        /// </summary>
        public byte[] Source
        {
            get
            {
                byte[] pbData;
                TryGetSource(out pbData).ThrowOnNotOK();

                return pbData;
            }
        }

        /// <summary>
        /// Retrieves the source code bytes.
        /// </summary>
        /// <param name="pbData">[out] A buffer that is to be filled in with the source bytes.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetSource(out byte[] pbData)
        {
            /*HRESULT get_source(
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pbData);*/
            int cbData = 0;
            int pcbData;
            pbData = null;
            HRESULT hr = Raw.get_source(cbData, out pcbData, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbData = pcbData;
            pbData = new byte[cbData];
            hr = Raw.get_source(cbData, out pcbData, pbData);
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
