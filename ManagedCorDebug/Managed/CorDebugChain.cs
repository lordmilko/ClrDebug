using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a segment of a physical or logical call stack.
    /// </summary>
    /// <remarks>
    /// The stack frames in a chain occupy contiguous stack space and share the same thread and context. A chain may represent
    /// either managed or unmanaged code chains. An empty <see cref="ICorDebugChain"/> instance represents an unmanaged code chain.
    /// </remarks>
    public class CorDebugChain : ComObject<ICorDebugChain>
    {
        public CorDebugChain(ICorDebugChain raw) : base(raw)
        {
        }

        #region ICorDebugChain
        #region GetThread

        /// <summary>
        /// Gets the physical thread this call chain is part of.
        /// </summary>
        public CorDebugThread Thread
        {
            get
            {
                HRESULT hr;
                CorDebugThread ppThreadResult;

                if ((hr = TryGetThread(out ppThreadResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppThreadResult;
            }
        }

        /// <summary>
        /// Gets the physical thread this call chain is part of.
        /// </summary>
        /// <param name="ppThreadResult">[out] A pointer to an <see cref="ICorDebugThread"/> object that represents the physical thread this call chain is part of.</param>
        public HRESULT TryGetThread(out CorDebugThread ppThreadResult)
        {
            /*HRESULT GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);*/
            ICorDebugThread ppThread;
            HRESULT hr = Raw.GetThread(out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = new CorDebugThread(ppThread);
            else
                ppThreadResult = default(CorDebugThread);

            return hr;
        }

        #endregion
        #region GetStackRange

        /// <summary>
        /// Gets the address range of the stack segment for this chain.
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
        /// Gets the address range of the stack segment for this chain.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The numeric range is meaningful only for comparison of stack frame locations. You cannot make any assumptions about
        /// what is actually stored on the stack.
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
        #region GetContext

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
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

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
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
        #region GetCaller

        /// <summary>
        /// Gets the chain that called this chain.
        /// </summary>
        public CorDebugChain Caller
        {
            get
            {
                HRESULT hr;
                CorDebugChain ppChainResult;

                if ((hr = TryGetCaller(out ppChainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppChainResult;
            }
        }

        /// <summary>
        /// Gets the chain that called this chain.
        /// </summary>
        /// <param name="ppChainResult">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the calling chain. If this chain was spontaneously called (as would be the case if this chain or the debugger initialized the call stack), ppChain will be null.</param>
        /// <remarks>
        /// The calling chain may be on a different thread, if the call was marshalled across threads.
        /// </remarks>
        public HRESULT TryGetCaller(out CorDebugChain ppChainResult)
        {
            /*HRESULT GetCaller([MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);*/
            ICorDebugChain ppChain;
            HRESULT hr = Raw.GetCaller(out ppChain);

            if (hr == HRESULT.S_OK)
                ppChainResult = new CorDebugChain(ppChain);
            else
                ppChainResult = default(CorDebugChain);

            return hr;
        }

        #endregion
        #region GetCallee

        /// <summary>
        /// Gets the chain that was called by this chain.
        /// </summary>
        public CorDebugChain Callee
        {
            get
            {
                HRESULT hr;
                CorDebugChain ppChainResult;

                if ((hr = TryGetCallee(out ppChainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppChainResult;
            }
        }

        /// <summary>
        /// Gets the chain that was called by this chain.
        /// </summary>
        /// <param name="ppChainResult">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the called chain. If this chain is currently executing (that is, if this chain is not waiting for a called chain to return), ppChain will be null.</param>
        /// <remarks>
        /// This chain will wait for the called chain to return before it resumes execution. The called chain may be on another
        /// thread in the case of cross-thread marshalled calls.
        /// </remarks>
        public HRESULT TryGetCallee(out CorDebugChain ppChainResult)
        {
            /*HRESULT GetCallee([MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);*/
            ICorDebugChain ppChain;
            HRESULT hr = Raw.GetCallee(out ppChain);

            if (hr == HRESULT.S_OK)
                ppChainResult = new CorDebugChain(ppChain);
            else
                ppChainResult = default(CorDebugChain);

            return hr;
        }

        #endregion
        #region GetPrevious

        /// <summary>
        /// Gets the previous chain of frames for the thread.
        /// </summary>
        public CorDebugChain Previous
        {
            get
            {
                HRESULT hr;
                CorDebugChain ppChainResult;

                if ((hr = TryGetPrevious(out ppChainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppChainResult;
            }
        }

        /// <summary>
        /// Gets the previous chain of frames for the thread.
        /// </summary>
        /// <param name="ppChainResult">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the previous chain of frames for this thread.<para/>
        /// If this chain is the first chain, ppChain is null.</param>
        public HRESULT TryGetPrevious(out CorDebugChain ppChainResult)
        {
            /*HRESULT GetPrevious([MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);*/
            ICorDebugChain ppChain;
            HRESULT hr = Raw.GetPrevious(out ppChain);

            if (hr == HRESULT.S_OK)
                ppChainResult = new CorDebugChain(ppChain);
            else
                ppChainResult = default(CorDebugChain);

            return hr;
        }

        #endregion
        #region GetNext

        /// <summary>
        /// Gets the next chain of frames for the thread.
        /// </summary>
        public CorDebugChain Next
        {
            get
            {
                HRESULT hr;
                CorDebugChain ppChainResult;

                if ((hr = TryGetNext(out ppChainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppChainResult;
            }
        }

        /// <summary>
        /// Gets the next chain of frames for the thread.
        /// </summary>
        /// <param name="ppChainResult">[out] A pointer to the address of an <see cref="ICorDebugChain"/> object that represents the next chain of frames for the thread.<para/>
        /// If this chain is the last chain, ppChain is null.</param>
        public HRESULT TryGetNext(out CorDebugChain ppChainResult)
        {
            /*HRESULT GetNext([MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);*/
            ICorDebugChain ppChain;
            HRESULT hr = Raw.GetNext(out ppChain);

            if (hr == HRESULT.S_OK)
                ppChainResult = new CorDebugChain(ppChain);
            else
                ppChainResult = default(CorDebugChain);

            return hr;
        }

        #endregion
        #region IsManaged

        /// <summary>
        /// Gets a value that indicates whether this chain is running managed code.
        /// </summary>
        public int IsManaged
        {
            get
            {
                HRESULT hr;
                int pManaged;

                if ((hr = TryIsManaged(out pManaged)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pManaged;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this chain is running managed code.
        /// </summary>
        /// <param name="pManaged">[out] true if this chain is running managed code; otherwise, false.</param>
        public HRESULT TryIsManaged(out int pManaged)
        {
            /*HRESULT IsManaged(out int pManaged);*/
            return Raw.IsManaged(out pManaged);
        }

        #endregion
        #region GetActiveFrame

        /// <summary>
        /// Gets the active (that is, most recent) frame on the chain.
        /// </summary>
        public CorDebugFrame ActiveFrame
        {
            get
            {
                HRESULT hr;
                CorDebugFrame ppFrameResult;

                if ((hr = TryGetActiveFrame(out ppFrameResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppFrameResult;
            }
        }

        /// <summary>
        /// Gets the active (that is, most recent) frame on the chain.
        /// </summary>
        /// <param name="ppFrameResult">[out] A pointer to the address of an <see cref="ICorDebugFrame"/> object that represents the active (that is, most recent) frame on the chain.</param>
        /// <remarks>
        /// If no managed stack frame is available, ppFrame is set to null. If the active frame is not available, the call
        /// will succeed and ppFrame will be null. Active frames will not be available for chains initiated due to CHAIN_ENTER_UNMANAGED,
        /// and for some chains initiated due to CHAIN_CLASS_INIT. See the <see cref="CorDebugChainReason"/> enumeration.
        /// </remarks>
        public HRESULT TryGetActiveFrame(out CorDebugFrame ppFrameResult)
        {
            /*HRESULT GetActiveFrame([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrame ppFrame);*/
            ICorDebugFrame ppFrame;
            HRESULT hr = Raw.GetActiveFrame(out ppFrame);

            if (hr == HRESULT.S_OK)
                ppFrameResult = CorDebugFrame.New(ppFrame);
            else
                ppFrameResult = default(CorDebugFrame);

            return hr;
        }

        #endregion
        #region GetRegisterSet

        /// <summary>
        /// Gets the register set for the active part of this chain.
        /// </summary>
        public CorDebugRegisterSet RegisterSet
        {
            get
            {
                HRESULT hr;
                CorDebugRegisterSet ppRegistersResult;

                if ((hr = TryGetRegisterSet(out ppRegistersResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppRegistersResult;
            }
        }

        /// <summary>
        /// Gets the register set for the active part of this chain.
        /// </summary>
        /// <param name="ppRegistersResult">[out] A pointer to the address of an <see cref="ICorDebugRegisterSet"/> object that represents the register set for the active part of this chain.</param>
        public HRESULT TryGetRegisterSet(out CorDebugRegisterSet ppRegistersResult)
        {
            /*HRESULT GetRegisterSet([MarshalAs(UnmanagedType.Interface)] out ICorDebugRegisterSet ppRegisters);*/
            ICorDebugRegisterSet ppRegisters;
            HRESULT hr = Raw.GetRegisterSet(out ppRegisters);

            if (hr == HRESULT.S_OK)
                ppRegistersResult = new CorDebugRegisterSet(ppRegisters);
            else
                ppRegistersResult = default(CorDebugRegisterSet);

            return hr;
        }

        #endregion
        #region GetReason

        /// <summary>
        /// Gets the reason for the genesis of this calling chain.
        /// </summary>
        public CorDebugChainReason Reason
        {
            get
            {
                HRESULT hr;
                CorDebugChainReason pReason;

                if ((hr = TryGetReason(out pReason)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pReason;
            }
        }

        /// <summary>
        /// Gets the reason for the genesis of this calling chain.
        /// </summary>
        /// <param name="pReason">[out] A pointer to a value (a bitwise combination) of the <see cref="CorDebugChainReason"/> enumeration that indicates the reason for the genesis of this calling chain.</param>
        public HRESULT TryGetReason(out CorDebugChainReason pReason)
        {
            /*HRESULT GetReason(out CorDebugChainReason pReason);*/
            return Raw.GetReason(out pReason);
        }

        #endregion
        #region EnumerateFrames

        /// <summary>
        /// Gets an enumerator that contains all the managed stack frames in the chain, starting with the most recent frame.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugFrameEnum"/> object that is the enumerator for the stack frames.</returns>
        /// <remarks>
        /// The chain represents the physical call stack for the thread. The EnumerateFrames method should be called only for
        /// managed chains. The debugging API does not provide methods for obtaining frames contained in unmanaged chains.
        /// The debugger must use other means to obtain this information.
        /// </remarks>
        public CorDebugFrameEnum EnumerateFrames()
        {
            HRESULT hr;
            CorDebugFrameEnum ppFramesResult;

            if ((hr = TryEnumerateFrames(out ppFramesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppFramesResult;
        }

        /// <summary>
        /// Gets an enumerator that contains all the managed stack frames in the chain, starting with the most recent frame.
        /// </summary>
        /// <param name="ppFramesResult">[out] A pointer to the address of an <see cref="ICorDebugFrameEnum"/> object that is the enumerator for the stack frames.</param>
        /// <remarks>
        /// The chain represents the physical call stack for the thread. The EnumerateFrames method should be called only for
        /// managed chains. The debugging API does not provide methods for obtaining frames contained in unmanaged chains.
        /// The debugger must use other means to obtain this information.
        /// </remarks>
        public HRESULT TryEnumerateFrames(out CorDebugFrameEnum ppFramesResult)
        {
            /*HRESULT EnumerateFrames([MarshalAs(UnmanagedType.Interface)] out ICorDebugFrameEnum ppFrames);*/
            ICorDebugFrameEnum ppFrames;
            HRESULT hr = Raw.EnumerateFrames(out ppFrames);

            if (hr == HRESULT.S_OK)
                ppFramesResult = new CorDebugFrameEnum(ppFrames);
            else
                ppFramesResult = default(CorDebugFrameEnum);

            return hr;
        }

        #endregion
        #endregion
    }
}