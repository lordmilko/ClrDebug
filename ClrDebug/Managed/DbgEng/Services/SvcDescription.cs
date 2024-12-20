namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: Various objects returned from services (processes, threads, symbol sets, etc...).
    /// </summary>
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

        /// <summary>
        /// Gets a description of the object on which the interface exists. This is intended for short textual display in some UI element.
        /// </summary>
        public string Description
        {
            get
            {
                string objectDescription;
                TryGetDescription(out objectDescription).ThrowDbgEngNotOK();

                return objectDescription;
            }
        }

        /// <summary>
        /// Gets a description of the object on which the interface exists. This is intended for short textual display in some UI element.
        /// </summary>
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
