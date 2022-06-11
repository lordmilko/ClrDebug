using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugExceptionDebugEvent : CorDebugDebugEvent
    {
        public CorDebugExceptionDebugEvent(ICorDebugExceptionDebugEvent raw) : base(raw)
        {
        }

        #region ICorDebugExceptionDebugEvent

        public new ICorDebugExceptionDebugEvent Raw => (ICorDebugExceptionDebugEvent) base.Raw;

        #region GetStackPointer

        public ulong StackPointer
        {
            get
            {
                HRESULT hr;
                ulong pStackPointer;

                if ((hr = TryGetStackPointer(out pStackPointer)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pStackPointer;
            }
        }

        public HRESULT TryGetStackPointer(out ulong pStackPointer)
        {
            /*HRESULT GetStackPointer(out ulong pStackPointer);*/
            return Raw.GetStackPointer(out pStackPointer);
        }

        #endregion
        #region GetNativeIP

        public ulong NativeIP
        {
            get
            {
                HRESULT hr;
                ulong pIP;

                if ((hr = TryGetNativeIP(out pIP)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pIP;
            }
        }

        public HRESULT TryGetNativeIP(out ulong pIP)
        {
            /*HRESULT GetNativeIP(out ulong pIP);*/
            return Raw.GetNativeIP(out pIP);
        }

        #endregion
        #region GetFlags

        public CorDebugExceptionFlags Flags
        {
            get
            {
                HRESULT hr;
                CorDebugExceptionFlags pdwFlags;

                if ((hr = TryGetFlags(out pdwFlags)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwFlags;
            }
        }

        public HRESULT TryGetFlags(out CorDebugExceptionFlags pdwFlags)
        {
            /*HRESULT GetFlags(out CorDebugExceptionFlags pdwFlags);*/
            return Raw.GetFlags(out pdwFlags);
        }

        #endregion
        #endregion
    }
}