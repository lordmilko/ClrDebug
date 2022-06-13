using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymENCUnmanagedMethod.GetLineFromOffset"/> method.
    /// </summary>
    [DebuggerDisplay("pline = {pline}, pcolumn = {pcolumn}, pendLine = {pendLine}, pendColumn = {pendColumn}, pdwStartOffset = {pdwStartOffset}")]
    public struct GetLineFromOffsetResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the line.
        /// </summary>
        public int pline { get; }

        /// <summary>
        /// A pointer to a ULONG32 that receives the column.
        /// </summary>
        public int pcolumn { get; }

        /// <summary>
        /// A pointer to a ULONG32 that receives the end line.
        /// </summary>
        public int pendLine { get; }

        /// <summary>
        /// A pointer to a ULONG32 that receives the end column.
        /// </summary>
        public int pendColumn { get; }

        /// <summary>
        /// A pointer to a ULONG32 that receives the associated sequence point.
        /// </summary>
        public int pdwStartOffset { get; }

        public GetLineFromOffsetResult(int pline, int pcolumn, int pendLine, int pendColumn, int pdwStartOffset)
        {
            this.pline = pline;
            this.pcolumn = pcolumn;
            this.pendLine = pendLine;
            this.pendColumn = pendColumn;
            this.pdwStartOffset = pdwStartOffset;
        }
    }
}