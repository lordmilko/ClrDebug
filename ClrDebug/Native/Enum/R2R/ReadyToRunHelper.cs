namespace ClrDebug
{
    public enum ReadyToRunHelper
    {
        READYTORUN_HELPER_Invalid = 0x00,

        // Not a real helper - handle to current module passed to delay load helpers.
        READYTORUN_HELPER_Module = 0x01,
        READYTORUN_HELPER_GSCookie = 0x02,
        READYTORUN_HELPER_IndirectTrapThreads = 0x03,

        //
        // Delay load helpers
        //

        // All delay load helpers use custom calling convention:
        // - scratch register - address of indirection cell. 0 = address is inferred from callsite.
        // - stack - section index, module handle
        READYTORUN_HELPER_DelayLoad_MethodCall = 0x08,

        READYTORUN_HELPER_DelayLoad_Helper = 0x10,
        READYTORUN_HELPER_DelayLoad_Helper_Obj = 0x11,
        READYTORUN_HELPER_DelayLoad_Helper_ObjObj = 0x12,

        // JIT helpers

        // Exception handling helpers
        READYTORUN_HELPER_Throw = 0x20,
        READYTORUN_HELPER_Rethrow = 0x21,
        READYTORUN_HELPER_Overflow = 0x22,
        READYTORUN_HELPER_RngChkFail = 0x23,
        READYTORUN_HELPER_FailFast = 0x24,
        READYTORUN_HELPER_ThrowNullRef = 0x25,
        READYTORUN_HELPER_ThrowDivZero = 0x26,

        // Write barriers
        READYTORUN_HELPER_WriteBarrier = 0x30,
        READYTORUN_HELPER_CheckedWriteBarrier = 0x31,
        READYTORUN_HELPER_ByRefWriteBarrier = 0x32,

        // Array helpers
        READYTORUN_HELPER_Stelem_Ref = 0x38,
        READYTORUN_HELPER_Ldelema_Ref = 0x39,

        READYTORUN_HELPER_MemZero = 0x3E,
        READYTORUN_HELPER_MemSet = 0x3F,
        READYTORUN_HELPER_NativeMemSet = 0x40,
        READYTORUN_HELPER_MemCpy = 0x41,

        // PInvoke helpers
        READYTORUN_HELPER_PInvokeBegin = 0x42,
        READYTORUN_HELPER_PInvokeEnd = 0x43,
        READYTORUN_HELPER_GCPoll = 0x44,
        READYTORUN_HELPER_ReversePInvokeEnter = 0x45,
        READYTORUN_HELPER_ReversePInvokeExit = 0x46,

        // Get string handle lazily
        READYTORUN_HELPER_GetString = 0x50,

        // Used by /Tuning for Profile optimizations
        READYTORUN_HELPER_LogMethodEnter = 0x51,

        // Reflection helpers
        READYTORUN_HELPER_GetRuntimeTypeHandle = 0x54,
        READYTORUN_HELPER_GetRuntimeMethodHandle = 0x55,
        READYTORUN_HELPER_GetRuntimeFieldHandle = 0x56,

        READYTORUN_HELPER_Box = 0x58,
        READYTORUN_HELPER_Box_Nullable = 0x59,
        READYTORUN_HELPER_Unbox = 0x5A,
        READYTORUN_HELPER_Unbox_Nullable = 0x5B,
        READYTORUN_HELPER_NewMultiDimArr = 0x5C,

        // Helpers used with generic handle lookup cases
        READYTORUN_HELPER_NewObject = 0x60,
        READYTORUN_HELPER_NewArray = 0x61,
        READYTORUN_HELPER_CheckCastAny = 0x62,
        READYTORUN_HELPER_CheckInstanceAny = 0x63,
        READYTORUN_HELPER_GenericGcStaticBase = 0x64,
        READYTORUN_HELPER_GenericNonGcStaticBase = 0x65,
        READYTORUN_HELPER_GenericGcTlsBase = 0x66,
        READYTORUN_HELPER_GenericNonGcTlsBase = 0x67,
        READYTORUN_HELPER_VirtualFuncPtr = 0x68,
        READYTORUN_HELPER_IsInstanceOfException = 0x69,
        READYTORUN_HELPER_NewMaybeFrozenArray = 0x6A,
        READYTORUN_HELPER_NewMaybeFrozenObject = 0x6B,

        // Long mul/div/shift ops
        READYTORUN_HELPER_LMul = 0xC0,
        READYTORUN_HELPER_LMulOfv = 0xC1,
        READYTORUN_HELPER_ULMulOvf = 0xC2,
        READYTORUN_HELPER_LDiv = 0xC3,
        READYTORUN_HELPER_LMod = 0xC4,
        READYTORUN_HELPER_ULDiv = 0xC5,
        READYTORUN_HELPER_ULMod = 0xC6,
        READYTORUN_HELPER_LLsh = 0xC7,
        READYTORUN_HELPER_LRsh = 0xC8,
        READYTORUN_HELPER_LRsz = 0xC9,
        READYTORUN_HELPER_Lng2Dbl = 0xCA,
        READYTORUN_HELPER_ULng2Dbl = 0xCB,

        // 32-bit division helpers
        READYTORUN_HELPER_Div = 0xCC,
        READYTORUN_HELPER_Mod = 0xCD,
        READYTORUN_HELPER_UDiv = 0xCE,
        READYTORUN_HELPER_UMod = 0xCF,

        // Floating point conversions
        READYTORUN_HELPER_Dbl2Int = 0xD0,
        READYTORUN_HELPER_Dbl2IntOvf = 0xD1,
        READYTORUN_HELPER_Dbl2Lng = 0xD2,
        READYTORUN_HELPER_Dbl2LngOvf = 0xD3,
        READYTORUN_HELPER_Dbl2UInt = 0xD4,
        READYTORUN_HELPER_Dbl2UIntOvf = 0xD5,
        READYTORUN_HELPER_Dbl2ULng = 0xD6,
        READYTORUN_HELPER_Dbl2ULngOvf = 0xD7,

        // Floating point ops
        READYTORUN_HELPER_DblRem = 0xE0,
        READYTORUN_HELPER_FltRem = 0xE1,

        // These two helpers can be removed once MINIMUM_READYTORUN_MAJOR_VERSION is 10+
        // alongside the CORINFO_HELP_FLTROUND/CORINFO_HELP_DBLROUND
        // counterparts and all related code.
        READYTORUN_HELPER_DblRound = 0xE2,
        READYTORUN_HELPER_FltRound = 0xE3,

        // Personality routines
        READYTORUN_HELPER_PersonalityRoutine = 0xF0,
        READYTORUN_HELPER_PersonalityRoutineFilterFunclet = 0xF1,

        // Synchronized methods
        READYTORUN_HELPER_MonitorEnter = 0xF8,
        READYTORUN_HELPER_MonitorExit = 0xF9,

        //
        // Deprecated/legacy
        //

        // JIT32 x86-specific write barriers
        READYTORUN_HELPER_WriteBarrier_EAX = 0x100,
        READYTORUN_HELPER_WriteBarrier_EBX = 0x101,
        READYTORUN_HELPER_WriteBarrier_ECX = 0x102,
        READYTORUN_HELPER_WriteBarrier_ESI = 0x103,
        READYTORUN_HELPER_WriteBarrier_EDI = 0x104,
        READYTORUN_HELPER_WriteBarrier_EBP = 0x105,
        READYTORUN_HELPER_CheckedWriteBarrier_EAX = 0x106,
        READYTORUN_HELPER_CheckedWriteBarrier_EBX = 0x107,
        READYTORUN_HELPER_CheckedWriteBarrier_ECX = 0x108,
        READYTORUN_HELPER_CheckedWriteBarrier_ESI = 0x109,
        READYTORUN_HELPER_CheckedWriteBarrier_EDI = 0x10A,
        READYTORUN_HELPER_CheckedWriteBarrier_EBP = 0x10B,

        // JIT32 x86-specific exception handling
        READYTORUN_HELPER_EndCatch = 0x110,

        // Stack probing helper
        READYTORUN_HELPER_StackProbe = 0x111,

        READYTORUN_HELPER_GetCurrentManagedThreadId = 0x112,
    }
}
