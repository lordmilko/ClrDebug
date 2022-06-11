using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugHandleValue : CorDebugReferenceValue
    {
        public CorDebugHandleValue(ICorDebugHandleValue raw) : base(raw)
        {
        }

        #region ICorDebugHandleValue

        public new ICorDebugHandleValue Raw => (ICorDebugHandleValue) base.Raw;

        #region GetHandleType

        public CorDebugHandleType HandleType
        {
            get
            {
                HRESULT hr;
                CorDebugHandleType pType;

                if ((hr = TryGetHandleType(out pType)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pType;
            }
        }

        public HRESULT TryGetHandleType(out CorDebugHandleType pType)
        {
            /*HRESULT GetHandleType(out CorDebugHandleType pType);*/
            return Raw.GetHandleType(out pType);
        }

        #endregion
        #region Dispose

        public void Dispose()
        {
            HRESULT hr;

            if ((hr = TryDispose()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDispose()
        {
            /*HRESULT Dispose();*/
            return Raw.Dispose();
        }

        #endregion
        #endregion
    }
}