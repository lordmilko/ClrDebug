namespace ClrDebug
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
        /// Throws an exception when a n<see cref="NTSTATUS"/> is not <see cref="NTSTATUS.STATUS_SUCCESS"/>.
        /// </summary>
        /// <param name="status">The <see cref="NTSTATUS"/> to process.</param>
        public static void ThrowOnNotOK(this NTSTATUS status)
        {
            if (status == NTSTATUS.STATUS_SUCCESS)
                return;

            ThrowOnFailed((HRESULT) ((int) status | FACILITY_NT_BIT));
        }

        /// <summary>
        /// Throws an exception when a <see cref="HRESULT"/> contains an error value.
        /// </summary>
        /// <param name="hr">The <see cref="HRESULT"/> to process.</param>
        /// <returns>The original <see cref="HRESULT"/> that was passed to this method.</returns>
        /// <exception cref="DebugException">The <see cref="HRESULT"/> contains an error value.</exception>
        public static HRESULT ThrowOnFailed(this HRESULT hr)
        {
            //We explicitly only allow these values. There are a number of "warning" HRESULT codes
            //that function in the same vein as S_FALSE. These signify there's something you need
            //to be aware of, and so unlike SUCCEEDED(), we treat them as errors.
            if (hr == HRESULT.S_OK || hr == HRESULT.S_FALSE || hr == HRESULT.STATUS_SUCCESS)
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
