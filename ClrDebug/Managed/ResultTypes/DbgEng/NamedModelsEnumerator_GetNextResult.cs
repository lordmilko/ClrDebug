using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="NamedModelsEnumerator.Next"/> property.
    /// </summary>
    [DebuggerDisplay("pModelName = {pModelName}, ppModel = {ppModel?.ToString(),nq}")]
    public struct NamedModelsEnumerator_GetNextResult
    {
        public string pModelName { get; }

        public ModelObject ppModel { get; }

        public NamedModelsEnumerator_GetNextResult(string pModelName, ModelObject ppModel)
        {
            this.pModelName = pModelName;
            this.ppModel = ppModel;
        }
    }
}
