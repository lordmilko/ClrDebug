namespace ClrDebug
{
    public enum SLE : uint
    {
        /// <summary>
        /// Indicates that invalid data was passed to the function that failed. This caused the application to fail.
        /// </summary>
        ERROR = 0x00000001,

        /// <summary>
        /// Indicates that invalid data was passed to the function, but the error probably will not cause the application to fail.
        /// </summary>
        MINORERROR = 0x00000002,

        /// <summary>
        /// Indicates that potentially invalid data was passed to the function, but the function completed processing.
        /// </summary>
        WARNING = 0x00000003
    }
}
