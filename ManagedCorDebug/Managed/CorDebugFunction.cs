using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugFunction : ComObject<ICorDebugFunction>
    {
        public CorDebugFunction(ICorDebugFunction raw) : base(raw)
        {
        }

        #region ICorDebugFunction
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
        #region GetToken

        public mdMethodDef Token
        {
            get
            {
                HRESULT hr;
                mdMethodDef pMethodDef;

                if ((hr = TryGetToken(out pMethodDef)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pMethodDef;
            }
        }

        public HRESULT TryGetToken(out mdMethodDef pMethodDef)
        {
            /*HRESULT GetToken(out mdMethodDef pMethodDef);*/
            return Raw.GetToken(out pMethodDef);
        }

        #endregion
        #region GetILCode

        public CorDebugCode ILCode
        {
            get
            {
                HRESULT hr;
                CorDebugCode ppCodeResult;

                if ((hr = TryGetILCode(out ppCodeResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppCodeResult;
            }
        }

        public HRESULT TryGetILCode(out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetILCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
            ICorDebugCode ppCode;
            HRESULT hr = Raw.GetILCode(out ppCode);

            if (hr == HRESULT.S_OK)
                ppCodeResult = new CorDebugCode(ppCode);
            else
                ppCodeResult = default(CorDebugCode);

            return hr;
        }

        #endregion
        #region GetNativeCode

        public CorDebugCode NativeCode
        {
            get
            {
                HRESULT hr;
                CorDebugCode ppCodeResult;

                if ((hr = TryGetNativeCode(out ppCodeResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppCodeResult;
            }
        }

        public HRESULT TryGetNativeCode(out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetNativeCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
            ICorDebugCode ppCode;
            HRESULT hr = Raw.GetNativeCode(out ppCode);

            if (hr == HRESULT.S_OK)
                ppCodeResult = new CorDebugCode(ppCode);
            else
                ppCodeResult = default(CorDebugCode);

            return hr;
        }

        #endregion
        #region GetLocalVarSigToken

        public mdSignature LocalVarSigToken
        {
            get
            {
                HRESULT hr;
                mdSignature pmdSig;

                if ((hr = TryGetLocalVarSigToken(out pmdSig)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pmdSig;
            }
        }

        public HRESULT TryGetLocalVarSigToken(out mdSignature pmdSig)
        {
            /*HRESULT GetLocalVarSigToken(out mdSignature pmdSig);*/
            return Raw.GetLocalVarSigToken(out pmdSig);
        }

        #endregion
        #region GetCurrentVersionNumber

        public uint CurrentVersionNumber
        {
            get
            {
                HRESULT hr;
                uint pnCurrentVersion;

                if ((hr = TryGetCurrentVersionNumber(out pnCurrentVersion)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnCurrentVersion;
            }
        }

        public HRESULT TryGetCurrentVersionNumber(out uint pnCurrentVersion)
        {
            /*HRESULT GetCurrentVersionNumber(out uint pnCurrentVersion);*/
            return Raw.GetCurrentVersionNumber(out pnCurrentVersion);
        }

        #endregion
        #region CreateBreakpoint

        public CorDebugFunctionBreakpoint CreateBreakpoint()
        {
            HRESULT hr;
            CorDebugFunctionBreakpoint ppBreakpointResult;

            if ((hr = TryCreateBreakpoint(out ppBreakpointResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppBreakpointResult;
        }

        public HRESULT TryCreateBreakpoint(out CorDebugFunctionBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugFunctionBreakpoint ppBreakpoint);*/
            ICorDebugFunctionBreakpoint ppBreakpoint;
            HRESULT hr = Raw.CreateBreakpoint(out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = new CorDebugFunctionBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(CorDebugFunctionBreakpoint);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugFunction2

        public ICorDebugFunction2 Raw2 => (ICorDebugFunction2) Raw;

        #region GetJMCStatus

        public int JMCStatus
        {
            get
            {
                HRESULT hr;
                int pbIsJustMyCode;

                if ((hr = TryGetJMCStatus(out pbIsJustMyCode)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbIsJustMyCode;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetJMCStatus(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetJMCStatus(out int pbIsJustMyCode)
        {
            /*HRESULT GetJMCStatus(out int pbIsJustMyCode);*/
            return Raw2.GetJMCStatus(out pbIsJustMyCode);
        }

        public HRESULT TrySetJMCStatus(int bIsJustMyCode)
        {
            /*HRESULT SetJMCStatus([In] int bIsJustMyCode);*/
            return Raw2.SetJMCStatus(bIsJustMyCode);
        }

        #endregion
        #region GetVersionNumber

        public uint VersionNumber
        {
            get
            {
                HRESULT hr;
                uint pnVersion;

                if ((hr = TryGetVersionNumber(out pnVersion)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnVersion;
            }
        }

        public HRESULT TryGetVersionNumber(out uint pnVersion)
        {
            /*HRESULT GetVersionNumber(out uint pnVersion);*/
            return Raw2.GetVersionNumber(out pnVersion);
        }

        #endregion
        #region EnumerateNativeCode

        public CorDebugCodeEnum EnumerateNativeCode()
        {
            HRESULT hr;
            CorDebugCodeEnum ppCodeEnumResult;

            if ((hr = TryEnumerateNativeCode(out ppCodeEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppCodeEnumResult;
        }

        public HRESULT TryEnumerateNativeCode(out CorDebugCodeEnum ppCodeEnumResult)
        {
            /*HRESULT EnumerateNativeCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCodeEnum ppCodeEnum);*/
            ICorDebugCodeEnum ppCodeEnum;
            HRESULT hr = Raw2.EnumerateNativeCode(out ppCodeEnum);

            if (hr == HRESULT.S_OK)
                ppCodeEnumResult = new CorDebugCodeEnum(ppCodeEnum);
            else
                ppCodeEnumResult = default(CorDebugCodeEnum);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugFunction3

        public ICorDebugFunction3 Raw3 => (ICorDebugFunction3) Raw;

        #region GetActiveReJitRequestILCode

        public CorDebugILCode ActiveReJitRequestILCode
        {
            get
            {
                HRESULT hr;
                CorDebugILCode ppReJitedILCodeResult;

                if ((hr = TryGetActiveReJitRequestILCode(out ppReJitedILCodeResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppReJitedILCodeResult;
            }
        }

        public HRESULT TryGetActiveReJitRequestILCode(out CorDebugILCode ppReJitedILCodeResult)
        {
            /*HRESULT GetActiveReJitRequestILCode([MarshalAs(UnmanagedType.Interface)] ref ICorDebugILCode ppReJitedILCode);*/
            ICorDebugILCode ppReJitedILCode = default(ICorDebugILCode);
            HRESULT hr = Raw3.GetActiveReJitRequestILCode(ref ppReJitedILCode);

            if (hr == HRESULT.S_OK)
                ppReJitedILCodeResult = new CorDebugILCode(ppReJitedILCode);
            else
                ppReJitedILCodeResult = default(CorDebugILCode);

            return hr;
        }

        #endregion
        #endregion
    }
}