using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DbgEngTypedData.Custom
{
    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy(typeof(DbgFieldCollectionDebugView))]
    class DbgFieldCollection : IEnumerable<DbgField>
    {
        private IList<DbgField> fields;

        public int Count => fields.Count;

        public DbgFieldCollection(IList<DbgField> fields)
        {
            this.fields = fields;
        }

        public DbgField this[string name]
        {
            get
            {
                var match = fields.SingleOrDefault(f => f.Info.Name == name);

                return match;
            }
        }

        public IEnumerator<DbgField> GetEnumerator() => fields.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
