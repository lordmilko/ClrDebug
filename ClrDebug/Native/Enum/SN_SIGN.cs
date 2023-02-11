namespace ClrDebug
{
    public enum SN_SIGN
    {
        /// <summary>
        /// Rehash all linked modules as well as resigning the manifest
        /// </summary>
        SN_SIGN_ALL_FILES = 0x00000001,

        /// <summary>
        /// Test sign the assembly
        /// </summary>
        SN_TEST_SIGN = 0x00000002,

        /// <summary>
        /// Sign the assembly treating the input key as the real ECMA key
        /// </summary>
        SN_ECMA_SIGN = 0x00000004
    }
}