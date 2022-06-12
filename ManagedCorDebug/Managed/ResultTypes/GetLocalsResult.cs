using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedScope.GetLocals"/> method.
    /// </summary>
    [DebuggerDisplay("pcLocals = {pcLocals}, locals = {locals}")]
    public struct GetLocalsResult
    {
        /// <summary>
        /// [out] A pointer to a ULONG32 that receives the size of the buffer required to contain the local variables.
        /// </summary>
        public int pcLocals { get; }

        /// <summary>
        /// [out] The array that receives the local variables.
        /// </summary>
        public IntPtr locals { get; }

        public GetLocalsResult(int pcLocals, IntPtr locals)
        {
            this.pcLocals = pcLocals;
            this.locals = locals;
        }
    }
}