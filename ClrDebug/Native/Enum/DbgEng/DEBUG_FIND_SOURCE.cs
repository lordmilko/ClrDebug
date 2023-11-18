using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// FindSourceFile flags.
    /// </summary>
    [Flags]
    public enum DEBUG_FIND_SOURCE : uint
    {
        DEFAULT = 0,

        /// <summary>
        /// Returns fully-qualified paths only. If this is not set the path returned may be relative.
        /// </summary>
        FULL_PATH = 1,

        /// <summary>
        /// Scans all the path elements for a match and returns the one that has the most similarity
        /// between the given file and the matching element.
        /// </summary>
        BEST_MATCH = 2,

        /// <summary>
        /// Do not search source server paths.
        /// </summary>
        NO_SRCSRV = 4,

        /// <summary>
        /// Restrict FindSourceFileAndToken to token lookup only.
        /// </summary>
        TOKEN_LOOKUP = 8,

        /// <summary>
        /// Indicates that the FileToken/FileTokenSize arguments refer to the checksum information
        /// for the source file obtained from a call to the GetSourceFileInformation method with
        /// the 'Which' parameter set to DEBUG_SRCFILE_SYMBOL_CHECKSUMINFO
        /// </summary>
        WITH_CHECKSUM = 16,

        /// <summary>
        /// This option is similar to DEBUG_FIND_SOURCE_WITH_CHECKSUM. The only difference is that
        /// DEBUG_SRCFILE_SYMBOL_CHECKSUMINFO will check for a checksum but won't enforce it i.e.
        /// if a file is found it may or may not match the requested checksum.
        /// DEBUG_FIND_SOURCE_WITH_CHECKSUM_STRICT eliminates this ambiguity i.e. if the file is found
        /// for sure it matches the checksum.<para/>
        ///
        /// Please note that line endings of the file may change when downloading a source file from
        /// various source code repositories. This means that the downloaded file would have a checksum
        /// which depends on file content and the updated line endings. The engine will try to match
        /// the checksum of the file to the requested checksum. If they don't match, the engine will
        /// calculate an alternative checksum of the file with modified line endings and will try to
        /// match it to the requested checksum.<para/>
        ///
        /// In summary: DEBUG_FIND_SOURCE_WITH_CHECKSUM_STRICT will return a file if its checksum
        /// matches to the requested checksum, or if the file's checksum calculated based on updated
        /// line endings matches the requested checksum.
        /// </summary>
        WITH_CHECKSUM_STRICT = 32
    }
}
