using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DataModelManager.GetModelForType"/> method.
    /// </summary>
    [DebuggerDisplay("dataModel = {dataModel?.ToString(),nq}, typeSignature = {typeSignature?.ToString(),nq}, wildcardMatches = {wildcardMatches?.ToString(),nq}")]
    public struct GetModelForTypeResult
    {
        /// <summary>
        /// The data model which is the canonical visualizer for the given type instance as determined by the best matching type signature registered via a prior call to RegisterModelForTypeSignature will be returned here.<para/>
        /// This data model will automatically be attached to any native/language object created with the type specified by the type argument.
        /// </summary>
        public ModelObject dataModel { get; }

        /// <summary>
        /// The type signature whose match against type caused us to return the data model registered from a prior call to RegisterModelForTypeSignature with the returned type signature.
        /// </summary>
        public DebugHostTypeSignature typeSignature { get; }

        /// <summary>
        /// If there are wildcards in the signature returned in the typeSignature argument, an enumerator of all matches between the wildcards and the concrete type instance given in the type argument is returned here.
        /// </summary>
        public DebugHostSymbolEnumerator wildcardMatches { get; }

        public GetModelForTypeResult(ModelObject dataModel, DebugHostTypeSignature typeSignature, DebugHostSymbolEnumerator wildcardMatches)
        {
            this.dataModel = dataModel;
            this.typeSignature = typeSignature;
            this.wildcardMatches = wildcardMatches;
        }
    }
}
