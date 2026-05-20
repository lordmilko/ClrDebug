using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    public unsafe class EnumSrc : Enum
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new EnumSrcVtbl* vtbl => (EnumSrcVtbl*) base.vtbl;

        public EnumSrc(IntPtr raw) : base(raw)
        {
        }

        #region Get

        //virtual void get(OUT PCSrcHeaderOut * ppcsrcheader) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate void GetDelegate(
            [In] IntPtr @this,
            [Out] out SrcHeaderOut* ppcsrcheader);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDelegate get;

        //Do not access Get prior to calling Next(), or you may AV
        public SrcHeaderOut* Get
        {
            get
            {
                InitDelegate(ref get, vtbl->get);

                get(Raw, out var ppcsrcheader);

                return ppcsrcheader;
            }
        }

        #endregion
    }
}
