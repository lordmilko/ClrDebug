using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="IndexableConcept.GetAt"/> method.
    /// </summary>
    [DebuggerDisplay("@object = {@object?.ToString(),nq}, metadata = {metadata?.ToString(),nq}")]
    public struct GetAtResult
    {
        /// <summary>
        /// The value of the element at the specified indicies is returned here. If the method fails, extended error information may be returned here as an error object.
        /// </summary>
        public ModelObject @object { get; }

        /// <summary>
        /// Optional metadata about the indexed element may be returned here.
        /// </summary>
        public KeyStore metadata { get; }

        public GetAtResult(ModelObject @object, KeyStore metadata)
        {
            this.@object = @object;
            this.metadata = metadata;
        }
    }
}
