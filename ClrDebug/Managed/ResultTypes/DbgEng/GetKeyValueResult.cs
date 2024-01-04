using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ModelObject.GetKeyValue"/> method.
    /// </summary>
    [DebuggerDisplay("@object = {@object?.ToString(),nq}, metadata = {metadata?.ToString(),nq}")]
    public struct GetKeyValueResult
    {
        /// <summary>
        /// The value of the key will be returned in this argument. In some error cases, extended error information may be passed out in this argument even though the method returns a failing HRESULT.
        /// </summary>
        public ModelObject @object { get; }

        /// <summary>
        /// The metadata store associated with this key will be optionally returned in this argument.
        /// </summary>
        public KeyStore metadata { get; }

        public GetKeyValueResult(ModelObject @object, KeyStore metadata)
        {
            this.@object = @object;
            this.metadata = metadata;
        }
    }
}
