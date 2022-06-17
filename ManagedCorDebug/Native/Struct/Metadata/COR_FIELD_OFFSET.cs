using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Stores the offset, within a class, of the specified field.
    /// </summary>
    /// <remarks>
    /// <see cref="IMetaDataImport.GetClassLayout"/> and <see cref="IMetaDataEmit.SetClassLayout"/> methods take a parameter
    /// of type <see cref="COR_FIELD_OFFSET"/>.
    /// </remarks>
    [DebuggerDisplay("ridOfField = {ridOfField.ToString(),nq}, ulOffset = {ulOffset}")]
    public struct COR_FIELD_OFFSET
    {
        /// <summary>
        /// An <see cref="mdFieldDef"/> metadata token that represents the field.
        /// </summary>
        public mdFieldDef ridOfField;

        /// <summary>
        /// The field's offset within its class.
        /// </summary>
        public int ulOffset;
    }
}
