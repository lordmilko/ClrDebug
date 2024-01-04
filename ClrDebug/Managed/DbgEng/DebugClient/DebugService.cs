using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugService : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugService = new Guid("5DDDE86F-9560-4A23-9592-8E69B92CDF4D");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugServiceVtbl* Vtbl => (IDebugServiceVtbl*) base.Vtbl;

        #endregion

        public DebugService(IntPtr raw) : base(raw, IID_IDebugService)
        {
        }

        public DebugService(IDebugService raw) : base(raw)
        {
        }
    }
}
