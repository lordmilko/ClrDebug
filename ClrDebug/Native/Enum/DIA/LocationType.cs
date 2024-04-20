namespace ClrDebug.DIA
{
    /// <summary>
    /// Indicates the kind of location information contained in a symbol.
    /// </summary>
    /// <remarks>
    /// The properties available to the <see cref="IDiaSymbol"/> interface depend on the symbol's location within the image
    /// file. For more information, see Symbol Locations. The values in this enumeration are returned by a call to the
    /// <see cref="IDiaSymbol.get_locationType"/> method.
    /// </remarks>
    public enum LocationType
    {
        /// <summary>
        /// Location information is unavailable.
        /// </summary>
        LocIsNull,

        /// <summary>
        /// Location is static.
        /// </summary>
        LocIsStatic,

        /// <summary>
        /// Location is in thread local storage.
        /// </summary>
        LocIsTLS,

        /// <summary>
        /// Location is register-relative.
        /// </summary>
        LocIsRegRel,

        /// <summary>
        /// Location is this-relative.
        /// </summary>
        LocIsThisRel,

        /// <summary>
        /// Location is in a register.
        /// </summary>
        LocIsEnregistered,

        /// <summary>
        /// Location is in a bit field.
        /// </summary>
        LocIsBitField,

        /// <summary>
        /// Location is a Microsoft Intermediate Language (MSIL) slot.
        /// </summary>
        LocIsSlot,

        /// <summary>
        /// Location is MSIL-relative.
        /// </summary>
        LocIsIlRel,

        /// <summary>
        /// Location is in metadata.
        /// </summary>
        LocInMetaData,

        /// <summary>
        /// Location is in a constant value.
        /// </summary>
        LocIsConstant,

        LocIsRegRelAliasIndir,

        LocTypeMax,
    }
}
