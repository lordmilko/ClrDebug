using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public abstract class CorDebugFrame : ComObject<ICorDebugFrame>
    {
        public static CorDebugFrame New(ICorDebugFrame value)
        {
            if (value is ICorDebugILFrame)
                return new CorDebugILFrame((ICorDebugILFrame) value);

            if (value is ICorDebugInternalFrame)
                return new CorDebugInternalFrame((ICorDebugInternalFrame) value);

            if (value is ICorDebugNativeFrame)
                return new CorDebugNativeFrame((ICorDebugNativeFrame) value);

            if (value is ICorDebugRuntimeUnwindableFrame)
                return new CorDebugRuntimeUnwindableFrame((ICorDebugRuntimeUnwindableFrame) value);

            throw new NotImplementedException("Encountered an ICorDebugFrame' interface of an unknown type. Cannot create wrapper type.");
        }

        protected CorDebugFrame(ICorDebugFrame raw) : base(raw)
        {
        }

        #region ICorDebugFrame
        #region GetChain

        public CorDebugChain Chain
        {
            get
            {
                HRESULT hr;
                CorDebugChain ppChainResult;

                if ((hr = TryGetChain(out ppChainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppChainResult;
            }
        }

        public HRESULT TryGetChain(out CorDebugChain ppChainResult)
        {
            /*HRESULT GetChain([MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);*/
            ICorDebugChain ppChain;
            HRESULT hr = Raw.GetChain(out ppChain);

            if (hr == HRESULT.S_OK)
                ppChainResult = new CorDebugChain(ppChain);
            else
                ppChainResult = default(CorDebugChain);

            return hr;
        }

        #endregion
        #region GetCode

        public CorDebugCode Code
        {
            get
            {
                HRESULT hr;
                CorDebugCode ppCodeResult;

                if ((hr = TryGetCode(out ppCodeResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppCodeResult;
            }
        }

        public HRESULT TryGetCode(out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetCode([MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
            ICorDebugCode ppCode;
            HRESULT hr = Raw.GetCode(out ppCode);

            if (hr == HRESULT.S_OK)
                ppCodeResult = new CorDebugCode(ppCode);
            else
                ppCodeResult = default(CorDebugCode);

            return hr;
        }

        #endregion
        #region GetFunction

        public CorDebugFunction Function
        {
            get
            {
                HRESULT hr;
                CorDebugFunction ppFunctionResult;

                if ((hr = TryGetFunction(out ppFunctionResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppFunctionResult;
            }
        }

        public HRESULT TryGetFunction(out CorDebugFunction ppFunctionResult)
        {
            /*HRESULT GetFunction([MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
            ICorDebugFunction ppFunction;
            HRESULT hr = Raw.GetFunction(out ppFunction);

            if (hr == HRESULT.S_OK)
                ppFunctionResult = new CorDebugFunction(ppFunction);
            else
                ppFunctionResult = default(CorDebugFunction);

            return hr;
        }

        #endregion
        #region GetFunctionToken

        public mdMethodDef FunctionToken
        {
            get
            {
                HRESULT hr;
                mdMethodDef pToken;

                if ((hr = TryGetFunctionToken(out pToken)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pToken;
            }
        }

        public HRESULT TryGetFunctionToken(out mdMethodDef pToken)
        {
            /*HRESULT GetFunctionToken(out mdMethodDef pToken);*/
            return Raw.GetFunctionToken(out pToken);
        }

        #endregion
        #region GetStackRange

        public GetStackRangeResult StackRange
        {
            get
            {
                HRESULT hr;
                GetStackRangeResult result;

                if ((hr = TryGetStackRange(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        public HRESULT TryGetStackRange(out GetStackRangeResult result)
        {
            /*HRESULT GetStackRange(out CORDB_ADDRESS pStart, out CORDB_ADDRESS pEnd);*/
            CORDB_ADDRESS pStart;
            CORDB_ADDRESS pEnd;
            HRESULT hr = Raw.GetStackRange(out pStart, out pEnd);

            if (hr == HRESULT.S_OK)
                result = new GetStackRangeResult(pStart, pEnd);
            else
                result = default(GetStackRangeResult);

            return hr;
        }

        #endregion
        #region GetCaller

        public CorDebugFrame Caller
        {
            get
            {
                HRESULT hr;
                CorDebugFrame ppFrameResult;

                if ((hr = TryGetCaller(out ppFrameResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppFrameResult;
            }
        }

        public HRESULT TryGetCaller(out CorDebugFrame ppFrameResult)
        {
            /*HRESULT GetCaller([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);*/
            ICorDebugFrame ppFrame;
            HRESULT hr = Raw.GetCaller(out ppFrame);

            if (hr == HRESULT.S_OK)
                ppFrameResult = CorDebugFrame.New(ppFrame);
            else
                ppFrameResult = default(CorDebugFrame);

            return hr;
        }

        #endregion
        #region GetCallee

        public CorDebugFrame Callee
        {
            get
            {
                HRESULT hr;
                CorDebugFrame ppFrameResult;

                if ((hr = TryGetCallee(out ppFrameResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppFrameResult;
            }
        }

        public HRESULT TryGetCallee(out CorDebugFrame ppFrameResult)
        {
            /*HRESULT GetCallee([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);*/
            ICorDebugFrame ppFrame;
            HRESULT hr = Raw.GetCallee(out ppFrame);

            if (hr == HRESULT.S_OK)
                ppFrameResult = CorDebugFrame.New(ppFrame);
            else
                ppFrameResult = default(CorDebugFrame);

            return hr;
        }

        #endregion
        #region CreateStepper

        public CorDebugStepper CreateStepper()
        {
            HRESULT hr;
            CorDebugStepper ppStepperResult;

            if ((hr = TryCreateStepper(out ppStepperResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppStepperResult;
        }

        public HRESULT TryCreateStepper(out CorDebugStepper ppStepperResult)
        {
            /*HRESULT CreateStepper([MarshalAs(UnmanagedType.Interface)] out ICorDebugStepper ppStepper);*/
            ICorDebugStepper ppStepper;
            HRESULT hr = Raw.CreateStepper(out ppStepper);

            if (hr == HRESULT.S_OK)
                ppStepperResult = new CorDebugStepper(ppStepper);
            else
                ppStepperResult = default(CorDebugStepper);

            return hr;
        }

        #endregion
        #endregion
    }
}