namespace ClrDebug.DbgEng
{
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
