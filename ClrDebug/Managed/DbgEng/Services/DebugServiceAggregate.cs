using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// A service which offers the ability to aggregate other services implements this interface. Typically, this is used in one of two scenarios
    /// 1) Enumerators which provide the capability to enumerate from multiple sources -- each an independent service.<para/>
    /// An aggregate service will "merge" all of the enumerators and direct calls to Find* to the appropriate service.
    /// 
    /// 2) ...
    /// </summary>
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

        /// <summary>
        /// Adds a new service to the aggregate.
        /// </summary>
        public void AggregateService(Guid serviceGuid, IDebugServiceLayer childService)
        {
            TryAggregateService(serviceGuid, childService).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Adds a new service to the aggregate.
        /// </summary>
        public HRESULT TryAggregateService(Guid serviceGuid, IDebugServiceLayer childService)
        {
            /*HRESULT AggregateService(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer childService);*/
            return Raw.AggregateService(serviceGuid, childService);
        }

        #endregion
        #region DeaggregateService

        /// <summary>
        /// Removes a service from the aggregate.
        /// </summary>
        public void DeaggregateService(Guid serviceGuid, IDebugServiceLayer childService)
        {
            TryDeaggregateService(serviceGuid, childService).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Removes a service from the aggregate.
        /// </summary>
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
