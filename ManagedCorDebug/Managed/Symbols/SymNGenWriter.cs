using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class SymNGenWriter : ComObject<ISymNGenWriter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymNGenWriter"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymNGenWriter(ISymNGenWriter raw) : base(raw)
        {
        }

        #region ISymNGenWriter
        #region AddSymbol

        public void AddSymbol(string pSymbol, ushort iSection, long rva)
        {
            HRESULT hr;

            if ((hr = TryAddSymbol(pSymbol, iSection, rva)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryAddSymbol(string pSymbol, ushort iSection, long rva)
        {
            /*HRESULT AddSymbol([MarshalAs(UnmanagedType.BStr), In] string pSymbol, [In] ushort iSection, [In] long rva);*/
            return Raw.AddSymbol(pSymbol, iSection, rva);
        }

        #endregion
        #region AddSection

        public void AddSection(ushort iSection, ushort flags, int offset, int cb)
        {
            HRESULT hr;

            if ((hr = TryAddSection(iSection, flags, offset, cb)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryAddSection(ushort iSection, ushort flags, int offset, int cb)
        {
            /*HRESULT AddSection([In] ushort iSection, [In] ushort flags, [In] int offset, [In] int cb);*/
            return Raw.AddSection(iSection, flags, offset, cb);
        }

        #endregion
        #endregion
        #region ISymNGenWriter2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISymNGenWriter2 Raw2 => (ISymNGenWriter2) Raw;

        #region OpenModW

        public IntPtr OpenModW(string wszModule, string wszObjFile)
        {
            HRESULT hr;
            IntPtr ppmod = default(IntPtr);

            if ((hr = TryOpenModW(wszModule, wszObjFile, ref ppmod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppmod;
        }

        public HRESULT TryOpenModW(string wszModule, string wszObjFile, ref IntPtr ppmod)
        {
            /*HRESULT OpenModW([In, MarshalAs(UnmanagedType.LPWStr)] string wszModule, [In, MarshalAs(UnmanagedType.LPWStr)] string wszObjFile, [Out] IntPtr ppmod);*/
            return Raw2.OpenModW(wszModule, wszObjFile, ppmod);
        }

        #endregion
        #region CloseMod

        public void CloseMod(IntPtr pmod)
        {
            HRESULT hr;

            if ((hr = TryCloseMod(pmod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCloseMod(IntPtr pmod)
        {
            /*HRESULT CloseMod([In] IntPtr pmod);*/
            return Raw2.CloseMod(pmod);
        }

        #endregion
        #region ModAddSymbols

        public void ModAddSymbols(IntPtr pmod, IntPtr pbSym, int cb)
        {
            HRESULT hr;

            if ((hr = TryModAddSymbols(pmod, pbSym, cb)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryModAddSymbols(IntPtr pmod, IntPtr pbSym, int cb)
        {
            /*HRESULT ModAddSymbols([In] IntPtr pmod, [In] IntPtr pbSym, [In] int cb);*/
            return Raw2.ModAddSymbols(pmod, pbSym, cb);
        }

        #endregion
        #region ModAddSecContribEx

        public void ModAddSecContribEx(IntPtr pmod, ushort isect, int off, int cb, int dwCharacteristics, int dwDataCrc, int dwRelocCrc)
        {
            HRESULT hr;

            if ((hr = TryModAddSecContribEx(pmod, isect, off, cb, dwCharacteristics, dwDataCrc, dwRelocCrc)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryModAddSecContribEx(IntPtr pmod, ushort isect, int off, int cb, int dwCharacteristics, int dwDataCrc, int dwRelocCrc)
        {
            /*HRESULT ModAddSecContribEx(
            [In] IntPtr pmod,
            [In] ushort isect,
            [In] int off,
            [In] int cb,
            [In] int dwCharacteristics,
            [In] int dwDataCrc,
            [In] int dwRelocCrc);*/
            return Raw2.ModAddSecContribEx(pmod, isect, off, cb, dwCharacteristics, dwDataCrc, dwRelocCrc);
        }

        #endregion
        #region QueryPDBNameExW

        public string QueryPDBNameExW(long cchMax)
        {
            HRESULT hr;
            string wszPDBResult;

            if ((hr = TryQueryPDBNameExW(cchMax, out wszPDBResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return wszPDBResult;
        }

        public HRESULT TryQueryPDBNameExW(long cchMax, out string wszPDBResult)
        {
            /*HRESULT QueryPDBNameExW([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszPDB, [In] long cchMax);*/
            StringBuilder wszPDB = null;
            HRESULT hr = Raw2.QueryPDBNameExW(wszPDB, cchMax);

            if (hr == HRESULT.S_OK)
                wszPDBResult = wszPDB.ToString();
            else
                wszPDBResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}