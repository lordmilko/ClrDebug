using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides a callback mechanism for reporting errors during the metadata merge.
    /// </summary>
    public class MetaDataError : ComObject<IMetaDataError>
    {
        public MetaDataError(IMetaDataError raw) : base(raw)
        {
        }

        #region IMetaDataError
        #region OnError

        /// <summary>
        /// Provides notification of errors that occur during the metadata merge.
        /// </summary>
        /// <param name="hrError">[in] The <see cref="HRESULT"/> error value returned to the calling method.</param>
        /// <param name="token">[in] The metadata token of the code object that was being merged when the error occurred.</param>
        public void OnError(HRESULT hrError, mdToken token)
        {
            HRESULT hr;

            if ((hr = TryOnError(hrError, token)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Provides notification of errors that occur during the metadata merge.
        /// </summary>
        /// <param name="hrError">[in] The <see cref="HRESULT"/> error value returned to the calling method.</param>
        /// <param name="token">[in] The metadata token of the code object that was being merged when the error occurred.</param>
        public HRESULT TryOnError(HRESULT hrError, mdToken token)
        {
            /*HRESULT OnError(HRESULT hrError, mdToken token);*/
            return Raw.OnError(hrError, token);
        }

        #endregion
        #endregion
    }
}