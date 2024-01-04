using System;

namespace ClrDebug.DbgEng
{
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

        public void GetCapability(Guid serviceGuid, Guid capabilitySet, int capabilityId, int bufferSize, IntPtr buffer)
        {
            TryGetCapability(serviceGuid, capabilitySet, capabilityId, bufferSize, buffer).ThrowDbgEngNotOK();
        }

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
