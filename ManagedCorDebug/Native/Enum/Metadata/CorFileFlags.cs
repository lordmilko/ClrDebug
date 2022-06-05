using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that describe the type of file defined in a call to <see cref="IMetaDataAssemblyEmit.DefineFile"/>.
    /// </summary>
    [Flags]
    public enum CorFileFlags : uint
    {
        /// <summary>
        /// Indicates that the file is not a resource file.
        /// </summary>
        ffContainsMetaData = 0x0000,     // This is not a resource file

        /// <summary>
        /// Indicates that the file, possibly a resource file, does not contain metadata.
        /// </summary>
        ffContainsNoMetaData = 0x0001,     // This is a resource file or other non-metadata-containing file
    }
}