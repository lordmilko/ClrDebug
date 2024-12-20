using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Enumerates all of the services in a container.
    /// </summary>
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

        /// <summary>
        /// Gets the next service in the container and the service GUID under which it was registered.
        /// </summary>
        public DebugServiceEnumerator_GetNextResult Next
        {
            get
            {
                DebugServiceEnumerator_GetNextResult result;
                TryGetNext(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Gets the next service in the container and the service GUID under which it was registered.
        /// </summary>
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

        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
