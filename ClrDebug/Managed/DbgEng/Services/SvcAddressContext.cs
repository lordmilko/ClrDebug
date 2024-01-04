namespace ClrDebug.DbgEng
{
    public class SvcAddressContext : ComObject<ISvcAddressContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcAddressContext"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcAddressContext(ISvcAddressContext raw) : base(raw)
        {
        }

        #region ISvcAddressContext
        #region AddressContextKind

        public AddressContextKind AddressContextKind
        {
            get
            {
                /*AddressContextKind GetAddressContextKind();*/
                return Raw.GetAddressContextKind();
            }
        }

        #endregion
        #endregion
    }
}
