using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
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

        public Guid ArchitectureGuid
        {
            get
            {
                Guid architecture;
                TryGetArchitectureGuid(out architecture).ThrowDbgEngNotOK();

                return architecture;
            }
        }

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
