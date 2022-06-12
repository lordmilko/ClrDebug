using System;

namespace ManagedCorDebug
{
    public struct GetLoadedModulesResult
    {
        public int PcFetchedModules { get; }

        public IntPtr PLoadedModules { get; }

        public GetLoadedModulesResult(int pcFetchedModules, IntPtr pLoadedModules)
        {
            PcFetchedModules = pcFetchedModules;
            PLoadedModules = pLoadedModules;
        }
    }
}