using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.ResolveTypeRef"/> method.
    /// </summary>
    [DebuggerDisplay("ppIScope = {ppIScope}, ptd = {ptd.ToString(),nq}")]
    public struct ResolveTypeRefResult
    {
        /// <summary>
        /// An interface to the module scope in which the referenced type is defined.
        /// </summary>
        public object ppIScope { get; }

        /// <summary>
        /// A pointer to a TypeDef token that represents the referenced type.
        /// </summary>
        public mdTypeDef ptd { get; }

        public ResolveTypeRefResult(object ppIScope, mdTypeDef ptd)
        {
            this.ppIScope = ppIScope;
            this.ptd = ptd;
        }
    }
}