using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugServiceEnumerator.Next"/> property.
    /// </summary>
    [DebuggerDisplay("serviceGuid = {serviceGuid.ToString(),nq}, service = {service?.ToString(),nq}")]
    public struct GetNextResult
    {
        public Guid serviceGuid { get; }

        public DebugServiceLayer service { get; }

        public GetNextResult(Guid serviceGuid, DebugServiceLayer service)
        {
            this.serviceGuid = serviceGuid;
            this.service = service;
        }
    }
}
