using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public abstract class CorDebugObjectValue : CorDebugValue
    {
        public static CorDebugObjectValue New(ICorDebugObjectValue value)
        {
            if (value is ICorDebugContext)
                return new CorDebugContext((ICorDebugContext) value);

            throw new NotImplementedException("Encountered an ICorDebugObjectValue' interface of an unknown type. Cannot create wrapper type.");
        }

        protected CorDebugObjectValue(ICorDebugObjectValue raw) : base(raw)
        {
        }

        #region ICorDebugObjectValue

        public new ICorDebugObjectValue Raw => (ICorDebugObjectValue) base.Raw;

        #region GetClass

        public CorDebugClass Class
        {
            get
            {
                HRESULT hr;
                CorDebugClass ppClassResult;

                if ((hr = TryGetClass(out ppClassResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppClassResult;
            }
        }

        public HRESULT TryGetClass(out CorDebugClass ppClassResult)
        {
            /*HRESULT GetClass([MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);*/
            ICorDebugClass ppClass;
            HRESULT hr = Raw.GetClass(out ppClass);

            if (hr == HRESULT.S_OK)
                ppClassResult = new CorDebugClass(ppClass);
            else
                ppClassResult = default(CorDebugClass);

            return hr;
        }

        #endregion
        #region GetContext

        public CorDebugContext Context
        {
            get
            {
                HRESULT hr;
                CorDebugContext ppContextResult;

                if ((hr = TryGetContext(out ppContextResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppContextResult;
            }
        }

        public HRESULT TryGetContext(out CorDebugContext ppContextResult)
        {
            /*HRESULT GetContext([MarshalAs(UnmanagedType.Interface)] out ICorDebugContext ppContext);*/
            ICorDebugContext ppContext;
            HRESULT hr = Raw.GetContext(out ppContext);

            if (hr == HRESULT.S_OK)
                ppContextResult = new CorDebugContext(ppContext);
            else
                ppContextResult = default(CorDebugContext);

            return hr;
        }

        #endregion
        #region IsValueClass

        public int IsValueClass
        {
            get
            {
                HRESULT hr;
                int pbIsValueClass;

                if ((hr = TryIsValueClass(out pbIsValueClass)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbIsValueClass;
            }
        }

        public HRESULT TryIsValueClass(out int pbIsValueClass)
        {
            /*HRESULT IsValueClass(out int pbIsValueClass);*/
            return Raw.IsValueClass(out pbIsValueClass);
        }

        #endregion
        #region GetManagedCopy

        [Obsolete]
        public object ManagedCopy
        {
            get
            {
                HRESULT hr;
                object ppObject;

                if ((hr = TryGetManagedCopy(out ppObject)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppObject;
            }
        }

        [Obsolete]
        public HRESULT TryGetManagedCopy(out object ppObject)
        {
            /*HRESULT GetManagedCopy([MarshalAs(UnmanagedType.IUnknown)] out object ppObject);*/
            return Raw.GetManagedCopy(out ppObject);
        }

        #endregion
        #region GetFieldValue

        public CorDebugValue GetFieldValue(ICorDebugClass pClass, mdFieldDef fieldDef)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetFieldValue(pClass, fieldDef, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetFieldValue(ICorDebugClass pClass, mdFieldDef fieldDef, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetFieldValue([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass, [In] mdFieldDef fieldDef, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetFieldValue(pClass, fieldDef, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetVirtualMethod

        public CorDebugFunction GetVirtualMethod(uint memberRef)
        {
            HRESULT hr;
            CorDebugFunction ppFunctionResult;

            if ((hr = TryGetVirtualMethod(memberRef, out ppFunctionResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppFunctionResult;
        }

        public HRESULT TryGetVirtualMethod(uint memberRef, out CorDebugFunction ppFunctionResult)
        {
            /*HRESULT GetVirtualMethod([In] uint memberRef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
            ICorDebugFunction ppFunction;
            HRESULT hr = Raw.GetVirtualMethod(memberRef, out ppFunction);

            if (hr == HRESULT.S_OK)
                ppFunctionResult = new CorDebugFunction(ppFunction);
            else
                ppFunctionResult = default(CorDebugFunction);

            return hr;
        }

        #endregion
        #region SetFromManagedCopy

        [Obsolete]
        public void SetFromManagedCopy(object pObject)
        {
            HRESULT hr;

            if ((hr = TrySetFromManagedCopy(pObject)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TrySetFromManagedCopy(object pObject)
        {
            /*HRESULT SetFromManagedCopy([MarshalAs(UnmanagedType.IUnknown), In]
            object pObject);*/
            return Raw.SetFromManagedCopy(pObject);
        }

        #endregion
        #endregion
        #region ICorDebugObjectValue2

        public new ICorDebugObjectValue2 Raw2 => (ICorDebugObjectValue2) Raw;

        #region GetVirtualMethodAndType

        public GetVirtualMethodAndTypeResult GetVirtualMethodAndType(uint memberRef)
        {
            HRESULT hr;
            GetVirtualMethodAndTypeResult result;

            if ((hr = TryGetVirtualMethodAndType(memberRef, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetVirtualMethodAndType(uint memberRef, out GetVirtualMethodAndTypeResult result)
        {
            /*HRESULT GetVirtualMethodAndType(
            [In] uint memberRef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
            ICorDebugFunction ppFunction;
            ICorDebugType ppType;
            HRESULT hr = Raw2.GetVirtualMethodAndType(memberRef, out ppFunction, out ppType);

            if (hr == HRESULT.S_OK)
                result = new GetVirtualMethodAndTypeResult(new CorDebugFunction(ppFunction), new CorDebugType(ppType));
            else
                result = default(GetVirtualMethodAndTypeResult);

            return hr;
        }

        #endregion
        #endregion
    }
}