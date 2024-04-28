namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Interface which clients must implement on any object which is convertible to a display string. Clients should not rely on the form of this string conversion for programmatic purposes.<para/>
    /// It is intended for display purposes only.
    /// </summary>
    public class StringDisplayableConcept : ComObject<IStringDisplayableConcept>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringDisplayableConcept"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public StringDisplayableConcept(IStringDisplayableConcept raw) : base(raw)
        {
        }

        #region IStringDisplayableConcept
        #region ToDisplayString

        /// <summary>
        /// The ToDisplayString method is called whenever a client wishes to convert an object into a string to display (to console, in the UI, etc...).<para/>
        /// Such a string conversion should not be used for the basis of additional programmatic manipulation. The string conversion itself may be deeply influenced by the metadata passed to the call.<para/>
        /// A string conversion should make every attempt to honor the PreferredRadix and PreferredFormat keys.
        /// </summary>
        /// <param name="contextObject">The instance (this pointer) being converted to a display string is passed in this argument.</param>
        /// <param name="metadata">An optional metadata store which defines how the caller would like the string to be converted. The implementation should make every attempt to honor the requests in the store (in particular, the PreferredRadix and PreferredFormat keys).</param>
        /// <returns>The string conversion as allocated by the SysAllocString function will be returned here.</returns>
        public string ToDisplayString(IModelObject contextObject, IKeyStore metadata)
        {
            string displayString;
            TryToDisplayString(contextObject, metadata, out displayString).ThrowDbgEngNotOK();

            return displayString;
        }

        /// <summary>
        /// The ToDisplayString method is called whenever a client wishes to convert an object into a string to display (to console, in the UI, etc...).<para/>
        /// Such a string conversion should not be used for the basis of additional programmatic manipulation. The string conversion itself may be deeply influenced by the metadata passed to the call.<para/>
        /// A string conversion should make every attempt to honor the PreferredRadix and PreferredFormat keys.
        /// </summary>
        /// <param name="contextObject">The instance (this pointer) being converted to a display string is passed in this argument.</param>
        /// <param name="metadata">An optional metadata store which defines how the caller would like the string to be converted. The implementation should make every attempt to honor the requests in the store (in particular, the PreferredRadix and PreferredFormat keys).</param>
        /// <param name="displayString">The string conversion as allocated by the SysAllocString function will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryToDisplayString(IModelObject contextObject, IKeyStore metadata, out string displayString)
        {
            /*HRESULT ToDisplayString(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata,
            [Out, MarshalAs(UnmanagedType.BStr)] out string displayString);*/
            return Raw.ToDisplayString(contextObject, metadata, out displayString);
        }

        #endregion
        #endregion
    }
}
