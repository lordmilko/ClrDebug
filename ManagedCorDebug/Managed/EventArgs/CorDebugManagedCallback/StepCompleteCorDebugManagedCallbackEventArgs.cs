using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.StepComplete"/> method.
    /// </summary>
    public class StepCompleteCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.StepComplete;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread in which the step has completed.
        /// </summary>
        public CorDebugAppDomain AppDomain
        {
            get
            {
                if (appDomain == null && rawAppDomain != null)
                    appDomain = new CorDebugAppDomain(rawAppDomain);

                return appDomain;
            }
        }

        #endregion
        #region Thread

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugThread rawThread;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugThread thread;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the step has completed.
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
        #region Stepper

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugStepper rawStepper;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugStepper stepper;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugStepper"/> object that represents the step in code execution.
        /// </summary>
        public CorDebugStepper Stepper
        {
            get
            {
                if (stepper == null && rawStepper != null)
                    stepper = new CorDebugStepper(rawStepper);

                return stepper;
            }
        }

        #endregion
        
        /// <summary>
        /// A value of the <see cref="CorDebugStepReason"/> enumeration that indicates the outcome of an individual step.
        /// </summary>
        public CorDebugStepReason Reason { get; }

        /// <summary>
        /// Notifies the debugger that a step has completed.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the thread in which the step has completed.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the step has completed.</param>
        /// <param name="pStepper">A pointer to an <see cref="ICorDebugStepper"/> object that represents the step in code execution.</param>
        /// <param name="reason">A value of the <see cref="CorDebugStepReason"/> enumeration that indicates the outcome of an individual step.</param>
        public StepCompleteCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugStepper pStepper, CorDebugStepReason reason)
        {
            rawAppDomain = pAppDomain;
            rawThread = pThread;
            rawStepper = pStepper;
            Reason = reason;
        }
    }
}