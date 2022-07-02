using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Represents an event that occurred from one of the methods in the <see cref="ICorDebugManagedCallback"/> interface or its derivatives.
    /// </summary>
    public abstract class CorDebugManagedCallbackEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public abstract CorDebugManagedCallbackKind Kind { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugController rawController;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugController controller;

        public CorDebugController Controller
        {
            get
            {
                if (controller == null && rawController != null)
                    controller = CorDebugController.New(rawController);

                return controller;
            }
        }

        protected CorDebugManagedCallbackEventArgs(ICorDebugController controller)
        {
            rawController = controller;
        }

        public void Continue()
        {
            Controller.Continue(false);
        }
    }
}