using System;

namespace ClrDebug
{
    /// <summary>
    /// Represents a frame on the current stack.
    /// </summary>
    public abstract class CorDebugFrame : ComObject<ICorDebugFrame>
    {
        public static CorDebugFrame New(ICorDebugFrame value)
        {
            if (value == null)
                return null;

            if (value is ICorDebugILFrame)
                return new CorDebugILFrame((ICorDebugILFrame) value);

            if (value is ICorDebugInternalFrame)
                return new CorDebugInternalFrame((ICorDebugInternalFrame) value);

            if (value is ICorDebugNativeFrame)
                return new CorDebugNativeFrame((ICorDebugNativeFrame) value);

            if (value is ICorDebugRuntimeUnwindableFrame)
                return new CorDebugRuntimeUnwindableFrame((ICorDebugRuntimeUnwindableFrame) value);

            throw new NotImplementedException("Encountered an 'ICorDebugFrame' interface of an unknown type. Cannot create wrapper type.");
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
                CorDebugChain ppChainResult;
                TryGetChain(out ppChainResult).ThrowOnNotOK();

                return ppChainResult;
            }
        }

        /// <summary>
        /// Gets a pointer to the chain this frame is a part of.
        /// </summary>
        /// <param name="ppChainResult">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the chain containing this frame.</param>
        public HRESULT TryGetChain(out CorDebugChain ppChainResult)
        {
            /*HRESULT GetChain(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);*/
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
                CorDebugCode ppCodeResult;
                TryGetCode(out ppCodeResult).ThrowOnNotOK();

                return ppCodeResult;
            }
        }

        /// <summary>
        /// Gets a pointer to the code associated with this stack frame.
        /// </summary>
        /// <param name="ppCodeResult">[out] A pointer to the address of an <see cref="ICorDebugCode"/> object that represents the code associated with this frame.</param>
        public HRESULT TryGetCode(out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetCode(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
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
                CorDebugFunction ppFunctionResult;
                TryGetFunction(out ppFunctionResult).ThrowOnNotOK();

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
            /*HRESULT GetFunction(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
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
                mdMethodDef pToken;
                TryGetFunctionToken(out pToken).ThrowOnNotOK();

                return pToken;
            }
        }

        /// <summary>
        /// Gets the metadata token for the function that contains the code associated with this stack frame.
        /// </summary>
        /// <param name="pToken">[out] A pointer to an <see cref="mdMethodDef"/> token that references the metadata for the function.</param>
        public HRESULT TryGetFunctionToken(out mdMethodDef pToken)
        {
            /*HRESULT GetFunctionToken(
            [Out] out mdMethodDef pToken);*/
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
                GetStackRangeResult result;
                TryGetStackRange(out result).ThrowOnNotOK();

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
            /*HRESULT GetStackRange(
            [Out] out CORDB_ADDRESS pStart,
            [Out] out CORDB_ADDRESS pEnd);*/
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
                CorDebugFrame ppFrameResult;
                TryGetCaller(out ppFrameResult).ThrowOnNotOK();

                return ppFrameResult;
            }
        }

        /// <summary>
        /// Gets a pointer to the <see cref="ICorDebugFrame"/> object in the current chain that called this frame.
        /// </summary>
        /// <param name="ppFrameResult">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> object that represents the calling frame. This value is null if the called frame is the outermost frame in the current chain.</param>
        public HRESULT TryGetCaller(out CorDebugFrame ppFrameResult)
        {
            /*HRESULT GetCaller(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);*/
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
                CorDebugFrame ppFrameResult;
                TryGetCallee(out ppFrameResult).ThrowOnNotOK();

                return ppFrameResult;
            }
        }

        /// <summary>
        /// Gets a pointer to the <see cref="ICorDebugFrame"/> object in the current chain that this frame called.
        /// </summary>
        /// <param name="ppFrameResult">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> object that represents the called frame. This value is null if the calling frame is the innermost frame in the current chain.</param>
        public HRESULT TryGetCallee(out CorDebugFrame ppFrameResult)
        {
            /*HRESULT GetCallee(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);*/
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
            CorDebugStepper ppStepperResult;
            TryCreateStepper(out ppStepperResult).ThrowOnNotOK();

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
            /*HRESULT CreateStepper(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugStepper ppStepper);*/
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
