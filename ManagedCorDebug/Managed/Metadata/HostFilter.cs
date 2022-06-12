using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides a method to indicate that a specified token will be processed.
    /// </summary>
    public class HostFilter : ComObject<IHostFilter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HostFilter"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public HostFilter(IHostFilter raw) : base(raw)
        {
        }

        #region IHostFilter
        #region MarkToken

        /// <summary>
        /// Indicates that the specified metadata token will be processed.
        /// </summary>
        /// <param name="tk">[in] The metadata token to be processed.</param>
        /// <remarks>
        /// Typically, you want a token to be processed if it is in the metadata scope. The MarkToken method is passed to the
        /// metadata engine via the <see cref="MetaDataEmit.SetHandler"/> method.
        /// </remarks>
        public void MarkToken(mdToken tk)
        {
            HRESULT hr;

            if ((hr = TryMarkToken(tk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Indicates that the specified metadata token will be processed.
        /// </summary>
        /// <param name="tk">[in] The metadata token to be processed.</param>
        /// <remarks>
        /// Typically, you want a token to be processed if it is in the metadata scope. The MarkToken method is passed to the
        /// metadata engine via the <see cref="MetaDataEmit.SetHandler"/> method.
        /// </remarks>
        public HRESULT TryMarkToken(mdToken tk)
        {
            /*HRESULT MarkToken(mdToken tk);*/
            return Raw.MarkToken(tk);
        }

        #endregion
        #endregion
    }
}