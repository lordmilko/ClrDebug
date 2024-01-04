using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class SvcBreakpointControllerAdvanced : ComObject<ISvcBreakpointControllerAdvanced>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcBreakpointControllerAdvanced"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcBreakpointControllerAdvanced(ISvcBreakpointControllerAdvanced raw) : base(raw)
        {
        }

        #region ISvcBreakpointControllerAdvanced
        #region DoesBreakpointTrapAddressReflectHardware

        public bool DoesBreakpointTrapAddressReflectHardware()
        {
            /*bool DoesBreakpointTrapAddressReflectHardware();*/
            return Raw.DoesBreakpointTrapAddressReflectHardware();
        }

        #endregion
        #endregion
        #region ISvcBreakpointControllerAdvanced2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISvcBreakpointControllerAdvanced2 Raw2 => (ISvcBreakpointControllerAdvanced2) Raw;

        #region SoftwareBreakpointAddressDelta

        public long SoftwareBreakpointAddressDelta
        {
            get
            {
                long pByteCountPastInstruction;
                TryGetSoftwareBreakpointAddressDelta(out pByteCountPastInstruction).ThrowDbgEngNotOK();

                return pByteCountPastInstruction;
            }
        }

        public HRESULT TryGetSoftwareBreakpointAddressDelta(out long pByteCountPastInstruction)
        {
            /*HRESULT GetSoftwareBreakpointAddressDelta(
            [Out] out long pByteCountPastInstruction);*/
            return Raw2.GetSoftwareBreakpointAddressDelta(out pByteCountPastInstruction);
        }

        #endregion
        #endregion
    }
}
