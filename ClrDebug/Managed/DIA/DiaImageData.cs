namespace ClrDebug.DIA
{
    /// <summary>
    /// Exposes the details of the base location and memory offsets of the module or image.
    /// </summary>
    /// <remarks>
    /// Some debug streams (XDATA, PDATA) contain copies of data also stored in the image. These stream data objects can
    /// be queried for the IDiaImageData interface. See the "Notes for Callers" section in this topic for details. Obtain
    /// this interface by calling QueryInterface on an IDiaEnumDebugStreamData object. Note that not all debug streams
    /// support the IDiaImageData interface. For example, currently only the XDATA and PDATA streams support the IDiaImageData
    /// interface.
    /// </remarks>
    public class DiaImageData : ComObject<IDiaImageData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaImageData"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaImageData(IDiaImageData raw) : base(raw)
        {
        }

        #region IDiaImageData
        #region RelativeVirtualAddress

        /// <summary>
        /// Retrieves the location in virtual memory of the module relative to the application.
        /// </summary>
        public int RelativeVirtualAddress
        {
            get
            {
                int pRetVal;
                TryGetRelativeVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the location in virtual memory of the module relative to the application.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the relative virtual memory offset of the module.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetRelativeVirtualAddress(out int pRetVal)
        {
            /*HRESULT get_relativeVirtualAddress(
            [Out] out int pRetVal);*/
            return Raw.get_relativeVirtualAddress(out pRetVal);
        }

        #endregion
        #region VirtualAddress

        /// <summary>
        /// Retrieves the location in virtual memory of the image.
        /// </summary>
        public long VirtualAddress
        {
            get
            {
                long pRetVal;
                TryGetVirtualAddress(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the location in virtual memory of the image.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the virtual address of the image.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetVirtualAddress(out long pRetVal)
        {
            /*HRESULT get_virtualAddress(
            [Out] out long pRetVal);*/
            return Raw.get_virtualAddress(out pRetVal);
        }

        #endregion
        #region ImageBase

        /// <summary>
        /// Retrieves the memory location where the image should be based.
        /// </summary>
        public long ImageBase
        {
            get
            {
                long pRetVal;
                TryGetImageBase(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the memory location where the image should be based.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the suggested image base value.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Due to image base conflicts, an image may be rebased automatically to an unused memory location when it is loaded.
        /// This method returns the base hint (suggested memory location) that was stored in the module at compile time.
        /// </remarks>
        public HRESULT TryGetImageBase(out long pRetVal)
        {
            /*HRESULT get_imageBase(
            [Out] out long pRetVal);*/
            return Raw.get_imageBase(out pRetVal);
        }

        #endregion
        #endregion
    }
}
