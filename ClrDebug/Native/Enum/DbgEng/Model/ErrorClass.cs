namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the class of error which is being reported to the host.
    /// </summary>
    public enum ErrorClass : uint
    {
        /// <summary>
        /// Warning
        /// </summary>
        ErrorClassWarning,

        /// <summary>
        /// Error
        /// </summary>
        ErrorClassError
    }
}
