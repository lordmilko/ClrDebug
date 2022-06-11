using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class GCHostControl : ComObject<IGCHostControl>
    {
        public GCHostControl(IGCHostControl raw) : base(raw)
        {
        }

        #region IGCHostControl
        #region RequestVirtualMemLimit

        public uint RequestVirtualMemLimit(uint sztMaxVirtualMemMB)
        {
            HRESULT hr;
            uint psztNewMaxVirtualMemMB = default(uint);

            if ((hr = TryRequestVirtualMemLimit(sztMaxVirtualMemMB, ref psztNewMaxVirtualMemMB)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return psztNewMaxVirtualMemMB;
        }

        public HRESULT TryRequestVirtualMemLimit(uint sztMaxVirtualMemMB, ref uint psztNewMaxVirtualMemMB)
        {
            /*HRESULT RequestVirtualMemLimit([In] uint sztMaxVirtualMemMB, [In, Out] ref uint psztNewMaxVirtualMemMB);*/
            return Raw.RequestVirtualMemLimit(sztMaxVirtualMemMB, ref psztNewMaxVirtualMemMB);
        }

        #endregion
        #endregion
    }
}