using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetFieldTypeAndOffset"/> method.
    /// </summary>
    [DebuggerDisplay("FieldTypeId = {FieldTypeId}, Offset = {Offset}")]
    public struct GetFieldTypeAndOffsetResult
    {
        /// <summary>
        /// Receives the type ID of the field.
        /// </summary>
        public int FieldTypeId { get; }

        /// <summary>
        /// Receives the offset of the field Field from the base memory location of an instance of the container.
        /// </summary>
        public int Offset { get; }

        public GetFieldTypeAndOffsetResult(int fieldTypeId, int offset)
        {
            FieldTypeId = fieldTypeId;
            Offset = offset;
        }
    }
}
