using ClrDebug.DbgEng;

namespace DbgEngTypedData.Custom
{
    class DbgModule
    {
        public string Name { get; }

        public long Base { get; }

        public DbgModule(long baseAddress, DbgState state)
        {
            Base = baseAddress;
            Name = state.Client.Symbols.GetModuleNameString(DEBUG_MODNAME.MODULE, -1, baseAddress);
        }
    }
}
