using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="KeyEnumerator.Next"/> property.
    /// </summary>
    [DebuggerDisplay("key = {key}, value = {value?.ToString(),nq}, metadata = {metadata?.ToString(),nq}")]
    public struct KeyEnumerator_GetNextResult
    {
        /// <summary>
        /// The name of the key being enumerated is returned here. The caller is responsible for freeing this string with the SysFreeString method.
        /// </summary>
        public string key { get; }

        /// <summary>
        /// The value of the key being enumerated is returned here. Depending on how the enumerator was acquired, this value may be the value associated with the key (EnumerateKeys), the resolved value of any property that the key refers to (EnumerateKeyValues), or a reference to the key (EnumerateKeyReferences).
        /// </summary>
        public ModelObject value { get; }

        /// <summary>
        /// Any metadata associated with the key is optionally returned in this argument.
        /// </summary>
        public KeyStore metadata { get; }

        public KeyEnumerator_GetNextResult(string key, ModelObject value, KeyStore metadata)
        {
            this.key = key;
            this.value = value;
            this.metadata = metadata;
        }
    }
}
