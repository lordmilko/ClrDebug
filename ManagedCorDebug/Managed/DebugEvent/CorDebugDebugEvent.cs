using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public abstract class CorDebugDebugEvent : ComObject<ICorDebugDebugEvent>
    {
        public static CorDebugDebugEvent New(ICorDebugDebugEvent value)
        {
            if (value is ICorDebugExceptionDebugEvent)
                return new CorDebugExceptionDebugEvent((ICorDebugExceptionDebugEvent) value);

            if (value is ICorDebugModuleDebugEvent)
                return new CorDebugModuleDebugEvent((ICorDebugModuleDebugEvent) value);

            throw new NotImplementedException("Encountered an ICorDebugDebugEvent' interface of an unknown type. Cannot create wrapper type.");
        }

        protected CorDebugDebugEvent(ICorDebugDebugEvent raw) : base(raw)
        {
        }

        #region ICorDebugDebugEvent
        #region GetEventKind

        public CorDebugDebugEventKind EventKind
        {
            get
            {
                HRESULT hr;
                CorDebugDebugEventKind pDebugEventKind;

                if ((hr = TryGetEventKind(out pDebugEventKind)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pDebugEventKind;
            }
        }

        public HRESULT TryGetEventKind(out CorDebugDebugEventKind pDebugEventKind)
        {
            /*HRESULT GetEventKind(out CorDebugDebugEventKind pDebugEventKind);*/
            return Raw.GetEventKind(out pDebugEventKind);
        }

        #endregion
        #region GetThread

        public CorDebugThread Thread
        {
            get
            {
                HRESULT hr;
                CorDebugThread ppThreadResult;

                if ((hr = TryGetThread(out ppThreadResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppThreadResult;
            }
        }

        public HRESULT TryGetThread(out CorDebugThread ppThreadResult)
        {
            /*HRESULT GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);*/
            ICorDebugThread ppThread;
            HRESULT hr = Raw.GetThread(out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = new CorDebugThread(ppThread);
            else
                ppThreadResult = default(CorDebugThread);

            return hr;
        }

        #endregion
        #endregion
    }
}