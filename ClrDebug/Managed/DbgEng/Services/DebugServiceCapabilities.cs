using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An optional interface for any service to implement to query certain capabilities that are potentially more granular than a QI of a single interface by IID can determine.<para/>
    /// Each defined capability has a "default answer" that is assumed if this interface is not supported. An example of a service capability query is whether the target supports backward execution.<para/>
    /// The default answer is "no". Without knowing this, calling various methods on the step controller would simply return an E_INVALIDARG / E_NOTIMPL without indication as to why.
    /// </summary>
    public class DebugServiceCapabilities : ComObject<IDebugServiceCapabilities>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugServiceCapabilities"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugServiceCapabilities(IDebugServiceCapabilities raw) : base(raw)
        {
        }

        #region IDebugServiceCapabilities
        #region GetCapability

        /// <summary>
        /// QueryCapability() For the service identified by 'serviceGuid', ask whether the capability identified by the combination of 'capabilitySet' and 'capabilityId' is or is not supported.<para/>
        /// The type of data returned from the query is defined by each 'capabilitySet' / 'capabilityId' combination. Each capability must define a default state when it is specified.<para/>
        /// If a given service does not support capability detection via IDebugServiceCapabilities, a client may assume the default state.<para/>
        /// Should that not be the case, some methods may fail with E_INVALIDARG. If 'serviceGuid' is not a supported service GUID, E_INVALIDARG should be returned.<para/>
        /// If 'capabilitySet' and 'capabilityId' are not recognized capabilities, E_NOT_SET should be returned.
        /// </summary>
        public void GetCapability(Guid serviceGuid, Guid capabilitySet, int capabilityId, int bufferSize, IntPtr buffer)
        {
            TryGetCapability(serviceGuid, capabilitySet, capabilityId, bufferSize, buffer).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// QueryCapability() For the service identified by 'serviceGuid', ask whether the capability identified by the combination of 'capabilitySet' and 'capabilityId' is or is not supported.<para/>
        /// The type of data returned from the query is defined by each 'capabilitySet' / 'capabilityId' combination. Each capability must define a default state when it is specified.<para/>
        /// If a given service does not support capability detection via IDebugServiceCapabilities, a client may assume the default state.<para/>
        /// Should that not be the case, some methods may fail with E_INVALIDARG. If 'serviceGuid' is not a supported service GUID, E_INVALIDARG should be returned.<para/>
        /// If 'capabilitySet' and 'capabilityId' are not recognized capabilities, E_NOT_SET should be returned.
        /// </summary>
        public HRESULT TryGetCapability(Guid serviceGuid, Guid capabilitySet, int capabilityId, int bufferSize, IntPtr buffer)
        {
            /*HRESULT GetCapability(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid serviceGuid,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid capabilitySet,
            [In] int capabilityId,
            [In] int bufferSize,
            [Out] IntPtr buffer);*/
            return Raw.GetCapability(serviceGuid, capabilitySet, capabilityId, bufferSize, buffer);
        }

        #endregion
        #endregion
    }
}
