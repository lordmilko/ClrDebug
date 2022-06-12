namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetColumnInfo"/> method.
    /// </summary>
    public struct GetColumnInfoResult
    {
        /// <summary>
        /// [out] A pointer to the offset of the column in the row.
        /// </summary>
        public int poCol { get; }

        /// <summary>
        /// [out] A pointer to the size, in bytes, of the column.
        /// </summary>
        public int pcbCol { get; }

        /// <summary>
        /// [out] A pointer to the type of the values in the column.
        /// </summary>
        public int pType { get; }

        public GetColumnInfoResult(int poCol, int pcbCol, int pType)
        {
            this.poCol = poCol;
            this.pcbCol = pcbCol;
            this.pType = pType;
        }
    }
}