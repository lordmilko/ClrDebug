using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugMutableDataTarget : CorDebugDataTarget
    {
        public CorDebugMutableDataTarget(ICorDebugMutableDataTarget raw) : base(raw)
        {
        }

        #region ICorDebugMutableDataTarget

        public new ICorDebugMutableDataTarget Raw => (ICorDebugMutableDataTarget) base.Raw;

        #region WriteVirtual

        public void WriteVirtual(ulong address, IntPtr pBuffer, uint bytesRequested)
        {
            HRESULT hr;

            if ((hr = TryWriteVirtual(address, pBuffer, bytesRequested)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryWriteVirtual(ulong address, IntPtr pBuffer, uint bytesRequested)
        {
            /*HRESULT WriteVirtual([In] ulong address, [In] IntPtr pBuffer, [In] uint bytesRequested);*/
            return Raw.WriteVirtual(address, pBuffer, bytesRequested);
        }

        #endregion
        #region SetThreadContext

        public void SetThreadContext(uint dwThreadId, uint contextSize, IntPtr pContext)
        {
            HRESULT hr;

            if ((hr = TrySetThreadContext(dwThreadId, contextSize, pContext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetThreadContext(uint dwThreadId, uint contextSize, IntPtr pContext)
        {
            /*HRESULT SetThreadContext([In] uint dwThreadId, [In] uint contextSize, [In] IntPtr pContext);*/
            return Raw.SetThreadContext(dwThreadId, contextSize, pContext);
        }

        #endregion
        #region ContinueStatusChanged

        public void ContinueStatusChanged(uint dwThreadId, uint continueStatus)
        {
            HRESULT hr;

            if ((hr = TryContinueStatusChanged(dwThreadId, continueStatus)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryContinueStatusChanged(uint dwThreadId, uint continueStatus)
        {
            /*HRESULT ContinueStatusChanged([In] uint dwThreadId, [In] uint continueStatus);*/
            return Raw.ContinueStatusChanged(dwThreadId, continueStatus);
        }

        #endregion
        #endregion
    }
}