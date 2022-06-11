using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class GCThreadControl : ComObject<IGCThreadControl>
    {
        public GCThreadControl(IGCThreadControl raw) : base(raw)
        {
        }

        #region IGCThreadControl
        #region ThreadIsBlockingForSuspension

        public void ThreadIsBlockingForSuspension()
        {
            HRESULT hr;

            if ((hr = TryThreadIsBlockingForSuspension()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryThreadIsBlockingForSuspension()
        {
            /*HRESULT ThreadIsBlockingForSuspension();*/
            return Raw.ThreadIsBlockingForSuspension();
        }

        #endregion
        #region SuspensionStarting

        public void SuspensionStarting()
        {
            HRESULT hr;

            if ((hr = TrySuspensionStarting()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySuspensionStarting()
        {
            /*HRESULT SuspensionStarting();*/
            return Raw.SuspensionStarting();
        }

        #endregion
        #region SuspensionEnding

        public void SuspensionEnding(uint generation)
        {
            HRESULT hr;

            if ((hr = TrySuspensionEnding(generation)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySuspensionEnding(uint generation)
        {
            /*HRESULT SuspensionEnding(uint Generation);*/
            return Raw.SuspensionEnding(generation);
        }

        #endregion
        #endregion
    }
}