using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public abstract class CorDebugValue : ComObject<ICorDebugValue>
    {
        public static CorDebugValue New(ICorDebugValue value)
        {
            if (value is ICorDebugGenericValue)
                return new CorDebugGenericValue((ICorDebugGenericValue) value);

            if (value is ICorDebugArrayValue)
                return new CorDebugArrayValue((ICorDebugArrayValue) value);

            if (value is ICorDebugBoxValue)
                return new CorDebugBoxValue((ICorDebugBoxValue) value);

            if (value is ICorDebugStringValue)
                return new CorDebugStringValue((ICorDebugStringValue) value);

            if (value is ICorDebugContext)
                return new CorDebugContext((ICorDebugContext) value);

            if (value is ICorDebugHandleValue)
                return new CorDebugHandleValue((ICorDebugHandleValue) value);

            throw new NotImplementedException("Encountered an ICorDebugValue' interface of an unknown type. Cannot create wrapper type.");
        }

        protected CorDebugValue(ICorDebugValue raw) : base(raw)
        {
        }

        #region ICorDebugValue
        #region GetType

        public CorElementType Type
        {
            get
            {
                HRESULT hr;
                CorElementType pType;

                if ((hr = TryGetType(out pType)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pType;
            }
        }

        public HRESULT TryGetType(out CorElementType pType)
        {
            /*HRESULT GetType(out CorElementType pType);*/
            return Raw.GetType(out pType);
        }

        #endregion
        #region GetSize

        public uint Size
        {
            get
            {
                HRESULT hr;
                uint pSize;

                if ((hr = TryGetSize(out pSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pSize;
            }
        }

        public HRESULT TryGetSize(out uint pSize)
        {
            /*HRESULT GetSize(out uint pSize);*/
            return Raw.GetSize(out pSize);
        }

        #endregion
        #region GetAddress

        public CORDB_ADDRESS Address
        {
            get
            {
                HRESULT hr;
                CORDB_ADDRESS pAddress;

                if ((hr = TryGetAddress(out pAddress)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pAddress;
            }
        }

        public HRESULT TryGetAddress(out CORDB_ADDRESS pAddress)
        {
            /*HRESULT GetAddress(out CORDB_ADDRESS pAddress);*/
            return Raw.GetAddress(out pAddress);
        }

        #endregion
        #region CreateBreakpoint

        public CorDebugValueBreakpoint CreateBreakpoint()
        {
            HRESULT hr;
            CorDebugValueBreakpoint ppBreakpointResult;

            if ((hr = TryCreateBreakpoint(out ppBreakpointResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppBreakpointResult;
        }

        public HRESULT TryCreateBreakpoint(out CorDebugValueBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);*/
            ICorDebugValueBreakpoint ppBreakpoint;
            HRESULT hr = Raw.CreateBreakpoint(out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = new CorDebugValueBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(CorDebugValueBreakpoint);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugValue2

        public ICorDebugValue2 Raw2 => (ICorDebugValue2) Raw;

        #region GetExactType

        public CorDebugType ExactType
        {
            get
            {
                HRESULT hr;
                CorDebugType ppTypeResult;

                if ((hr = TryGetExactType(out ppTypeResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppTypeResult;
            }
        }

        public HRESULT TryGetExactType(out CorDebugType ppTypeResult)
        {
            /*HRESULT GetExactType([MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
            ICorDebugType ppType;
            HRESULT hr = Raw2.GetExactType(out ppType);

            if (hr == HRESULT.S_OK)
                ppTypeResult = new CorDebugType(ppType);
            else
                ppTypeResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugValue3

        public ICorDebugValue3 Raw3 => (ICorDebugValue3) Raw;

        #region GetSize64

        public ulong Size64
        {
            get
            {
                HRESULT hr;
                ulong pSize;

                if ((hr = TryGetSize64(out pSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pSize;
            }
        }

        public HRESULT TryGetSize64(out ulong pSize)
        {
            /*HRESULT GetSize64(out ulong pSize);*/
            return Raw3.GetSize64(out pSize);
        }

        #endregion
        #endregion
    }
}