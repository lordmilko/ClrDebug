using System;

namespace ClrDebug
{
    [Flags]
    public enum ReadyToRunFieldSigFlags
    {
        READYTORUN_FIELD_SIG_MemberRefToken = 0x10,
        READYTORUN_FIELD_SIG_OwnerType = 0x40,
    }
}
