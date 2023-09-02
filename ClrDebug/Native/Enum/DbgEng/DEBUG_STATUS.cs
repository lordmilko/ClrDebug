using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /* This is an enum but INSIDE_WAIT and WAIT_TIMEOUT are long instead of int.
     * Could we simply use an enum backed by ulong? The new .NET shell for WinDbg has DEBUG_STATUS defined as
     * an enum backed by ulong, however it's entirely possible they've changed the size of the parameter that
     * is passed to IDebugControl::SetExecutionStatus(). When I try and define DEBUG_STATUS as an enum backed
     * by ulong and pass in a value like DEBUG_STATUS.GO, the CLR says I've just corrupted the stack. */
    [DebuggerDisplay("{ToString(),nq}")]
    public struct DEBUG_STATUS
    {
        public static readonly DEBUG_STATUS NO_CHANGE = 0;
        public static readonly DEBUG_STATUS GO = 1;
        public static readonly DEBUG_STATUS GO_HANDLED = 2;
        public static readonly DEBUG_STATUS GO_NOT_HANDLED = 3;
        public static readonly DEBUG_STATUS STEP_OVER = 4;
        public static readonly DEBUG_STATUS STEP_INTO = 5;
        public static readonly DEBUG_STATUS BREAK = 6;
        public static readonly DEBUG_STATUS NO_DEBUGGEE = 7;
        public static readonly DEBUG_STATUS STEP_BRANCH = 8;
        public static readonly DEBUG_STATUS IGNORE_EVENT = 9;
        public static readonly DEBUG_STATUS RESTART_REQUESTED = 10;
        public static readonly DEBUG_STATUS REVERSE_GO = 11;
        public static readonly DEBUG_STATUS REVERSE_STEP_BRANCH = 12;
        public static readonly DEBUG_STATUS REVERSE_STEP_OVER = 13;
        public static readonly DEBUG_STATUS REVERSE_STEP_INTO = 14;
        public static readonly DEBUG_STATUS OUT_OF_SYNC = 15;
        public static readonly DEBUG_STATUS WAIT_INPUT = 16;
        public static readonly DEBUG_STATUS TIMEOUT = 17;
        public static readonly DEBUG_STATUS MASK = 0x1f;

        /// <summary>
        /// This bit is added in DEBUG_CES_EXECUTION_STATUS notifications when the
        /// engines execution status is changing due to operations performed during a
        /// wait, such as making synchronous callbacks. If the bit is not set the
        /// execution status is changing due to a wait being satisfied.
        /// </summary>
        public static readonly long INSIDE_WAIT = 0x100000000;

        /// <summary>
        /// This bit is added in DEBUG_CES_EXECUTION_STATUS notifications when the
        /// engines execution status update is coming after a wait has timed-out. It
        /// indicates that the execution status change was not due to an actual event.
        /// </summary>
        public static readonly long WAIT_TIMEOUT = 0x200000000;

        private int value;

        public DEBUG_STATUS(int value)
        {
            this.value = value;
        }

        public static implicit operator DEBUG_STATUS(int value) => new DEBUG_STATUS(value);
        public static explicit operator DEBUG_STATUS(ulong value) => new DEBUG_STATUS((int) value);

        public static DEBUG_STATUS operator &(DEBUG_STATUS left, DEBUG_STATUS right) => left.value & right.value;
        public static DEBUG_STATUS operator |(DEBUG_STATUS left, DEBUG_STATUS right) => left.value | right.value;

        public static bool operator ==(DEBUG_STATUS left, DEBUG_STATUS right) => left.value == right.value;

        public static bool operator !=(DEBUG_STATUS left, DEBUG_STATUS right) => left.value != right.value;

        public override bool Equals(object obj)
        {
            if (obj is DEBUG_STATUS)
                return value == ((DEBUG_STATUS) obj).value;

            return value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            switch (value)
            {
                case 0: return nameof(NO_CHANGE);
                case 1: return nameof(GO);
                case 2: return nameof(GO_HANDLED);
                case 3: return nameof(GO_NOT_HANDLED);
                case 4: return nameof(STEP_OVER);
                case 5: return nameof(STEP_INTO);
                case 6: return nameof(BREAK);
                case 7: return nameof(NO_DEBUGGEE);
                case 8: return nameof(STEP_BRANCH);
                case 9: return nameof(IGNORE_EVENT);
                case 10: return nameof(RESTART_REQUESTED);
                case 11: return nameof(REVERSE_GO);
                case 12: return nameof(REVERSE_STEP_BRANCH);
                case 13: return nameof(REVERSE_STEP_OVER);
                case 14: return nameof(REVERSE_STEP_INTO);
                case 15: return nameof(OUT_OF_SYNC);
                case 16: return nameof(WAIT_INPUT);
                case 17: return nameof(TIMEOUT);
                case 0x1f: return nameof(MASK);

                default:
                    return value.ToString();
            }
        }
    }
}
