using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("ulRvaStart = {ulRvaStart}, cbBlock = {cbBlock}, cbLocals = {cbLocals}, cbParams = {cbParams}, cbStkMax = {cbStkMax}, frameFunc = {frameFunc}, cbProlog = {cbProlog}, cbSavedRegs = {cbSavedRegs}, fHasSEH = {fHasSEH}, fHasEH = {fHasEH}, fIsFunctionStart = {fIsFunctionStart}, reserved = {reserved}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct FRAMEDATA
    {
        public int ulRvaStart;
        public int cbBlock;
        public int cbLocals;
        public int cbParams;
        public int cbStkMax;
        public int frameFunc;
        public short cbProlog;
        public short cbSavedRegs;

        #region BitField

        public bool fHasSEH
        {
            get => GetBitFlag(data, 0);
            set => SetBitFlag(ref data, 0, value);
        }

        public bool fHasEH
        {
            get => GetBitFlag(data, 1);
            set => SetBitFlag(ref data, 1, value);
        }

        public bool fIsFunctionStart
        {
            get => GetBitFlag(data, 2);
            set => SetBitFlag(ref data, 2, value);
        }

        public int reserved
        {
            get => GetBits(data, 3, 29); //3-31
            set => SetBits(ref data, 3, 29, value);
        }

        public int data;

        #endregion
    }
}
