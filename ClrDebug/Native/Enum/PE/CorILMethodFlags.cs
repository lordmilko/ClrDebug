using System;

namespace ClrDebug
{
    /// <summary>
    /// Legal values for <see cref="IMAGE_COR_ILMETHOD_FAT.Flags"/> or
    /// <see cref="IMAGE_COR_ILMETHOD_TINY.Flags_CodeSize"/> fields.<para/>
    ///
    /// The only semantic flag at present is <see cref="InitLocals"/>.<para/>
    ///
    /// See also: <see cref="Extensions.CorILMethod_FormatShift"/> and <see cref="Extensions.CorILMethod_FormatMask"/>.
    /// </summary>
    [Flags]
    public enum CorILMethodFlags
    {
        /// <summary>
        /// Call default constructor on all local vars
        /// </summary>
        InitLocals = 0x0010,

        /// <summary>
        /// There is another attribute after this one
        /// </summary>
        MoreSects = 0x0008,

        /// <summary>
        /// Not used.
        /// </summary>
        CompressedIL = 0x0040,

        //Indicates the format for the COR_ILMETHOD header

        /// <summary>
        /// Specifies that the code size is even
        /// </summary>
        TinyFormat = 0x0002,
        SmallFormat = 0x0000,
        FatFormat = 0x0003,

        /// <summary>
        /// Specifies that the code size is odd
        /// </summary>
        TinyFormat1 = 0x0006,
    }
}
