using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedMethod.GetSequencePoints"/> method.
    /// </summary>
    public struct GetSequencePointsResult
    {
        /// <summary>
        /// [out] A pointer to a ULONG32 that receives the length of the buffer required to contain the sequence points.
        /// </summary>
        public int pcPoints { get; }

        /// <summary>
        /// [in] An array in which to store the documents in which the sequence points are located.
        /// </summary>
        public IntPtr documents { get; }

        /// <summary>
        /// [in] An array in which to store the lines in the documents at which the sequence points are located.
        /// </summary>
        public int[] lines { get; }

        /// <summary>
        /// [in] An array in which to store the columns in the documents at which the sequence points are located.
        /// </summary>
        public int[] columns { get; }

        /// <summary>
        /// [in] The array of lines in the documents at which the sequence points end.
        /// </summary>
        public int[] endLines { get; }

        /// <summary>
        /// [in] The array of columns in the documents at which the sequence points end.
        /// </summary>
        public int[] endColumns { get; }

        public GetSequencePointsResult(int pcPoints, IntPtr documents, int[] lines, int[] columns, int[] endLines, int[] endColumns)
        {
            this.pcPoints = pcPoints;
            this.documents = documents;
            this.lines = lines;
            this.columns = columns;
            this.endLines = endLines;
            this.endColumns = endColumns;
        }
    }
}