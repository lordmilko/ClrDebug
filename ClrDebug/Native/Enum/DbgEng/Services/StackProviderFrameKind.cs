namespace ClrDebug.DbgEng
{
    public enum StackProviderFrameKind : uint
    {
        StackProviderFrameGeneric,
        StackProviderFramePhysical,
        StackProviderFrameInline,
        StackProviderFramePartialPhysical
    }
}
