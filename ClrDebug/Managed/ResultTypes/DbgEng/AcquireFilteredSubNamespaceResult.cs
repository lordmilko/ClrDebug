using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DataModelManager.AcquireFilteredSubNamespace"/> method.
    /// </summary>
    [DebuggerDisplay("namespaceModelObject = {namespaceModelObject?.ToString(),nq}, token = {token?.ToString(),nq}")]
    public struct AcquireFilteredSubNamespaceResult
    {
        public ModelObject namespaceModelObject { get; }

        public FilteredNamespacePropertyToken token { get; }

        public AcquireFilteredSubNamespaceResult(ModelObject namespaceModelObject, FilteredNamespacePropertyToken token)
        {
            this.namespaceModelObject = namespaceModelObject;
            this.token = token;
        }
    }
}
