using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetColumnInfo"/> method.
    /// </summary>
    [DebuggerDisplay("poCol = {poCol}, pcbCol = {pcbCol}, pType = {pType}")]
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

        public GetColumnInfoResult(int poCol, int pcbCol, int pType)
        {
            this.poCol = poCol;
            this.pcbCol = pcbCol;
            this.pType = pType;
        }
    }
}