using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="KeyStore.GetKey"/> method.
    /// </summary>
    [DebuggerDisplay("@object = {@object?.ToString(),nq}, metadata = {metadata?.ToString(),nq}")]
    public struct KeyStore_GetKeyResult
    {
        /// <summary>
        /// The value of the key will be returned in this argument.
        /// </summary>
        public ModelObject @object { get; }

        /// <summary>
        /// The metadata store associated with this key will be optionally returned in this argument. There is no present use for second level metadata.<para/>
        /// This argument should therefore typically be specified as null.
        /// </summary>
        public KeyStore metadata { get; }

        public KeyStore_GetKeyResult(ModelObject @object, KeyStore metadata)
        {
            this.@object = @object;
            this.metadata = metadata;
        }
    }
}
