namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator which enumerates an available set of script templates. An enumerator interface that the script provider implements in order to advertise all the various templates it supports.
    /// </summary>
    public class DataModelScriptTemplateEnumerator : ComObject<IDataModelScriptTemplateEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptTemplateEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptTemplateEnumerator(IDataModelScriptTemplateEnumerator raw) : base(raw)
        {
        }

        #region IDataModelScriptTemplateEnumerator
        #region Next

        /// <summary>
        /// The GetNext method moves the enumerator to the next template and returns it. At the end of enumeration, the enumerator returns E_BOUNDS.<para/>
        /// Once the E_BOUNDS marker has been hit, the enumerator will continue to produce E_BOUNDS errors indefinitely until a Reset call is made.
        /// </summary>
        public DataModelScriptTemplate Next
        {
            get
            {
                DataModelScriptTemplate templateContentResult;
                TryGetNext(out templateContentResult).ThrowDbgEngNotOK();

                return templateContentResult;
            }
        }

        /// <summary>
        /// The GetNext method moves the enumerator to the next template and returns it. At the end of enumeration, the enumerator returns E_BOUNDS.<para/>
        /// Once the E_BOUNDS marker has been hit, the enumerator will continue to produce E_BOUNDS errors indefinitely until a Reset call is made.
        /// </summary>
        /// <param name="templateContentResult">The next template in enumeration order is returned here as a component implementing the <see cref="IDataModelScriptTemplate"/> interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetNext(out DataModelScriptTemplate templateContentResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptTemplate templateContent);*/
            IDataModelScriptTemplate templateContent;
            HRESULT hr = Raw.GetNext(out templateContent);

            if (hr == HRESULT.S_OK)
                templateContentResult = templateContent == null ? null : new DataModelScriptTemplate(templateContent);
            else
                templateContentResult = default(DataModelScriptTemplate);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// The Reset method resets the enumerator to the position it was at when it was first created -- before the first template produced.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The Reset method resets the enumerator to the position it was at when it was first created -- before the first template produced.
        /// </summary>
        /// <returns>This method returns HRESULT.</returns>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
