﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ClrDebug
{
    public class SOSStackRefEnum : IEnumerable<SOSStackRefData>, IEnumerator<SOSStackRefData>
    {
        public ISOSStackRefEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SOSStackRefEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SOSStackRefEnum(ISOSStackRefEnum raw)
        {
            Raw = raw;
        }

        #region EnumerateErrors

        public SOSStackRefError[] Errors => EnumerateErrors().ToArray();

        public SOSStackRefErrorEnum EnumerateErrors()
        {
            SOSStackRefErrorEnum ppEnumResult;
            TryEnumerateErrors(out ppEnumResult).ThrowOnNotOK();

            return ppEnumResult;
        }

        public HRESULT TryEnumerateErrors(out SOSStackRefErrorEnum ppEnumResult)
        {
            /*HRESULT EnumerateErrors(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISOSStackRefErrorEnum ppEnum);*/
            ISOSStackRefErrorEnum ppEnum;
            HRESULT hr = Raw.EnumerateErrors(out ppEnum);

            if (hr == HRESULT.S_OK)
                ppEnumResult = ppEnum == null ? null : new SOSStackRefErrorEnum(ppEnum);
            else
                ppEnumResult = default(SOSStackRefErrorEnum);

            return hr;
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(SOSStackRefData);
        }

        #region IEnumerable

        public IEnumerator<SOSStackRefData> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public SOSStackRefData Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            SOSStackRefData result;
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
