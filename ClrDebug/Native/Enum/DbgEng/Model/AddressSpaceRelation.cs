namespace ClrDebug.DbgEng
{
    public enum AddressSpaceRelation : uint
    {
        Disjoint,
        Equal,
        Overlapping,
        Subset,
        Superset
    }
}
