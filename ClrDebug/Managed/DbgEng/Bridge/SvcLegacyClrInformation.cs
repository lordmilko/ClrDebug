namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Private bridge interface to inquire about existing CLR capability.
    /// </summary>
    public class SvcLegacyClrInformation : ComObject<ISvcLegacyClrInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcLegacyClrInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcLegacyClrInformation(ISvcLegacyClrInformation raw) : base(raw)
        {
        }

        #region ISvcLegacyClrInformation
        #region SupportsManagedStackUnwind

        /// <summary>
        /// Indicates whether or not there is specific unwinder support for managed stack unwinds.
        /// </summary>
        public bool SupportsManagedStackUnwind()
        {
            /*bool SupportsManagedStackUnwind();*/
            return Raw.SupportsManagedStackUnwind();
        }

        #endregion
        #endregion
    }
}
