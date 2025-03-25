namespace ClrDebug.DbgEng
{
    public enum DEBUG_CLASS_QUALIFIER : uint
    {
        //Specific types of kernel debuggees.

        KERNEL_CONNECTION = 0,
        KERNEL_LOCAL = 1,
        KERNEL_EXDI_DRIVER = 2,
        KERNEL_IDNA = 3,
        KERNEL_REPT = 5,
        KERNEL_SMALL_DUMP = DUMP_SMALL,
        KERNEL_DUMP = DUMP_DEFAULT,
        KERNEL_ACTIVE_DUMP = DUMP_ACTIVE,
        KERNEL_FULL_DUMP = DUMP_FULL,
        KERNEL_TRACE_LOG = DUMP_TRACE_LOG,

        //Specific types of Windows user debuggees.

        USER_WINDOWS_PROCESS = 0,
        USER_WINDOWS_PROCESS_SERVER = 1,
        USER_WINDOWS_IDNA = 2,
        USER_WINDOWS_REPT = 3,
        USER_WINDOWS_SMALL_DUMP = DUMP_SMALL,
        USER_WINDOWS_DUMP = DUMP_DEFAULT,
        USER_WINDOWS_DUMP_WINDOWS_CE = DUMP_WINDOWS_CE,

        STATIC_TARGET_COMPOSITION = 3143,
        LIVE_TARGET_COMPOSITION = 3144,
        REPLAYABLE_TARGET_COMPSITION = 3145,

        UNINITIALIZED = 4294967295,

        //Generic dump types (could apply to either user or kernel)

        DUMP_SMALL = 1024,
        DUMP_DEFAULT = 1025,
        DUMP_FULL = 1026,
        DUMP_IMAGE_FILE = 1027,
        DUMP_TRACE_LOG = 1028,
        DUMP_WINDOWS_CE = 1029,
        DUMP_ACTIVE = 1030
    }
}
