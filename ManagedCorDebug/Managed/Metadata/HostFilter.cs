using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class HostFilter : ComObject<IHostFilter>
    {
        public HostFilter(IHostFilter raw) : base(raw)
        {
        }

        #region IHostFilter
        #region MarkToken

        public void MarkToken(mdToken tk)
        {
            HRESULT hr;

            if ((hr = TryMarkToken(tk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryMarkToken(mdToken tk)
        {
            /*HRESULT MarkToken(mdToken tk);*/
            return Raw.MarkToken(tk);
        }

        #endregion
        #endregion
    }
}