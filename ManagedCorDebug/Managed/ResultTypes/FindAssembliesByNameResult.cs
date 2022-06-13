using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataAssemblyImport.FindAssembliesByName"/> method.
    /// </summary>
    [DebuggerDisplay("ppIUnk = {ppIUnk}, pcAssemblies = {pcAssemblies}")]
    public struct FindAssembliesByNameResult
    {
        /// <summary>
        /// An array that holds the <see cref="IMetaDataAssemblyImport"/> interface pointers.
        /// </summary>
        public object[] ppIUnk { get; }

        /// <summary>
        /// The number of interface pointers returned - that is, the number of interface pointers actually placed in ppIUnk.
        /// </summary>
        public int pcAssemblies { get; }

        public FindAssembliesByNameResult(object[] ppIUnk, int pcAssemblies)
        {
            this.ppIUnk = ppIUnk;
            this.pcAssemblies = pcAssemblies;
        }
    }
}