using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ModelObject.GetKeyReference"/> method.
    /// </summary>
    [DebuggerDisplay("objectReference = {objectReference?.ToString(),nq}, metadata = {metadata?.ToString(),nq}")]
    public struct GetKeyReferenceResult
    {
        /// <summary>
        /// The object reference.
        /// </summary>
        public ModelObject objectReference { get; }

        /// <summary>
        /// The metadata store associated with this key will be optionally returned in this argument.
        /// </summary>
        public KeyStore metadata { get; }

        public GetKeyReferenceResult(ModelObject objectReference, KeyStore metadata)
        {
            this.objectReference = objectReference;
            this.metadata = metadata;
        }
    }
}
