namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a constant within symbolic information (e.g.: a non-type template argument in C++).
    /// </summary>
    public class DebugHostConstant : DebugHostSymbol
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostConstant"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostConstant(IDebugHostConstant raw) : base(raw)
        {
        }

        #region IDebugHostConstant

        public new IDebugHostConstant Raw => (IDebugHostConstant) base.Raw;

        #region Value

        /// <summary>
        /// The GetValue method returns the value of the constant packed into a VARIANT. It is important to note that the GetType method on <see cref="IDebugHostSymbol"/> may return a specific type symbol for the constant.<para/>
        /// In such cases, there is no guarantee that the packing of the constant value as defined by the type symbol is the same as the packing as returned by the GetValue method here.
        /// </summary>
        public object Value
        {
            get
            {
                object value;
                TryGetValue(out value).ThrowDbgEngNotOK();

                return value;
            }
        }

        /// <summary>
        /// The GetValue method returns the value of the constant packed into a VARIANT. It is important to note that the GetType method on <see cref="IDebugHostSymbol"/> may return a specific type symbol for the constant.<para/>
        /// In such cases, there is no guarantee that the packing of the constant value as defined by the type symbol is the same as the packing as returned by the GetValue method here.
        /// </summary>
        /// <param name="value">The value of the data packed into a VARIANT will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetValue(out object value)
        {
            /*HRESULT GetValue(
            [Out, MarshalAs(UnmanagedType.Struct)] out object value);*/
            return Raw.GetValue(out value);
        }

        #endregion
        #endregion
    }
}
