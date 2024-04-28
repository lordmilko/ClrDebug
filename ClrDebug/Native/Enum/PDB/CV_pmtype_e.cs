namespace ClrDebug.PDB
{
    /// <summary>
    /// enumeration for pointer-to-member types
    /// </summary>
    public enum CV_pmtype_e : short
    {
        /// <summary>
        /// not specified (pre VC8)
        /// </summary>
        CV_PMTYPE_Undef     = 0x00,

        /// <summary>
        /// member data, single inheritance
        /// </summary>
        CV_PMTYPE_D_Single  = 0x01,

        /// <summary>
        /// member data, multiple inheritance
        /// </summary>
        CV_PMTYPE_D_Multiple= 0x02,

        /// <summary>
        /// member data, virtual inheritance
        /// </summary>
        CV_PMTYPE_D_Virtual = 0x03,

        /// <summary>
        /// member data, most general
        /// </summary>
        CV_PMTYPE_D_General = 0x04,

        /// <summary>
        /// member function, single inheritance
        /// </summary>
        CV_PMTYPE_F_Single  = 0x05,

        /// <summary>
        /// member function, multiple inheritance
        /// </summary>
        CV_PMTYPE_F_Multiple= 0x06,

        /// <summary>
        /// member function, virtual inheritance
        /// </summary>
        CV_PMTYPE_F_Virtual = 0x07,

        /// <summary>
        /// member function, most general
        /// </summary>
        CV_PMTYPE_F_General = 0x08
    }
}
