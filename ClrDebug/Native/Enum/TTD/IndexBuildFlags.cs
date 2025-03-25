namespace ClrDebug.TTD
{
    public enum IndexBuildFlags
    {
        /// <summary>
        /// Create an index for the trace file (if one is not already present).
        /// </summary>
        Default = 0,

        /// <summary>
        /// Create an index for the trace file (overwrites existing index).
        /// </summary>
        Force = 1,

        /// <summary>
        /// Create a temporary index for trace file (deleted when the trace file is closed)
        /// </summary>
        Temporary = 3,
    }
}