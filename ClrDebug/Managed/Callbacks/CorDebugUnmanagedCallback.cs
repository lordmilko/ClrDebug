using System;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides notification of native events that are not directly related to the common language runtime (CLR).
    /// </summary>
#if GENERATED_MARSHALLING
    [GeneratedComClass]
#endif
    public partial class CorDebugUnmanagedCallback : ICorDebugUnmanagedCallback
    {
        #region ICorDebugUnmanagedCallback EventHandlers

        /// <summary>
        /// Notifies the debugger that a native event has been fired.
        /// </summary>
        public event EventHandler<DebugEventCorDebugUnmanagedCallbackEventArgs> OnDebugEvent;

        #endregion
        #region ICorDebugUnmanagedCallback Methods

        HRESULT ICorDebugUnmanagedCallback.DebugEvent(ref DEBUG_EVENT pDebugEvent, bool fOutOfBand) => HandleEvent(OnDebugEvent, new DebugEventCorDebugUnmanagedCallbackEventArgs(pDebugEvent, fOutOfBand));

        #endregion

        protected virtual HRESULT HandleEvent(EventHandler<DebugEventCorDebugUnmanagedCallbackEventArgs> handler, DebugEventCorDebugUnmanagedCallbackEventArgs args)
        {
            handler?.Invoke(this, args);

            return HRESULT.S_OK;
        }
    }
}
