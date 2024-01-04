using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ModelObject.GetConcept"/> method.
    /// </summary>
    [DebuggerDisplay("conceptInterface = {conceptInterface}, conceptMetadata = {conceptMetadata?.ToString(),nq}")]
    public struct ModelObject_GetConceptResult
    {
        /// <summary>
        /// The interface defined by conceptId will be returned in this argument.
        /// </summary>
        public object conceptInterface { get; }

        /// <summary>
        /// The metadata store associated with this concept will be optionally returned in this argument
        /// </summary>
        public KeyStore conceptMetadata { get; }

        public ModelObject_GetConceptResult(object conceptInterface, KeyStore conceptMetadata)
        {
            this.conceptInterface = conceptInterface;
            this.conceptMetadata = conceptMetadata;
        }
    }
}
