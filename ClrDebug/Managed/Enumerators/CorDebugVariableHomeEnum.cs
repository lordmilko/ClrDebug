using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Provides an enumerator to the local variables and arguments in a function.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugVariableHomeEnum"/> interface implements the <see cref="ICorDebugEnum"/> interface. An <see cref="ICorDebugVariableHomeEnum"/> instance
    /// is populated with <see cref="ICorDebugVariableHome"/> instances by calling the <see cref="CorDebugCode.EnumerateVariableHomes"/>
    /// method. Each <see cref="ICorDebugVariableHome"/> instance in the collection represents a local variable or argument
    /// in a function. The <see cref="ICorDebugVariableHome"/> objects in the collection can be enumerated by calling the
    /// <see cref="MoveNext"/> method.
    /// </remarks>
    public class CorDebugVariableHomeEnum : IEnumerable<CorDebugVariableHome>, IEnumerator<CorDebugVariableHome>
    {
        public ICorDebugVariableHomeEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugVariableHomeEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugVariableHomeEnum(ICorDebugVariableHomeEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CorDebugVariableHome);
        }

        public CorDebugVariableHomeEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugVariableHomeEnum((ICorDebugVariableHomeEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CorDebugVariableHome> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CorDebugVariableHome Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            ICorDebugVariableHome result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new CorDebugVariableHome(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
