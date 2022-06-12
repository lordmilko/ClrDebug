using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a frame on the current stack.
    /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected CorDebugFrame(ICorDebugFrame raw) : base(raw)
        {
        }

        #region ICorDebugFrame
        #region Chain

        /// <summary>
        /// Gets a pointer to the chain this frame is a part of.
        /// </summary>
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

        /// <summary>
        /// Gets a pointer to the chain this frame is a part of.
        /// </summary>
        /// <param name="ppChainResult">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the chain containing this frame.</param>
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
        #region Code

        /// <summary>
        /// Gets a pointer to the code associated with this stack frame.
        /// </summary>
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

        /// <summary>
        /// Gets a pointer to the code associated with this stack frame.
        /// </summary>
        /// <param name="ppCodeResult">[out] A pointer to the address of an <see cref="ICorDebugCode"/> object that represents the code associated with this frame.</param>
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
        #region Function

        /// <summary>
        /// Gets the function that contains the code associated with this stack frame.
        /// </summary>
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

        /// <summary>
        /// Gets the function that contains the code associated with this stack frame.
        /// </summary>
        /// <param name="ppFunctionResult">[out] A pointer to the address of an <see cref="ICorDebugFunction"/> object that represents the function containing the code associated with this stack frame.</param>
        /// <remarks>
        /// The GetFunction method may fail if the frame is not associated with any particular function.
        /// </remarks>
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
        #region FunctionToken

        /// <summary>
        /// Gets the metadata token for the function that contains the code associated with this stack frame.
        /// </summary>
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

        /// <summary>
        /// Gets the metadata token for the function that contains the code associated with this stack frame.
        /// </summary>
        /// <param name="pToken">[out] A pointer to an <see cref="mdMethodDef"/> token that references the metadata for the function.</param>
        public HRESULT TryGetFunctionToken(out mdMethodDef pToken)
        {
            /*HRESULT GetFunctionToken(out mdMethodDef pToken);*/
            return Raw.GetFunctionToken(out pToken);
        }

        #endregion
        #region StackRange

        /// <summary>
        /// Gets the absolute address range of this stack frame.
        /// </summary>
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

        /// <summary>
        /// Gets the absolute address range of this stack frame.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The address range of the stack is useful for piecing together interleaved stack traces gathered from multiple debugging
        /// engines. The numeric range provides no information about the contents of the stack frame. It is meaningful only
        /// for comparison of stack frame locations.
        /// </remarks>
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
        #region Caller

        /// <summary>
        /// Gets a pointer to the <see cref="ICorDebugFrame"/> object in the current chain that called this frame.
        /// </summary>
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

        /// <summary>
        /// Gets a pointer to the <see cref="ICorDebugFrame"/> object in the current chain that called this frame.
        /// </summary>
        /// <param name="ppFrameResult">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> object that represents the calling frame. This value is null if the called frame is the outermost frame in the current chain.</param>
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
        #region Callee

        /// <summary>
        /// Gets a pointer to the <see cref="ICorDebugFrame"/> object in the current chain that this frame called.
        /// </summary>
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

        /// <summary>
        /// Gets a pointer to the <see cref="ICorDebugFrame"/> object in the current chain that this frame called.
        /// </summary>
        /// <param name="ppFrameResult">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> object that represents the called frame. This value is null if the calling frame is the innermost frame in the current chain.</param>
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

        /// <summary>
        /// Gets a stepper that allows the debugger to perform stepping operations relative to this <see cref="ICorDebugFrame"/>.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugStepper"/> object that allows the debugger to perform stepping operations relative to the current frame.</returns>
        /// <remarks>
        /// If the frame is not active, the stepper object will typically have to return to the frame before the step is completed.
        /// </remarks>
        public CorDebugStepper CreateStepper()
        {
            HRESULT hr;
            CorDebugStepper ppStepperResult;

            if ((hr = TryCreateStepper(out ppStepperResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppStepperResult;
        }

        /// <summary>
        /// Gets a stepper that allows the debugger to perform stepping operations relative to this <see cref="ICorDebugFrame"/>.
        /// </summary>
        /// <param name="ppStepperResult">[out] A pointer to the address of an <see cref="ICorDebugStepper"/> object that allows the debugger to perform stepping operations relative to the current frame.</param>
        /// <remarks>
        /// If the frame is not active, the stepper object will typically have to return to the frame before the step is completed.
        /// </remarks>
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