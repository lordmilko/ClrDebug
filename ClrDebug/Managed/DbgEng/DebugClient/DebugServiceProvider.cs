using System;

namespace ClrDebug.DbgEng
{
    public class DebugServiceProvider : ComObject<IDebugServiceProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugServiceProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
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
            /*HRESULT QueryService(
            [In] long server,
            [MarshalAs(UnmanagedType.LPStruct), In] Guid serviceId,
            [MarshalAs(UnmanagedType.LPStruct), In] Guid serviceInterfaceId,
            [MarshalAs(UnmanagedType.Interface), Out] out IDebugService @interface);*/
            IDebugService @interface;
            HRESULT hr = Raw.QueryService(server, serviceId, serviceInterfaceId, out @interface);

            if (hr == HRESULT.S_OK)
                interfaceResult = @interface == null ? null : new DebugService(@interface);
            else
                interfaceResult = default(DebugService);

            return hr;
        }

        #endregion
        #endregion
    }
}
