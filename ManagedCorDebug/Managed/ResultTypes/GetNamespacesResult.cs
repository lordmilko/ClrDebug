using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedScope.GetNamespaces"/> method.
    /// </summary>
    [DebuggerDisplay("pcNameSpaces = {pcNameSpaces}, namespaces = {namespaces}")]
    public struct GetNamespacesResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the size of the buffer required to contain the namespaces.
        /// </summary>
        public int pcNameSpaces { get; }

        /// <summary>
        /// The array that receives the namespaces.
        /// </summary>
        public ISymUnmanagedNamespace[] namespaces { get; }

        public GetNamespacesResult(int pcNameSpaces, ISymUnmanagedNamespace[] namespaces)
        {
            this.pcNameSpaces = pcNameSpaces;
            this.namespaces = namespaces;
        }
    }
}