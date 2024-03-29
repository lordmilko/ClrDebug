﻿namespace ClrDebug.DbgEng
{
    public enum DEBUG_HANDLE_DATA_TYPE : uint
    {
        BASIC = 0,
        TYPE_NAME = 1,
        OBJECT_NAME = 2,
        HANDLE_COUNT = 3,
        TYPE_NAME_WIDE = 4,
        OBJECT_NAME_WIDE = 5,
        MINI_THREAD_1 = 6,
        MINI_MUTANT_1 = 7,
        MINI_MUTANT_2 = 8,
        PER_HANDLE_OPERATIONS = 9,
        ALL_HANDLE_OPERATIONS = 10,
        MINI_PROCESS_1 = 11,
        MINI_PROCESS_2 = 12,
        MINI_EVENT_1 = 13,
        MINI_SECTION_1 = 14,
        MINI_SEMAPHORE_1 = 15
    }
}
