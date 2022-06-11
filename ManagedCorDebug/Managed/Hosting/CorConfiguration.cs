using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorConfiguration : ComObject<ICorConfiguration>
    {
        public CorConfiguration(ICorConfiguration raw) : base(raw)
        {
        }

        #region ICorConfiguration
        #region SetGCThreadControl

        public void SetGCThreadControl(IGCThreadControl pGCThreadControl)
        {
            HRESULT hr;

            if ((hr = TrySetGCThreadControl(pGCThreadControl)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetGCThreadControl(IGCThreadControl pGCThreadControl)
        {
            /*HRESULT SetGCThreadControl([In] [MarshalAs(UnmanagedType.Interface)] IGCThreadControl pGCThreadControl);*/
            return Raw.SetGCThreadControl(pGCThreadControl);
        }

        #endregion
        #region SetGCHostControl

        public void SetGCHostControl(IGCHostControl pGCHostControl)
        {
            HRESULT hr;

            if ((hr = TrySetGCHostControl(pGCHostControl)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetGCHostControl(IGCHostControl pGCHostControl)
        {
            /*HRESULT SetGCHostControl([In] [MarshalAs(UnmanagedType.Interface)] IGCHostControl pGCHostControl);*/
            return Raw.SetGCHostControl(pGCHostControl);
        }

        #endregion
        #region SetDebuggerThreadControl

        public void SetDebuggerThreadControl(IDebuggerThreadControl pDebuggerThreadControl)
        {
            HRESULT hr;

            if ((hr = TrySetDebuggerThreadControl(pDebuggerThreadControl)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetDebuggerThreadControl(IDebuggerThreadControl pDebuggerThreadControl)
        {
            /*HRESULT SetDebuggerThreadControl([In] [MarshalAs(UnmanagedType.Interface)] IDebuggerThreadControl pDebuggerThreadControl);*/
            return Raw.SetDebuggerThreadControl(pDebuggerThreadControl);
        }

        #endregion
        #region AddDebuggerSpecialThread

        public void AddDebuggerSpecialThread(uint dwSpecialThreadId)
        {
            HRESULT hr;

            if ((hr = TryAddDebuggerSpecialThread(dwSpecialThreadId)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryAddDebuggerSpecialThread(uint dwSpecialThreadId)
        {
            /*HRESULT AddDebuggerSpecialThread([In] uint dwSpecialThreadId);*/
            return Raw.AddDebuggerSpecialThread(dwSpecialThreadId);
        }

        #endregion
        #endregion
    }
}