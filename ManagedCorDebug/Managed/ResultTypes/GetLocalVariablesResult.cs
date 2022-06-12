using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedENCUpdate.GetLocalVariables"/> method.
    /// </summary>
    public struct GetLocalVariablesResult
    {
        /// <summary>
        /// [out] The returned array of <see cref="ISymUnmanagedVariable"/> instances.
        /// </summary>
        public IntPtr rgLocals { get; }

        /// <summary>
        /// [out] A pointer to a ULONG that receives the size of the rgLocals buffer required to contain the locals.
        /// </summary>
        public int pceltFetched { get; }

        public GetLocalVariablesResult(IntPtr rgLocals, int pceltFetched)
        {
            this.rgLocals = rgLocals;
            this.pceltFetched = pceltFetched;
        }
    }
}