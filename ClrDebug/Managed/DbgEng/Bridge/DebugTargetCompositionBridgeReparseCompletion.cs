using System;

namespace ClrDebug.DbgEng
{
    public class DebugTargetCompositionBridgeReparseCompletion : ComObject<IDebugTargetCompositionBridgeReparseCompletion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugTargetCompositionBridgeReparseCompletion"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugTargetCompositionBridgeReparseCompletion(IDebugTargetCompositionBridgeReparseCompletion raw) : base(raw)
        {
        }

        #region IDebugTargetCompositionBridgeReparseCompletion
        #region NotifyReparseCompletion

        /// <summary>
        /// NotifyReparseCompletion When a reparse is complete *AND* the service manager has all requisite services added, this method will be called in reverse nested order (innermost to outermost) for any reparses done via IDebugTargetCompositionBridge4::ReparseActivation2 This is the *ONLY* way to modify the service container *AFTER* a ReparseActivation* call.<para/>
        /// Note that returning a failing status from this method will cause the service container (and hence target) to fail to initialize properly.
        /// </summary>
        public void NotifyReparseCompletion(IDebugServiceManager pServiceManager, IntPtr pData)
        {
            TryNotifyReparseCompletion(pServiceManager, pData).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// NotifyReparseCompletion When a reparse is complete *AND* the service manager has all requisite services added, this method will be called in reverse nested order (innermost to outermost) for any reparses done via IDebugTargetCompositionBridge4::ReparseActivation2 This is the *ONLY* way to modify the service container *AFTER* a ReparseActivation* call.<para/>
        /// Note that returning a failing status from this method will cause the service container (and hence target) to fail to initialize properly.
        /// </summary>
        public HRESULT TryNotifyReparseCompletion(IDebugServiceManager pServiceManager, IntPtr pData)
        {
            /*HRESULT NotifyReparseCompletion(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In] IntPtr pData);*/
            return Raw.NotifyReparseCompletion(pServiceManager, pData);
        }

        #endregion
        #endregion
    }
}
