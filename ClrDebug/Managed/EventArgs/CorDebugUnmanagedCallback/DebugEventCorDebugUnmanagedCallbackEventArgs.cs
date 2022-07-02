using System;

namespace ClrDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugUnmanagedCallback.DebugEvent"/> method.
    /// </summary>
    public class DebugEventCorDebugUnmanagedCallbackEventArgs : EventArgs
    {
        /// <summary>
        /// A pointer to the native event.
        /// </summary>
        public DEBUG_EVENT DebugEvent { get; }

        /// <summary>
        /// true, if interaction with the managed process state is impossible after an unmanaged event occurs, until the debugger calls <see cref="ICorDebugController.Continue"/>; otherwise, false.
        /// </summary>
        public bool OutOfBand { get; }

        /// <summary>
        /// Notifies the debugger that a native event has been fired.
        /// </summary>
        /// <param name="pDebugEvent">A pointer to the native event.</param>
        /// <param name="fOutOfBand">true, if interaction with the managed process state is impossible after an unmanaged event occurs, until the debugger calls <see cref="ICorDebugController.Continue"/>; otherwise, false.</param>
        public DebugEventCorDebugUnmanagedCallbackEventArgs(DEBUG_EVENT pDebugEvent, bool fOutOfBand)
        {
            DebugEvent = pDebugEvent;
            OutOfBand = fOutOfBand;
        }
    }
}