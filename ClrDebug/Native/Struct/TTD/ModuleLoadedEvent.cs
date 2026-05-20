using System.Diagnostics;

namespace ClrDebug.TTD
{
    [DebuggerDisplay("[{position.ToString(),nq}] {ToString(),nq}")]
    public unsafe struct ModuleLoadedEvent
    {
        public Position position;
        public Module* info;

        public override string ToString()
        {
            return info->ToString();
        }
    }
}
