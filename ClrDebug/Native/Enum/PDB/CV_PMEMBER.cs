namespace ClrDebug.PDB
{
    public enum CV_PMEMBER
    {
        /// <summary>
        /// 16:16 data no virtual fcn or base
        /// </summary>
        CV_PDM16_NONVIRT = 0x00,

        /// <summary>
        /// 16:16 data with virtual functions
        /// </summary>
        CV_PDM16_VFCN = 0x01,

        /// <summary>
        /// 16:16 data with virtual bases
        /// </summary>
        CV_PDM16_VBASE = 0x02,

        /// <summary>
        /// 16:32 data w/wo virtual functions
        /// </summary>
        CV_PDM32_NVVFCN = 0x03,

        /// <summary>
        /// 16:32 data with virtual bases
        /// </summary>
        CV_PDM32_VBASE = 0x04,

        /// <summary>
        /// 16:16 near method nonvirtual single address point
        /// </summary>
        CV_PMF16_NEARNVSA = 0x05,

        /// <summary>
        /// 16:16 near method nonvirtual multiple address points
        /// </summary>
        CV_PMF16_NEARNVMA = 0x06,

        /// <summary>
        /// 16:16 near method virtual bases
        /// </summary>
        CV_PMF16_NEARVBASE = 0x07,

        /// <summary>
        /// 16:16 far method nonvirtual single address point
        /// </summary>
        CV_PMF16_FARNVSA = 0x08,

        /// <summary>
        /// 16:16 far method nonvirtual multiple address points
        /// </summary>
        CV_PMF16_FARNVMA = 0x09,

        /// <summary>
        /// 16:16 far method virtual bases
        /// </summary>
        CV_PMF16_FARVBASE = 0x0a,

        /// <summary>
        /// 16:32 method nonvirtual single address point
        /// </summary>
        CV_PMF32_NVSA = 0x0b,

        /// <summary>
        /// 16:32 method nonvirtual multiple address point
        /// </summary>
        CV_PMF32_NVMA = 0x0c,

        /// <summary>
        /// 16:32 method virtual bases
        /// </summary>
        CV_PMF32_VBASE = 0x0d
    }
}
