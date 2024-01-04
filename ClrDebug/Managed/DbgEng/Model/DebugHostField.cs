using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a field within a structure or class.
    /// </summary>
    public class DebugHostField : DebugHostSymbol
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostField"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostField(IDebugHostField raw) : base(raw)
        {
        }

        #region IDebugHostField

        public new IDebugHostField Raw => (IDebugHostField) base.Raw;

        #region LocationKind

        /// <summary>
        /// The GetLocationKind method returns what kind of location the symbol is at according to the LocationKind enumeration.<para/>
        /// Such enumeration can be one of the following values:
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
        /// Such enumeration can be one of the following values:
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
        #region Offset

        /// <summary>
        /// For fields which have an offset (e.g. fields whose location kind indicates LocationMember), the GetOffset method will return the offset from the base address of the containing type (the this pointer) to the data for the field itself.<para/>
        /// Such offsets are always expressed as unsigned 64-bit values. If the given field does not have a location which is an offset from the base address of the containing type, the GetOffset method will fail.
        /// </summary>
        public long Offset
        {
            get
            {
                long offset;
                TryGetOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        /// <summary>
        /// For fields which have an offset (e.g. fields whose location kind indicates LocationMember), the GetOffset method will return the offset from the base address of the containing type (the this pointer) to the data for the field itself.<para/>
        /// Such offsets are always expressed as unsigned 64-bit values. If the given field does not have a location which is an offset from the base address of the containing type, the GetOffset method will fail.
        /// </summary>
        /// <param name="offset">The offset of the field data from the base address of the containing type (e.g.: the this pointer) will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetOffset(out long offset)
        {
            /*HRESULT GetOffset(
            [Out] out long offset);*/
            return Raw.GetOffset(out offset);
        }

        #endregion
        #region Location

        /// <summary>
        /// For fields which have an address regardless of the particular type instance (e.g. fields whose location kind indicates LocationStatic), the GetLocation method will return the abstract location (address) of the field.<para/>
        /// If the given field does not have a static location, the GetLocation method will fail.
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
        /// For fields which have an address regardless of the particular type instance (e.g. fields whose location kind indicates LocationStatic), the GetLocation method will return the abstract location (address) of the field.<para/>
        /// If the given field does not have a static location, the GetLocation method will fail.
        /// </summary>
        /// <param name="location">The abstract location (e.g.: address) of the field will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        /// <remarks>
        /// Sample Code*
        /// </remarks>
        public HRESULT TryGetLocation(out Location location)
        {
            /*HRESULT GetLocation(
            [Out] out Location location);*/
            return Raw.GetLocation(out location);
        }

        #endregion
        #region Value

        /// <summary>
        /// For fields which have a constant value defined within the symbolic information (e.g.: fields whose location kind indicates LocationConstant), the GetValue method will return the constant value of the field.<para/>
        /// If the given field does not have a constant value, the GetValue method will fail.
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
        /// For fields which have a constant value defined within the symbolic information (e.g.: fields whose location kind indicates LocationConstant), the GetValue method will return the constant value of the field.<para/>
        /// If the given field does not have a constant value, the GetValue method will fail.
        /// </summary>
        /// <param name="value">The value of the field packed into a VARIANT will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetValue(out object value)
        {
            /*HRESULT GetValue(
            [Out, MarshalAs(UnmanagedType.Struct)] out object value);*/
            return Raw.GetValue(out value);
        }

        #endregion
        #endregion
        #region IDebugHostField2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public new IDebugHostField2 Raw2 => (IDebugHostField2) Raw;

        #region ContainingType

        public DebugHostType ContainingType
        {
            get
            {
                DebugHostType containingParentTypeResult;
                TryGetContainingType(out containingParentTypeResult).ThrowDbgEngNotOK();

                return containingParentTypeResult;
            }
        }

        public HRESULT TryGetContainingType(out DebugHostType containingParentTypeResult)
        {
            /*HRESULT GetContainingType(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType3 containingParentType);*/
            IDebugHostType3 containingParentType;
            HRESULT hr = Raw2.GetContainingType(out containingParentType);

            if (hr == HRESULT.S_OK)
                containingParentTypeResult = containingParentType == null ? null : new DebugHostType(containingParentType);
            else
                containingParentTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #endregion
    }
}
