namespace ManagedCorDebug
{
    /// <summary>
    /// Stores the offset, within a class, of the specified field.
    /// </summary>
    /// <remarks>
    /// <see cref="IMetaDataImport.GetClassLayout"/> and <see cref="IMetaDataEmit.SetClassLayout"/> methods take a parameter
    /// of type COR_FIELD_OFFSET.
    /// </remarks>
    public struct COR_FIELD_OFFSET
    {
        /// <summary>
        /// An mdFieldDef metadata token that represents the field.
        /// </summary>
        public mdFieldDef ridOfField;

        /// <summary>
        /// The field's offset within its class.
        /// </summary>
        public uint ulOffset;
    }
}