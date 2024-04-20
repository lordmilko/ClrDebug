namespace ClrDebug.DIA
{
    /// <summary>
    /// Maps data from the section number to segments of address space.
    /// </summary>
    /// <remarks>
    /// Because the DIA SDK already performs translations from the section offset to relative virtual addresses, most applications
    /// will not make use of the information in the segment map. Obtain this interface by calling the <see cref="DiaEnumSegments.Item"/>
    /// or <see cref="DiaEnumSegments.MoveNext"/> methods. See the example for details.
    /// </remarks>
    public class DiaSegment : ComObject<IDiaSegment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaSegment"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaSegment(IDiaSegment raw) : base(raw)
        {
        }

        #region IDiaSegment
        #region Frame

        /// <summary>
        /// Retrieves the segment number.
        /// </summary>
        public int Frame
        {
            get
            {
                int pRetVal;
                TryGetFrame(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the segment number.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the segment number.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetFrame(out int pRetVal)
        {
            /*HRESULT get_frame(
            [Out] out int pRetVal);*/
            return Raw.get_frame(out pRetVal);
        }

        #endregion
        #region Offset

        /// <summary>
        /// Retrieves the offset, in segments, where the section begins.
        /// </summary>
        public int Offset
        {
            get
            {
                int pRetVal;
                TryGetOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the offset, in segments, where the section begins.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the offset, in segments, where the section begins.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetOffset(out int pRetVal)
        {
            /*HRESULT get_offset(
            [Out] out int pRetVal);*/
            return Raw.get_offset(out pRetVal);
        }

        #endregion
        #region Length

        /// <summary>
        /// Retrieves the number of bytes in the segment.
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
        /// Retrieves the number of bytes in the segment.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of bytes in the segment.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetLength(out int pRetVal)
        {
            /*HRESULT get_length(
            [Out] out int pRetVal);*/
            return Raw.get_length(out pRetVal);
        }

        #endregion
        #region Read

        /// <summary>
        /// Retrieves a flag that indicates whether the segment can be read.
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
        /// Retrieves a flag that indicates whether the segment can be read.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the segment can be read; otherwise, returns FALSE.</param>
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
        /// Retrieves a flag that indicates whether the segment can be modified.
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
        /// Retrieves a flag that indicates whether the segment can be modified.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the segment can be written to; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetWrite(out bool pRetVal)
        {
            /*HRESULT get_write(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_write(out pRetVal);
        }

        #endregion
        #region Execute

        /// <summary>
        /// Retrieves a flag that indicates whether the segment is executable.
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
        /// Retrieves a flag that indicates whether the segment is executable.
        /// </summary>
        /// <param name="pRetVal">[out] Returns TRUE if the segment is marked as executable; otherwise, returns FALSE.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetExecute(out bool pRetVal)
        {
            /*HRESULT get_execute(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.get_execute(out pRetVal);
        }

        #endregion
        #region AddressSection

        /// <summary>
        /// Retrieves the section number that maps to this segment.
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
        /// Retrieves the section number that maps to this segment.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the section number that maps to this segment.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetAddressSection(out int pRetVal)
        {
            /*HRESULT get_addressSection(
            [Out] out int pRetVal);*/
            return Raw.get_addressSection(out pRetVal);
        }

        #endregion
        #region RelativeVirtualAddress

        /// <summary>
        /// Retrieves the relative virtual address (RVA) of the beginning of the section.
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
        /// Retrieves the relative virtual address (RVA) of the beginning of the section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the RVA of the beginning of the section.</param>
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
        /// Retrieves the virtual address (VA) of the beginning of the section.
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
        /// Retrieves the virtual address (VA) of the beginning of the section.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the VA of the beginning of the section.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if this property is not supported. Otherwise, returns an error code.</returns>
        public HRESULT TryGetVirtualAddress(out long pRetVal)
        {
            /*HRESULT get_virtualAddress(
            [Out] out long pRetVal);*/
            return Raw.get_virtualAddress(out pRetVal);
        }

        #endregion
        #endregion
    }
}
