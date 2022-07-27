using System.Diagnostics;

namespace DbgEngTypedData.Custom
{
    [DebuggerTypeProxy(typeof(DbgComplexFieldDebugView))]
    class DbgComplexField : DbgField
    {
        public new DbgObject Value => (DbgObject) base.Value;

        public DbgComplexField(long address, DbgFieldInfo info, DbgObject parent, DbgObject value) : base(address, info, parent, value)
        {
        }
    }
}