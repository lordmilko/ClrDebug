namespace ClrDebug.DbgEng
{
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

        public string Name
        {
            get
            {
                string registerName;
                TryGetName(out registerName).ThrowDbgEngNotOK();

                return registerName;
            }
        }

        public HRESULT TryGetName(out string registerName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string registerName);*/
            return Raw.GetName(out registerName);
        }

        #endregion
        #region Id

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

        public GetSubRegisterInformationResult SubRegisterInformation
        {
            get
            {
                GetSubRegisterInformationResult result;
                TryGetSubRegisterInformation(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

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

        public SvcRegisterFlagsEnumerator EnumerateRegisterFlags()
        {
            SvcRegisterFlagsEnumerator flagsEnumResult;
            TryEnumerateRegisterFlags(out flagsEnumResult).ThrowDbgEngNotOK();

            return flagsEnumResult;
        }

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

        public SvcRegisterFlagInformation GetRegisterFlagInformation(int position)
        {
            SvcRegisterFlagInformation flagInfoResult;
            TryGetRegisterFlagInformation(position, out flagInfoResult).ThrowDbgEngNotOK();

            return flagInfoResult;
        }

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
