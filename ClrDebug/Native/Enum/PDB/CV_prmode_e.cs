namespace ClrDebug.PDB
{
    /// <summary>
    /// pointer mode enumeration values
    /// </summary>
    public enum CV_prmode_e
    {
        /// <summary>
        /// mode is not a pointer
        /// </summary>
        CV_TM_DIRECT = 0,

        /// <summary>
        /// mode is a near pointer
        /// </summary>
        CV_TM_NPTR   = 1,

        /// <summary>
        /// mode is a far pointer
        /// </summary>
        CV_TM_FPTR   = 2,

        /// <summary>
        /// mode is a huge pointer
        /// </summary>
        CV_TM_HPTR   = 3,

        /// <summary>
        /// mode is a 32 bit near pointer
        /// </summary>
        CV_TM_NPTR32 = 4,

        /// <summary>
        /// mode is a 32 bit far pointer
        /// </summary>
        CV_TM_FPTR32 = 5,

        /// <summary>
        /// mode is a 64 bit near pointer
        /// </summary>
        CV_TM_NPTR64 = 6,

        /// <summary>
        /// mode is a 128 bit near pointer
        /// </summary>
        CV_TM_NPTR128 = 7
    }
}
