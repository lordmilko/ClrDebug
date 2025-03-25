namespace ClrDebug.TTD
{
    public unsafe struct ModuleUnloadedEvent
    {
        public Position position;
        public Module* info;
    }
}
