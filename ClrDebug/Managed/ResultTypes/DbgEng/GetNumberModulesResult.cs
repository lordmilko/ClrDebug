using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.NumberModules"/> property.
    /// </summary>
    [DebuggerDisplay("Loaded = {Loaded}, Unloaded = {Unloaded}")]
    public struct GetNumberModulesResult
    {
        /// <summary>
        /// Receives the number of loaded modules in the current process's module list.
        /// </summary>
        public int Loaded { get; }

        /// <summary>
        /// Receives the number of unloaded modules in the current process's module list. This number will be zero if the version of Microsoft Windows running on the target computer does not track unloaded modules.
        /// </summary>
        public int Unloaded { get; }

        public GetNumberModulesResult(int loaded, int unloaded)
        {
            Loaded = loaded;
            Unloaded = unloaded;
        }
    }
}
