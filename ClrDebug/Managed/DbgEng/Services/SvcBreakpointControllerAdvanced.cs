using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Advanced information from the breakpoint controller.
    /// </summary>
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

        /// <summary>
        /// ; Indicates whether or not the register context retrieved for a breakpoint trap reflects @pc as reported by the underlying hardware trap/fault.<para/>
        /// This should normally return *true* and, if this interface is not present, the assumption is that the value is true.<para/>
        /// On ARM64, the "BRK ..." instruction used for software breakpoints represents a fault where the address points *AT* the "BRK ..." instruction.<para/>
        /// This is unlike the "int 3" trap on X64 where the address points *AFTER* the "int 3" instruction. For ARM64, the Windows kernel adjusts the program counter of the corresponding trap frame to match the X64 semantics.<para/>
        /// That is, the address of the exception points at "BRK ..." but the context record for the thread (&amp; trap frame) refer to a @pc which is *AFTER* the "BRK ..." instruction.<para/>
        /// Other platforms (e.g.: Linux) **DO NOT** make this adjustment. The debugger needs to know whether this has happened or not.<para/>
        /// This method returning "true" indicates that the values returned reflect the hardware without any such "adjustments" applied.<para/>
        /// This method returning "false" indicates the Windows behavior where the context record (&amp; trap frame) @pc refer to an instruction *AFTER* the "BRK ...".
        /// </summary>
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
