﻿namespace ClrDebug.DbgEng
{
    public enum DEBUG_CLASS_QUALIFIER : uint
    {
        //Specific types of kernel debuggees.

        KERNEL_CONNECTION = 0,
        KERNEL_LOCAL = 1,
        KERNEL_EXDI_DRIVER = 2,
        KERNEL_IDNA = 3,
        KERNEL_SMALL_DUMP = 1024,
        KERNEL_DUMP = 1025,
        KERNEL_FULL_DUMP = 1026,

        //Specific types of Windows user debuggees.

        USER_WINDOWS_PROCESS = 0,
        USER_WINDOWS_PROCESS_SERVER = 1,
        USER_WINDOWS_IDNA = 2,
        USER_WINDOWS_SMALL_DUMP = 1024,
        USER_WINDOWS_DUMP = 1026,
    }
}
