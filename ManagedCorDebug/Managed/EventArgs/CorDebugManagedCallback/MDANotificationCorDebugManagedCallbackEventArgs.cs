using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback2.MDANotification"/> method.
    /// </summary>
    public class MDANotificationCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.MDANotification;

        #region Controller

        /// <summary>
        /// A pointer to an <see cref="ICorDebugController"/> interface that exposes the process or application domain in which the MDA occurred.<para/>
        /// A debugger should not make any assumptions about whether the controller is a process or an application domain, although it can always query the interface to make a determination.
        /// </summary>
        public new CorDebugController Controller => base.Controller;

        #endregion
        #region Thread

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugThread rawThread;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugThread thread;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugThread"/> interface that exposes the managed thread on which the debug event occurred.<para/>
        /// If the MDA occurred on an unmanaged thread, the value of pThread will be null. You must get the operating system (OS) thread ID from the MDA object itself.
        /// </summary>
        public CorDebugThread Thread
        {
            get
            {
                if (thread == null && rawThread != null)
                    thread = new CorDebugThread(rawThread);

                return thread;
            }
        }

        #endregion
        #region MDA

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugMDA rawMDA;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugMDA mDA;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugMDA"/> interface that exposes the MDA information.
        /// </summary>
        public CorDebugMDA MDA
        {
            get
            {
                if (mDA == null && rawMDA != null)
                    mDA = new CorDebugMDA(rawMDA);

                return mDA;
            }
        }

        #endregion
        
        /// <summary>
        /// Provides notification that code execution has encountered a managed debugging assistant (MDA) in the application that is being debugged.
        /// </summary>
        /// <param name="pController">A pointer to an <see cref="ICorDebugController"/> interface that exposes the process or application domain in which the MDA occurred.<para/>
        /// A debugger should not make any assumptions about whether the controller is a process or an application domain, although it can always query the interface to make a determination.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> interface that exposes the managed thread on which the debug event occurred.<para/>
        /// If the MDA occurred on an unmanaged thread, the value of pThread will be null. You must get the operating system (OS) thread ID from the MDA object itself.</param>
        /// <param name="pMDA">A pointer to an <see cref="ICorDebugMDA"/> interface that exposes the MDA information.</param>
        public MDANotificationCorDebugManagedCallbackEventArgs(ICorDebugController pController, ICorDebugThread pThread, ICorDebugMDA pMDA) : base(pController)
        {
            rawThread = pThread;
            rawMDA = pMDA;
        }
    }
}