using System;

namespace ClrDebug.DbgEng
{
    public class DebugServiceEnumerator : ComObject<IDebugServiceEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugServiceEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugServiceEnumerator(IDebugServiceEnumerator raw) : base(raw)
        {
        }

        #region IDebugServiceEnumerator
        #region Next

        public DebugServiceEnumerator_GetNextResult Next
        {
            get
            {
                DebugServiceEnumerator_GetNextResult result;
                TryGetNext(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetNext(out DebugServiceEnumerator_GetNextResult result)
        {
            /*HRESULT GetNext(
            [Out] out Guid serviceGuid,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer service);*/
            Guid serviceGuid;
            IDebugServiceLayer service;
            HRESULT hr = Raw.GetNext(out serviceGuid, out service);

            if (hr == HRESULT.S_OK)
                result = new DebugServiceEnumerator_GetNextResult(serviceGuid, service == null ? null : new DebugServiceLayer(service));
            else
                result = default(DebugServiceEnumerator_GetNextResult);

            return hr;
        }

        #endregion
        #region Reset

        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
