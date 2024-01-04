using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugServiceProvider : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugServiceProvider = new Guid("58034A5B-F616-47C5-B5D5-B1390E0F0B23");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugServiceProviderVtbl* Vtbl => (IDebugServiceProviderVtbl*) base.Vtbl;

        #endregion

        public DebugServiceProvider(IntPtr raw) : base(raw, IID_IDebugServiceProvider)
        {
        }

        public DebugServiceProvider(IDebugServiceProvider raw) : base(raw)
        {
        }

        #region IDebugServiceProvider
        #region QueryService

        public DebugService QueryService(long server, Guid serviceId, Guid serviceInterfaceId)
        {
            DebugService interfaceResult;
            TryQueryService(server, serviceId, serviceInterfaceId, out interfaceResult).ThrowDbgEngNotOK();

            return interfaceResult;
        }

        public HRESULT TryQueryService(long server, Guid serviceId, Guid serviceInterfaceId, out DebugService interfaceResult)
        {
            InitDelegate(ref queryService, Vtbl->QueryService);
            /*HRESULT QueryService(
            [In] long server,
            [MarshalAs(UnmanagedType.LPStruct), In] Guid serviceId,
            [MarshalAs(UnmanagedType.LPStruct), In] Guid serviceInterfaceId,
            [MarshalAs(UnmanagedType.Interface), Out] out IDebugService @interface);*/
            IDebugService @interface;
            HRESULT hr = queryService(Raw, server, serviceId, serviceInterfaceId, out @interface);

            if (hr == HRESULT.S_OK)
                interfaceResult = @interface == null ? null : new DebugService(@interface);
            else
                interfaceResult = default(DebugService);

            return hr;
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugServiceProvider

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryServiceDelegate queryService;

        #endregion
        #endregion
        #region Delegates
        #region IDebugServiceProvider

        private delegate HRESULT QueryServiceDelegate(IntPtr self, [In] long server, [MarshalAs(UnmanagedType.LPStruct), In] Guid serviceId, [MarshalAs(UnmanagedType.LPStruct), In] Guid serviceInterfaceId, [MarshalAs(UnmanagedType.Interface), Out] out IDebugService @interface);

        #endregion
        #endregion
    }
}
