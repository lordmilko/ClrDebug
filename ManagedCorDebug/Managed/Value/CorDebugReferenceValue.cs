using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public abstract class CorDebugReferenceValue : CorDebugValue
    {
        public static CorDebugReferenceValue New(ICorDebugReferenceValue value)
        {
            if (value is ICorDebugHandleValue)
                return new CorDebugHandleValue((ICorDebugHandleValue) value);

            throw new NotImplementedException("Encountered an ICorDebugReferenceValue' interface of an unknown type. Cannot create wrapper type.");
        }

        protected CorDebugReferenceValue(ICorDebugReferenceValue raw) : base(raw)
        {
        }

        #region ICorDebugReferenceValue

        public new ICorDebugReferenceValue Raw => (ICorDebugReferenceValue) base.Raw;

        #region IsNull

        public int IsNull
        {
            get
            {
                HRESULT hr;
                int pbNull;

                if ((hr = TryIsNull(out pbNull)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbNull;
            }
        }

        public HRESULT TryIsNull(out int pbNull)
        {
            /*HRESULT IsNull(out int pbNull);*/
            return Raw.IsNull(out pbNull);
        }

        #endregion
        #region GetValue

        public CORDB_ADDRESS Value
        {
            get
            {
                HRESULT hr;
                CORDB_ADDRESS pValue;

                if ((hr = TryGetValue(out pValue)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pValue;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetValue(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetValue(out CORDB_ADDRESS pValue)
        {
            /*HRESULT GetValue(out CORDB_ADDRESS pValue);*/
            return Raw.GetValue(out pValue);
        }

        public HRESULT TrySetValue(CORDB_ADDRESS value)
        {
            /*HRESULT SetValue([In] CORDB_ADDRESS value);*/
            return Raw.SetValue(value);
        }

        #endregion
        #region Dereference

        public CorDebugValue Dereference()
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryDereference(out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryDereference(out CorDebugValue ppValueResult)
        {
            /*HRESULT Dereference([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.Dereference(out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region DereferenceStrong

        public CorDebugValue DereferenceStrong()
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryDereferenceStrong(out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryDereferenceStrong(out CorDebugValue ppValueResult)
        {
            /*HRESULT DereferenceStrong([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.DereferenceStrong(out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
    }
}