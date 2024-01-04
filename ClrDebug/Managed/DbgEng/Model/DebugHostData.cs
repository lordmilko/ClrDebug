namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An (<see cref="IDebugHostSymbol"/> derived) interface to data. Represents data within a module (were this within a structure or class it would be an <see cref="IDebugHostField"/>).
    /// </summary>
    public class DebugHostData : DebugHostSymbol
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostData"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostData(IDebugHostData raw) : base(raw)
        {
        }

        #region IDebugHostData

        public new IDebugHostData Raw => (IDebugHostData) base.Raw;

        #region LocationKind

        /// <summary>
        /// The GetLocationKind method returns what kind of location the symbol is at according to the LocationKind enumeration.<para/>
        /// The description of this enumeration can be found in the documentation for <see cref="IDebugHostField"/>.
        /// </summary>
        public LocationKind LocationKind
        {
            get
            {
                LocationKind locationKind;
                TryGetLocationKind(out locationKind).ThrowDbgEngNotOK();

                return locationKind;
            }
        }

        /// <summary>
        /// The GetLocationKind method returns what kind of location the symbol is at according to the LocationKind enumeration.<para/>
        /// The description of this enumeration can be found in the documentation for <see cref="IDebugHostField"/>.
        /// </summary>
        /// <param name="locationKind">The kind of location for this field will be returned here as a value of the LocationKind enumeration.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetLocationKind(out LocationKind locationKind)
        {
            /*HRESULT GetLocationKind(
            [Out] out LocationKind locationKind);*/
            return Raw.GetLocationKind(out locationKind);
        }

        #endregion
        #region Location

        /// <summary>
        /// For data which has an address, the GetLocation method will return the abstract location (address) of the field.If the given data does not have a static location, the GetLocation method will fail.
        /// </summary>
        public Location Location
        {
            get
            {
                Location location;
                TryGetLocation(out location).ThrowDbgEngNotOK();

                return location;
            }
        }

        /// <summary>
        /// For data which has an address, the GetLocation method will return the abstract location (address) of the field.If the given data does not have a static location, the GetLocation method will fail.
        /// </summary>
        /// <param name="location">The abstract location (e.g.: address) of the data will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetLocation(out Location location)
        {
            /*HRESULT GetLocation(
            [Out] out Location location);*/
            return Raw.GetLocation(out location);
        }

        #endregion
        #region Value

        /// <summary>
        /// Returns the value of the constant in a VARIANT data structure.
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
        /// Returns the value of the constant in a VARIANT data structure.
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
