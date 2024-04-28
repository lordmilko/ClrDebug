namespace ClrDebug.PDB
{
    /// <summary>
    /// type enumeration values
    /// </summary>
    public enum CV_type_e
    {
        /// <summary>
        /// special type size values
        /// </summary>
        CV_SPECIAL      = 0x00,

        /// <summary>
        /// signed integral size values
        /// </summary>
        CV_SIGNED       = 0x01,

        /// <summary>
        /// unsigned integral size values
        /// </summary>
        CV_UNSIGNED     = 0x02,

        /// <summary>
        /// Boolean size values
        /// </summary>
        CV_BOOLEAN      = 0x03,

        /// <summary>
        /// real number size values
        /// </summary>
        CV_REAL         = 0x04,

        /// <summary>
        /// complex number size values
        /// </summary>
        CV_COMPLEX      = 0x05,

        /// <summary>
        /// second set of special types
        /// </summary>
        CV_SPECIAL2     = 0x06,

        /// <summary>
        /// integral (int) values
        /// </summary>
        CV_INT          = 0x07,

        CV_CVRESERVED   = 0x0f,
    }
}
