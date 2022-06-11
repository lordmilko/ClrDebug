using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class HostSecurityContext : ComObject<IHostSecurityContext>
    {
        public HostSecurityContext(IHostSecurityContext raw) : base(raw)
        {
        }

        #region IHostSecurityContext
        #region Capture

        public HostSecurityContext Capture()
        {
            HRESULT hr;
            HostSecurityContext ppClonedContextResult;

            if ((hr = TryCapture(out ppClonedContextResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppClonedContextResult;
        }

        public HRESULT TryCapture(out HostSecurityContext ppClonedContextResult)
        {
            /*HRESULT Capture([Out, MarshalAs(UnmanagedType.Interface)] out IHostSecurityContext ppClonedContext);*/
            IHostSecurityContext ppClonedContext;
            HRESULT hr = Raw.Capture(out ppClonedContext);

            if (hr == HRESULT.S_OK)
                ppClonedContextResult = new HostSecurityContext(ppClonedContext);
            else
                ppClonedContextResult = default(HostSecurityContext);

            return hr;
        }

        #endregion
        #endregion
    }
}