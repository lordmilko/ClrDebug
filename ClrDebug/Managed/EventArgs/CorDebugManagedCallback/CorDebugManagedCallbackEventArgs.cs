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

        /// <summary>
        /// Gets or sets whether <see cref="CorDebugController.Continue(bool)"/> should be called at the end of processing this event. By default this value is <see langword="true"/>.<para/>
        /// This property is merely provided for the convenience of your event handler. It is your responsibility to ultimately hook up the call to <see cref="CorDebugController.Continue(bool)"/>.
        /// </summary>
        public bool Continue { get; set; } = true;
    }
}
