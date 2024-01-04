using System;

namespace ClrDebug.DbgEng
{
    public class DebugServiceAggregate : ComObject<IDebugServiceAggregate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugServiceAggregate"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugServiceAggregate(IDebugServiceAggregate raw) : base(raw)
        {
        }

        #region IDebugServiceAggregate
        #region AggregateService

        public void AggregateService(Guid serviceGuid, IDebugServiceLayer childService)
        {
            TryAggregateService(serviceGuid, childService).ThrowDbgEngNotOK();
        }

        public HRESULT TryAggregateService(Guid serviceGuid, IDebugServiceLayer childService)
        {
            /*HRESULT AggregateService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer childService);*/
            return Raw.AggregateService(serviceGuid, childService);
        }

        #endregion
        #region DeaggregateService

        public void DeaggregateService(Guid serviceGuid, IDebugServiceLayer childService)
        {
            TryDeaggregateService(serviceGuid, childService).ThrowDbgEngNotOK();
        }

        public HRESULT TryDeaggregateService(Guid serviceGuid, IDebugServiceLayer childService)
        {
            /*HRESULT DeaggregateService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer childService);*/
            return Raw.DeaggregateService(serviceGuid, childService);
        }

        #endregion
        #endregion
    }
}
