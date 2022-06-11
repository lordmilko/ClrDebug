using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRProfiling : ComObject<ICLRProfiling>
    {
        public CLRProfiling(ICLRProfiling raw) : base(raw)
        {
        }

        #region ICLRProfiling
        #region AttachProfiler

        public void AttachProfiler(uint dwProfileeProcessID, uint dwMillisecondsMax, Guid pClsidProfiler, string wszProfilerPath, IntPtr pvClientData, uint cbClientData)
        {
            HRESULT hr;

            if ((hr = TryAttachProfiler(dwProfileeProcessID, dwMillisecondsMax, pClsidProfiler, wszProfilerPath, pvClientData, cbClientData)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryAttachProfiler(uint dwProfileeProcessID, uint dwMillisecondsMax, Guid pClsidProfiler, string wszProfilerPath, IntPtr pvClientData, uint cbClientData)
        {
            /*HRESULT AttachProfiler(
            [In] uint dwProfileeProcessID,
            [In] uint dwMillisecondsMax,
            [In] ref Guid pClsidProfiler,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszProfilerPath,
            [In] IntPtr pvClientData,
            [In] uint cbClientData);*/
            return Raw.AttachProfiler(dwProfileeProcessID, dwMillisecondsMax, ref pClsidProfiler, wszProfilerPath, pvClientData, cbClientData);
        }

        #endregion
        #endregion
    }
}