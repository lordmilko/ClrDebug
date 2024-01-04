using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ModelKeyReference.Key"/> property.
    /// </summary>
    [DebuggerDisplay("@object = {@object?.ToString(),nq}, metadata = {metadata?.ToString(),nq}")]
    public struct ModelKeyReference_GetKeyResult
    {
        /// <summary>
        /// The value of the key will be returned here.
        /// </summary>
        public ModelObject @object { get; }

        /// <summary>
        /// Optional metadata which is associated with the key will be returned here.
        /// </summary>
        public KeyStore metadata { get; }

        public ModelKeyReference_GetKeyResult(ModelObject @object, KeyStore metadata)
        {
            this.@object = @object;
            this.metadata = metadata;
        }
    }
}
