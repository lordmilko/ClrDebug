namespace DbgEngTypedData.Custom
{
    class DbgComplexFieldDebugView
    {
        private DbgComplexField field;

        public DbgComplexFieldDebugView(DbgComplexField field)
        {
            this.field = field;
        }

        public long Address => field.Address;

        public string Name => field.Name;

        public long Offset => field.Offset;

        public DbgType Type => field.Type;

        public DbgObject Value => field.Value;

        public DbgFieldCollection Fields => field.Fields;
    }
}