using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, cbFrame = {cbFrame}, cbPad = {cbPad}, offPad = {offPad.ToString(),nq}, cbSaveRegs = {cbSaveRegs}, offExHdlr = {offExHdlr.ToString(),nq}, sectExHdlr = {sectExHdlr}, fHasAlloca = {fHasAlloca}, fHasSetJmp = {fHasSetJmp}, fHasLongJmp = {fHasLongJmp}, fHasInlAsm = {fHasInlAsm}, fHasEH = {fHasEH}, fInlSpec = {fInlSpec}, fHasSEH = {fHasSEH}, fNaked = {fNaked}, fSecurityChecks = {fSecurityChecks}, fAsyncEH = {fAsyncEH}, fGSNoStackOrdering = {fGSNoStackOrdering}, fWasInlined = {fWasInlined}, fGSCheck = {fGSCheck}, fSafeBuffers = {fSafeBuffers}, encodedLocalBasePointer = {encodedLocalBasePointer}, encodedParamBasePointer = {encodedParamBasePointer}, fPogoOn = {fPogoOn}, fValidCounts = {fValidCounts}, fOptSpeed = {fOptSpeed}, fGuardCF = {fGuardCF}, fGuardCFW = {fGuardCFW}, pad = {pad}, flags = {flags}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FRAMEPROCSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_FRAMEPROC
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// count of bytes of total frame of procedure
        /// </summary>
        public int cbFrame;

        /// <summary>
        /// count of bytes of padding in the frame
        /// </summary>
        public int cbPad;

        /// <summary>
        /// offset (relative to frame poniter) to where padding starts
        /// </summary>
        public CV_uoff32_t offPad;

        /// <summary>
        /// count of bytes of callee save registers
        /// </summary>
        public int cbSaveRegs;

        /// <summary>
        /// offset of exception handler
        /// </summary>
        public CV_uoff32_t offExHdlr;

        /// <summary>
        /// section id of exception handler
        /// </summary>
        public short sectExHdlr;

        #region BitField

        /// <summary>
        /// function uses _alloca()
        /// </summary>
        public bool fHasAlloca
        {
            get => GetBitFlag(flags, 0);
            set => SetBitFlag(ref flags, 0, value);
        }

        /// <summary>
        /// function uses setjmp()
        /// </summary>
        public bool fHasSetJmp
        {
            get => GetBitFlag(flags, 1);
            set => SetBitFlag(ref flags, 1, value);
        }

        /// <summary>
        /// function uses longjmp()
        /// </summary>
        public bool fHasLongJmp
        {
            get => GetBitFlag(flags, 2);
            set => SetBitFlag(ref flags, 2, value);
        }

        /// <summary>
        /// function uses inline asm
        /// </summary>
        public bool fHasInlAsm
        {
            get => GetBitFlag(flags, 3);
            set => SetBitFlag(ref flags, 3, value);
        }

        /// <summary>
        /// function has EH states
        /// </summary>
        public bool fHasEH
        {
            get => GetBitFlag(flags, 4);
            set => SetBitFlag(ref flags, 4, value);
        }

        /// <summary>
        /// function was speced as inline
        /// </summary>
        public bool fInlSpec
        {
            get => GetBitFlag(flags, 5);
            set => SetBitFlag(ref flags, 5, value);
        }

        /// <summary>
        /// function has SEH
        /// </summary>
        public bool fHasSEH
        {
            get => GetBitFlag(flags, 6);
            set => SetBitFlag(ref flags, 6, value);
        }

        /// <summary>
        /// function is __declspec(naked)
        /// </summary>
        public bool fNaked
        {
            get => GetBitFlag(flags, 7);
            set => SetBitFlag(ref flags, 7, value);
        }

        /// <summary>
        /// function has buffer security check introduced by /GS.
        /// </summary>
        public bool fSecurityChecks
        {
            get => GetBitFlag(flags, 8);
            set => SetBitFlag(ref flags, 8, value);
        }

        /// <summary>
        /// function compiled with /EHa
        /// </summary>
        public bool fAsyncEH
        {
            get => GetBitFlag(flags, 9);
            set => SetBitFlag(ref flags, 9, value);
        }

        /// <summary>
        /// function has /GS buffer checks, but stack ordering couldn't be done
        /// </summary>
        public bool fGSNoStackOrdering
        {
            get => GetBitFlag(flags, 10);
            set => SetBitFlag(ref flags, 10, value);
        }

        /// <summary>
        /// function was inlined within another function
        /// </summary>
        public bool fWasInlined
        {
            get => GetBitFlag(flags, 11);
            set => SetBitFlag(ref flags, 11, value);
        }

        /// <summary>
        /// function is __declspec(strict_gs_check)
        /// </summary>
        public bool fGSCheck
        {
            get => GetBitFlag(flags, 12);
            set => SetBitFlag(ref flags, 12, value);
        }

        /// <summary>
        /// function is __declspec(safebuffers)
        /// </summary>
        public bool fSafeBuffers
        {
            get => GetBitFlag(flags, 13);
            set => SetBitFlag(ref flags, 13, value);
        }

        /// <summary>
        /// record function's local pointer explicitly.
        /// </summary>
        public int encodedLocalBasePointer
        {
            get => GetBits(flags, 14, 2); //14-15
            set => SetBits(ref flags, 14, 2, value);
        }

        /// <summary>
        /// record function's parameter pointer explicitly.
        /// </summary>
        public int encodedParamBasePointer
        {
            get => GetBits(flags, 16, 2); //16-17
            set => SetBits(ref flags, 16, 2, value);
        }

        /// <summary>
        /// function was compiled with PGO/PGU
        /// </summary>
        public bool fPogoOn
        {
            get => GetBitFlag(flags, 18);
            set => SetBitFlag(ref flags, 18, value);
        }

        /// <summary>
        /// Do we have valid Pogo counts?
        /// </summary>
        public bool fValidCounts
        {
            get => GetBitFlag(flags, 19);
            set => SetBitFlag(ref flags, 19, value);
        }

        /// <summary>
        /// Did we optimize for speed?
        /// </summary>
        public bool fOptSpeed
        {
            get => GetBitFlag(flags, 20);
            set => SetBitFlag(ref flags, 20, value);
        }

        /// <summary>
        /// function contains CFG checks (and no write checks)
        /// </summary>
        public bool fGuardCF
        {
            get => GetBitFlag(flags, 21);
            set => SetBitFlag(ref flags, 21, value);
        }

        /// <summary>
        /// function contains CFW checks and/or instrumentation
        /// </summary>
        public bool fGuardCFW
        {
            get => GetBitFlag(flags, 22);
            set => SetBitFlag(ref flags, 22, value);
        }

        /// <summary>
        /// must be zero
        /// </summary>
        public int pad
        {
            get => GetBits(flags, 23, 9); //23-31
            set => SetBits(ref flags, 23, 9, value);
        }

        public int flags; //32 bits

        #endregion
    }
}
