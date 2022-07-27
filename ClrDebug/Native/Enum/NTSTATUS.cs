namespace ClrDebug
{
    public enum NTSTATUS : uint
    {
        STATUS_SUCCESS = 0,

        STATUS_INFO_LENGTH_MISMATCH = 0xC0000004,

        /// <summary>
        /// The operation that was requested is pending completion.<para/>
        /// This value is also known as STILL_ACTIVE.
        /// </summary>
        STATUS_PENDING = 0x00000103,

        /// <summary>
        /// The instruction at 0x%p referenced memory at 0x%p. The memory could not be %s.<para/>
        /// This value is also known as EXCEPTION_ACCESS_VIOLATION.
        /// </summary>
        STATUS_ACCESS_VIOLATION = 0xC0000005,

        /// <summary>
        /// This value is also known as EXCEPTION_GUARD_PAGE.
        /// </summary>
        STATUS_GUARD_PAGE_VIOLATION = 0x80000001,

        /// <summary>
        /// A datatype misalignment error was detected in a load or store instruction.<para/>
        /// This value is also known as EXCEPTION_DATATYPE_MISALIGNMENT.
        /// </summary>
        STATUS_DATATYPE_MISALIGNMENT = 0x80000002,

        /// <summary>
        /// A breakpoint has been reached.<para/>
        /// This value is also known as EXCEPTION_BREAKPOINT.
        /// </summary>
        STATUS_BREAKPOINT = 0x80000003,

        /// <summary>
        /// A single step or trace operation has just been completed.<para/>
        /// This value is also known as EXCEPTION_SINGLE_STEP.
        /// </summary>
        STATUS_SINGLE_STEP = 0x80000004,

        /// <summary>
        /// The data was too large to fit into the specified buffer.
        /// </summary>
        STATUS_BUFFER_OVERFLOW = 0x80000005,

        /// <summary>
        /// The instruction at 0x%p referenced memory at 0x%p. The required data was not placed into memory because of an I/O error status of 0x%x.<para/>
        /// This value is also known as EXCEPTION_IN_PAGE_ERROR.
        /// </summary>
        STATUS_IN_PAGE_ERROR = 0xC0000006,

        /// <summary>
        /// An invalid HANDLE was specified.<para/>
        /// This value is also known as EXCEPTION_INVALID_HANDLE.
        /// </summary>
        STATUS_INVALID_HANDLE = 0xC0000008,

        /// <summary>
        /// Array bounds exceeded.<para/>
        /// This value is also known as EXCEPTION_ARRAY_BOUNDS_EXCEEDED.
        /// </summary>
        STATUS_ARRAY_BOUNDS_EXCEEDED = 0xC000008C,

        /// <summary>
        /// Floating-point denormal operand.<para/>
        /// This value is also known as EXCEPTION_FLT_DENORMAL_OPERAND.
        /// </summary>
        STATUS_FLOAT_DENORMAL_OPERAND = 0xC000008D,

        /// <summary>
        /// Floating-point division by zero.<para/>
        /// This value is also known as EXCEPTION_FLT_DIVIDE_BY_ZERO.
        /// </summary>
        STATUS_FLOAT_DIVIDE_BY_ZERO = 0xC000008E,

        /// <summary>
        /// Floating-point inexact result.<para/>
        /// This value is also known as EXCEPTION_FLT_INEXACT_RESULT.
        /// </summary>
        STATUS_FLOAT_INEXACT_RESULT = 0xC000008F,

        /// <summary>
        /// Floating-point invalid operation.<para/>
        /// This value is also known as EXCEPTION_FLT_INVALID_OPERATION.
        /// </summary>
        STATUS_FLOAT_INVALID_OPERATION = 0xC0000090,

        /// <summary>
        /// Floating-point overflow.<para/>
        /// This value is also known as EXCEPTION_FLT_OVERFLOW.
        /// </summary>
        STATUS_FLOAT_OVERFLOW = 0xC0000091,

        /// <summary>
        /// Floating-point stack check.<para/>
        /// This value is also known as EXCEPTION_FLT_STACK_CHECK.
        /// </summary>
        STATUS_FLOAT_STACK_CHECK = 0xC0000092,

        /// <summary>
        /// Floating-point underflow.<para/>
        /// This value is also known as EXCEPTION_FLT_UNDERFLOW.
        /// </summary>
        STATUS_FLOAT_UNDERFLOW = 0xC0000093,

        /// <summary>
        /// Integer division by zero.<para/>
        /// This value is also known as EXCEPTION_INT_DIVIDE_BY_ZERO.
        /// </summary>
        STATUS_INTEGER_DIVIDE_BY_ZERO = 0xC0000094,

        /// <summary>
        /// Integer overflow.<para/>
        /// This value is also known as EXCEPTION_INT_OVERFLOW.
        /// </summary>
        STATUS_INTEGER_OVERFLOW = 0xC0000095,

        /// <summary>
        /// Privileged instruction.<para/>
        /// This value is also known as EXCEPTION_PRIV_INSTRUCTION.
        /// </summary>
        STATUS_PRIVILEGED_INSTRUCTION = 0xC0000096,

        /// <summary>
        /// An attempt was made to execute an illegal instruction.<para/>
        /// This value is also known as EXCEPTION_ILLEGAL_INSTRUCTION.
        /// </summary>
        STATUS_ILLEGAL_INSTRUCTION = 0xC000001D,

        /// <summary>
        /// Windows cannot continue from this exception.<para/>
        /// This value is also known as EXCEPTION_NONCONTINUABLE_EXCEPTION.
        /// </summary>
        STATUS_NONCONTINUABLE_EXCEPTION = 0xC0000025,

        /// <summary>
        /// A new guard page for the stack cannot be created.<para/>
        /// This value is also known as EXCEPTION_STACK_OVERFLOW.
        /// </summary>
        STATUS_STACK_OVERFLOW = 0xC00000FD,

        /// <summary>
        /// An invalid exception disposition was returned by an exception handler.<para/>
        /// This value is also known as EXCEPTION_INVALID_DISPOSITION.
        /// </summary>
        STATUS_INVALID_DISPOSITION = 0xC0000026,

        /// <summary>
        /// The application terminated as a result of a CTRL+C.<para/>
        /// This value is also known as CONTROL_C_EXIT.
        /// </summary>
        STATUS_CONTROL_C_EXIT = 0xC000013A,

        /// <summary>
        /// Possible deadlock condition.<para/>
        /// This value is also known as EXCEPTION_POSSIBLE_DEADLOCK.
        /// </summary>
        STATUS_POSSIBLE_DEADLOCK = 0xC0000194,

        /// <summary>
        /// Debugger got control C.
        /// </summary>
        DBG_CONTROL_C = 0x40010005,

        STATUS_CPP_EH_EXCEPTION = 0xE06D7363
    }
}
