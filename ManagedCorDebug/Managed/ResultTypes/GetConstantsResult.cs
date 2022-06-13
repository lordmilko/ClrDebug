using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedScope.GetConstants"/> method.
    /// </summary>
    [DebuggerDisplay("pcConstants = {pcConstants}, constants = {constants}")]
    public struct GetConstantsResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the constants.
        /// </summary>
        public int pcConstants { get; }

        /// <summary>
        /// The buffer that stores the constants.
        /// </summary>
        public IntPtr constants { get; }

        public GetConstantsResult(int pcConstants, IntPtr constants)
        {
            this.pcConstants = pcConstants;
            this.constants = constants;
        }
    }
}