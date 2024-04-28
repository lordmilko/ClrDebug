using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct COMPILESYM3
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_COMPILE3
        /// </summary>
        public SYM_ENUM_e rectyp;

        #region BitField

        /// <summary>
        /// language index
        /// </summary>
        public int iLanguage
        {
            get => GetBits(flags, 0, 8); //0-7
            set => SetBits(ref flags, 0, 8, value);
        }

        /// <summary>
        /// compiled for E/C
        /// </summary>
        public bool fEC
        {
            get => GetBitFlag(flags, 8);
            set => SetBitFlag(ref flags, 8, value);
        }

        /// <summary>
        /// not compiled with debug info
        /// </summary>
        public bool fNoDbgInfo
        {
            get => GetBitFlag(flags, 9);
            set => SetBitFlag(ref flags, 9, value);
        }

        /// <summary>
        /// compiled with LTCG
        /// </summary>
        public bool fLTCG
        {
            get => GetBitFlag(flags, 10);
            set => SetBitFlag(ref flags, 10, value);
        }

        /// <summary>
        /// compiled with -Bzalign
        /// </summary>
        public bool fNoDataAlign
        {
            get => GetBitFlag(flags, 11);
            set => SetBitFlag(ref flags, 11, value);
        }

        /// <summary>
        /// managed code/data present
        /// </summary>
        public bool fManagedPresent
        {
            get => GetBitFlag(flags, 12);
            set => SetBitFlag(ref flags, 12, value);
        }

        /// <summary>
        /// compiled with /GS
        /// </summary>
        public bool fSecurityChecks
        {
            get => GetBitFlag(flags, 13);
            set => SetBitFlag(ref flags, 13, value);
        }

        /// <summary>
        /// compiled with /hotpatch
        /// </summary>
        public bool fHotPatch
        {
            get => GetBitFlag(flags, 14);
            set => SetBitFlag(ref flags, 14, value);
        }

        /// <summary>
        /// converted with CVTCIL
        /// </summary>
        public bool fCVTCIL
        {
            get => GetBitFlag(flags, 15);
            set => SetBitFlag(ref flags, 15, value);
        }

        /// <summary>
        /// MSIL netmodule
        /// </summary>
        public bool fMSILModule
        {
            get => GetBitFlag(flags, 16);
            set => SetBitFlag(ref flags, 16, value);
        }

        /// <summary>
        /// compiled with /sdl
        /// </summary>
        public bool fSdl
        {
            get => GetBitFlag(flags, 17);
            set => SetBitFlag(ref flags, 17, value);
        }

        /// <summary>
        /// compiled with /ltcg:pgo or pgu
        /// </summary>
        public bool fPGO
        {
            get => GetBitFlag(flags, 18);
            set => SetBitFlag(ref flags, 18, value);
        }

        /// <summary>
        /// .exp module
        /// </summary>
        public bool fExp
        {
            get => GetBitFlag(flags, 19);
            set => SetBitFlag(ref flags, 19, value);
        }

        /// <summary>
        /// reserved, must be 0
        /// </summary>
        public int pad
        {
            get => GetBits(flags, 20, 12); //20-31
            set => SetBits(ref flags, 20, 12, value);
        }

        public int flags; //32 bits

        #endregion

        /// <summary>
        /// target processor
        /// </summary>
        public short machine;

        /// <summary>
        /// front end major version #
        /// </summary>
        public short verFEMajor;

        /// <summary>
        /// front end minor version #
        /// </summary>
        public short verFEMinor;

        /// <summary>
        /// front end build version #
        /// </summary>
        public short verFEBuild;

        /// <summary>
        /// front end QFE version #
        /// </summary>
        public short verFEQFE;

        /// <summary>
        /// back end major version #
        /// </summary>
        public short verMajor;

        /// <summary>
        /// back end minor version #
        /// </summary>
        public short verMinor;

        /// <summary>
        /// back end build version #
        /// </summary>
        public short verBuild;

        /// <summary>
        /// back end QFE version #
        /// </summary>
        public short verQFE;

        /// <summary>
        /// Zero terminated compiler version string
        /// </summary>
        public fixed byte verSz[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = verSz)
                return CreateString(ptr);
        }
    }
}
