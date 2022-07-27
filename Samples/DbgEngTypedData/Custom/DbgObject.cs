using System.Collections.Generic;
using System.Diagnostics;
using ClrDebug.DbgEng;

namespace DbgEngTypedData.Custom
{
    /// <summary>
    /// Represents an object instance (such as an instance of a struct) in a remote process.
    /// </summary>
    class DbgObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected DbgState state;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected DebugClient client => state.Client;

        public DbgType Type { get; }

        /// <summary>
        /// Gets the address at which this struct resides.
        /// </summary>
        public long Address { get; }

        public DbgFieldCollection Fields
        {
            get
            {
                var results = new List<DbgField>();

                foreach (var field in Type.Fields)
                {
                    var addr = Address + field.Offset;

                    if (field.IsPointer)
                    {
                        if (field.Size == 4)
                            addr = client.DataSpaces.ReadVirtual<int>(addr);
                        else
                            addr = client.DataSpaces.ReadVirtual<long>(addr);
                    }

                    results.Add(DbgField.New(addr, field, this));
                }

                return new DbgFieldCollection(results.ToArray());
            }
        }

        public DbgObject(long address, string type, DbgState state)
        {
            Address = address;
            Type = DbgType.New(type, state);
            this.state = state;
        }

        public DbgObject(long address, DbgType type)
        {
            Address = address;
            Type = type;
            state = type.GetState();
        }

        public DbgState GetState() => state;

        public DbgField this[string name] => Fields[name];

        public override string ToString()
        {
            return $"{Type} : 0x{Address:X}";
        }
    }
}
