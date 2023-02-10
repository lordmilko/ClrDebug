namespace ClrDebug
{
    /// <summary>
    /// Contains values that indicate the version of the common language runtime (CLR): desktop or CoreCLR, which is used in Silverlight.
    /// </summary>
    public enum COR_PRF_RUNTIME_TYPE
    {
        /// <summary>
        /// The desktop version of the CLR.
        /// </summary>
        COR_PRF_DESKTOP_CLR = 1,

        /// <summary>
        /// The core version of the CLR, used in Silverlight.
        /// </summary>
        COR_PRF_CORE_CLR = 2,
    }
}
