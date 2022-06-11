using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugModuleDebugEvent : CorDebugDebugEvent
    {
        public CorDebugModuleDebugEvent(ICorDebugModuleDebugEvent raw) : base(raw)
        {
        }

        #region ICorDebugModuleDebugEvent

        public new ICorDebugModuleDebugEvent Raw => (ICorDebugModuleDebugEvent) base.Raw;

        #region GetModule

        public CorDebugModule Module
        {
            get
            {
                HRESULT hr;
                CorDebugModule ppModuleResult;

                if ((hr = TryGetModule(out ppModuleResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppModuleResult;
            }
        }

        public HRESULT TryGetModule(out CorDebugModule ppModuleResult)
        {
            /*HRESULT GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);*/
            ICorDebugModule ppModule;
            HRESULT hr = Raw.GetModule(out ppModule);

            if (hr == HRESULT.S_OK)
                ppModuleResult = new CorDebugModule(ppModule);
            else
                ppModuleResult = default(CorDebugModule);

            return hr;
        }

        #endregion
        #endregion
    }
}