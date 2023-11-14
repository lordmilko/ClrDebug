namespace ClrDebug.DIA
{
    /// <summary>
    /// Provides control over how the DIA SDK computes virtual and relative virtual addresses for debug objects.
    /// </summary>
    /// <remarks>
    /// The control provided by this interface is encapsulated in two sets of data you supply: image headers and address
    /// maps. Most clients use the IDiaDataSource method to find the proper debug information for an image and the method
    /// can typically discover all of the necessary headers and maps data itself. However some clients implement specialized
    /// processing and searching for data. Such clients use the methods of the IDiaAddressMap interface to provide the
    /// DIA SDK with the search results. This interface is available from the DIA session object. The client calls the
    /// QueryInterface method on DIA session object interface, usually IDiaSession, to retrieve the IDiaAddressMap interface.
    /// </remarks>
    public class DiaAddressMap : ComObject<IDiaAddressMap>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaAddressMap"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaAddressMap(IDiaAddressMap raw) : base(raw)
        {
        }

        #region IDiaAddressMap
        #region AddressMapEnabled

        /// <summary>
        /// Indicates whether an address map has been established for a particular session.
        /// </summary>
        public bool AddressMapEnabled
        {
            get
            {
                bool pRetVal;
                TryGetAddressMapEnabled(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
            set
            {
                TryPutAddressMapEnabled(value).ThrowOnNotOK();
            }
        }

        /// <summary>
        /// Indicates whether an address map has been established for a particular session.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the address mapping is enabled.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Executable post-processors sometimes update the executable. DIA contains a mechanism to support the translation
        /// of symbols to the new layout. Client applications can set the address map for a particular session by getting the
        /// IDiaAddressMap interface from the IDiaSession interface and calling the IDiaAddressMap method followed by a call
        /// to the IDiaAddressMap method. The get_addressMapEnabled method returns the results of calling the put_addressMapEnabled
        /// method.
        /// </remarks>
        public HRESULT TryGetAddressMapEnabled(out bool pRetVal)
        {
            /*HRESULT get_addressMapEnabled(
            [Out] out bool pRetVal);*/
            return Raw.get_addressMapEnabled(out pRetVal);
        }

        /// <summary>
        /// Specifies whether the address map should be used to translate symbol addresses.
        /// </summary>
        /// <param name="newVal">[in] Set to TRUE to enable the translation of symbols, or FALSE to disable.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Executable post-processors sometimes update the executable. DIA contains a mechanism to support the translation
        /// of symbols to the new layout. When a PDB file is loaded, the address map stored in the file is enabled. There are
        /// times, however, when a client application may need to supply its own address map by calling the IDiaAddressMap
        /// method. If the set_addressMap method is successful, the client application must call the put_addressMapEnabled
        /// method with a NewVal parameter of TRUE to enable the use of that address map. The current state of the address
        /// map being enabled can be retrieved with a call to the IDiaAddressMap method.
        /// </remarks>
        public HRESULT TryPutAddressMapEnabled(bool newVal)
        {
            /*HRESULT put_addressMapEnabled(
            [In] bool NewVal);*/
            return Raw.put_addressMapEnabled(newVal);
        }

        #endregion
        #region RelativeVirtualAddressEnabled

        /// <summary>
        /// Indicates whether the calculation and use of relative virtual addresses (RVA) is enabled.
        /// </summary>
        public bool RelativeVirtualAddressEnabled
        {
            get
            {
                bool pRetVal;
                TryGetRelativeVirtualAddressEnabled(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
            set
            {
                TryPutRelativeVirtualAddressEnabled(value).ThrowOnNotOK();
            }
        }

        /// <summary>
        /// Indicates whether the calculation and use of relative virtual addresses (RVA) is enabled.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the calculation of RVAs is enabled.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// RVAs are enabled if the segments have been initially loaded from a PDB file. The use of RVAs can be temporarily
        /// disabled by calling the IDiaAddressMap method. Also, new image headers can be established by calling the IDiaAddressMap
        /// method followed by a call to the put_relativeVirtualAddressEnabled method to enable use of the RVAs using the new
        /// image headers.
        /// </remarks>
        public HRESULT TryGetRelativeVirtualAddressEnabled(out bool pRetVal)
        {
            /*HRESULT get_relativeVirtualAddressEnabled(
            [Out] out bool pRetVal);*/
            return Raw.get_relativeVirtualAddressEnabled(out pRetVal);
        }

        /// <summary>
        /// Allows the client to enable or disable the calculation and use of relative virtual addresses (RVA).
        /// </summary>
        /// <param name="newVal">[in] Set to TRUE to enable, or FALSE to disable.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Addresses for debug objects described by DIA interfaces, and relative to the executable's image base, can be retrieved
        /// as relative virtual addresses. The use of RVAs is enabled when segments are initially loaded from a PDB file. To
        /// get the current state of the use of RVAs, call the IDiaAddressMap method. The put_relativeVirtualAddress method
        /// must be called to enable RVAs after a successful call to the IDiaAddressMap method has established new image headers.
        /// </remarks>
        public HRESULT TryPutRelativeVirtualAddressEnabled(bool newVal)
        {
            /*HRESULT put_relativeVirtualAddressEnabled(
            [In] bool NewVal);*/
            return Raw.put_relativeVirtualAddressEnabled(newVal);
        }

        #endregion
        #region ImageAlign

        /// <summary>
        /// Retrieves the current image alignment.
        /// </summary>
        public int ImageAlign
        {
            get
            {
                int pRetVal;
                TryGetImageAlign(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
            set
            {
                TryPutImageAlign(value).ThrowOnNotOK();
            }
        }

        /// <summary>
        /// Retrieves the current image alignment.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the image alignment value from the executable.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Images are aligned to specific memory boundaries depending how the image was loaded and created. The alignment
        /// is typically on 1, 2, 4, 8, 16, 32, or 64 byte boundaries. The image alignment can be set with a call to the IDiaAddressMap
        /// method.
        /// </remarks>
        public HRESULT TryGetImageAlign(out int pRetVal)
        {
            /*HRESULT get_imageAlign(
            [Out] out int pRetVal);*/
            return Raw.get_imageAlign(out pRetVal);
        }

        /// <summary>
        /// Sets the image alignment.
        /// </summary>
        /// <param name="newVal">[in] The new image alignment value for the executable.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Images (loaded executables) are aligned to specified memory boundaries. This alignment can be affected by the current
        /// system architecture and by compile and link time options. Image alignment is always on byte boundaries. The following
        /// image alignment values are valid: 1, 2, 4, 8, 16, 32, and 64 byte boundaries. The current image alignment can be
        /// retrieved with a call to the IDiaAddressMap method.
        /// </remarks>
        public HRESULT TryPutImageAlign(int newVal)
        {
            /*HRESULT put_imageAlign(
            [In] int NewVal);*/
            return Raw.put_imageAlign(newVal);
        }

        #endregion
        #region SetImageHeaders

        /// <summary>
        /// Sets image headers to enable relative virtual address translation.
        /// </summary>
        /// <param name="cbData">[in] Number of bytes of header data. Must be n*sizeof(IMAGE_SECTION_HEADER) where n is the number of section headers in the executable.</param>
        /// <param name="pbData">[in] An array of IMAGE_SECTION_HEADER structures to be used as the image headers.</param>
        /// <param name="originalHeaders">[in] Set to FALSE if the image headers are from the new image, TRUE if they reflect the original image prior to an upgrade.<para/>
        /// Typically, this would be set to TRUE only in combination with calls to the IDiaAddressMap method.</param>
        /// <remarks>
        /// The IMAGE_SECTION_HEADER structure is declared in Winnt.h and represents the image section header format of the
        /// executable. Relative virtual address calculations depend upon the IMAGE_SECTION_HEADER values. Usually, the DIA
        /// retrieves these from the program database (.pdb) file. If these values are missing, the DIA is unable to calculate
        /// relative virtual addresses and the IDiaAddressMap method returns FALSE. The client must then call the IDiaAddressMap
        /// method to enable the relative virtual address calculations after providing the missing image headers from the image
        /// itself.
        /// </remarks>
        public void SetImageHeaders(int cbData, byte[] pbData, bool originalHeaders)
        {
            TrySetImageHeaders(cbData, pbData, originalHeaders).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets image headers to enable relative virtual address translation.
        /// </summary>
        /// <param name="cbData">[in] Number of bytes of header data. Must be n*sizeof(IMAGE_SECTION_HEADER) where n is the number of section headers in the executable.</param>
        /// <param name="pbData">[in] An array of IMAGE_SECTION_HEADER structures to be used as the image headers.</param>
        /// <param name="originalHeaders">[in] Set to FALSE if the image headers are from the new image, TRUE if they reflect the original image prior to an upgrade.<para/>
        /// Typically, this would be set to TRUE only in combination with calls to the IDiaAddressMap method.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The IMAGE_SECTION_HEADER structure is declared in Winnt.h and represents the image section header format of the
        /// executable. Relative virtual address calculations depend upon the IMAGE_SECTION_HEADER values. Usually, the DIA
        /// retrieves these from the program database (.pdb) file. If these values are missing, the DIA is unable to calculate
        /// relative virtual addresses and the IDiaAddressMap method returns FALSE. The client must then call the IDiaAddressMap
        /// method to enable the relative virtual address calculations after providing the missing image headers from the image
        /// itself.
        /// </remarks>
        public HRESULT TrySetImageHeaders(int cbData, byte[] pbData, bool originalHeaders)
        {
            /*HRESULT set_imageHeaders(
            [In] int cbData,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 0)] byte[] pbData,
            [In] bool originalHeaders);*/
            return Raw.set_imageHeaders(cbData, pbData, originalHeaders);
        }

        #endregion
        #region SetAddressMap

        /// <summary>
        /// Provides an address map to support image layout translations.
        /// </summary>
        /// <param name="cData">[in] The number of elements in the data parameter.</param>
        /// <param name="pData">[in] An array of DiaAddressMapEntry Structure structures that define the translation map.</param>
        /// <param name="imageToSymbols">[in] TRUE if the data parameter defines a map from the new image layout to the original layout (as described by the debug symbols).<para/>
        /// FALSE if data is a map to the new image layout taken from the original layout.</param>
        /// <remarks>
        /// Usually, the DIA retrieves address translation maps from the program database (.pdb) file. If these values are
        /// missing, the IDiaAddressMap method is called twice, once with the imagetoSymbols parameter set to TRUE and once
        /// with the imagetoSymbols parameter set to FALSE. Address map translations cannot be enabled using the IDiaAddressMap
        /// method unless both translation maps are provided.
        /// </remarks>
        public void SetAddressMap(int cData, DiaAddressMapEntry[] pData, bool imageToSymbols)
        {
            TrySetAddressMap(cData, pData, imageToSymbols).ThrowOnNotOK();
        }

        /// <summary>
        /// Provides an address map to support image layout translations.
        /// </summary>
        /// <param name="cData">[in] The number of elements in the data parameter.</param>
        /// <param name="pData">[in] An array of DiaAddressMapEntry Structure structures that define the translation map.</param>
        /// <param name="imageToSymbols">[in] TRUE if the data parameter defines a map from the new image layout to the original layout (as described by the debug symbols).<para/>
        /// FALSE if data is a map to the new image layout taken from the original layout.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Usually, the DIA retrieves address translation maps from the program database (.pdb) file. If these values are
        /// missing, the IDiaAddressMap method is called twice, once with the imagetoSymbols parameter set to TRUE and once
        /// with the imagetoSymbols parameter set to FALSE. Address map translations cannot be enabled using the IDiaAddressMap
        /// method unless both translation maps are provided.
        /// </remarks>
        public HRESULT TrySetAddressMap(int cData, DiaAddressMapEntry[] pData, bool imageToSymbols)
        {
            /*HRESULT set_addressMap(
            [In] int cData,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DiaAddressMapEntry[] pData,
            [In] bool imageToSymbols);*/
            return Raw.set_addressMap(cData, pData, imageToSymbols);
        }

        #endregion
        #endregion
    }
}
