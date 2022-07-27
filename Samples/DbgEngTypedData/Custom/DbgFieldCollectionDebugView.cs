using System.Diagnostics;
using System.Linq;

namespace DbgEngTypedData.Custom
{
    internal sealed class DbgFieldCollectionDebugView
    {
        private DbgFieldCollection list;

        public DbgFieldCollectionDebugView(DbgFieldCollection list)
        {
            this.list = list;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public DbgField[] Items
        {
            get
            {
                var items = list.ToArray();
                return items;
            }
        }
    }
}
