using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DbgEngTypedData.Custom
{
    //Represents the head list entry
    class DbgListEntryHead : DbgObject, IEnumerable<DbgObject>
    {
        public DbgListEntryHead(long address, DbgType type) : base(address, type)
        {
        }

        public List<DbgObject> ToList(string elementType, string pointerField)
        {
            var list = new List<DbgObject>();

            var enumerator = new TypedListEntryEnumerator(this, elementType, pointerField);

            while (enumerator.MoveNext())
                list.Add(enumerator.Current);

            return list;
        }

        public DbgObject[] ToArray(string elementType, string pointerField) => ToList(elementType, pointerField).ToArray();

        public IEnumerator<DbgObject> GetEnumerator() => new ListEntryEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #region ListEntryEnumerator

        private class ListEntryEnumerator : IEnumerator<DbgObject>
        {
            private DbgListEntryHead head;

            public ListEntryEnumerator(DbgListEntryHead head)
            {
                this.head = head;
            }

            public bool MoveNext()
            {
                DbgField next;

                //The head of the list is literally just a LIST_ENTRY; but every other LIST_ENTRY* we point to is in fact a member in some struct
                if (Current == null)
                    next = head["Flink"];
                else
                    next = Current["Flink"];

                //Observe how this check is performed regardless of whether we're currently processing the head's Flink or not. If the head points to itself, the list is empty!
                if (next.Address == head.Address)
                    return false;

                Current = next;
                return true;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            public DbgObject Current { get; private set; }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }

        #endregion
        #region TypedListEntryEnumerator

        private class TypedListEntryEnumerator : IEnumerator<DbgObject>
        {
            private DbgListEntryHead head;
            private DbgType elementType;
            private long offset;

            public TypedListEntryEnumerator(DbgListEntryHead head, string elementType, string pointerField)
            {
                this.head = head;
                this.elementType = DbgType.New(elementType, head.GetState());

                var field = this.elementType.Fields.SingleOrDefault(f => f.Name == pointerField);

                if (field == null)
                    throw new ArgumentException($"Could not find field '{pointerField}' on type '{elementType}'");

                offset = field.Offset;
            }

            public bool MoveNext()
            {
                DbgObject entry;

                if (Current == null)
                    entry = head["Flink"];
                else
                    entry = currentEntry["Flink"];

                //Observe how this check is performed regardless of whether we're currently processing the head's Flink or not. If the head points to itself, the list is empty!
                if (entry.Address == head.Address)
                    return false;

                currentEntry = entry;
                return true;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            //LIST_ENTRY
            private DbgObject currentEntry;

            public DbgObject Current
            {
                get
                {
                    if (currentEntry == null)
                        return null;

                    return new DbgObject(currentEntry.Address - offset, elementType);
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }

        #endregion
    }
}
