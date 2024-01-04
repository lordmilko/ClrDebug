namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An (<see cref="IDebugHostSymbol"/> derived) interface to a public symbol (address/name only). Represents a symbol within the publics table of a PDB.<para/>
    /// This does not have type information associated with it. It is a name and address.
    /// </summary>
    public class DebugHostPublic : DebugHostSymbol
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostPublic"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostPublic(IDebugHostPublic raw) : base(raw)
        {
        }

        #region IDebugHostPublic

        public new IDebugHostPublic Raw => (IDebugHostPublic) base.Raw;

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
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetLocationKind(out LocationKind locationKind)
        {
            /*HRESULT GetLocationKind(
            [Out] out LocationKind locationKind);*/
            return Raw.GetLocationKind(out locationKind);
        }

        #endregion
        #region Location

        /// <summary>
        /// For data which has an address, the GetLocation method will return the abstract location (address) of the field.<para/>
        /// If the given public does not have a static location, the GetLocation method will fail.
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
        /// For data which has an address, the GetLocation method will return the abstract location (address) of the field.<para/>
        /// If the given public does not have a static location, the GetLocation method will fail.
        /// </summary>
        /// <param name="location">The abstract location (e.g.: address) of the data will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetLocation(out Location location)
        {
            /*HRESULT GetLocation(
            [Out] out Location location);*/
            return Raw.GetLocation(out location);
        }

        #endregion
        #endregion
    }
}
