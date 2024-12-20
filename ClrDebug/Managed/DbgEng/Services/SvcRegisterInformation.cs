namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcRegisterInformation interface describes details about a particular machine register.
    /// </summary>
    public class SvcRegisterInformation : ComObject<ISvcRegisterInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcRegisterInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcRegisterInformation(ISvcRegisterInformation raw) : base(raw)
        {
        }

        #region ISvcRegisterInformation
        #region Name

        /// <summary>
        /// Gets the name of the register.
        /// </summary>
        public string Name
        {
            get
            {
                string registerName;
                TryGetName(out registerName).ThrowDbgEngNotOK();

                return registerName;
            }
        }

        /// <summary>
        /// Gets the name of the register.
        /// </summary>
        public HRESULT TryGetName(out string registerName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string registerName);*/
            return Raw.GetName(out registerName);
        }

        #endregion
        #region Id

        /// <summary>
        /// Gets the ID of this register. This is the canonical register number for the architecture. If the architecture is a custom architecture, this ID can be custom.<para/>
        /// The *default behavior* of a symbol provider without explicit knowledge of a given architecture is to directly map register numbers in debug information to the register ID returned here.<para/>
        /// The DWARF symbol provider, for instance, will directly map a register number N in DWARF debug information to the register in the context whose GetId returns N unless it has explicit knowledge about the architecture and/or ABI being targeted.<para/>
        /// Providing a custom mapping to particular formats requres implementing interfaces beyond ISvcMachineArchitecture.<para/>
        /// It requires supporting a DEBUG_SERVICE_REGISTERTRANSLATION conditional service whose primary condition is the architecture GUID and whose secondary condition is a GUID describing the debug format.
        /// </summary>
        public int Id
        {
            get
            {
                /*int GetId();*/
                return Raw.GetId();
            }
        }

        #endregion
        #region Flags

        /// <summary>
        /// Gets the set of flags describing the category, etc... of this register.
        /// </summary>
        public SvcContextFlags Flags
        {
            get
            {
                /*SvcContextFlags GetFlags();*/
                return Raw.GetFlags();
            }
        }

        #endregion
        #region Size

        /// <summary>
        /// Gets the size of this register.
        /// </summary>
        public int Size
        {
            get
            {
                /*int GetSize();*/
                return Raw.GetSize();
            }
        }

        #endregion
        #region SubRegisterInformation

        /// <summary>
        /// ; Gets the sub-register mapping for this register. This will fail with E_NOT_SET if the register is NOT part of another register; otherwise, the parent register and the least/most significant bits of the mapping are returned.<para/>
        /// For instance, 'ah' would return a parent id of 'ax' and bits 0-7. Likewise, 'ax' would return 'eax' as a parent id and bits 0-15.
        /// </summary>
        public GetSubRegisterInformationResult SubRegisterInformation
        {
            get
            {
                GetSubRegisterInformationResult result;
                TryGetSubRegisterInformation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// ; Gets the sub-register mapping for this register. This will fail with E_NOT_SET if the register is NOT part of another register; otherwise, the parent register and the least/most significant bits of the mapping are returned.<para/>
        /// For instance, 'ah' would return a parent id of 'ax' and bits 0-7. Likewise, 'ax' would return 'eax' as a parent id and bits 0-15.
        /// </summary>
        public HRESULT TryGetSubRegisterInformation(out GetSubRegisterInformationResult result)
        {
            /*HRESULT GetSubRegisterInformation(
            [Out] out int parentRegisterId,
            [Out] out int lsbOfMapping,
            [Out] out int msbOfMapping);*/
            int parentRegisterId;
            int lsbOfMapping;
            int msbOfMapping;
            HRESULT hr = Raw.GetSubRegisterInformation(out parentRegisterId, out lsbOfMapping, out msbOfMapping);

            if (hr == HRESULT.S_OK)
                result = new GetSubRegisterInformationResult(parentRegisterId, lsbOfMapping, msbOfMapping);
            else
                result = default(GetSubRegisterInformationResult);

            return hr;
        }

        #endregion
        #region EnumerateRegisterFlags

        /// <summary>
        /// Enumerates all of the control flags within the register. This will fail with E_NOT_SET if the register is NOT a flags register.
        /// </summary>
        public SvcRegisterFlagsEnumerator EnumerateRegisterFlags()
        {
            SvcRegisterFlagsEnumerator flagsEnumResult;
            TryEnumerateRegisterFlags(out flagsEnumResult).ThrowDbgEngNotOK();

            return flagsEnumResult;
        }

        /// <summary>
        /// Enumerates all of the control flags within the register. This will fail with E_NOT_SET if the register is NOT a flags register.
        /// </summary>
        public HRESULT TryEnumerateRegisterFlags(out SvcRegisterFlagsEnumerator flagsEnumResult)
        {
            /*HRESULT EnumerateRegisterFlags(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterFlagsEnumerator flagsEnum);*/
            ISvcRegisterFlagsEnumerator flagsEnum;
            HRESULT hr = Raw.EnumerateRegisterFlags(out flagsEnum);

            if (hr == HRESULT.S_OK)
                flagsEnumResult = flagsEnum == null ? null : new SvcRegisterFlagsEnumerator(flagsEnum);
            else
                flagsEnumResult = default(SvcRegisterFlagsEnumerator);

            return hr;
        }

        #endregion
        #region GetRegisterFlagInformation

        /// <summary>
        /// Gets the flag information for a particular bit of a flags register. This will fail with E_NOT_SET if the register is NOT a flags register.<para/>
        /// This will fail with E_BOUNDS if the bit position within the register is not a valid flag bit.
        /// </summary>
        public SvcRegisterFlagInformation GetRegisterFlagInformation(int position)
        {
            SvcRegisterFlagInformation flagInfoResult;
            TryGetRegisterFlagInformation(position, out flagInfoResult).ThrowDbgEngNotOK();

            return flagInfoResult;
        }

        /// <summary>
        /// Gets the flag information for a particular bit of a flags register. This will fail with E_NOT_SET if the register is NOT a flags register.<para/>
        /// This will fail with E_BOUNDS if the bit position within the register is not a valid flag bit.
        /// </summary>
        public HRESULT TryGetRegisterFlagInformation(int position, out SvcRegisterFlagInformation flagInfoResult)
        {
            /*HRESULT GetRegisterFlagInformation(
            [In] int position,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterFlagInformation flagInfo);*/
            ISvcRegisterFlagInformation flagInfo;
            HRESULT hr = Raw.GetRegisterFlagInformation(position, out flagInfo);

            if (hr == HRESULT.S_OK)
                flagInfoResult = flagInfo == null ? null : new SvcRegisterFlagInformation(flagInfo);
            else
                flagInfoResult = default(SvcRegisterFlagInformation);

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
            return Name;
        }
    }
}
