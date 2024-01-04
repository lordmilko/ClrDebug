namespace ClrDebug.DbgEng
{
    public enum IndexSearchFlags : uint
    {
        IndexSearchImmediateChildrenAreOrContainDescendent = 0x00000001,
        IndexSearchImmediateChildrenOnlyContainDescendent = 0x00000002,
        IndexSearchDescendents = 0x00000004
    }
}
