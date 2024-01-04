using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="ActionEnumerator.Next"/> property.
    /// </summary>
    [DebuggerDisplay("keyName = {keyName}, actionName = {actionName}, actionDescription = {actionDescription}, actionIsDefault = {actionIsDefault}, actionMethod = {actionMethod?.ToString(),nq}, metadta = {metadta?.ToString(),nq}")]
    public struct GetNextResult
    {
        public string keyName { get; }

        public string actionName { get; }

        public string actionDescription { get; }

        public bool actionIsDefault { get; }

        public ModelObject actionMethod { get; }

        public KeyStore metadta { get; }

        public GetNextResult(string keyName, string actionName, string actionDescription, bool actionIsDefault, ModelObject actionMethod, KeyStore metadta)
        {
            this.keyName = keyName;
            this.actionName = actionName;
            this.actionDescription = actionDescription;
            this.actionIsDefault = actionIsDefault;
            this.actionMethod = actionMethod;
            this.metadta = metadta;
        }
    }
}
