using System.Diagnostics;

namespace ClrDebug
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
            TryOnCodeGenerated(method).ThrowOnNotOK();
        }

        public HRESULT TryOnCodeGenerated(IXCLRDataMethodInstance method)
        {
            /*HRESULT OnCodeGenerated(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataMethodInstance method);*/
            return Raw.OnCodeGenerated(method);
        }

        #endregion
        #region OnCodeDiscarded

        public void OnCodeDiscarded(IXCLRDataMethodInstance method)
        {
            TryOnCodeDiscarded(method).ThrowOnNotOK();
        }

        public HRESULT TryOnCodeDiscarded(IXCLRDataMethodInstance method)
        {
            /*HRESULT OnCodeDiscarded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataMethodInstance method);*/
            return Raw.OnCodeDiscarded(method);
        }

        #endregion
        #region OnProcessExecution

        public void OnProcessExecution(int state)
        {
            TryOnProcessExecution(state).ThrowOnNotOK();
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
            TryOnTaskExecution(task, state).ThrowOnNotOK();
        }

        public HRESULT TryOnTaskExecution(IXCLRDataTask task, int state)
        {
            /*HRESULT OnTaskExecution(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTask task,
            [In] int state);*/
            return Raw.OnTaskExecution(task, state);
        }

        #endregion
        #region OnModuleLoaded

        public void OnModuleLoaded(IXCLRDataModule mod)
        {
            TryOnModuleLoaded(mod).ThrowOnNotOK();
        }

        public HRESULT TryOnModuleLoaded(IXCLRDataModule mod)
        {
            /*HRESULT OnModuleLoaded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataModule mod);*/
            return Raw.OnModuleLoaded(mod);
        }

        #endregion
        #region OnModuleUnloaded

        public void OnModuleUnloaded(IXCLRDataModule mod)
        {
            TryOnModuleUnloaded(mod).ThrowOnNotOK();
        }

        public HRESULT TryOnModuleUnloaded(IXCLRDataModule mod)
        {
            /*HRESULT OnModuleUnloaded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataModule mod);*/
            return Raw.OnModuleUnloaded(mod);
        }

        #endregion
        #region OnTypeLoaded

        public void OnTypeLoaded(IXCLRDataTypeInstance typeInst)
        {
            TryOnTypeLoaded(typeInst).ThrowOnNotOK();
        }

        public HRESULT TryOnTypeLoaded(IXCLRDataTypeInstance typeInst)
        {
            /*HRESULT OnTypeLoaded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeInstance typeInst);*/
            return Raw.OnTypeLoaded(typeInst);
        }

        #endregion
        #region OnTypeUnloaded

        public void OnTypeUnloaded(IXCLRDataTypeInstance typeInst)
        {
            TryOnTypeUnloaded(typeInst).ThrowOnNotOK();
        }

        public HRESULT TryOnTypeUnloaded(IXCLRDataTypeInstance typeInst)
        {
            /*HRESULT OnTypeUnloaded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataTypeInstance typeInst);*/
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
            TryOnAppDomainLoaded(domain).ThrowOnNotOK();
        }

        public HRESULT TryOnAppDomainLoaded(IXCLRDataAppDomain domain)
        {
            /*HRESULT OnAppDomainLoaded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataAppDomain domain);*/
            return Raw2.OnAppDomainLoaded(domain);
        }

        #endregion
        #region OnAppDomainUnloaded

        public void OnAppDomainUnloaded(IXCLRDataAppDomain domain)
        {
            TryOnAppDomainUnloaded(domain).ThrowOnNotOK();
        }

        public HRESULT TryOnAppDomainUnloaded(IXCLRDataAppDomain domain)
        {
            /*HRESULT OnAppDomainUnloaded(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataAppDomain domain);*/
            return Raw2.OnAppDomainUnloaded(domain);
        }

        #endregion
        #region OnException

        public void OnException(IXCLRDataExceptionState exception)
        {
            TryOnException(exception).ThrowOnNotOK();
        }

        public HRESULT TryOnException(IXCLRDataExceptionState exception)
        {
            /*HRESULT OnException(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataExceptionState exception);*/
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
            TryOnGcEvent(gcEvtArgs).ThrowOnNotOK();
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
            TryExceptionCatcherEnter(catchingMethod, catcherNativeOffset).ThrowOnNotOK();
        }

        public HRESULT TryExceptionCatcherEnter(IXCLRDataMethodInstance catchingMethod, int catcherNativeOffset)
        {
            /*HRESULT ExceptionCatcherEnter(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataMethodInstance catchingMethod,
            [In] int catcherNativeOffset);*/
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
            TryOnCodeGenerated2(method, nativeCodeLocation).ThrowOnNotOK();
        }

        public HRESULT TryOnCodeGenerated2(IXCLRDataMethodInstance method, CLRDATA_ADDRESS nativeCodeLocation)
        {
            /*HRESULT OnCodeGenerated2(
            [In, MarshalAs(UnmanagedType.Interface)] IXCLRDataMethodInstance method,
            [In] CLRDATA_ADDRESS nativeCodeLocation);*/
            return Raw5.OnCodeGenerated2(method, nativeCodeLocation);
        }

        #endregion
        #endregion
    }
}
