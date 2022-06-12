using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugDataTarget.GetLoadedModules"/> method.
    /// </summary>
    [DebuggerDisplay("pcFetchedModules = {pcFetchedModules}, pLoadedModules = {pLoadedModules}")]
    public struct GetLoadedModulesResult
    {
        /// <summary>
        /// [out] A pointer to the number of modules about which information was returned.
        /// </summary>
        public int pcFetchedModules { get; }

        /// <summary>
        /// [out] A pointer to an array of <see cref="ICorDebugLoadedModule"/> objects that provide information about loaded modules.
        /// </summary>
        public IntPtr pLoadedModules { get; }

        public GetLoadedModulesResult(int pcFetchedModules, IntPtr pLoadedModules)
        {
            this.pcFetchedModules = pcFetchedModules;
            this.pLoadedModules = pLoadedModules;
        }
    }
}