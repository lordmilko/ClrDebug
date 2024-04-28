using System.Diagnostics;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("grfFlags = {grfFlags}, fCode = {fCode}, fFunction = {fFunction}, fManaged = {fManaged}, fMSIL = {fMSIL}, __unused = {__unused}")]
    public struct CV_PUBSYMFLAGS
    {
        public int grfFlags;

        //Bitfields in grfFlags

        /// <summary>
        /// set if public symbol refers to a code address
        /// </summary>
        public bool fCode
        {
            get => GetBitFlag(grfFlags, 0);
            set => SetBitFlag(ref grfFlags, 0, value);
        }

        /// <summary>
        /// set if public symbol is a function
        /// </summary>
        public bool fFunction
        {
            get => GetBitFlag(grfFlags, 1);
            set => SetBitFlag(ref grfFlags, 1, value);
        }

        /// <summary>
        /// set if managed code (native or IL)
        /// </summary>
        public bool fManaged
        {
            get => GetBitFlag(grfFlags, 2);
            set => SetBitFlag(ref grfFlags, 2, value);
        }

        /// <summary>
        /// set if managed IL code
        /// </summary>
        public bool fMSIL
        {
            get => GetBitFlag(grfFlags, 3);
            set => SetBitFlag(ref grfFlags, 3, value);
        }

        /// <summary>
        /// must be zero
        /// </summary>
        public int __unused
        {
            get => GetBits(grfFlags, 4, 28); //4-31
            set => SetBits(ref grfFlags, 4, 28, value);
        }
    }
}
