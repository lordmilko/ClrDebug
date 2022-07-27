using System;
using System.Collections.Generic;
using System.Diagnostics;
using ClrDebug.DbgEng;
using DbgEngConsole;

namespace DbgEngTypedData.Custom
{
    /// <summary>
    /// Represents a type in a remote process.
    /// </summary>
    class DbgType
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DbgState state;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugClient client => state.Client;

        public string FullName => Module.Name + "!" + Name;

        public string Name { get; }

        public string DisplayName
        {
            get
            {
                if (Name.StartsWith("unsigned"))
                    return "U" + Name.Substring(Name.IndexOf(' ') + 1).ToUpper();

                if (Name.StartsWith("void*"))
                    return Name;

                if (BasicType == Custom.BasicType.WChar)
                    return "WCHAR";

                if (Tag == SymTag.PointerType && BaseType?.BasicType == Custom.BasicType.WChar)
                    return "WCHAR*";

                return FullName;
            }
        }

        /// <summary>
        /// Gets module in which this object's type is defined.
        /// </summary>
        public DbgModule Module { get; }

        /// <summary>
        /// Gets the type ID 
        /// </summary>
        public int TypeId { get; }

        public SymTag Tag { get; }

        /// <summary>
        /// Gets the base symbol type of the current type, e.g. if the current
        /// type is a pointer, the base type will be the type of value the pointer points to.
        /// </summary>
        public DbgType BaseType { get; }

        /// <summary>
        /// Gets the fundamental type this type represents, e.g. an integer, etc.
        /// </summary>
        public BasicType? BasicType { get; }

        public DbgFieldInfo[] Fields
        {
            get
            {
                var fields = new List<DbgFieldInfo>();

                state.WinDbgAPI.Ioctl().TryDumpSymbolInfo(FullName, DBG_DUMP.NO_PRINT | DBG_DUMP.CALL_FOR_EACH, callbackRoutine: (fieldPtr, ctx) =>
                {
                    var dbgField = new DbgFieldInfo(fieldPtr, Module.Base, client);

                    fields.Add(dbgField);

                    return 0;
                });

                return fields.ToArray();
            }
        }

        public static DbgType New(string expr, DbgState state)
        {
            var result = state.Client.Symbols.GetSymbolTypeId(expr);

            return New(result.Module, result.TypeId, state);
        }

        public static DbgType New(long moduleBase, int typeId, DbgState state)
        {
            var tag = GetSymTag(moduleBase, typeId, state);
            var baseId = GetTypeId(moduleBase, typeId, state);

            DbgType baseType = null;

            if (baseId != null)
                baseType = New(moduleBase, baseId.Value, state);

            //All struct fields (items of type Data) will havea base entry which is the original type. We don't need to store the fact it's a field
            //(if it is a field this type will be contained in a DbgField)
            if (tag == SymTag.Data && baseType != null)
                return baseType;

            return new DbgType(moduleBase, typeId, tag, baseType, state);
        }

        private static SymTag GetSymTag(long moduleBase, int typeId, DbgState state)
        {
            var result = NativeMethods.SymGetTypeInfo(
                state.ProcessHandle,
                moduleBase,
                typeId,
                IMAGEHLP_SYMBOL_TYPE_INFO.TI_GET_SYMTAG,
                out var info
            );

            if (!result)
                throw new InvalidOperationException($"Failed to get tag from module {moduleBase} type {typeId}");

            var tag = (SymTag)info.ToInt32();

            return tag;
        }

        private static int? GetTypeId(long moduleBase, int typeId, DbgState state)
        {
            var result = NativeMethods.SymGetTypeInfo(
                state.ProcessHandle,
                moduleBase,
                typeId,
                IMAGEHLP_SYMBOL_TYPE_INFO.TI_GET_TYPEID,
                out var info
            );

            if (!result)
                return null;

            return info.ToInt32();
        }

        protected DbgType(long moduleBase, int typeId, SymTag tag, DbgType baseType, DbgState state)
        {
            TypeId = typeId;
            Module = new DbgModule(moduleBase, state);
            Tag = tag;
            BaseType = baseType;
            this.state = state;

            Name = client.Symbols.GetTypeNameWide(moduleBase, typeId);

            if (tag == SymTag.BaseType)
            {
                if (TryGetTypeInfo(typeId, IMAGEHLP_SYMBOL_TYPE_INFO.TI_GET_BASETYPE, out var basicType))
                    BasicType = (BasicType) basicType;
            }
        }

        private bool TryGetTypeInfo(int typeId, IMAGEHLP_SYMBOL_TYPE_INFO typeInfo, out IntPtr info)
        {
            var result = NativeMethods.SymGetTypeInfo(
                state.ProcessHandle,
                Module.Base,
                typeId,
                typeInfo,
                out info
            );

            return result;
        }

        public DbgState GetState() => state;

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
