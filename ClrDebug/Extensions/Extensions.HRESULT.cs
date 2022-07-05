namespace ClrDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Throws an exception when a <see cref="HRESULT"/> is <see cref="HRESULT.S_FALSE"/> or contains an error value.
        /// </summary>
        /// <param name="hr">The <see cref="HRESULT"/> to process.</param>
        /// <exception cref="CorDebugException">The <see cref="HRESULT"/> is <see cref="HRESULT.S_FALSE"/> or contains an error value.</exception>
        public static void ThrowOnNotOK(this HRESULT hr)
        {
            if (hr == HRESULT.S_FALSE)
                throw new CorDebugException(hr);

            ThrowOnFailed(hr);
        }

        /// <summary>
        /// Throws an exception when a <see cref="HRESULT"/> contains an error value.
        /// </summary>
        /// <param name="hr">The <see cref="HRESULT"/> to process.</param>
        /// <returns>The original <see cref="HRESULT"/> that was passed to this method.</returns>
        /// <exception cref="CorDebugException">The <see cref="HRESULT"/> contains an error value.</exception>
        public static HRESULT ThrowOnFailed(this HRESULT hr)
        {
            if (hr == HRESULT.S_OK || hr == HRESULT.S_FALSE)
                return hr;

            throw new CorDebugException(hr);
        }
    }
}
