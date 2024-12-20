namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This interface represents an address context. From many user's perspective, this is a largely opaque construct which is passed from place to place.<para/>
    /// An object which implements this interface can be several different types of address context (as indicated by AddressContextKind above).<para/>
    /// The object will either QI for ISvcProcess of ISvcAddressContextHardware ISvcExecutionUnitHardware.
    /// </summary>
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

        /// <summary>
        /// Gets the kind of address context.
        /// </summary>
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
