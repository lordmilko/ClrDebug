using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, iLanguage = {iLanguage}, fEC = {fEC}, fNoDbgInfo = {fNoDbgInfo}, fLTCG = {fLTCG}, fNoDataAlign = {fNoDataAlign}, fManagedPresent = {fManagedPresent}, fSecurityChecks = {fSecurityChecks}, fHotPatch = {fHotPatch}, fCVTCIL = {fCVTCIL}, fMSILModule = {fMSILModule}, pad = {pad}, flags = {flags}, machine = {machine}, verFEMajor = {verFEMajor}, verFEMinor = {verFEMinor}, verFEBuild = {verFEBuild}, verMajor = {verMajor}, verMinor = {verMinor}, verBuild = {verBuild}, verSt = {verSt}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct COMPILESYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_COMPILE2
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
        /// reserved, must be 0
        /// </summary>
        public int pad
        {
            get => GetBits(flags, 17, 15); //17-31
            set => SetBits(ref flags, 17, 15, value);
        }

        public int flags; //32 bits

        #endregion

        /// <summary>
        /// target processor
        /// </summary>
        public short machine; //todo: enum?

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
        /// Length-prefixed compiler version string, followed by an optional block of zero terminated strings terminated with a double zero.
        /// </summary>
        public fixed byte verSt[1];
    }
}
