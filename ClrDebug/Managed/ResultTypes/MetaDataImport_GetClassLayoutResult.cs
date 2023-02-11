using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetClassLayout"/> method.
    /// </summary>
    [DebuggerDisplay("pdwPackSize = {pdwPackSize}, rFieldOffset = {rFieldOffset}, pulClassSize = {pulClassSize}")]
    public struct MetaDataImport_GetClassLayoutResult
    {
        /// <summary>
        /// One of the values 1, 2, 4, 8, or 16, representing the pack size of the class.
        /// </summary>
        public int pdwPackSize { get; }

        /// <summary>
        /// An array of <see cref="COR_FIELD_OFFSET"/> values.
        /// </summary>
        public COR_FIELD_OFFSET[] rFieldOffset { get; }

        /// <summary>
        /// The size in bytes of the class represented by td.
        /// </summary>
        public int pulClassSize { get; }

        public MetaDataImport_GetClassLayoutResult(int pdwPackSize, COR_FIELD_OFFSET[] rFieldOffset, int pulClassSize)
        {
            this.pdwPackSize = pdwPackSize;
            this.rFieldOffset = rFieldOffset;
            this.pulClassSize = pulClassSize;
        }
    }
}
