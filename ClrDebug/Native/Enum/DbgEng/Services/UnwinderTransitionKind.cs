namespace ClrDebug.DbgEng
{
    public enum UnwinderTransitionKind : uint
    {
        UnwinderTransitionNone,
        UnwinderTransitionAddFrame,
        UnwinderTransitionUnwindFrame
    }
}
