using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugThread : ComObject<ICorDebugThread>
    {
        public CorDebugThread(ICorDebugThread raw) : base(raw)
        {
        }

        #region ICorDebugThread
        #region GetProcess

        public CorDebugProcess Process
        {
            get
            {
                HRESULT hr;
                CorDebugProcess ppProcessResult;

                if ((hr = TryGetProcess(out ppProcessResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppProcessResult;
            }
        }

        public HRESULT TryGetProcess(out CorDebugProcess ppProcessResult)
        {
            /*HRESULT GetProcess([MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.GetProcess(out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region GetID

        public uint Id
        {
            get
            {
                HRESULT hr;
                uint pdwThreadId;

                if ((hr = TryGetID(out pdwThreadId)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwThreadId;
            }
        }

        public HRESULT TryGetID(out uint pdwThreadId)
        {
            /*HRESULT GetID(out uint pdwThreadId);*/
            return Raw.GetID(out pdwThreadId);
        }

        #endregion
        #region GetHandle

        public IntPtr Handle
        {
            get
            {
                HRESULT hr;
                IntPtr phThreadHandle;

                if ((hr = TryGetHandle(out phThreadHandle)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return phThreadHandle;
            }
        }

        public HRESULT TryGetHandle(out IntPtr phThreadHandle)
        {
            /*HRESULT GetHandle(out IntPtr phThreadHandle);*/
            return Raw.GetHandle(out phThreadHandle);
        }

        #endregion
        #region GetAppDomain

        public CorDebugAppDomain AppDomain
        {
            get
            {
                HRESULT hr;
                CorDebugAppDomain ppAppDomainResult;

                if ((hr = TryGetAppDomain(out ppAppDomainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppAppDomainResult;
            }
        }

        public HRESULT TryGetAppDomain(out CorDebugAppDomain ppAppDomainResult)
        {
            /*HRESULT GetAppDomain([MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomain ppAppDomain);*/
            ICorDebugAppDomain ppAppDomain;
            HRESULT hr = Raw.GetAppDomain(out ppAppDomain);

            if (hr == HRESULT.S_OK)
                ppAppDomainResult = new CorDebugAppDomain(ppAppDomain);
            else
                ppAppDomainResult = default(CorDebugAppDomain);

            return hr;
        }

        #endregion
        #region GetDebugState

        public CorDebugThreadState DebugState
        {
            get
            {
                HRESULT hr;
                CorDebugThreadState pState;

                if ((hr = TryGetDebugState(out pState)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pState;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetDebugState(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetDebugState(out CorDebugThreadState pState)
        {
            /*HRESULT GetDebugState(out CorDebugThreadState pState);*/
            return Raw.GetDebugState(out pState);
        }

        public HRESULT TrySetDebugState(CorDebugThreadState state)
        {
            /*HRESULT SetDebugState([In] CorDebugThreadState state);*/
            return Raw.SetDebugState(state);
        }

        #endregion
        #region GetUserState

        public CorDebugUserState UserState
        {
            get
            {
                HRESULT hr;
                CorDebugUserState pState;

                if ((hr = TryGetUserState(out pState)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pState;
            }
        }

        public HRESULT TryGetUserState(out CorDebugUserState pState)
        {
            /*HRESULT GetUserState(out CorDebugUserState pState);*/
            return Raw.GetUserState(out pState);
        }

        #endregion
        #region GetCurrentException

        public CorDebugValue CurrentException
        {
            get
            {
                HRESULT hr;
                CorDebugValue ppExceptionObjectResult;

                if ((hr = TryGetCurrentException(out ppExceptionObjectResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppExceptionObjectResult;
            }
        }

        public HRESULT TryGetCurrentException(out CorDebugValue ppExceptionObjectResult)
        {
            /*HRESULT GetCurrentException([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppExceptionObject);*/
            ICorDebugValue ppExceptionObject;
            HRESULT hr = Raw.GetCurrentException(out ppExceptionObject);

            if (hr == HRESULT.S_OK)
                ppExceptionObjectResult = CorDebugValue.New(ppExceptionObject);
            else
                ppExceptionObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetActiveChain

        public CorDebugChain ActiveChain
        {
            get
            {
                HRESULT hr;
                CorDebugChain ppChainResult;

                if ((hr = TryGetActiveChain(out ppChainResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppChainResult;
            }
        }

        public HRESULT TryGetActiveChain(out CorDebugChain ppChainResult)
        {
            /*HRESULT GetActiveChain([MarshalAs(UnmanagedType.Interface)] out ICorDebugChain ppChain);*/
            ICorDebugChain ppChain;
            HRESULT hr = Raw.GetActiveChain(out ppChain);

            if (hr == HRESULT.S_OK)
                ppChainResult = new CorDebugChain(ppChain);
            else
                ppChainResult = default(CorDebugChain);

            return hr;
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
        #region GetObject

        public CorDebugValue Object
        {
            get
            {
                HRESULT hr;
                CorDebugValue ppObjectResult;

                if ((hr = TryGetObject(out ppObjectResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppObjectResult;
            }
        }

        public HRESULT TryGetObject(out CorDebugValue ppObjectResult)
        {
            /*HRESULT GetObject([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);*/
            ICorDebugValue ppObject;
            HRESULT hr = Raw.GetObject(out ppObject);

            if (hr == HRESULT.S_OK)
                ppObjectResult = CorDebugValue.New(ppObject);
            else
                ppObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region ClearCurrentException

        public void ClearCurrentException()
        {
            HRESULT hr;

            if ((hr = TryClearCurrentException()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryClearCurrentException()
        {
            /*HRESULT ClearCurrentException();*/
            return Raw.ClearCurrentException();
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
        #region EnumerateChains

        public CorDebugChainEnum EnumerateChains()
        {
            HRESULT hr;
            CorDebugChainEnum ppChainsResult;

            if ((hr = TryEnumerateChains(out ppChainsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppChainsResult;
        }

        public HRESULT TryEnumerateChains(out CorDebugChainEnum ppChainsResult)
        {
            /*HRESULT EnumerateChains([MarshalAs(UnmanagedType.Interface)] out ICorDebugChainEnum ppChains);*/
            ICorDebugChainEnum ppChains;
            HRESULT hr = Raw.EnumerateChains(out ppChains);

            if (hr == HRESULT.S_OK)
                ppChainsResult = new CorDebugChainEnum(ppChains);
            else
                ppChainsResult = default(CorDebugChainEnum);

            return hr;
        }

        #endregion
        #region CreateEval

        public CorDebugEval CreateEval()
        {
            HRESULT hr;
            CorDebugEval ppEvalResult;

            if ((hr = TryCreateEval(out ppEvalResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppEvalResult;
        }

        public HRESULT TryCreateEval(out CorDebugEval ppEvalResult)
        {
            /*HRESULT CreateEval([MarshalAs(UnmanagedType.Interface)] out ICorDebugEval ppEval);*/
            ICorDebugEval ppEval;
            HRESULT hr = Raw.CreateEval(out ppEval);

            if (hr == HRESULT.S_OK)
                ppEvalResult = new CorDebugEval(ppEval);
            else
                ppEvalResult = default(CorDebugEval);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugThread2

        public ICorDebugThread2 Raw2 => (ICorDebugThread2) Raw;

        #region GetConnectionID

        public uint ConnectionID
        {
            get
            {
                HRESULT hr;
                uint pdwConnectionId;

                if ((hr = TryGetConnectionID(out pdwConnectionId)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwConnectionId;
            }
        }

        public HRESULT TryGetConnectionID(out uint pdwConnectionId)
        {
            /*HRESULT GetConnectionID(out uint pdwConnectionId);*/
            return Raw2.GetConnectionID(out pdwConnectionId);
        }

        #endregion
        #region GetTaskID

        public ulong TaskID
        {
            get
            {
                HRESULT hr;
                ulong pTaskId;

                if ((hr = TryGetTaskID(out pTaskId)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pTaskId;
            }
        }

        public HRESULT TryGetTaskID(out ulong pTaskId)
        {
            /*HRESULT GetTaskID(out ulong pTaskId);*/
            return Raw2.GetTaskID(out pTaskId);
        }

        #endregion
        #region GetVolatileOSThreadID

        public uint VolatileOSThreadID
        {
            get
            {
                HRESULT hr;
                uint pdwTid;

                if ((hr = TryGetVolatileOSThreadID(out pdwTid)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwTid;
            }
        }

        public HRESULT TryGetVolatileOSThreadID(out uint pdwTid)
        {
            /*HRESULT GetVolatileOSThreadID(out uint pdwTid);*/
            return Raw2.GetVolatileOSThreadID(out pdwTid);
        }

        #endregion
        #region GetActiveFunctions

        public GetActiveFunctionsResult GetActiveFunctions(uint cFunctions)
        {
            HRESULT hr;
            GetActiveFunctionsResult result;

            if ((hr = TryGetActiveFunctions(cFunctions, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetActiveFunctions(uint cFunctions, out GetActiveFunctionsResult result)
        {
            /*HRESULT GetActiveFunctions([In] uint cFunctions, out uint pcFunctions,
            [MarshalAs(UnmanagedType.LPArray), In, Out] COR_ACTIVE_FUNCTION[] pFunctions);*/
            uint pcFunctions;
            COR_ACTIVE_FUNCTION[] pFunctions = null;
            HRESULT hr = Raw2.GetActiveFunctions(cFunctions, out pcFunctions, pFunctions);

            if (hr == HRESULT.S_OK)
                result = new GetActiveFunctionsResult(pcFunctions, pFunctions);
            else
                result = default(GetActiveFunctionsResult);

            return hr;
        }

        #endregion
        #region InterceptCurrentException

        public void InterceptCurrentException(ICorDebugFrame pFrame)
        {
            HRESULT hr;

            if ((hr = TryInterceptCurrentException(pFrame)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryInterceptCurrentException(ICorDebugFrame pFrame)
        {
            /*HRESULT InterceptCurrentException([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame);*/
            return Raw2.InterceptCurrentException(pFrame);
        }

        #endregion
        #endregion
        #region ICorDebugThread3

        public ICorDebugThread3 Raw3 => (ICorDebugThread3) Raw;

        #region CreateStackWalk

        public CorDebugStackWalk CreateStackWalk()
        {
            HRESULT hr;
            CorDebugStackWalk ppStackWalkResult;

            if ((hr = TryCreateStackWalk(out ppStackWalkResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppStackWalkResult;
        }

        public HRESULT TryCreateStackWalk(out CorDebugStackWalk ppStackWalkResult)
        {
            /*HRESULT CreateStackWalk([MarshalAs(UnmanagedType.Interface)] out ICorDebugStackWalk ppStackWalk);*/
            ICorDebugStackWalk ppStackWalk;
            HRESULT hr = Raw3.CreateStackWalk(out ppStackWalk);

            if (hr == HRESULT.S_OK)
                ppStackWalkResult = new CorDebugStackWalk(ppStackWalk);
            else
                ppStackWalkResult = default(CorDebugStackWalk);

            return hr;
        }

        #endregion
        #region GetActiveInternalFrames

        public GetActiveInternalFramesResult GetActiveInternalFrames(uint cInternalFrames)
        {
            HRESULT hr;
            GetActiveInternalFramesResult result;

            if ((hr = TryGetActiveInternalFrames(cInternalFrames, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetActiveInternalFrames(uint cInternalFrames, out GetActiveInternalFramesResult result)
        {
            /*HRESULT GetActiveInternalFrames(
            [In] uint cInternalFrames,
            out uint pcInternalFrames,
            [In, Out] IntPtr ppInternalFrames);*/
            uint pcInternalFrames;
            IntPtr ppInternalFrames = default(IntPtr);
            HRESULT hr = Raw3.GetActiveInternalFrames(cInternalFrames, out pcInternalFrames, ppInternalFrames);

            if (hr == HRESULT.S_OK)
                result = new GetActiveInternalFramesResult(pcInternalFrames, ppInternalFrames);
            else
                result = default(GetActiveInternalFramesResult);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugThread4

        public ICorDebugThread4 Raw4 => (ICorDebugThread4) Raw;

        #region GetBlockingObjects

        public CorDebugBlockingObjectEnum BlockingObjects
        {
            get
            {
                HRESULT hr;
                CorDebugBlockingObjectEnum ppBlockingObjectEnumResult;

                if ((hr = TryGetBlockingObjects(out ppBlockingObjectEnumResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppBlockingObjectEnumResult;
            }
        }

        public HRESULT TryGetBlockingObjects(out CorDebugBlockingObjectEnum ppBlockingObjectEnumResult)
        {
            /*HRESULT GetBlockingObjects(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugBlockingObjectEnum ppBlockingObjectEnum);*/
            ICorDebugBlockingObjectEnum ppBlockingObjectEnum;
            HRESULT hr = Raw4.GetBlockingObjects(out ppBlockingObjectEnum);

            if (hr == HRESULT.S_OK)
                ppBlockingObjectEnumResult = new CorDebugBlockingObjectEnum(ppBlockingObjectEnum);
            else
                ppBlockingObjectEnumResult = default(CorDebugBlockingObjectEnum);

            return hr;
        }

        #endregion
        #region GetCurrentCustomDebuggerNotification

        public CorDebugValue CurrentCustomDebuggerNotification
        {
            get
            {
                HRESULT hr;
                CorDebugValue ppNotificationObjectResult;

                if ((hr = TryGetCurrentCustomDebuggerNotification(out ppNotificationObjectResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppNotificationObjectResult;
            }
        }

        public HRESULT TryGetCurrentCustomDebuggerNotification(out CorDebugValue ppNotificationObjectResult)
        {
            /*HRESULT GetCurrentCustomDebuggerNotification(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppNotificationObject);*/
            ICorDebugValue ppNotificationObject;
            HRESULT hr = Raw4.GetCurrentCustomDebuggerNotification(out ppNotificationObject);

            if (hr == HRESULT.S_OK)
                ppNotificationObjectResult = CorDebugValue.New(ppNotificationObject);
            else
                ppNotificationObjectResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region HasUnhandledException

        public void HasUnhandledException()
        {
            HRESULT hr;

            if ((hr = TryHasUnhandledException()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryHasUnhandledException()
        {
            /*HRESULT HasUnhandledException();*/
            return Raw4.HasUnhandledException();
        }

        #endregion
        #endregion
    }
}