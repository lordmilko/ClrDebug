using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DynamicConceptProviderConcept.GetConcept"/> method.
    /// </summary>
    [DebuggerDisplay("conceptInterface = {conceptInterface}, conceptMetadata = {conceptMetadata?.ToString(),nq}, hasConcept = {hasConcept}")]
    public struct GetConceptResult
    {
        /// <summary>
        /// The core interface to the concept as defined by the conceptId argument is returned here.
        /// </summary>
        public object conceptInterface { get; }

        /// <summary>
        /// Any metadata which is associated with the concept can optionally be returned here.
        /// </summary>
        public KeyStore conceptMetadata { get; }

        /// <summary>
        /// An indication of whether the dynamic provider has the concept is returned here. If the provider does not have the concept, the value false should be returned here and the method should succeed.
        /// </summary>
        public bool hasConcept { get; }

        public GetConceptResult(object conceptInterface, KeyStore conceptMetadata, bool hasConcept)
        {
            this.conceptInterface = conceptInterface;
            this.conceptMetadata = conceptMetadata;
            this.hasConcept = hasConcept;
        }
    }
}
