namespace ClrDebug.DbgEng
{
    public enum VersionKind : uint
    {
        /// <summary>
        /// Leave it to the provider to interpret what kind of version information to return.
        /// </summary>
        VersionGeneric,

        /// <summary>
        /// The version information associated with the image file itself.
        /// </summary>
        VersionFile,

        /// <summary>
        /// The verison information associated with the package that the image file belongs to.
        /// </summary>
        VersionPackage,

        /// <summary>
        /// The version information associated with the distribution / product that the image file shipped with.
        /// </summary>
        VersionDistribution
    }
}
