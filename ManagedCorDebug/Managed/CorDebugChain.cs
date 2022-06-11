using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugChain : ComObject<ICorDebugChain>
    {
        public CorDebugChain(ICorDebugChain raw) : base(raw)
        {
        }

        #region ICorDebugChain
        #region GetThread

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
        #region GetCaller

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

        public HRESULT TryIsManaged(out int pManaged)
        {
            /*HRESULT IsManaged(out int pManaged);*/
            return Raw.IsManaged(out pManaged);
        }

        #endregion
        #region GetActiveFrame

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

        public HRESULT TryGetReason(out CorDebugChainReason pReason)
        {
            /*HRESULT GetReason(out CorDebugChainReason pReason);*/
            return Raw.GetReason(out pReason);
        }

        #endregion
        #region EnumerateFrames

        public CorDebugFrameEnum EnumerateFrames()
        {
            HRESULT hr;
            CorDebugFrameEnum ppFramesResult;

            if ((hr = TryEnumerateFrames(out ppFramesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppFramesResult;
        }

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