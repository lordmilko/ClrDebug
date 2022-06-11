using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class DebuggerThreadControl : ComObject<IDebuggerThreadControl>
    {
        public DebuggerThreadControl(IDebuggerThreadControl raw) : base(raw)
        {
        }

        #region IDebuggerThreadControl
        #region ThreadIsBlockingForDebugger

        public void ThreadIsBlockingForDebugger()
        {
            HRESULT hr;

            if ((hr = TryThreadIsBlockingForDebugger()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryThreadIsBlockingForDebugger()
        {
            /*HRESULT ThreadIsBlockingForDebugger();*/
            return Raw.ThreadIsBlockingForDebugger();
        }

        #endregion
        #region ReleaseAllRuntimeThreads

        public void ReleaseAllRuntimeThreads()
        {
            HRESULT hr;

            if ((hr = TryReleaseAllRuntimeThreads()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryReleaseAllRuntimeThreads()
        {
            /*HRESULT ReleaseAllRuntimeThreads();*/
            return Raw.ReleaseAllRuntimeThreads();
        }

        #endregion
        #region StartBlockingForDebugger

        public void StartBlockingForDebugger(uint dwUnused)
        {
            HRESULT hr;

            if ((hr = TryStartBlockingForDebugger(dwUnused)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStartBlockingForDebugger(uint dwUnused)
        {
            /*HRESULT StartBlockingForDebugger(uint dwUnused);*/
            return Raw.StartBlockingForDebugger(dwUnused);
        }

        #endregion
        #endregion
    }
}