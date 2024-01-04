using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.GetExpressionSyntaxNames"/> method.
    /// </summary>
    [DebuggerDisplay("FullNameBuffer = {FullNameBuffer}, AbbrevNameBuffer = {AbbrevNameBuffer}")]
    public struct GetExpressionSyntaxNamesResult
    {
        /// <summary>
        /// Receives the full name of the expression syntax. If FullNameBuffer is NULL, this information is not returned.
        /// </summary>
        public string FullNameBuffer { get; }

        /// <summary>
        /// Receives the abbreviated name of the expression syntax. This size includes the space for the '\0' terminating character.<para/>
        /// If AbbrevNameBuffer is NULL, this information is not returned.
        /// </summary>
        public string AbbrevNameBuffer { get; }

        public GetExpressionSyntaxNamesResult(string fullNameBuffer, string abbrevNameBuffer)
        {
            FullNameBuffer = fullNameBuffer;
            AbbrevNameBuffer = abbrevNameBuffer;
        }
    }
}
