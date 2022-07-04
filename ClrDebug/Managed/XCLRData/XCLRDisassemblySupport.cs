using System;

namespace ClrDebug
{
    public class XCLRDisassemblySupport : ComObject<IXCLRDisassemblySupport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDisassemblySupport"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDisassemblySupport(IXCLRDisassemblySupport raw) : base(raw)
        {
        }

        #region IXCLRDisassemblySupport
        #region SetTranslateAddrCallback

        public void SetTranslateAddrCallback(CDSTranslateAddrCB cb)
        {
            TrySetTranslateAddrCallback(cb).ThrowOnNotOK();
        }

        public HRESULT TrySetTranslateAddrCallback(CDSTranslateAddrCB cb)
        {
            /*HRESULT SetTranslateAddrCallback(
            [In, MarshalAs(UnmanagedType.FunctionPtr)] CDSTranslateAddrCB cb);*/
            return Raw.SetTranslateAddrCallback(cb);
        }

        #endregion
        #region PvClientSet

        public void PvClientSet(IntPtr pv)
        {
            TryPvClientSet(pv).ThrowOnNotOK();
        }

        public HRESULT TryPvClientSet(IntPtr pv)
        {
            /*HRESULT PvClientSet(
            [In] IntPtr pv);*/
            return Raw.PvClientSet(pv);
        }

        #endregion
        #region CbDisassemble

        public long CbDisassemble(CLRDATA_ADDRESS a, IntPtr b, long c)
        {
            /*long CbDisassemble(
            [In] CLRDATA_ADDRESS a,
            [In] IntPtr b,
            [In] long c);*/
            return Raw.CbDisassemble(a, b, c);
        }

        #endregion
        #region Cinstruction

        public long Cinstruction()
        {
            /*long Cinstruction();*/
            return Raw.Cinstruction();
        }

        #endregion
        #region FSelectInstruction

        public void FSelectInstruction(long a)
        {
            TryFSelectInstruction(a).ThrowOnNotOK();
        }

        public HRESULT TryFSelectInstruction(long a)
        {
            /*int FSelectInstruction(
            [In] long a);*/
            return (HRESULT) Raw.FSelectInstruction(a);
        }

        #endregion
        #region CchFormatInstr

        public long CchFormatInstr(string a, long b)
        {
            /*long CchFormatInstr(
            [In, MarshalAs(UnmanagedType.LPWStr)] string a,
            [In] long b);*/
            return Raw.CchFormatInstr(a, b);
        }

        #endregion
        #region PvClient

        public void PvClient()
        {
            /*void PvClient();*/
            Raw.PvClient();
        }

        #endregion
        #region SetTranslateFixupCallback

        public void SetTranslateFixupCallback(CDSTranslateFixupCB cb)
        {
            TrySetTranslateFixupCallback(cb).ThrowOnNotOK();
        }

        public HRESULT TrySetTranslateFixupCallback(CDSTranslateFixupCB cb)
        {
            /*HRESULT SetTranslateFixupCallback(
            [In] CDSTranslateFixupCB cb);*/
            return Raw.SetTranslateFixupCallback(cb);
        }

        #endregion
        #region SetTranslateConstCallback

        public void SetTranslateConstCallback(CDSTranslateConstCB cb)
        {
            TrySetTranslateConstCallback(cb).ThrowOnNotOK();
        }

        public HRESULT TrySetTranslateConstCallback(CDSTranslateConstCB cb)
        {
            /*HRESULT SetTranslateConstCallback(
            [In] CDSTranslateConstCB cb);*/
            return Raw.SetTranslateConstCallback(cb);
        }

        #endregion
        #region SetTranslateRegrelCallback

        public void SetTranslateRegrelCallback(CDSTranslateRegrelCB cb)
        {
            TrySetTranslateRegrelCallback(cb).ThrowOnNotOK();
        }

        public HRESULT TrySetTranslateRegrelCallback(CDSTranslateRegrelCB cb)
        {
            /*HRESULT SetTranslateRegrelCallback(
            [In] CDSTranslateRegrelCB cb);*/
            return Raw.SetTranslateRegrelCallback(cb);
        }

        #endregion
        #region TargetIsAddress

        public int TargetIsAddress()
        {
            /*int TargetIsAddress();*/
            return Raw.TargetIsAddress();
        }

        #endregion
        #endregion
    }
}
