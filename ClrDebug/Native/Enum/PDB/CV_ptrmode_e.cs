namespace ClrDebug.PDB
{
    /// <summary>
    ///  Mode enum for pointers
    /// </summary>
    /// <remarks>
    /// To support for l-value and r-value reference, we added CV_PTR_MODE_LVREF
    /// and CV_PTR_MODE_RVREF.  CV_PTR_MODE_REF should be removed at some point.
    /// We keep it now so that old code that uses it won't be broken.
    /// </remarks>
    public enum CV_ptrmode_e : byte
    {
        /// <summary>
        /// "normal" pointer
        /// </summary>
        CV_PTR_MODE_PTR     = 0x00,

        /// <summary>
        /// "old" reference
        /// </summary>
        CV_PTR_MODE_REF     = 0x01,

        /// <summary>
        /// l-value reference
        /// </summary>
        CV_PTR_MODE_LVREF   = 0x01,

        /// <summary>
        /// pointer to data member
        /// </summary>
        CV_PTR_MODE_PMEM    = 0x02,

        /// <summary>
        /// pointer to member function
        /// </summary>
        CV_PTR_MODE_PMFUNC  = 0x03,

        /// <summary>
        /// r-value reference
        /// </summary>
        CV_PTR_MODE_RVREF   = 0x04,

        CV_PTR_MODE_RESERVED = 0x05  // first unused pointer mode
    }
}
