namespace ClrDebug.DbgEng
{
    public enum IndexSearchFlags : uint
    {
        /// <summary>
        /// IndexSearchImmediateChildrenAreOrContainDescendent Indicates that the search of X will contain the immediate children of X which either are or have descendents that match the search criteria.
        /// </summary>
        IndexSearchImmediateChildrenAreOrContainDescendent = 0x00000001,

        /// <summary>
        /// IndexSearchImmediateChildrenOnlyContainDescendent Indicates that the search of X will contain the immediate children of X which have descendents that match the search criteria.<para/>
        /// The immediate children themselves are not returned.
        /// </summary>
        IndexSearchImmediateChildrenOnlyContainDescendent = 0x00000002,

        /// <summary>
        /// IndexSearchDescendents Indicates that the search of X will contain descendents of X which match the search criteria.<para/>
        /// The results may or may not be immediate children of X. They are, however, always contained in the sub-tree rooted at X.
        /// </summary>
        IndexSearchDescendents = 0x00000004
    }
}
