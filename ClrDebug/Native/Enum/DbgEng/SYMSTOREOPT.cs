using System;

namespace ChaosLib
{
    //https://learn.microsoft.com/en-us/previous-versions/ee942775(v=vs.85)

    [Flags]
    public enum SYMSTOREOPT
    {
        /// <summary>
        /// Compress the file.
        /// </summary>
        SYMSTOREOPT_COMPRESS = 0x1,

        /// <summary>
        /// Overwrite the file if it exists.
        /// </summary>
        SYMSTOREOPT_OVERWRITE = 0x2,

        /// <summary>
        /// Do not report an error if the file already exists in the symbol store.
        /// </summary>
        SYMSTOREOPT_PASS_IF_EXISTS = 0x40,

        /// <summary>
        /// Store in File.ptr.
        /// </summary>
        SYMSTOREOPT_POINTER = 0x8,

        /// <summary>
        /// Return the index only.
        /// </summary>
        SYMSTOREOPT_RETURNINDEX = 0x4,
    }
}
