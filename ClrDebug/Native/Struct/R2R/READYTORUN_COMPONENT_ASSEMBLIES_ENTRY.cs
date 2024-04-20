using System.Diagnostics;

namespace ClrDebug
{
    [DebuggerDisplay("CorHeader = {CorHeader.ToString(),nq}, ReadyToRunCoreHeader = {ReadyToRunCoreHeader.ToString(),nq}")]
    public struct READYTORUN_COMPONENT_ASSEMBLIES_ENTRY
    {
        public IMAGE_DATA_DIRECTORY CorHeader;
        public IMAGE_DATA_DIRECTORY ReadyToRunCoreHeader;
    }
}
