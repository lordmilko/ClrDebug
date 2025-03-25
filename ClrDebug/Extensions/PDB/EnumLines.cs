using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    public unsafe class EnumLines : Enum
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new EnumLinesVtbl* vtbl => (EnumLinesVtbl*) base.vtbl;

        public EnumLines(IntPtr raw) : base(raw)
        {
        }

        #region GetLines

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate void GetLinesDelegate(
        //    [In] IntPtr @this);

        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private GetLinesDelegate getLines;

        //public void GetLines()
        //{
        //    InitDelegate(ref getLines, vtbl->getLines);

        //    getLines(Raw);
        //}

        #endregion
        #region GetLinesColumns

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetLinesColumnsDelegate(
            [In] IntPtr @this,
            [Out] out int fileId,
            [Out] out int poffset,
            [Out] out short pseg,
            [Out] out int pcb,
            [In, Out] ref int pcLines,
            [Out] out CV_Line_t* pLines,
            [Out] out CV_Column_t* pColumns);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetLinesColumnsDelegate getLinesColumns;

        public bool GetLinesColumns(
            out int fileId,
            out int poffset,
            out short pseg,
            out int pcb,
            ref int pcLines,
            out CV_Line_t* pLines,
            out CV_Column_t* pColumns)
        {
            Extensions.InitDelegate(ref getLinesColumns, vtbl->getLinesColumns);

            return getLinesColumns(Raw, out fileId, out poffset, out pseg, out pcb, ref pcLines, out pLines, out pColumns);
        }

        #endregion
        #region Clone

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate void CloneDelegate(
        //    [In] IntPtr @this);

        //[DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private CloneDelegate clone;

        //public void Clone()
        //{
        //    InitDelegate(ref clone, vtbl->clone);

        //    clone(Raw);
        //}

        #endregion
    }
}
