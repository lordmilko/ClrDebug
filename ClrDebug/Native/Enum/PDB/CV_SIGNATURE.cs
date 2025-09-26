namespace ClrDebug.PDB
{
    public enum CV_SIGNATURE : byte //It's normally an int, but in OMFTypeFlags it needs to be a byte
    {
        /// <summary>
        /// Described by microsoft-pdb as "Actual signature is >64K"<para/>
        /// This enum value is special in that it represents the absence of a value. <see cref="CV_SIGNATURE"/> was not used
        /// until C7. When inspecting a <see cref="CV_SIGNATURE"/>, if the value does not match C7, C11 or C13, it is assumed to be C6,
        /// in which case the 4 bytes that were interpreted as being a signature are actually data<para/>
        /// I don't know what the >64K remark refers to. When you incorrectly interpret symbol data as a <see cref="CV_SIGNATURE"/>
        /// you may get a value in the thousands, but not above 64K.
        /// </summary>
        C6 = 0,

        /// <summary>
        /// First explicit signature
        /// </summary>
        C7 = 1,

        /// <summary>
        /// C11 (vc5.x) 32-bit types
        /// </summary>
        C11 = 2,

        /// <summary>
        /// C13 (vc7.x) zero terminated names
        /// </summary>
        C13 = 4
    }
}
