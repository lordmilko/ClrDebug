using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains flag values that control metadata behavior upon opening manifest files.
    /// </summary>
    [Flags]
    public enum CorOpenFlags : uint
    {
        /// <summary>
        /// Indicates that the file should be opened for reading only.
        /// </summary>
        ofRead = 0x00000000,     // Open scope for read

        /// <summary>
        /// Indicates that the file should be opened for writing. If you are using the ofWrite flag when opening a .winmd file, you should also pass the ofNoTransform flag.
        /// </summary>
        ofWrite = 0x00000001,     // Open scope for write.

        /// <summary>
        /// A mask for reading and writing.
        /// </summary>
        ofReadWriteMask = 0x00000001,     // Mask for read/write bit.

        /// <summary>
        /// Indicates that the file should be read into memory. Metadata should maintain its own copy.
        /// </summary>
        ofCopyMemory = 0x00000002,     // Open scope with memory. Ask metadata to maintain its own copy of memory.

        /// <summary>
        /// Indicates that the file should be opened for reading, and that a call to QueryInterface for an <see cref="IMetaDataEmit"/> cannot be made.
        /// </summary>
        ofReadOnly = 0x00000010,     // Open scope for read. Will be unable to QI for a IMetadataEmit* interface

        /// <summary>
        /// Indicates that the memory was allocated using a call to CoTaskMemAlloc and will be freed by the metadata.
        /// </summary>
        ofTakeOwnership = 0x00000020,     // The memory was allocated with CoTaskMemAlloc and will be freed by the metadata

        /// <summary>
        /// Obsolete. This flag is ignored.
        /// </summary>
        ofNoTypeLib = 0x00000080,     // Don't OpenScope on a typelib.

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        ofReserved1 = 0x00000100,     // Reserved for internal use.

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        ofReserved2 = 0x00000200,     // Reserved for internal use.

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        ofReserved3 = 0x00000400,     // Reserved for internal use.

        /// <summary>
        /// Reserved for internal use.
        /// </summary>
        ofReserved = 0xffffff40      // All the reserved bits.
    }
}