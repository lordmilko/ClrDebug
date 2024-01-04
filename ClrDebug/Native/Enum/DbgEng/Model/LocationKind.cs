namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the location of a field or other data.
    /// </summary>
    public enum LocationKind : uint
    {
        /// <summary>
        /// The field is a member and has an offset relative to the this pointer.
        /// </summary>
        LocationMember,

        /// <summary>
        /// The field is static and has an address.
        /// </summary>
        LocationStatic,

        /// <summary>
        /// The field is constant and has a value.
        /// </summary>
        LocationConstant,

        /// <summary>
        /// The field has no location (e.g.: it has been optimized out or was a static which was defined but not declared).
        /// </summary>
        LocationNone
    }
}
