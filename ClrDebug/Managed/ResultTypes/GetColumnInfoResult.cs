using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetColumnInfo"/> method.
    /// </summary>
    [DebuggerDisplay("poCol = {poCol}, pcbCol = {pcbCol}, pType = {pType}, ppName = {ppName}")]
    public struct GetColumnInfoResult
    {
        /// <summary>
        /// A pointer to the offset of the column in the row.
        /// </summary>
        public int poCol { get; }

        /// <summary>
        /// A pointer to the size, in bytes, of the column.
        /// </summary>
        public int pcbCol { get; }

        /// <summary>
        /// A pointer to the type of the values in the column.
        /// </summary>
        public int pType { get; }

        /// <summary>
        /// A pointer to a pointer to the column name.
        /// </summary>
        public string ppName { get; }

        public GetColumnInfoResult(int poCol, int pcbCol, int pType, string ppName)
        {
            this.poCol = poCol;
            this.pcbCol = pcbCol;
            this.pType = pType;
            this.ppName = ppName;
        }
    }
}
