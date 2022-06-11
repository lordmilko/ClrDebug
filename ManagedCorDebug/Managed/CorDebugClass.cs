using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugClass : ComObject<ICorDebugClass>
    {
        public CorDebugClass(ICorDebugClass raw) : base(raw)
        {
        }

        #region ICorDebugClass
        #region GetModule

        public CorDebugModule Module
        {
            get
            {
                HRESULT hr;
                CorDebugModule pModuleResult;

                if ((hr = TryGetModule(out pModuleResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pModuleResult;
            }
        }

        public HRESULT TryGetModule(out CorDebugModule pModuleResult)
        {
            /*HRESULT GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule pModule);*/
            ICorDebugModule pModule;
            HRESULT hr = Raw.GetModule(out pModule);

            if (hr == HRESULT.S_OK)
                pModuleResult = new CorDebugModule(pModule);
            else
                pModuleResult = default(CorDebugModule);

            return hr;
        }

        #endregion
        #region GetToken

        public mdTypeDef Token
        {
            get
            {
                HRESULT hr;
                mdTypeDef pTypeDef;

                if ((hr = TryGetToken(out pTypeDef)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pTypeDef;
            }
        }

        public HRESULT TryGetToken(out mdTypeDef pTypeDef)
        {
            /*HRESULT GetToken(out mdTypeDef pTypeDef);*/
            return Raw.GetToken(out pTypeDef);
        }

        #endregion
        #region GetStaticFieldValue

        public CorDebugValue GetStaticFieldValue(uint fieldDef, ICorDebugFrame pFrame)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetStaticFieldValue(fieldDef, pFrame, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetStaticFieldValue(uint fieldDef, ICorDebugFrame pFrame, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetStaticFieldValue([In] uint fieldDef, [MarshalAs(UnmanagedType.Interface), In]
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
        #region ICorDebugClass2

        public ICorDebugClass2 Raw2 => (ICorDebugClass2) Raw;

        #region GetParameterizedType

        public CorDebugType GetParameterizedType(CorElementType elementType, uint nTypeArgs, ICorDebugType ppTypeArgs)
        {
            HRESULT hr;
            CorDebugType ppTypeResult;

            if ((hr = TryGetParameterizedType(elementType, nTypeArgs, ppTypeArgs, out ppTypeResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppTypeResult;
        }

        public HRESULT TryGetParameterizedType(CorElementType elementType, uint nTypeArgs, ICorDebugType ppTypeArgs, out CorDebugType ppTypeResult)
        {
            /*HRESULT GetParameterizedType(
            [In] CorElementType elementType,
            [In] uint nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);*/
            ICorDebugType ppType;
            HRESULT hr = Raw2.GetParameterizedType(elementType, nTypeArgs, ref ppTypeArgs, out ppType);

            if (hr == HRESULT.S_OK)
                ppTypeResult = new CorDebugType(ppType);
            else
                ppTypeResult = default(CorDebugType);

            return hr;
        }

        #endregion
        #region SetJMCStatus

        public void SetJMCStatus(int bIsJustMyCode)
        {
            HRESULT hr;

            if ((hr = TrySetJMCStatus(bIsJustMyCode)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetJMCStatus(int bIsJustMyCode)
        {
            /*HRESULT SetJMCStatus([In] int bIsJustMyCode);*/
            return Raw2.SetJMCStatus(bIsJustMyCode);
        }

        #endregion
        #endregion
    }
}