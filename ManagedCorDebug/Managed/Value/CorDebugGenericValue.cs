using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugGenericValue : CorDebugValue
    {
        public CorDebugGenericValue(ICorDebugGenericValue raw) : base(raw)
        {
        }

        #region ICorDebugGenericValue

        public new ICorDebugGenericValue Raw => (ICorDebugGenericValue) base.Raw;

        #region GetValue

        public IntPtr Value
        {
            get
            {
                HRESULT hr;
                IntPtr pTo = default(IntPtr);

                if ((hr = TryGetValue(ref pTo)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pTo;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetValue(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetValue(ref IntPtr pTo)
        {
            /*HRESULT GetValue([Out] IntPtr pTo);*/
            return Raw.GetValue(pTo);
        }

        public HRESULT TrySetValue(IntPtr pFrom)
        {
            /*HRESULT SetValue([In] IntPtr pFrom);*/
            return Raw.SetValue(pFrom);
        }

        #endregion
        #endregion
    }
}