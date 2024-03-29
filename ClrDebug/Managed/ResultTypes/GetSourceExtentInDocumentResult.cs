﻿using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymENCUnmanagedMethod.GetSourceExtentInDocument"/> method.
    /// </summary>
    [DebuggerDisplay("pstartLine = {pstartLine}, pendLine = {pendLine}")]
    public struct GetSourceExtentInDocumentResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the start line.
        /// </summary>
        public int pstartLine { get; }

        /// <summary>
        /// A pointer to a ULONG32 that receives the end line.
        /// </summary>
        public int pendLine { get; }

        public GetSourceExtentInDocumentResult(int pstartLine, int pendLine)
        {
            this.pstartLine = pstartLine;
            this.pendLine = pendLine;
        }
    }
}
