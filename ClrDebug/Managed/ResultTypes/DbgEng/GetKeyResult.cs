using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DynamicKeyProviderConcept.GetKey"/> method.
    /// </summary>
    [DebuggerDisplay("keyValue = {keyValue?.ToString(),nq}, metadata = {metadata?.ToString(),nq}, hasKey = {hasKey}")]
    public struct GetKeyResult
    {
        /// <summary>
        /// The value of the key as determined by the dynamic provider is returned here. If an error occurs in the fetch and an invalid HRESULT is returned, this may return extended error information.<para/>
        /// It is legal for the implementation of the GetKey method to return a property accessor (<see cref="IModelPropertyAccessor"/>).
        /// </summary>
        public ModelObject keyValue { get; }

        /// <summary>
        /// Any metadata which is associated with the key can optionally be returned here.
        /// </summary>
        public KeyStore metadata { get; }

        /// <summary>
        /// An indication of whether the dynamic provider has the key or not. If the provider does not have the key, it must return false here and succeed.
        /// </summary>
        public bool hasKey { get; }

        public GetKeyResult(ModelObject keyValue, KeyStore metadata, bool hasKey)
        {
            this.keyValue = keyValue;
            this.metadata = metadata;
            this.hasKey = hasKey;
        }
    }
}
