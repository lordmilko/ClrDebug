namespace ClrDebug.DbgEng
{
    public class SvcDescription : ComObject<ISvcDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcDescription"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcDescription(ISvcDescription raw) : base(raw)
        {
        }

        #region ISvcDescription
        #region Description

        public string Description
        {
            get
            {
                string objectDescription;
                TryGetDescription(out objectDescription).ThrowDbgEngNotOK();

                return objectDescription;
            }
        }

        public HRESULT TryGetDescription(out string objectDescription)
        {
            /*HRESULT GetDescription(
            [Out, MarshalAs(UnmanagedType.BStr)] out string objectDescription);*/
            return Raw.GetDescription(out objectDescription);
        }

        #endregion
        #endregion
    }
}
