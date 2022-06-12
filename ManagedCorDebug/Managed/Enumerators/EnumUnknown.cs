using System.Collections;
using System.Collections.Generic;
using System.Deployment.Internal.Isolation;

namespace ManagedCorDebug
{
    public class EnumUnknown : IEnumerable<object>, IEnumerator<object>
    {
        private IEnumUnknown rawEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumUnknown"/> class.
        /// </summary>
        /// <param name="rawEnumerator">The raw COM interface that should be contained in this object.</param>
        public EnumUnknown(IEnumUnknown rawEnumerator)
        {
            this.rawEnumerator = rawEnumerator;
        }

        public void Reset()
        {
            if (rawEnumerator == null)
                return;

            rawEnumerator.Reset();
            Current = default(object);
        }

        public EnumUnknown Clone()
        {
            if (rawEnumerator == null)
                return this;

            IEnumUnknown clone;
            rawEnumerator.Clone(out clone);

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
            if (rawEnumerator == null)
                return false;

            int fetched;
            object result;
            var hr = rawEnumerator.Next(1, out result, out fetched);

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