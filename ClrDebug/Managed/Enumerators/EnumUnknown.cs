﻿using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    public class EnumUnknown : IEnumerable<object>, IEnumerator<object>
    {
        public IEnumUnknown Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumUnknown"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public EnumUnknown(IEnumUnknown raw)
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

        public EnumUnknown Clone()
        {
            if (Raw == null)
                return this;

            IEnumUnknown clone;
            Raw.Clone(out clone);

            return new EnumUnknown(clone);
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
            else
                Current = default(object);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
