namespace ClrDebug
{
    /// <summary>
    /// Contains values that describe the type of file mapping that is returned from a call to the <see cref="IMetaDataInfo.GetFileMapping"/> method.
    /// </summary>
    public enum CorFileMapping
    {
        /// <summary>
        /// The file is mapped as a data file. That is, the SEC_IMAGE flag was not passed to the Microsoft Win32 CreateFileMapping function.
        /// </summary>
        fmFlat = 0,

        /// <summary>
        /// The file is mapped for execution, by using either the LoadLibrary function or the CreateFileMapping function with the SEC_IMAGE flag.
        /// </summary>
        fmExecutableImage = 1,
    }
}