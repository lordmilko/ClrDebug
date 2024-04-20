namespace ClrDebug
{
    public enum ReadyToRunMethodSigFlags
    {
        READYTORUN_METHOD_SIG_UnboxingStub = 0x01,
        READYTORUN_METHOD_SIG_InstantiatingStub = 0x02,
        READYTORUN_METHOD_SIG_MethodInstantiation = 0x04,
        READYTORUN_METHOD_SIG_SlotInsteadOfToken = 0x08,
        READYTORUN_METHOD_SIG_MemberRefToken = 0x10,
        READYTORUN_METHOD_SIG_Constrained = 0x20,
        READYTORUN_METHOD_SIG_OwnerType = 0x40,
        READYTORUN_METHOD_SIG_UpdateContext = 0x80,
    }
}
