using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides a method for enumerating a collection of variants, including heterogeneous collections
    /// of objects and intrinsic types. Callers of this interface do not need to know the specific type
    /// (or types) of the elements in the collection.
    /// </summary>
    public class EnumVARIANT : IEnumerable<object>, IEnumerator<object>
    {
        public IEnumVARIANT Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumVARIANT"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public EnumVARIANT(IEnumVARIANT raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(object);
        }

        public EnumVARIANT Clone()
        {
            if (Raw == null)
                return this;

            IEnumVARIANT clone;
            Raw.Clone(out clone);

            return new EnumVARIANT(clone);
        }

        #region IEnumerable

        public IEnumerator<object> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public object Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            object result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result;

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
