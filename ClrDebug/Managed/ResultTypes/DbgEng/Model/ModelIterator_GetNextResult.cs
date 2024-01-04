using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ModelIterator.GetNext"/> method.
    /// </summary>
    [DebuggerDisplay("@object = {@object?.ToString(),nq}, indexers = {indexers}, metadata = {metadata?.ToString(),nq}")]
    public struct ModelIterator_GetNextResult
    {
        /// <summary>
        /// The object produced from the iterator is returned here.
        /// </summary>
        public ModelObject @object { get; }

        /// <summary>
        /// A buffer of size dimensions which will be filled in with the default indicies to get back to the returned element from the indexer.
        /// </summary>
        public IModelObject[] indexers { get; }

        /// <summary>
        /// If there is any metadata associated with the iterated element, it is returned (optionally) in this argument.
        /// </summary>
        public KeyStore metadata { get; }

        public ModelIterator_GetNextResult(ModelObject @object, IModelObject[] indexers, KeyStore metadata)
        {
            this.@object = @object;
            this.indexers = indexers;
            this.metadata = metadata;
        }
    }
}
