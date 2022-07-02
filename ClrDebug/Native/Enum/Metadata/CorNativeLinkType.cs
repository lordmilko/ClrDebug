namespace ClrDebug
{
    /// <summary>
    /// Provides values that indicate the type linked in native code.
    /// </summary>
    public enum CorNativeLinkType : byte
    {
        /// <summary>
        /// Indicates that none of the keywords are specified.
        /// </summary>
        nltNone = 1,    // none of the keywords are specified

        /// <summary>
        /// Indicates that an ANSI keyword is specified.
        /// </summary>
        nltAnsi = 2,    // ansi keyword specified

        /// <summary>
        /// Indicates that a Unicode keyword is specified
        /// </summary>
        nltUnicode = 3,    // unicode keyword specified

        /// <summary>
        /// Indicates that an auto keyword is specified.
        /// </summary>
        nltAuto = 4,    // auto keyword specified

        /// <summary>
        /// Indicates that an OLE keyword is specified.
        /// </summary>
        nltOle = 5,    // ole keyword specified

        /// <summary>
        /// Not used.
        /// </summary>
        nltMaxValue = 7,    // used so we can assert how many bits are required for this enum
    }
}