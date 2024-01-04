using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostEvaluator.AssignTo"/> method.
    /// </summary>
    [DebuggerDisplay("assignmentResult = {assignmentResult?.ToString(),nq}, assignmentMetadata = {assignmentMetadata?.ToString(),nq}")]
    public struct AssignToResult
    {
        /// <summary>
        /// The result of assignment, if successful. If not, optionally, an extended error object indicating why the assignment failed.<para/>
        /// Note that result of assignment in this case is what the language defines as the result of an assignment operation.<para/>
        /// For C++, this would be a language reference to the thing assigned.
        /// </summary>
        public ModelObject assignmentResult { get; }

        /// <summary>
        /// Any optional metadata associated with the assignment result is returned here.
        /// </summary>
        public KeyStore assignmentMetadata { get; }

        public AssignToResult(ModelObject assignmentResult, KeyStore assignmentMetadata)
        {
            this.assignmentResult = assignmentResult;
            this.assignmentMetadata = assignmentMetadata;
        }
    }
}
