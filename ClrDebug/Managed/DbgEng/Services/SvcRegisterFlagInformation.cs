namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The ISvcRegisterFlagInformation interface describes details about a particular control/status flag within a register (e.g.: the zero flag, the carry flag, etc...).
    /// </summary>
    public class SvcRegisterFlagInformation : ComObject<ISvcRegisterFlagInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcRegisterFlagInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcRegisterFlagInformation(ISvcRegisterFlagInformation raw) : base(raw)
        {
        }

        #region ISvcRegisterFlagInformation
        #region Name

        /// <summary>
        /// Gets the name of the flag (e.g.: carry, overflow, etc...).
        /// </summary>
        public string Name
        {
            get
            {
                string flagName;
                TryGetName(out flagName).ThrowDbgEngNotOK();

                return flagName;
            }
        }

        /// <summary>
        /// Gets the name of the flag (e.g.: carry, overflow, etc...).
        /// </summary>
        public HRESULT TryGetName(out string flagName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string flagName);*/
            return Raw.GetName(out flagName);
        }

        #endregion
        #region Abbreviation

        /// <summary>
        /// Gets a short abbreviation of the flag (e.g.: cf, zf, of, etc...).
        /// </summary>
        public string Abbreviation
        {
            get
            {
                string abbrevName;
                TryGetAbbreviation(out abbrevName).ThrowDbgEngNotOK();

                return abbrevName;
            }
        }

        /// <summary>
        /// Gets a short abbreviation of the flag (e.g.: cf, zf, of, etc...).
        /// </summary>
        public HRESULT TryGetAbbreviation(out string abbrevName)
        {
            /*HRESULT GetAbbreviation(
            [Out, MarshalAs(UnmanagedType.BStr)] out string abbrevName);*/
            return Raw.GetAbbreviation(out abbrevName);
        }

        #endregion
        #region Position

        /// <summary>
        /// Gets the bit position of this flag within its containing register.
        /// </summary>
        public int Position
        {
            get
            {
                /*int GetPosition();*/
                return Raw.GetPosition();
            }
        }

        #endregion
        #region Size

        /// <summary>
        /// Gets the size of the flag information. Typically, this would be one bit. If this is not one, the flag is assumed to go from [ GetPosition(lsb), 'GetPosition + GetSize'(msb) ).
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
