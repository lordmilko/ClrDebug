namespace ClrDebug.PDB
{
    /// <summary>
    /// Type enum for pointer records
    /// </summary>
    public enum CV_ptrtype_e
    {
        /// <summary>
        /// 16 bit pointer
        /// </summary>
        CV_PTR_NEAR = 0x00,

        /// <summary>
        /// 16:16 far pointer
        /// </summary>
        CV_PTR_FAR = 0x01,

        /// <summary>
        /// 16:16 huge pointer
        /// </summary>
        CV_PTR_HUGE = 0x02,

        /// <summary>
        /// based on segment
        /// </summary>
        CV_PTR_BASE_SEG = 0x03,

        /// <summary>
        /// based on value of base
        /// </summary>
        CV_PTR_BASE_VAL = 0x04,

        /// <summary>
        /// based on segment value of base
        /// </summary>
        CV_PTR_BASE_SEGVAL = 0x05,

        /// <summary>
        /// based on address of base
        /// </summary>
        CV_PTR_BASE_ADDR = 0x06,

        /// <summary>
        /// based on segment address of base
        /// </summary>
        CV_PTR_BASE_SEGADDR = 0x07,

        /// <summary>
        /// based on type
        /// </summary>
        CV_PTR_BASE_TYPE = 0x08,

        /// <summary>
        /// based on self
        /// </summary>
        CV_PTR_BASE_SELF = 0x09,

        /// <summary>
        /// 32 bit pointer
        /// </summary>
        CV_PTR_NEAR32 = 0x0a,

        /// <summary>
        /// 16:32 pointer
        /// </summary>
        CV_PTR_FAR32 = 0x0b,

        /// <summary>
        /// 64 bit pointer
        /// </summary>
        CV_PTR_64 = 0x0c,

        CV_PTR_UNUSEDPTR = 0x0d  // first unused pointer type
    }
}
