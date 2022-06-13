using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.LogMessage"/> method.
    /// </summary>
    public class LogMessageCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.LogMessage;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread that logged the event.
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
        /// A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.
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
        
        /// <summary>
        /// A value of the <see cref="LoggingLevelEnum"/> enumeration that indicates the severity level of the descriptive message that was written to the event log.
        /// </summary>
        public LoggingLevelEnum LLevel { get; }

        /// <summary>
        /// A pointer to the name of the tracing switch.
        /// </summary>
        public string LogSwitchName { get; }

        /// <summary>
        /// A pointer to the message that was written to the event log.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <see cref="EventLog"/> class to log an event.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread that logged the event.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        /// <param name="lLevel">A value of the <see cref="LoggingLevelEnum"/> enumeration that indicates the severity level of the descriptive message that was written to the event log.</param>
        /// <param name="pLogSwitchName">A pointer to the name of the tracing switch.</param>
        /// <param name="pMessage">A pointer to the message that was written to the event log.</param>
        public LogMessageCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, LoggingLevelEnum lLevel, string pLogSwitchName, string pMessage)
        {
            rawAppDomain = pAppDomain;
            rawThread = pThread;
            LLevel = lLevel;
            LogSwitchName = pLogSwitchName;
            Message = pMessage;
        }
    }
}