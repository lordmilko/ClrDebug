using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetTableInfo"/> method.
    /// </summary>
    [DebuggerDisplay("pcbRow = {pcbRow}, pcRows = {pcRows}, pcCols = {pcCols}, piKey = {piKey}, ppName = {ppName}")]
    public struct GetTableInfoResult
    {
        /// <summary>
        /// A pointer to the size, in bytes, of a table row.
        /// </summary>
        public int pcbRow { get; }

        /// <summary>
        /// A pointer to the number of rows in the table.
        /// </summary>
        public int pcRows { get; }

        /// <summary>
        /// A pointer to the number of columns in the table.
        /// </summary>
        public int pcCols { get; }

        /// <summary>
        /// A pointer to the index of the key column, or -1 if the table has no key column.
        /// </summary>
        public int piKey { get; }

        /// <summary>
        /// A pointer to a pointer to the table name.
        /// </summary>
        public string ppName { get; }

        public GetTableInfoResult(int pcbRow, int pcRows, int pcCols, int piKey, string ppName)
        {
            this.pcbRow = pcbRow;
            this.pcRows = pcRows;
            this.pcCols = pcCols;
            this.piKey = piKey;
            this.ppName = ppName;
        }
    }
}