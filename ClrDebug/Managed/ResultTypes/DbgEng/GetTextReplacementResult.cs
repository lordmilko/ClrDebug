﻿using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.GetTextReplacement"/> method.
    /// </summary>
    [DebuggerDisplay("SrcBuffer = {SrcBuffer}, DstBuffer = {DstBuffer}")]
    public struct GetTextReplacementResult
    {
        /// <summary>
        /// Receives the name of the alias. This is the name specified in SrcText, if SrcText is not NULL. If SrcBuffer is NULL, this information is not returned.
        /// </summary>
        public string SrcBuffer { get; }

        /// <summary>
        /// Receives the value of the alias specified by SrcText and Index. If DstBuffer is NULL, this information is not returned.
        /// </summary>
        public string DstBuffer { get; }

        public GetTextReplacementResult(string srcBuffer, string dstBuffer)
        {
            SrcBuffer = srcBuffer;
            DstBuffer = dstBuffer;
        }
    }
}
