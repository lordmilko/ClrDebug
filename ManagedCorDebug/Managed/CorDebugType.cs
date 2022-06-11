using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugType : ComObject<ICorDebugType>
    {
        public CorDebugType(ICorDebugType raw) : base(raw)
        {
        }

        #region ICorDebugType
        #region GetType

        public CorElementType Type
        {
            get
            {
                HRESULT hr;
                CorElementType ty;

                if ((hr = TryGetType(out ty)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ty;
            }
        }

        public HRESULT TryGetType(out CorElementType ty)
        {
            /*HRESULT GetType(out CorElementType ty);*/
            return Raw.GetType(out ty);
        }

        #endregion
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
        #region GetFirstTypeParameter

        public CorDebugType FirstTypeParameter
        {
            get
            {
                HRESULT hr;
                CorDebugType valueResult;

                if ((hr = TryGetFirstTypeParameter(out valueResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return valueResult;
            }
        }

        public HRESULT TryGetFirstTypeParameter(out CorDebugType valueResult)
        {
            /*HRESULT GetFirstTypeParameter([MarshalAs(UnmanagedType.Interface)] out ICorDebugType value);*/
            ICorDebugType value;
            HRESULT hr = Raw.GetFirstTypeParameter(out value);

            if (hr == HRESULT.S_OK)
                valueResult = new CorDebugType(value);
            else
                valueResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #region GetBase

        public CorDebugType Base
        {
            get
            {
                HRESULT hr;
                CorDebugType pBaseResult;

                if ((hr = TryGetBase(out pBaseResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pBaseResult;
            }
        }

        public HRESULT TryGetBase(out CorDebugType pBaseResult)
        {
            /*HRESULT GetBase([MarshalAs(UnmanagedType.Interface)] out ICorDebugType pBase);*/
            ICorDebugType pBase;
            HRESULT hr = Raw.GetBase(out pBase);

            if (hr == HRESULT.S_OK)
                pBaseResult = new CorDebugType(pBase);
            else
                pBaseResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #region GetRank

        public uint Rank
        {
            get
            {
                HRESULT hr;
                uint pnRank;

                if ((hr = TryGetRank(out pnRank)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnRank;
            }
        }

        public HRESULT TryGetRank(out uint pnRank)
        {
            /*HRESULT GetRank(out uint pnRank);*/
            return Raw.GetRank(out pnRank);
        }

        #endregion
        #region EnumerateTypeParameters

        public CorDebugTypeEnum EnumerateTypeParameters()
        {
            HRESULT hr;
            CorDebugTypeEnum ppTyParEnumResult;

            if ((hr = TryEnumerateTypeParameters(out ppTyParEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppTyParEnumResult;
        }

        public HRESULT TryEnumerateTypeParameters(out CorDebugTypeEnum ppTyParEnumResult)
        {
            /*HRESULT EnumerateTypeParameters([MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTyParEnum);*/
            ICorDebugTypeEnum ppTyParEnum;
            HRESULT hr = Raw.EnumerateTypeParameters(out ppTyParEnum);

            if (hr == HRESULT.S_OK)
                ppTyParEnumResult = new CorDebugTypeEnum(ppTyParEnum);
            else
                ppTyParEnumResult = default(CorDebugTypeEnum);

            return hr;
        }

        #endregion
        #region GetStaticFieldValue

        public CorDebugValue GetStaticFieldValue(mdFieldDef fieldDef, ICorDebugFrame pFrame)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetStaticFieldValue(fieldDef, pFrame, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetStaticFieldValue(mdFieldDef fieldDef, ICorDebugFrame pFrame, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetStaticFieldValue([In] mdFieldDef fieldDef, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetStaticFieldValue(fieldDef, pFrame, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugType2

        public ICorDebugType2 Raw2 => (ICorDebugType2) Raw;

        #region GetTypeID

        public COR_TYPEID TypeID
        {
            get
            {
                HRESULT hr;
                COR_TYPEID id;

                if ((hr = TryGetTypeID(out id)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return id;
            }
        }

        public HRESULT TryGetTypeID(out COR_TYPEID id)
        {
            /*HRESULT GetTypeID(out COR_TYPEID id);*/
            return Raw2.GetTypeID(out id);
        }

        #endregion
        #endregion
    }
}