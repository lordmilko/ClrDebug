using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class XCLRDataExceptionNotification : ComObject<IXCLRDataExceptionNotification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataExceptionNotification"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataExceptionNotification(IXCLRDataExceptionNotification raw) : base(raw)
        {
        }

        #region IXCLRDataExceptionNotification
        #region OnCodeGenerated

        public void OnCodeGenerated(IXCLRDataMethodInstance method)
        {
            HRESULT hr;

            if ((hr = TryOnCodeGenerated(method)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnCodeGenerated(IXCLRDataMethodInstance method)
        {
            /*HRESULT OnCodeGenerated(
            [In] IXCLRDataMethodInstance method);*/
            return Raw.OnCodeGenerated(method);
        }

        #endregion
        #region OnCodeDiscarded

        public void OnCodeDiscarded(IXCLRDataMethodInstance method)
        {
            HRESULT hr;

            if ((hr = TryOnCodeDiscarded(method)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnCodeDiscarded(IXCLRDataMethodInstance method)
        {
            /*HRESULT OnCodeDiscarded(
            [In] IXCLRDataMethodInstance method);*/
            return Raw.OnCodeDiscarded(method);
        }

        #endregion
        #region OnProcessExecution

        public void OnProcessExecution(int state)
        {
            HRESULT hr;

            if ((hr = TryOnProcessExecution(state)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnProcessExecution(int state)
        {
            /*HRESULT OnProcessExecution(
            [In] int state);*/
            return Raw.OnProcessExecution(state);
        }

        #endregion
        #region OnTaskExecution

        public void OnTaskExecution(IXCLRDataTask task, int state)
        {
            HRESULT hr;

            if ((hr = TryOnTaskExecution(task, state)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnTaskExecution(IXCLRDataTask task, int state)
        {
            /*HRESULT OnTaskExecution(
            [In] IXCLRDataTask task,
            [In] int state);*/
            return Raw.OnTaskExecution(task, state);
        }

        #endregion
        #region OnModuleLoaded

        public void OnModuleLoaded(IXCLRDataModule mod)
        {
            HRESULT hr;

            if ((hr = TryOnModuleLoaded(mod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnModuleLoaded(IXCLRDataModule mod)
        {
            /*HRESULT OnModuleLoaded(
            [In] IXCLRDataModule mod);*/
            return Raw.OnModuleLoaded(mod);
        }

        #endregion
        #region OnModuleUnloaded

        public void OnModuleUnloaded(IXCLRDataModule mod)
        {
            HRESULT hr;

            if ((hr = TryOnModuleUnloaded(mod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnModuleUnloaded(IXCLRDataModule mod)
        {
            /*HRESULT OnModuleUnloaded(
            [In] IXCLRDataModule mod);*/
            return Raw.OnModuleUnloaded(mod);
        }

        #endregion
        #region OnTypeLoaded

        public void OnTypeLoaded(IXCLRDataTypeInstance typeInst)
        {
            HRESULT hr;

            if ((hr = TryOnTypeLoaded(typeInst)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnTypeLoaded(IXCLRDataTypeInstance typeInst)
        {
            /*HRESULT OnTypeLoaded(
            [In] IXCLRDataTypeInstance typeInst);*/
            return Raw.OnTypeLoaded(typeInst);
        }

        #endregion
        #region OnTypeUnloaded

        public void OnTypeUnloaded(IXCLRDataTypeInstance typeInst)
        {
            HRESULT hr;

            if ((hr = TryOnTypeUnloaded(typeInst)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnTypeUnloaded(IXCLRDataTypeInstance typeInst)
        {
            /*HRESULT OnTypeUnloaded(
            [In] IXCLRDataTypeInstance typeInst);*/
            return Raw.OnTypeUnloaded(typeInst);
        }

        #endregion
        #endregion
        #region IXCLRDataExceptionNotification2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IXCLRDataExceptionNotification2 Raw2 => (IXCLRDataExceptionNotification2) Raw;

        #region OnAppDomainLoaded

        public void OnAppDomainLoaded(IXCLRDataAppDomain domain)
        {
            HRESULT hr;

            if ((hr = TryOnAppDomainLoaded(domain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnAppDomainLoaded(IXCLRDataAppDomain domain)
        {
            /*HRESULT OnAppDomainLoaded(
            [In] IXCLRDataAppDomain domain);*/
            return Raw2.OnAppDomainLoaded(domain);
        }

        #endregion
        #region OnAppDomainUnloaded

        public void OnAppDomainUnloaded(IXCLRDataAppDomain domain)
        {
            HRESULT hr;

            if ((hr = TryOnAppDomainUnloaded(domain)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnAppDomainUnloaded(IXCLRDataAppDomain domain)
        {
            /*HRESULT OnAppDomainUnloaded(
            [In] IXCLRDataAppDomain domain);*/
            return Raw2.OnAppDomainUnloaded(domain);
        }

        #endregion
        #region OnException

        public void OnException(IXCLRDataExceptionState exception)
        {
            HRESULT hr;

            if ((hr = TryOnException(exception)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnException(IXCLRDataExceptionState exception)
        {
            /*HRESULT OnException(
            [In] IXCLRDataExceptionState exception);*/
            return Raw2.OnException(exception);
        }

        #endregion
        #endregion
        #region IXCLRDataExceptionNotification3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IXCLRDataExceptionNotification3 Raw3 => (IXCLRDataExceptionNotification3) Raw;

        #region OnGcEvent

        public void OnGcEvent(GcEvtArgs gcEvtArgs)
        {
            HRESULT hr;

            if ((hr = TryOnGcEvent(gcEvtArgs)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnGcEvent(GcEvtArgs gcEvtArgs)
        {
            /*HRESULT OnGcEvent(
            [In] GcEvtArgs gcEvtArgs);*/
            return Raw3.OnGcEvent(gcEvtArgs);
        }

        #endregion
        #endregion
        #region IXCLRDataExceptionNotification4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IXCLRDataExceptionNotification4 Raw4 => (IXCLRDataExceptionNotification4) Raw;

        #region ExceptionCatcherEnter

        public void ExceptionCatcherEnter(IXCLRDataMethodInstance catchingMethod, int catcherNativeOffset)
        {
            HRESULT hr;

            if ((hr = TryExceptionCatcherEnter(catchingMethod, catcherNativeOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryExceptionCatcherEnter(IXCLRDataMethodInstance catchingMethod, int catcherNativeOffset)
        {
            /*HRESULT ExceptionCatcherEnter(
            [In] IXCLRDataMethodInstance catchingMethod,
            int catcherNativeOffset);*/
            return Raw4.ExceptionCatcherEnter(catchingMethod, catcherNativeOffset);
        }

        #endregion
        #endregion
        #region IXCLRDataExceptionNotification5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IXCLRDataExceptionNotification5 Raw5 => (IXCLRDataExceptionNotification5) Raw;

        #region OnCodeGenerated2

        public void OnCodeGenerated2(IXCLRDataMethodInstance method, CLRDATA_ADDRESS nativeCodeLocation)
        {
            HRESULT hr;

            if ((hr = TryOnCodeGenerated2(method, nativeCodeLocation)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryOnCodeGenerated2(IXCLRDataMethodInstance method, CLRDATA_ADDRESS nativeCodeLocation)
        {
            /*HRESULT OnCodeGenerated2(
            [In] IXCLRDataMethodInstance method,
            [In] CLRDATA_ADDRESS nativeCodeLocation);*/
            return Raw5.OnCodeGenerated2(method, nativeCodeLocation);
        }

        #endregion
        #endregion
    }
}