namespace ClrDebug.TTD
{
    public unsafe struct ModuleLoadedEvent
    {
        public Position position;
        public Module* info;
    }
}