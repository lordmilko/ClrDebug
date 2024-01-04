namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface which enumerates the raw children (e.g.: base classes, fields, etc...) of an object (and their values and associated metadata).<para/>
    /// A raw enumerator can be acquired through the EnumerateRawValues or EnumerateRawReferences methods on <see cref="IModelObject"/>.
    /// </summary>
    public class RawEnumerator : ComObject<IRawEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RawEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public RawEnumerator(IRawEnumerator raw) : base(raw)
        {
        }

        #region IRawEnumerator
        #region Next

        /// <summary>
        /// Moves the iterator forward and fetches the name of the raw element and, optionally, its value (or a reference to it) and what kind of element it is.<para/>
        /// Note that depending on how this enumerator was acquired, the object returned in the value field may be the value of the raw element (EnumerateRawValues) or a reference to the raw element (EnumerateRawReferences).<para/>
        /// If there was an error in reading the value of the raw element (for EnumerateRawValues, for instance), the method may return an error AND fill value with an error object.<para/>
        /// When the enumerator hits the end of the sequence, E_BOUNDS will be returned.
        /// </summary>
        public RawEnumerator_GetNextResult Next
        {
            get
            {
                RawEnumerator_GetNextResult result;
                TryGetNext(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Moves the iterator forward and fetches the name of the raw element and, optionally, its value (or a reference to it) and what kind of element it is.<para/>
        /// Note that depending on how this enumerator was acquired, the object returned in the value field may be the value of the raw element (EnumerateRawValues) or a reference to the raw element (EnumerateRawReferences).<para/>
        /// If there was an error in reading the value of the raw element (for EnumerateRawValues, for instance), the method may return an error AND fill value with an error object.<para/>
        /// When the enumerator hits the end of the sequence, E_BOUNDS will be returned.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT.</returns>
        public HRESULT TryGetNext(out RawEnumerator_GetNextResult result)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name,
            [Out] out SymbolKind kind,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject value);*/
            string name;
            SymbolKind kind;
            IModelObject value;
            HRESULT hr = Raw.GetNext(out name, out kind, out value);

            if (hr == HRESULT.S_OK)
                result = new RawEnumerator_GetNextResult(name, kind, value == null ? null : new ModelObject(value));
            else
                result = default(RawEnumerator_GetNextResult);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// Resets the enumerator to its initial state. A subsequent GetNext call will return the first raw element (native field, base class, etc...) in enumerator order.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Resets the enumerator to its initial state. A subsequent GetNext call will return the first raw element (native field, base class, etc...) in enumerator order.
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
