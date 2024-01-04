using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DataModelNameBinder.BindValue"/> method.
    /// </summary>
    [DebuggerDisplay("value = {value?.ToString(),nq}, metadata = {metadata?.ToString(),nq}")]
    public struct BindValueResult
    {
        /// <summary>
        /// The value of name in the context of contextObject is returned. As a value binding, this cannot be used to support assignment back to name.
        /// </summary>
        public ModelObject value { get; }

        /// <summary>
        /// Any metadata optionally associated with name is returned here.
        /// </summary>
        public KeyStore metadata { get; }

        public BindValueResult(ModelObject value, KeyStore metadata)
        {
            this.value = value;
            this.metadata = metadata;
        }
    }
}
