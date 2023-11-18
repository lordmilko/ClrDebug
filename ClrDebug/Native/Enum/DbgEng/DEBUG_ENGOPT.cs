using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Engine control flags.
    /// </summary>
    [Flags]
    public enum DEBUG_ENGOPT : uint
    {
        NONE = 0,

        IGNORE_DBGHELP_VERSION = 0x00000001,
        IGNORE_EXTENSION_VERSIONS = 0x00000002,

        //If neither allow nor disallow is specified
        //the engine will pick one based on what kind
        //of debugging is going on.

        ALLOW_NETWORK_PATHS = 0x00000004,
        DISALLOW_NETWORK_PATHS = 0x00000008,
        NETWORK_PATHS = (0x00000004 | 0x00000008),

        /// <summary>
        /// Ignore loader-generated first-chance exceptions.
        /// </summary>
        IGNORE_LOADER_EXCEPTIONS = 0x00000010,

        /// <summary>
        /// Break in on a debuggees initial event. In user-mode this will break at the initial
        /// system breakpoint for every created process. In kernel-mode it will attempt break in
        /// on the target at the first WaitForEvent.
        /// </summary>
        INITIAL_BREAK = 0x00000020,

        /// <summary>
        /// Break in on the first module load for a debuggee.
        /// </summary>
        INITIAL_MODULE_BREAK = 0x00000040,

        /// <summary>
        /// Break in on a debuggees final event. In user-mode this will break on process exit for
        /// every process. In kernel-mode it currently does nothing.
        /// </summary>
        FINAL_BREAK = 0x00000080,

        /// <summary>
        /// By default Execute will repeat the last command if it is given an empty string.
        /// The flags to Execute can override this behavior for a single command or this engine
        /// option can be used to change the default globally.
        /// </summary>
        NO_EXECUTE_REPEAT = 0x00000100,

        /// <summary>
        /// Disable places in the engine that have fallback code when presented with incomplete
        /// information.<para/>
        /// 1. Fails minidump module loads unless matching executables can be mapped.
        /// </summary>
        FAIL_INCOMPLETE_INFORMATION = 0x00000200,

        /// <summary>
        /// Allow the debugger to manipulate page protections in order to insert code breakpoints
        /// on pages that do not have write access. This option is not on by default as it allows
        /// breakpoints to be set in potentially hazardous memory areas.
        /// </summary>
        ALLOW_READ_ONLY_BREAKPOINTS = 0x00000400,

        /// <summary>
        /// When using a software (bp/bu) breakpoint in code that will be executed by multiple threads
        /// it is possible for breakpoint management to cause the breakpoint to be missed or for
        /// spurious single-step exceptions to be generated.<para/>
        ///
        /// This flag suspends all but the active thread when doing breakpoint management and thereby
        /// avoids multithreading problems. Care must be taken when using it, though, as the suspension
        /// of threads can cause deadlocks if the suspended threads are holding resources that the
        /// active thread needs.<para/>
        ///
        /// Additionally, there are still rare situations where problems may occur, but setting this flag
        /// corrects nearly all multithreading issues with software breakpoints. Thread-restricted
        /// stepping and execution supersedes this flags effect.<para/>
        /// This flag is ignored in kernel sessions as there is no way to restrict processor execution.
        /// </summary>
        SYNCHRONIZE_BREAKPOINTS = 0x00000800,

        /// <summary>
        /// Disallows executing shell commands through the engine with .shell (!!).
        /// </summary>
        DISALLOW_SHELL_COMMANDS = 0x00001000,

        /// <summary>
        /// Turns on "quiet mode", a somewhat less verbose mode of operation supported in the debuggers
        /// that were superseded by dbgeng.dll.  This equates to the KDQUIET environment variable.
        /// </summary>
        KD_QUIET_MODE = 0x00002000,

        /// <summary>
        /// Disables managed code debugging support in the engine. If managed support is already in use
        /// this flag has no effect.
        /// </summary>
        DISABLE_MANAGED_SUPPORT = 0x00004000,

        /// <summary>
        /// Disables symbol loading for all modules created after this flag is set.
        /// </summary>
        DISABLE_MODULE_SYMBOL_LOAD = 0x00008000,

        /// <summary>
        /// Disables execution commands.
        /// </summary>
        DISABLE_EXECUTION_COMMANDS = 0x00010000,

        /// <summary>
        /// Disallows mapping of image files from disk for any use. For example, this disallows
        /// image mapping for memory content when debugging minidumps.<para/>
        /// Does not affect existing mappings, only future attempts.
        /// </summary>
        DISALLOW_IMAGE_FILE_MAPPING = 0x00020000,

        /// <summary>
        /// Requests that dbgeng run DML-enhanced versions of commands and operations by default.
        /// </summary>
        PREFER_DML = 0x00040000,

        /// <summary>
        /// Explicitly disable SQM upload.
        /// </summary>
        DISABLESQM = 0x00080000,

        /// <summary>
        /// This is used to disable the source stepping (step over/step in) into CFG code.
        /// </summary>
        DISABLE_STEPLINES_OPTIONS = 0x00200000,

        /// <summary>
        /// This is used when debugging target with sensitive data. It will disable saving dumps
        /// during debugging Can be set only (no reset once it is set)
        /// </summary>
        DEBUGGING_SENSITIVE_DATA = 0x00400000,

        /// <summary>
        /// When opening .cab or .zip files, if there is a trace (.run file), open it instead of any
        /// other dump files in the archive.
        /// </summary>
        PREFER_TRACE_FILES = 0x00800000,

        /// <summary>
        /// Use suffixes of the form @n (n is a non-negative integer) to disambiguate shadowed variables.
        /// </summary>
        RESOLVE_SHADOWED_VARIABLES = 0x01000000,

        ALL = 0x01EFFFFF,
    }
}
