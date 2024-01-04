using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ModelObject.GetParentModel"/> method.
    /// </summary>
    [DebuggerDisplay("model = {model?.ToString(),nq}, contextObject = {contextObject?.ToString(),nq}")]
    public struct GetParentModelResult
    {
        /// <summary>
        /// An <see cref="IModelObject"/> representing the i-th parent model will be returned here.
        /// </summary>
        public ModelObject model { get; }

        /// <summary>
        /// If the parent model has an associated context adjustor, the adjusted context will be returned here. See the documentation for AddParentModel for more information about this value.
        /// </summary>
        public ModelObject contextObject { get; }

        public GetParentModelResult(ModelObject model, ModelObject contextObject)
        {
            this.model = model;
            this.contextObject = contextObject;
        }
    }
}
