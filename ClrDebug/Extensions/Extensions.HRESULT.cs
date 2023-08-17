﻿namespace ClrDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Throws an exception when a <see cref="HRESULT"/> is <see cref="HRESULT.S_FALSE"/> or contains an error value.
        /// </summary>
        /// <param name="hr">The <see cref="HRESULT"/> to process.</param>
        /// <exception cref="DebugException">The <see cref="HRESULT"/> is <see cref="HRESULT.S_FALSE"/> or contains an error value.</exception>
        public static void ThrowOnNotOK(this HRESULT hr)
        {
            if (hr == HRESULT.S_FALSE)
                throw new DebugException(hr);

            ThrowOnFailed(hr);
        }

        /// <summary>
        /// Throws an exception when a <see cref="HRESULT"/> contains an error value.
        /// </summary>
        /// <param name="hr">The <see cref="HRESULT"/> to process.</param>
        /// <returns>The original <see cref="HRESULT"/> that was passed to this method.</returns>
        /// <exception cref="DebugException">The <see cref="HRESULT"/> contains an error value.</exception>
        public static HRESULT ThrowOnFailed(this HRESULT hr)
        {
            if (hr == HRESULT.S_OK || hr == HRESULT.S_FALSE)
                return hr;

            throw new DebugException(hr);
        }

        /// <summary>
        /// Throws an exception when a <see cref="HostStatusCode"/> is not exactly <see cref="HostStatusCode.Success"/> or contains an error value.
        /// </summary>
        /// <param name="status">The <see cref="HostStatusCode"/> to process.</param>
        /// <exception cref="HostingException">The <see cref="HostStatusCode"/> is not <see cref="HostStatusCode.Success"/> or contains an error value.</exception>
        public static void ThrowOnNotOK(this HostStatusCode status)
        {
            if (status > 0)
                throw new HostingException(status);

            ThrowOnFailed(status);
        }

        /// <summary>
        /// Throws an exception when a <see cref="HostStatusCode"/> contains an error value.
        /// </summary>
        /// <param name="status">The <see cref="HostStatusCode"/> to process.</param>
        /// <returns>The original <see cref="HostStatusCode"/> that was passed to this method.</returns>
        /// <exception cref="HostingException">The <see cref="HostStatusCode"/> contains an error value.</exception>
        public static HostStatusCode ThrowOnFailed(this HostStatusCode status)
        {
            if ((int) status >= 0)
                return status;

            throw new HostingException(status);
        }
    }
}
