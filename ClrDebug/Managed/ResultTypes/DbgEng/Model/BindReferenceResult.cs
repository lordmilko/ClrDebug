using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DataModelNameBinder.BindReference"/> method.
    /// </summary>
    [DebuggerDisplay("reference = {reference?.ToString(),nq}, metadata = {metadata?.ToString(),nq}")]
    public struct BindReferenceResult
    {
        /// <summary>
        /// A reference to name in the context of contextObject is returned. As a reference binding, this can be used to support assignment back to name.
        /// </summary>
        public ModelObject reference { get; }

        /// <summary>
        /// Any metadata optionally associated with name is returned here.
        /// </summary>
        public KeyStore metadata { get; }

        public BindReferenceResult(ModelObject reference, KeyStore metadata)
        {
            this.reference = reference;
            this.metadata = metadata;
        }
    }
}
