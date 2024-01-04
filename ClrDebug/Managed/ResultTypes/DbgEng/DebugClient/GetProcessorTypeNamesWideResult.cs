using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.GetProcessorTypeNamesWide"/> method.
    /// </summary>
    [DebuggerDisplay("FullNameBuffer = {FullNameBuffer}, AbbrevNameBuffer = {AbbrevNameBuffer}")]
    public struct GetProcessorTypeNamesWideResult
    {
        /// <summary>
        /// Receives the full name of the processor type. If FullNameBuffer is NULL, this information is not returned.
        /// </summary>
        public string FullNameBuffer { get; }

        /// <summary>
        /// Receives the abbreviated name of the processor type. If AbbrevNameBuffer is NULL, this information is not returned.
        /// </summary>
        public string AbbrevNameBuffer { get; }

        public GetProcessorTypeNamesWideResult(string fullNameBuffer, string abbrevNameBuffer)
        {
            FullNameBuffer = fullNameBuffer;
            AbbrevNameBuffer = abbrevNameBuffer;
        }
    }
}
