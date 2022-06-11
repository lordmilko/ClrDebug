using System;

namespace ManagedCorDebug
{
    public struct GetLoadedModulesResult
    {
        public uint PcFetchedModules { get; }

        public IntPtr PLoadedModules { get; }

        public GetLoadedModulesResult(uint pcFetchedModules, IntPtr pLoadedModules)
        {
            PcFetchedModules = pcFetchedModules;
            PLoadedModules = pLoadedModules;
        }
    }
}