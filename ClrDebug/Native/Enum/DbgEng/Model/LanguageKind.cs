namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Identifies the language of the compiland containing a given symbol.
    /// </summary>
    public enum LanguageKind : uint
    {
        /// <summary>
        /// Indicates that the language cannot be identified
        /// </summary>
        LanguageUnknown,

        /// <summary>
        /// Indicates the C language
        /// </summary>
        LanguageC,

        /// <summary>
        /// Indicates the C++ language
        /// </summary>
        LanguageCPP,

        /// <summary>
        /// Indicates the assembly language
        /// </summary>
        LanguageAssembly,
        LanguageRust
    }
}
