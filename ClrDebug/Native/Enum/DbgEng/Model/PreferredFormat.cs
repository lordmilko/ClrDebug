namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Predefined values of the "PreferredFormat" key which may appear as the metadata on a returned key value. This indicates the preferred DISPLAY FORMAT for a given value.
    /// </summary>
    public enum PreferredFormat : uint
    {
        /// <summary>
        /// There is no preferred format
        /// </summary>
        FormatNone,

        /// <summary>
        /// The preferred format is a single character as '*'
        /// </summary>
        FormatSingleCharacter,

        /// <summary>
        /// The preferred format is a quoted 8-bit string
        /// </summary>
        FormatQuotedString,

        /// <summary>
        /// The preferred format is a non-quoted 8-bit string
        /// </summary>
        FormatString,

        /// <summary>
        /// The preferred format is a quoted Unicode (UTF-16) string
        /// </summary>
        FormatQuotedUnicodeString,

        /// <summary>
        /// The preferred format is a non-quoted Unicode (UTF-16) string
        /// </summary>
        FormatUnicodeString,

        /// <summary>
        /// The preferred format is a quoted UTF-8 string
        /// </summary>
        FormatQuotedUTF8String,

        /// <summary>
        /// The preferred format is a non-quoted UTF-8 string
        /// </summary>
        FormatUTF8String,

        /// <summary>
        /// The preferred format is a quoted BSTR
        /// </summary>
        FormatBSTRString,

        /// <summary>
        /// The preferred format is a quoted WinRT HSTRING
        /// </summary>
        FormatQuotedHString,

        /// <summary>
        /// The preferred format is a non-quoted WinRT HSTRING
        /// </summary>
        FormatHString,

        /// <summary>
        /// The preferred format is the raw (native) type
        /// </summary>
        FormatRaw,

        /// <summary>
        /// The preferred format is the enum name only
        /// </summary>
        FormatEnumNameOnly,

        /// <summary>
        /// The preferred format is the quoted string with escaped characters
        /// </summary>
        FormatEscapedStringWithQuote,

        /// <summary>
        /// The preferred format is a non-quoted Unicode (UTF-32) string
        /// </summary>
        FormatUTF32String,

        /// <summary>
        /// The preferred format is a quoted Unicode (UTF-32) string
        /// </summary>
        FormatQuotedUTF32String
    }
}
