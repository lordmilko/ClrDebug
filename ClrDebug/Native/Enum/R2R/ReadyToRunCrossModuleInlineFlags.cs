namespace ClrDebug
{
    public enum ReadyToRunCrossModuleInlineFlags
    {
        CrossModuleInlinee           = 0x1,
        HasCrossModuleInliners       = 0x2,
        CrossModuleInlinerIndexShift = 2,

        InlinerRidHasModule          = 0x1,
        InlinerRidShift              = 1,
    }
}
