using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    public class CorDebugManagedCallback : ComObject<ICorDebugManagedCallback>
    {
        public CorDebugManagedCallback(ICorDebugManagedCallback raw) : base(raw)
        {
        }

        #region ICorDebugManagedCallback
        #region Breakpoint

        public void Breakpoint(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint)
        {
            HRESULT hr;

            if ((hr = TryBreakpoint(pAppDomain, pThread, pBreakpoint)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryBreakpoint(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint)
        {
            /*HRESULT Breakpoint(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugBreakpoint pBreakpoint);*/
            return Raw.Breakpoint(pAppDomain, pThread, pBreakpoint);
        }

        #endregion
        #region StepComplete

        public void StepComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugStepper pStepper, CorDebugStepReason reason)
        {
            HRESULT hr;

            if ((hr = TryStepComplete(pAppDomain, pThread, pStepper, reason)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStepComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugStepper pStepper, CorDebugStepReason reason)
        {
            /*HRESULT StepComplete(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugStepper pStepper,
            [In] CorDebugStepReason reason);*/
            return Raw.StepComplete(pAppDomain, pThread, pStepper, reason);
        }

        #endregion
        #region Break

        public void Break(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            HRESULT hr;

            if ((hr = TryBreak(pAppDomain, thread)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryBreak(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            /*HRESULT Break([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);*/
            return Raw.Break(pAppDomain, thread);
        }

        #endregion
        #region Exception

        public void Exception(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int unhandled)
        {
            HRESULT hr;

            if ((hr = TryException(pAppDomain, pThread, unhandled)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryException(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int unhandled)
        {
            /*HRESULT Exception([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [In] int unhandled);*/
            return Raw.Exception(pAppDomain, pThread, unhandled);
        }

        #endregion
        #region EvalComplete

        public void EvalComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugEval pEval)
        {
            HRESULT hr;

            if ((hr = TryEvalComplete(pAppDomain, pThread, pEval)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEvalComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugEval pEval)
        {
            /*HRESULT EvalComplete([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugEval pEval);*/
            return Raw.EvalComplete(pAppDomain, pThread, pEval);
        }

        #endregion
        #region EvalException

        public void EvalException(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugEval pEval)
        {
            HRESULT hr;

            if ((hr = TryEvalException(pAppDomain, pThread, pEval)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEvalException(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugEval pEval)
        {
            /*HRESULT EvalException([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugEval pEval);*/
            return Raw.EvalException(pAppDomain, pThread, pEval);
        }

        #endregion
        #region CreateProcess

        public void CreateProcess(ICorDebugProcess pProcess)
        {
            HRESULT hr;

            if ((hr = TryCreateProcess(pProcess)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCreateProcess(ICorDebugProcess pProcess)
        {
            /*HRESULT CreateProcess([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);*/
            return Raw.CreateProcess(pProcess);
        }

        #endregion
        #region ExitProcess

        public void ExitProcess(ICorDebugProcess pProcess)
        {
            HRESULT hr;

            if ((hr = TryExitProcess(pProcess)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryExitProcess(ICorDebugProcess pProcess)
        {
            /*HRESULT ExitProcess([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);*/
            return Raw.ExitProcess(pProcess);
        }

        #endregion
        #region CreateThread

        public void CreateThread(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            HRESULT hr;

            if ((hr = TryCreateThread(pAppDomain, thread)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCreateThread(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            /*HRESULT CreateThread([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);*/
            return Raw.CreateThread(pAppDomain, thread);
        }

        #endregion
        #region ExitThread

        public void ExitThread(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            HRESULT hr;

            if ((hr = TryExitThread(pAppDomain, thread)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryExitThread(ICorDebugAppDomain pAppDomain, ICorDebugThread thread)
        {
            /*HRESULT ExitThread([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);*/
            return Raw.ExitThread(pAppDomain, thread);
        }

        #endregion
        #region LoadModule

        public void LoadModule(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule)
        {
            HRESULT hr;

            if ((hr = TryLoadModule(pAppDomain, pModule)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryLoadModule(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule)
        {
            /*HRESULT LoadModule([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule);*/
            return Raw.LoadModule(pAppDomain, pModule);
        }

        #endregion
        #region UnloadModule

        public void UnloadModule(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule)
        {
            HRESULT hr;

            if ((hr = TryUnloadModule(pAppDomain, pModule)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUnloadModule(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule)
        {
            /*HRESULT UnloadModule([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule);*/
            return Raw.UnloadModule(pAppDomain, pModule);
        }

        #endregion
        #region LoadClass

        public void LoadClass(ICorDebugAppDomain pAppDomain, ICorDebugClass c)
        {
            HRESULT hr;

            if ((hr = TryLoadClass(pAppDomain, c)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryLoadClass(ICorDebugAppDomain pAppDomain, ICorDebugClass c)
        {
            /*HRESULT LoadClass([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass c);*/
            return Raw.LoadClass(pAppDomain, c);
        }

        #endregion
        #region UnloadClass

        public void UnloadClass(ICorDebugAppDomain pAppDomain, ICorDebugClass c)
        {
            HRESULT hr;

            if ((hr = TryUnloadClass(pAppDomain, c)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUnloadClass(ICorDebugAppDomain pAppDomain, ICorDebugClass c)
        {
            /*HRESULT UnloadClass([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass c);*/
            return Raw.UnloadClass(pAppDomain, c);
        }

        #endregion
        #region DebuggerError

        public void DebuggerError(ICorDebugProcess pProcess, HRESULT errorHR, uint errorCode)
        {
            HRESULT hr;

            if ((hr = TryDebuggerError(pProcess, errorHR, errorCode)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDebuggerError(ICorDebugProcess pProcess, HRESULT errorHR, uint errorCode)
        {
            /*HRESULT DebuggerError([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Error), In] HRESULT errorHR, [In] uint errorCode);*/
            return Raw.DebuggerError(pProcess, errorHR, errorCode);
        }

        #endregion
        #region LogMessage

        public void LogMessage(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, LoggingLevelEnum lLevel, string pLogSwitchName, string pMessage)
        {
            HRESULT hr;

            if ((hr = TryLogMessage(pAppDomain, pThread, lLevel, pLogSwitchName, pMessage)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryLogMessage(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, LoggingLevelEnum lLevel, string pLogSwitchName, string pMessage)
        {
            /*HRESULT LogMessage(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] LoggingLevelEnum lLevel,
            [MarshalAs(UnmanagedType.LPWStr), In] string pLogSwitchName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pMessage);*/
            return Raw.LogMessage(pAppDomain, pThread, lLevel, pLogSwitchName, pMessage);
        }

        #endregion
        #region LogSwitch

        public void LogSwitch(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int lLevel, LogSwitchCallReason ulReason, string pLogSwitchName, string pParentName)
        {
            HRESULT hr;

            if ((hr = TryLogSwitch(pAppDomain, pThread, lLevel, ulReason, pLogSwitchName, pParentName)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryLogSwitch(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int lLevel, LogSwitchCallReason ulReason, string pLogSwitchName, string pParentName)
        {
            /*HRESULT LogSwitch(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] int lLevel,
            [In] LogSwitchCallReason ulReason,
            [MarshalAs(UnmanagedType.LPWStr)]  [In] string pLogSwitchName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pParentName);*/
            return Raw.LogSwitch(pAppDomain, pThread, lLevel, ulReason, pLogSwitchName, pParentName);
        }

        #endregion
        #region CreateAppDomain

        public void CreateAppDomain(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain)
        {
            HRESULT hr;

            if ((hr = TryCreateAppDomain(pProcess, pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCreateAppDomain(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain)
        {
            /*HRESULT CreateAppDomain([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);*/
            return Raw.CreateAppDomain(pProcess, pAppDomain);
        }

        #endregion
        #region ExitAppDomain

        public void ExitAppDomain(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain)
        {
            HRESULT hr;

            if ((hr = TryExitAppDomain(pProcess, pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryExitAppDomain(ICorDebugProcess pProcess, ICorDebugAppDomain pAppDomain)
        {
            /*HRESULT ExitAppDomain([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);*/
            return Raw.ExitAppDomain(pProcess, pAppDomain);
        }

        #endregion
        #region LoadAssembly

        public void LoadAssembly(ICorDebugAppDomain pAppDomain, ICorDebugAssembly pAssembly)
        {
            HRESULT hr;

            if ((hr = TryLoadAssembly(pAppDomain, pAssembly)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryLoadAssembly(ICorDebugAppDomain pAppDomain, ICorDebugAssembly pAssembly)
        {
            /*HRESULT LoadAssembly([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAssembly pAssembly);*/
            return Raw.LoadAssembly(pAppDomain, pAssembly);
        }

        #endregion
        #region UnloadAssembly

        public void UnloadAssembly(ICorDebugAppDomain pAppDomain, ICorDebugAssembly pAssembly)
        {
            HRESULT hr;

            if ((hr = TryUnloadAssembly(pAppDomain, pAssembly)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUnloadAssembly(ICorDebugAppDomain pAppDomain, ICorDebugAssembly pAssembly)
        {
            /*HRESULT UnloadAssembly([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAssembly pAssembly);*/
            return Raw.UnloadAssembly(pAppDomain, pAssembly);
        }

        #endregion
        #region ControlCTrap

        public void ControlCTrap(ICorDebugProcess pProcess)
        {
            HRESULT hr;

            if ((hr = TryControlCTrap(pProcess)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryControlCTrap(ICorDebugProcess pProcess)
        {
            /*HRESULT ControlCTrap([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);*/
            return Raw.ControlCTrap(pProcess);
        }

        #endregion
        #region NameChange

        public void NameChange(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread)
        {
            HRESULT hr;

            if ((hr = TryNameChange(pAppDomain, pThread)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryNameChange(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread)
        {
            /*HRESULT NameChange([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread);*/
            return Raw.NameChange(pAppDomain, pThread);
        }

        #endregion
        #region UpdateModuleSymbols

        public void UpdateModuleSymbols(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule, IStream pSymbolStream)
        {
            HRESULT hr;

            if ((hr = TryUpdateModuleSymbols(pAppDomain, pModule, pSymbolStream)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryUpdateModuleSymbols(ICorDebugAppDomain pAppDomain, ICorDebugModule pModule, IStream pSymbolStream)
        {
            /*HRESULT UpdateModuleSymbols(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pSymbolStream);*/
            return Raw.UpdateModuleSymbols(pAppDomain, pModule, pSymbolStream);
        }

        #endregion
        #region EditAndContinueRemap

        public void EditAndContinueRemap(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction, int fAccurate)
        {
            HRESULT hr;

            if ((hr = TryEditAndContinueRemap(pAppDomain, pThread, pFunction, fAccurate)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEditAndContinueRemap(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction, int fAccurate)
        {
            /*HRESULT EditAndContinueRemap(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction,
            [In] int fAccurate);*/
            return Raw.EditAndContinueRemap(pAppDomain, pThread, pFunction, fAccurate);
        }

        #endregion
        #region BreakpointSetError

        public void BreakpointSetError(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint, uint dwError)
        {
            HRESULT hr;

            if ((hr = TryBreakpointSetError(pAppDomain, pThread, pBreakpoint, dwError)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryBreakpointSetError(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugBreakpoint pBreakpoint, uint dwError)
        {
            /*HRESULT BreakpointSetError(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugBreakpoint pBreakpoint,
            [In] uint dwError);*/
            return Raw.BreakpointSetError(pAppDomain, pThread, pBreakpoint, dwError);
        }

        #endregion
        #endregion
        #region ICorDebugManagedCallback2

        public ICorDebugManagedCallback2 Raw2 => (ICorDebugManagedCallback2) Raw;

        #region FunctionRemapOpportunity

        public void FunctionRemapOpportunity(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pOldFunction, ICorDebugFunction pNewFunction, uint oldILOffset)
        {
            HRESULT hr;

            if ((hr = TryFunctionRemapOpportunity(pAppDomain, pThread, pOldFunction, pNewFunction, oldILOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryFunctionRemapOpportunity(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pOldFunction, ICorDebugFunction pNewFunction, uint oldILOffset)
        {
            /*HRESULT FunctionRemapOpportunity(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pOldFunction,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pNewFunction,
            [In] uint oldILOffset);*/
            return Raw2.FunctionRemapOpportunity(pAppDomain, pThread, pOldFunction, pNewFunction, oldILOffset);
        }

        #endregion
        #region CreateConnection

        public void CreateConnection(ICorDebugProcess pProcess, uint dwConnectionId, string pConnName)
        {
            HRESULT hr;

            if ((hr = TryCreateConnection(pProcess, dwConnectionId, pConnName)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCreateConnection(ICorDebugProcess pProcess, uint dwConnectionId, string pConnName)
        {
            /*HRESULT CreateConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] uint dwConnectionId, [MarshalAs(UnmanagedType.LPWStr), In] string pConnName);*/
            return Raw2.CreateConnection(pProcess, dwConnectionId, pConnName);
        }

        #endregion
        #region ChangeConnection

        public void ChangeConnection(ICorDebugProcess pProcess, uint dwConnectionId)
        {
            HRESULT hr;

            if ((hr = TryChangeConnection(pProcess, dwConnectionId)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryChangeConnection(ICorDebugProcess pProcess, uint dwConnectionId)
        {
            /*HRESULT ChangeConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] uint dwConnectionId);*/
            return Raw2.ChangeConnection(pProcess, dwConnectionId);
        }

        #endregion
        #region DestroyConnection

        public void DestroyConnection(ICorDebugProcess pProcess, uint dwConnectionId)
        {
            HRESULT hr;

            if ((hr = TryDestroyConnection(pProcess, dwConnectionId)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDestroyConnection(ICorDebugProcess pProcess, uint dwConnectionId)
        {
            /*HRESULT DestroyConnection([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [In] uint dwConnectionId);*/
            return Raw2.DestroyConnection(pProcess, dwConnectionId);
        }

        #endregion
        #region Exception

        public void Exception(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFrame pFrame, uint nOffset, CorDebugExceptionCallbackType dwEventType, uint dwFlags)
        {
            HRESULT hr;

            if ((hr = TryException(pAppDomain, pThread, pFrame, nOffset, dwEventType, dwFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryException(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFrame pFrame, uint nOffset, CorDebugExceptionCallbackType dwEventType, uint dwFlags)
        {
            /*HRESULT Exception(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame,
            [In] uint nOffset,
            [In] CorDebugExceptionCallbackType dwEventType,
            [In] uint dwFlags);*/
            return Raw2.Exception(pAppDomain, pThread, pFrame, nOffset, dwEventType, dwFlags);
        }

        #endregion
        #region ExceptionUnwind

        public void ExceptionUnwind(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, CorDebugExceptionUnwindCallbackType dwEventType, uint dwFlags)
        {
            HRESULT hr;

            if ((hr = TryExceptionUnwind(pAppDomain, pThread, dwEventType, dwFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryExceptionUnwind(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, CorDebugExceptionUnwindCallbackType dwEventType, uint dwFlags)
        {
            /*HRESULT ExceptionUnwind(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] CorDebugExceptionUnwindCallbackType dwEventType,
            [In] uint dwFlags);*/
            return Raw2.ExceptionUnwind(pAppDomain, pThread, dwEventType, dwFlags);
        }

        #endregion
        #region FunctionRemapComplete

        public void FunctionRemapComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction)
        {
            HRESULT hr;

            if ((hr = TryFunctionRemapComplete(pAppDomain, pThread, pFunction)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryFunctionRemapComplete(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugFunction pFunction)
        {
            /*HRESULT FunctionRemapComplete(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction);*/
            return Raw2.FunctionRemapComplete(pAppDomain, pThread, pFunction);
        }

        #endregion
        #region MDANotification

        public void MDANotification(ICorDebugController pController, ICorDebugThread pThread, ICorDebugMDA pMDA)
        {
            HRESULT hr;

            if ((hr = TryMDANotification(pController, pThread, pMDA)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryMDANotification(ICorDebugController pController, ICorDebugThread pThread, ICorDebugMDA pMDA)
        {
            /*HRESULT MDANotification(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugController pController,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugMDA pMDA);*/
            return Raw2.MDANotification(pController, pThread, pMDA);
        }

        #endregion
        #endregion
        #region ICorDebugManagedCallback3

        public ICorDebugManagedCallback3 Raw3 => (ICorDebugManagedCallback3) Raw;

        #region CustomNotification

        public void CustomNotification(ICorDebugThread pThread, ICorDebugAppDomain pAppDomain)
        {
            HRESULT hr;

            if ((hr = TryCustomNotification(pThread, pAppDomain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCustomNotification(ICorDebugThread pThread, ICorDebugAppDomain pAppDomain)
        {
            /*HRESULT CustomNotification([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);*/
            return Raw3.CustomNotification(pThread, pAppDomain);
        }

        #endregion
        #endregion
    }
}