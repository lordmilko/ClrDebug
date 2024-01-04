using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostType.BitField"/> property.
    /// </summary>
    [DebuggerDisplay("lsbOfField = {lsbOfField}, lengthOfField = {lengthOfField}")]
    public struct GetBitFieldResult
    {
        /// <summary>
        /// Indicates the least significant bit of the field (where 0 is defined to be the least significant bit of the containing type).<para/>
        /// The bit field is defined to utilize bits from this point towards the most significant bit of the containing type according to the length specified by the lengthOfField argument.
        /// </summary>
        public int lsbOfField { get; }

        /// <summary>
        /// The number of bits in the field. This will be at least one and no more than the number of bits in the containing type.<para/>
        /// The bit field occupies from the bit specified in the lsbOfField argument upwards towards the most significant bit of the containing value according to the number of bits returned here.
        /// </summary>
        public int lengthOfField { get; }

        public GetBitFieldResult(int lsbOfField, int lengthOfField)
        {
            this.lsbOfField = lsbOfField;
            this.lengthOfField = lengthOfField;
        }
    }
}
