using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Extends the <see cref="ICorDebugDebugEvent"/> interface to support module-level events.
    /// </summary>
    /// <remarks>
    /// The <see cref="CorDebugDebugEventKind.DEBUG_EVENT_KIND_MODULE_LOADED"/> and <see cref="CorDebugDebugEventKind.DEBUG_EVENT_KIND_MODULE_UNLOADED"/>
    /// event types implement this interface.
    /// </remarks>
    public class CorDebugModuleDebugEvent : CorDebugDebugEvent
    {
        public CorDebugModuleDebugEvent(ICorDebugModuleDebugEvent raw) : base(raw)
        {
        }

        #region ICorDebugModuleDebugEvent

        public new ICorDebugModuleDebugEvent Raw => (ICorDebugModuleDebugEvent) base.Raw;

        #region GetModule

        /// <summary>
        /// Gets the merged module that was just loaded or unloaded.
        /// </summary>
        public CorDebugModule Module
        {
            get
            {
                HRESULT hr;
                CorDebugModule ppModuleResult;

                if ((hr = TryGetModule(out ppModuleResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppModuleResult;
            }
        }

        /// <summary>
        /// Gets the merged module that was just loaded or unloaded.
        /// </summary>
        /// <param name="ppModuleResult">[out] A pointer to the address of an <see cref="ICorDebugModule"/> object that represents the merged module that was just loaded or unloaded.</param>
        /// <remarks>
        /// You can call the <see cref="CorDebugDebugEvent.EventKind"/> property to determine whether the module was loaded
        /// or unloaded.
        /// </remarks>
        public HRESULT TryGetModule(out CorDebugModule ppModuleResult)
        {
            /*HRESULT GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);*/
            ICorDebugModule ppModule;
            HRESULT hr = Raw.GetModule(out ppModule);

            if (hr == HRESULT.S_OK)
                ppModuleResult = new CorDebugModule(ppModule);
            else
                ppModuleResult = default(CorDebugModule);

            return hr;
        }

        #endregion
        #endregion
    }
}