using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugServiceEnumerator.Next"/> property.
    /// </summary>
    [DebuggerDisplay("serviceGuid = {serviceGuid.ToString(),nq}, service = {service?.ToString(),nq}")]
    public struct DebugServiceEnumerator_GetNextResult
    {
        public Guid serviceGuid { get; }

        public DebugServiceLayer service { get; }

        public DebugServiceEnumerator_GetNextResult(Guid serviceGuid, DebugServiceLayer service)
        {
            this.serviceGuid = serviceGuid;
            this.service = service;
        }
    }
}
