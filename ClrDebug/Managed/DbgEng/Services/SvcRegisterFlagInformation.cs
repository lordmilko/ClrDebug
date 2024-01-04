namespace ClrDebug.DbgEng
{
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

        public string Name
        {
            get
            {
                string flagName;
                TryGetName(out flagName).ThrowDbgEngNotOK();

                return flagName;
            }
        }

        public HRESULT TryGetName(out string flagName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string flagName);*/
            return Raw.GetName(out flagName);
        }

        #endregion
        #region Abbreviation

        public string Abbreviation
        {
            get
            {
                string abbrevName;
                TryGetAbbreviation(out abbrevName).ThrowDbgEngNotOK();

                return abbrevName;
            }
        }

        public HRESULT TryGetAbbreviation(out string abbrevName)
        {
            /*HRESULT GetAbbreviation(
            [Out, MarshalAs(UnmanagedType.BStr)] out string abbrevName);*/
            return Raw.GetAbbreviation(out abbrevName);
        }

        #endregion
        #region Position

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
