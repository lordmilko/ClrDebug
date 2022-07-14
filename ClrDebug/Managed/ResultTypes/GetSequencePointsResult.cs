using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedMethod.SequencePoints"/> property.
    /// </summary>
    [DebuggerDisplay("offsets = {offsets}, documents = {documents}, lines = {lines}, columns = {columns}, endLines = {endLines}, endColumns = {endColumns}")]
    public struct GetSequencePointsResult
    {
        /// <summary>
        /// An array in which to store the Microsoft intermediate language (MSIL) offsets from the beginning of the method for the sequence points.
        /// </summary>
        public int[] offsets { get; }

        /// <summary>
        /// An array in which to store the documents in which the sequence points are located.
        /// </summary>
        public ISymUnmanagedDocument[] documents { get; }

        /// <summary>
        /// An array in which to store the lines in the documents at which the sequence points are located.
        /// </summary>
        public int[] lines { get; }

        /// <summary>
        /// An array in which to store the columns in the documents at which the sequence points are located.
        /// </summary>
        public int[] columns { get; }

        /// <summary>
        /// The array of lines in the documents at which the sequence points end.
        /// </summary>
        public int[] endLines { get; }

        /// <summary>
        /// The array of columns in the documents at which the sequence points end.
        /// </summary>
        public int[] endColumns { get; }

        public GetSequencePointsResult(int[] offsets, ISymUnmanagedDocument[] documents, int[] lines, int[] columns, int[] endLines, int[] endColumns)
        {
            this.offsets = offsets;
            this.documents = documents;
            this.lines = lines;
            this.columns = columns;
            this.endLines = endLines;
            this.endColumns = endColumns;
        }
    }
}
