namespace ClrDebug.DbgEng
{
    /* I've gone back and forth as to whether or not DEBUG_STATUS should be an enum or not. GetExecutionStatus/SetExecutinStatus
     * want a uint, but the INSIDE_WAIT/WAIT_TIMEUT flags are ulong. However, it's important to note that these two flags are
     * never actually stored in the persisted execution status; rather, they are merely include in the notification event
     * sent to DEBUG_STATUS_INSIDE_WAIT. */

    //This is a class containing long values so that you can easily do
    //    bool hasInsideWait = (argument & DEBUG_STATUS_FLAGS.INSIDE_WAIT) != 0;
    //without having to do any crazy casting
    public static class DEBUG_STATUS_FLAGS
    {
        /// <summary>
        /// This bit is added in DEBUG_CES_EXECUTION_STATUS notifications when the
        /// engines execution status is changing due to operations performed during a
        /// wait, such as making synchronous callbacks. If the bit is not set the
        /// execution status is changing due to a wait being satisfied.
        /// </summary>
        public const long INSIDE_WAIT = 0x100000000;

        /// <summary>
        /// This bit is added in DEBUG_CES_EXECUTION_STATUS notifications when the
        /// engines execution status update is coming after a wait has timed-out. It
        /// indicates that the execution status change was not due to an actual event.
        /// </summary>
        public const long WAIT_TIMEOUT = 0x200000000;
    }

    /// <summary>
    /// The DEBUG_STATUS_XXX status codes have two purposes. They instruct the engine on how execution in the target should proceed, and they are used by the
    /// engine to report the execution status of the target.<para/>
    ///
    /// After an event occurs, the engine can receive several instructions that tell it how execution in the target should proceed. In this case, it acts on the
    /// instruction with the highest precedence. Typically, the higher precedence status codes represent less execution for the target.<para/>
    ///
    /// The values in the following table are reverse ordered by precedence; the values that appear earlier in the table have higher precedence.<para/>
    ///
    /// See also: <see cref="DEBUG_STATUS_FLAGS"/>
    /// </summary>
    public enum DEBUG_STATUS : uint
    {
        /// <summary>
        /// When reporting: N/A<para/>
        /// When instructing: No instruction. This value is returned by an event callback method when it does not wish to instruct the engine how to proceed with execution in the target.<para/>
        ///
        /// Lowest precedence
        /// </summary>
        NO_CHANGE = 0,

        /// <summary>
        /// When reporting: The target is executing normally.<para/>
        /// When instructing: Continue normal execution of the target.
        /// </summary>
        GO = 1,

        /// <summary>
        /// When reporting: N/A<para/>
        /// When instructing: Continue execution of the target, flagging the event as handled.
        /// </summary>
        GO_HANDLED = 2,

        /// <summary>
        /// When reporting: N/A<para/>
        /// When instructing: Continue execution of the target, flagging the event as not handled.
        /// </summary>
        GO_NOT_HANDLED = 3,

        /// <summary>
        /// When reporting: The target is executing a single instruction or--if that instruction is a subroutine call--subroutine.<para/>
        /// When instructing: Continue execution of the target for a single instruction. If the instruction is a subroutine call, the call is entered and the target is allowed to run until the subroutine returns.
        /// </summary>
        STEP_OVER = 4,

        /// <summary>
        /// When reporting: The target is executing a single instruction.<para/>
        /// When instructing: Continue execution of the target for a single instruction.
        /// </summary>
        STEP_INTO = 5,

        /// <summary>
        /// When reporting: The target is suspended.<para/>
        /// When instructing: Suspend the target.<para/>
        ///
        /// Highest precedence
        /// </summary>
        BREAK = 6,

        /// <summary>
        /// When reporting: No debugging session is active.<para/>
        /// When instructing: N/A
        /// </summary>
        NO_DEBUGGEE = 7,

        /// <summary>
        /// When reporting: The target is executing until the next branch instruction.<para/>
        /// When instructing: Continue execution of the target until the next branch instruction.
        /// </summary>
        STEP_BRANCH = 8,

        /// <summary>
        /// When reporting: N/A<para/>
        /// When instructing: Continue previous execution of the target, ignoring the event.
        /// </summary>
        IGNORE_EVENT = 9,

        /// <summary>
        /// When reporting: The target is restarting.<para/>
        /// When instructing: Restart the target.
        /// </summary>
        RESTART_REQUESTED = 10,

        REVERSE_GO = 11,
        REVERSE_STEP_BRANCH = 12,
        REVERSE_STEP_OVER = 13,
        REVERSE_STEP_INTO = 14,

        /// <summary>
        /// When reporting: The debugger communications channel is out of sync.<para/>
        /// When instructing: N/A
        /// </summary>
        OUT_OF_SYNC = 15,

        /// <summary>
        /// When reporting: The target is awaiting input from the user.<para/>
        /// When instructing: N/A
        /// </summary>
        WAIT_INPUT = 16,

        /// <summary>
        /// When reporting: The debugger communications channel has timed out.<para/>
        /// When instructing: N/A
        /// </summary>
        TIMEOUT = 17,

        MASK = 0x1f,
    }
}
