using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_MACHINE (always). The ISvcMachineConfiguration interface is provided by the machine service.
    /// </summary>
    public class SvcMachineConfiguration : ComObject<ISvcMachineConfiguration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcMachineConfiguration"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcMachineConfiguration(ISvcMachineConfiguration raw) : base(raw)
        {
        }

        #region ISvcMachineConfiguration
        #region Architecture

        /// <summary>
        /// Returns the archtiecture of the machine as an IMAGE_FILE_MACHINE_* constant.
        /// </summary>
        public int Architecture
        {
            get
            {
                /*int GetArchitecture();*/
                return Raw.GetArchitecture();
            }
        }

        #endregion
        #endregion
        #region ISvcMachineConfiguration2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISvcMachineConfiguration2 Raw2 => (ISvcMachineConfiguration2) Raw;

        #region ArchitectureGuid

        /// <summary>
        /// Returns the architecture of the machine as a DEBUG_ARCHDEF_* guid. This supports the notion of a custom architecture.<para/>
        /// If such is utilized, the returned GUID *MUST* also be the component aggregate for the architecture.
        /// </summary>
        public Guid ArchitectureGuid
        {
            get
            {
                Guid architecture;
                TryGetArchitectureGuid(out architecture).ThrowDbgEngNotOK();

                return architecture;
            }
        }

        /// <summary>
        /// Returns the architecture of the machine as a DEBUG_ARCHDEF_* guid. This supports the notion of a custom architecture.<para/>
        /// If such is utilized, the returned GUID *MUST* also be the component aggregate for the architecture.
        /// </summary>
        public HRESULT TryGetArchitectureGuid(out Guid architecture)
        {
            /*HRESULT GetArchitectureGuid(
            [Out] out Guid architecture);*/
            return Raw2.GetArchitectureGuid(out architecture);
        }

        #endregion
        #endregion
    }
}
