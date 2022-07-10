using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetFieldTypeAndOffsetWide"/> method.
    /// </summary>
    [DebuggerDisplay("FieldTypeId = {FieldTypeId}, Offset = {Offset}")]
    public struct GetFieldTypeAndOffsetWideResult
    {
        /// <summary>
        /// Receives the type ID of the field.
        /// </summary>
        public uint FieldTypeId { get; }

        /// <summary>
        /// Receives the offset of the field Field from the base memory location of an instance of the container.
        /// </summary>
        public uint Offset { get; }

        public GetFieldTypeAndOffsetWideResult(uint fieldTypeId, uint offset)
        {
            FieldTypeId = fieldTypeId;
            Offset = offset;
        }
    }
}
