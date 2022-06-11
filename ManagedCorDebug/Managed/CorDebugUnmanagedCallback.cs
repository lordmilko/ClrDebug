using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugUnmanagedCallback : ComObject<ICorDebugUnmanagedCallback>
    {
        public CorDebugUnmanagedCallback(ICorDebugUnmanagedCallback raw) : base(raw)
        {
        }

        #region ICorDebugUnmanagedCallback
        #region DebugEvent

        public void DebugEvent(ulong pDebugEvent, int fOutOfBand)
        {
            HRESULT hr;

            if ((hr = TryDebugEvent(pDebugEvent, fOutOfBand)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDebugEvent(ulong pDebugEvent, int fOutOfBand)
        {
            /*HRESULT DebugEvent([In] ulong pDebugEvent, [In] int fOutOfBand);*/
            return Raw.DebugEvent(pDebugEvent, fOutOfBand);
        }

        #endregion
        #endregion
    }
}