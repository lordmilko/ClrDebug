using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng;

namespace DbgEngTypedData.Custom
{
    class DbgFieldInfo
    {
        public string Name { get; }

        public long Offset { get; }

        public int Size { get; }

        public BitVector32 Flags { get; }

        public DbgType Type { get; }

        public bool IsPointer => (Flags.Data & 0x0001) != 0;
        public bool IsPointer64 => (Flags.Data & 0x0002) != 0;
        public bool IsArray => (Flags.Data & 0x0004) != 0;
        public bool IsStruct => (Flags.Data & 0x0008) != 0;
        public bool IsConstant => (Flags.Data & 0x0010) != 0;
        public bool IsStatic => (Flags.Data & 0x0020) != 0;

        public DbgFieldInfo(IntPtr fieldPtr, long moduleBase, DbgState state)
        {
            var field = Marshal.PtrToStructure<FIELD_INFO>(fieldPtr);

            Name = Marshal.PtrToStringAnsi(field.fName);
            Offset = field.address;
            Size = field.size;
            Flags = field.Flags;

            Type = DbgType.New(moduleBase, field.TypeId, state);
        }

        public override string ToString()
        {
            return $"{Type} : {Name}";
        }
    }
}
