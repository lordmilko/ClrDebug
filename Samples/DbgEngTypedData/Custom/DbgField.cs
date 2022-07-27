using System;
using System.Diagnostics;
using ClrDebug.DbgEng;

namespace DbgEngTypedData.Custom
{
    class DbgField
    {
        public long Address { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public DbgFieldInfo Info { get; }

        public string Name => Info.Name;

        public long Offset => Info.Offset;

        public DbgType Type => Info.Type;

        public object Value { get; }

        public DbgFieldCollection Fields => ((DbgObject) Value).Fields;

        public DbgObject Parent { get; }

        public static DbgField New(long address, DbgFieldInfo info, DbgObject parent)
        {
            if (info.Type.Tag == SymTag.BaseType)
                return new DbgField(address, info, parent, GetSimpleValue(address, info));
            else
            {
                DbgObject value;

                if (info.Type.Name == "_LIST_ENTRY" && parent.Type.Name != "_LIST_ENTRY")
                    value = new DbgListEntryHead(address, info.Type);
                else if (info.Type.Name == "_UNICODE_STRING")
                    value = new DbgUnicodeString(address, info.Type);
                else
                    value = new DbgObject(address, info.Type);

                return new DbgComplexField(address, info, parent, value);
            }
        }

        protected DbgField(long address, DbgFieldInfo info, DbgObject parent, object value)
        {
            Address = address;
            Info = info;
            Parent = parent;
            Value = value;
        }

        private static object GetSimpleValue(long address, DbgFieldInfo info)
        {
            var value = info.Type.GetState().Client.DataSpaces.ReadVirtual(address, info.Size);

            switch (info.Size)
            {
                case 1:
                    return value[0] == 1;
                case 2:
                    return BitConverter.ToUInt16(value, 0);
                case 4:
                    return BitConverter.ToUInt32(value, 0);
                case 8:
                    return BitConverter.ToUInt64(value, 0);
                default:
                    throw new NotImplementedException($"Don't know how to handle a simple value of {info.Size} bytes");
            }
        }

        public static implicit operator DbgObject(DbgField field) => (DbgObject) field.Value;

        public DbgField this[string name] => Fields[name];

        public override string ToString()
        {
            if (!(Value is DbgObject))
            {
                var v = Value;

                if (v is ushort || v is uint || v is ulong)
                    v = $"0x{Convert.ToUInt64(v).ToString("X")}";

                return $"{Info.Name} : {v}";
            }

            var value = $"0x{(Address.ToString("X"))}";

            if (Value is DbgUnicodeString)
                value = ((DbgUnicodeString) Value).String;

            return $"{Info.Type} : {Info.Name} : {value}";
        }
    }
}
