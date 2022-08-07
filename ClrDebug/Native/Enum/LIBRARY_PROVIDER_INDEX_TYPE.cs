namespace ClrDebug
{
    /// <summary>
    /// The type of index information passed to the library provider is either the identity of the requested module or of the runtime (coreclr) module.
    /// </summary>
    /// <remarks>
    /// The "index information" is the timestamp/file size on Windows or the build id on Linux/MacOS.
    /// </remarks>
    public enum LIBRARY_PROVIDER_INDEX_TYPE
    {
        /// <summary>
        /// Invalid index type.
        /// </summary>
        Unknown,

        /// <summary>
        /// The index information of the requested module.
        /// </summary>
        Identity,

        /// <summary>
        /// The runtime module's index information.
        /// </summary>
        Runtime,
    }
}
