namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Indicates information about a file or image and how it was mapped into memory. An implemtnation of ISvcModule can optionally support this interface to indicate how the image was placed into memory.<para/>
    /// If this interface is *NOT* implemented on an ISvcModule, callers should assume that the module is a standard load (e.g.: SvcMappingLoaded).
    /// </summary>
    public class SvcMappingInformation : ComObject<ISvcMappingInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcMappingInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcMappingInformation(ISvcMappingInformation raw) : base(raw)
        {
        }

        #region ISvcMappingInformation
        #region MappingForm

        /// <summary>
        /// Gets the manner in which the object QI'd for this interface is mapped into memory.
        /// </summary>
        public SvcMappingForm MappingForm
        {
            get
            {
                /*SvcMappingForm GetMappingForm();*/
                return Raw.GetMappingForm();
            }
        }

        #endregion
        #endregion
    }
}
