namespace ClrDebug.DIA
{
    /// <summary>
    /// Retrieves data describing a section contribution, that is, a contiguous block of memory contributed to the image by a compiland.
    /// </summary>
    /// <remarks>
    /// This interface is obtained by calling the IDiaEnumSectionContribs and IDiaEnumSectionContribs methods. See the
    /// IDiaEnumSectionContribs interface for an example of obtaining the IDiaSectionContrib interface.
    /// </remarks>
    public class DiaSectionContrib : ComObject<IDiaSectionContrib>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaSectionContrib"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaSectionContrib(IDiaSectionContrib raw) : base(raw)
        {
        }

        #region IDiaSectionContrib
        #region Compiland

        /// <summary>
        /// Retrieves a reference to the compiland symbol that contributed this section.
        /// </summary>
        public DiaSymbol Compiland
        {
            get
            {
                DiaSymbol pRetValResult;
                TryGetCompiland(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves a reference to the compiland symbol that contributed this section.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns an IDiaSymbol object representing the compiland that contributed this section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetCompiland(out DiaSymbol pRetValResult)
        {
            /*HRESULT get_compiland(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol pRetVal);*/
            IDiaSymbol pRetVal;
            HRESULT hr = Raw.get_compiland(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new DiaSymbol(pRetVal);
            else
                pRetValResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region AddressSection

        /// <summary>
        /// Retrieves the section part of the contribution's address.
        /// </summary>
        public int AddressSection
        {
            get
            {
                int pRetVal;
                TryGetAddressSection(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the section part of the contribution's address.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the section part of the contribution's address.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetAddressSection(out int pRetVal)
        {
            /*HRESULT get_addressSection(
            [Out] out int pRetVal);*/
            return Raw.get_addressSection(out pRetVal);
        }

        #endregion
        #region AddressOffset

        /// <summary>
        /// Retrieves the offset part of the contribution's address.
        /// </summary>
        public int AddressOffset
        {
            get
            {
                int pRetVal;
                TryGetAddressOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the offset part of the contribution's address.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset part of the contribution's address.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetAddressOffset(out int pRetVal)
        {
            /*HRESULT get_addressOffset(
            [Out] out int pRetVal);*/
            return Raw.get_addressOffset(out pRetVal);
        }

        #endregion
        #region RelativeVirtualAddress

        /// <summary>
        /// Retrieves the image relative virtual address (RVA) of the contribution.
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
        /// Retrieves the image relative virtual address (RVA) of the contribution.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the image RVA of the contribution.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetRelativeVirtualAddress(out int pRetVal)
        {
            /*HRESULT get_relativeVirtualAddress(
            [Out] out int pRetVal);*/
            return Raw.get_relativeVirtualAddress(out pRetVal);
        }

        #endregion
        #region VirtualAddress

        /// <summary>
        /// Retrieves the virtual address (VA) of the contribution.
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
        /// Retrieves the virtual address (VA) of the contribution.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the VA of the contribution.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetVirtualAddress(out long pRetVal)
        {
            /*HRESULT get_virtualAddress(
            [Out] out long pRetVal);*/
            return Raw.get_virtualAddress(out pRetVal);
        }

        #endregion
        #region Length

        /// <summary>
        /// Retrieves the number of bytes in a section.
        /// </summary>
        public int Length
        {
            get
            {
                int pRetVal;
                TryGetLength(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of bytes in a section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes in a section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetLength(out int pRetVal)
        {
            /*HRESULT get_length(
            [Out] out int pRetVal);*/
            return Raw.get_length(out pRetVal);
        }

        #endregion
        #region NotPaged

        /// <summary>
        /// Retrieves a flag that indicates whether the section cannot be paged out of memory.
        /// </summary>
        public bool NotPaged
        {
            get
            {
                bool pRetVal;
                TryGetNotPaged(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section cannot be paged out of memory.
        /// </summary>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetNotPaged(out bool pRetVal)
        {
            /*HRESULT get_notPaged(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_notPaged(out pRetVal);
        }

        #endregion
        #region Code

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains executable code.
        /// </summary>
        public bool Code
        {
            get
            {
                bool pRetVal;
                TryGetCode(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains executable code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section contains executable code; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetCode(out bool pRetVal)
        {
            /*HRESULT get_code(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_code(out pRetVal);
        }

        #endregion
        #region InitializedData

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains initialized data.
        /// </summary>
        public bool InitializedData
        {
            get
            {
                bool pRetVal;
                TryGetInitializedData(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains initialized data.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section contains initialized data; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetInitializedData(out bool pRetVal)
        {
            /*HRESULT get_initializedData(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_initializedData(out pRetVal);
        }

        #endregion
        #region UninitializedData

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains uninitialized data.
        /// </summary>
        public bool UninitializedData
        {
            get
            {
                bool pRetVal;
                TryGetUninitializedData(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains uninitialized data.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section contains uninitialized data; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetUninitializedData(out bool pRetVal)
        {
            /*HRESULT get_uninitializedData(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_uninitializedData(out pRetVal);
        }

        #endregion
        #region Remove

        /// <summary>
        /// Retrieves a flag that indicates whether the section is removed before it is made part of the in-memory image.
        /// </summary>
        public bool Remove
        {
            get
            {
                bool pRetVal;
                TryGetRemove(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section is removed before it is made part of the in-memory image.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section is not to be added to the in-memory image; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetRemove(out bool pRetVal)
        {
            /*HRESULT get_remove(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_remove(out pRetVal);
        }

        #endregion
        #region Comdat

        /// <summary>
        /// Retrieves a flag that indicates whether the section is a COMDAT record.
        /// </summary>
        public bool Comdat
        {
            get
            {
                bool pRetVal;
                TryGetComdat(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section is a COMDAT record.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section is a COMDAT record; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// A COMDAT record is a Common Object File Format (COFF) record that makes packaged functions visible to the linker.
        /// </remarks>
        public HRESULT TryGetComdat(out bool pRetVal)
        {
            /*HRESULT get_comdat(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_comdat(out pRetVal);
        }

        #endregion
        #region Discardable

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be discarded.
        /// </summary>
        public bool Discardable
        {
            get
            {
                bool pRetVal;
                TryGetDiscardable(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be discarded.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section can be discarded from memory as needed; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetDiscardable(out bool pRetVal)
        {
            /*HRESULT get_discardable(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_discardable(out pRetVal);
        }

        #endregion
        #region NotCached

        /// <summary>
        /// Retrieves a flag that indicates whether the section cannot be cached.
        /// </summary>
        public bool NotCached
        {
            get
            {
                bool pRetVal;
                TryGetNotCached(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section cannot be cached.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section cannot be cached; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetNotCached(out bool pRetVal)
        {
            /*HRESULT get_notCached(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_notCached(out pRetVal);
        }

        #endregion
        #region Share

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be shared in memory.
        /// </summary>
        public bool Share
        {
            get
            {
                bool pRetVal;
                TryGetShare(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be shared in memory.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section is shareable in memory; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetShare(out bool pRetVal)
        {
            /*HRESULT get_share(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_share(out pRetVal);
        }

        #endregion
        #region Execute

        /// <summary>
        /// Retrieves a flag that indicates whether the section is executable as code.
        /// </summary>
        public bool Execute
        {
            get
            {
                bool pRetVal;
                TryGetExecute(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section is executable as code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section can be executed as code; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetExecute(out bool pRetVal)
        {
            /*HRESULT get_execute(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_execute(out pRetVal);
        }

        #endregion
        #region Read

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be read.
        /// </summary>
        public bool Read
        {
            get
            {
                bool pRetVal;
                TryGetRead(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be read.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section can be read; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetRead(out bool pRetVal)
        {
            /*HRESULT get_read(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_read(out pRetVal);
        }

        #endregion
        #region Write

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be modified.
        /// </summary>
        public bool Write
        {
            get
            {
                bool pRetVal;
                TryGetWrite(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section can be modified.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the section can be written to; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetWrite(out bool pRetVal)
        {
            /*HRESULT get_write(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_write(out pRetVal);
        }

        #endregion
        #region DataCrc

        /// <summary>
        /// Retrieves the cyclic redundancy check (CRC) of the data in the section.
        /// </summary>
        public int DataCrc
        {
            get
            {
                int pRetVal;
                TryGetDataCrc(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the cyclic redundancy check (CRC) of the data in the section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the CRC of the data in the section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetDataCrc(out int pRetVal)
        {
            /*HRESULT get_dataCrc(
            [Out] out int pRetVal);*/
            return Raw.get_dataCrc(out pRetVal);
        }

        #endregion
        #region RelocationsCrc

        /// <summary>
        /// Retrieves the cyclic redundancy check (CRC) of the relocation information for the section.
        /// </summary>
        public int RelocationsCrc
        {
            get
            {
                int pRetVal;
                TryGetRelocationsCrc(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the cyclic redundancy check (CRC) of the relocation information for the section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the CRC of the relocation information for the section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetRelocationsCrc(out int pRetVal)
        {
            /*HRESULT get_relocationsCrc(
            [Out] out int pRetVal);*/
            return Raw.get_relocationsCrc(out pRetVal);
        }

        #endregion
        #region CompilandId

        /// <summary>
        /// Retrieves the compiland identifier for the section.
        /// </summary>
        public int CompilandId
        {
            get
            {
                int pRetVal;
                TryGetCompilandId(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the compiland identifier for the section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the compiland identifier for the section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetCompilandId(out int pRetVal)
        {
            /*HRESULT get_compilandId(
            [Out] out int pRetVal);*/
            return Raw.get_compilandId(out pRetVal);
        }

        #endregion
        #region Code16bit

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains 16-bit code.
        /// </summary>
        public bool Code16bit
        {
            get
            {
                bool pRetVal;
                TryGetCode16bit(out pRetVal).ThrowOnFailed();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves a flag that indicates whether the section contains 16-bit code.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the code in the section is 16-bit; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// This method only indicates if the code is 16-bit. If the code is not 16-bit, it could be anything else, such as
        /// 32-bit or 64-bit code.
        /// </remarks>
        public HRESULT TryGetCode16bit(out bool pRetVal)
        {
            /*HRESULT get_code16bit(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_code16bit(out pRetVal);
        }

        #endregion
        #endregion
    }
}
