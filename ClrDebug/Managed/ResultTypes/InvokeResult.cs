using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="TypeInfo.Invoke"/> method.
    /// </summary>
    [DebuggerDisplay("pVarResult = {pVarResult.ToString(),nq}, pExcepInfo = {pExcepInfo.ToString(),nq}, puArgErr = {puArgErr}")]
    public struct InvokeResult
    {
        /// <summary>
        /// A reference to the location at which the result is to be stored. If wFlags specifies DISPATCH_PROPERTYPUT or DISPATCH_PROPERTYPUTREF, pVarResult is ignored. Set to null if no result is desired.
        /// </summary>
        public IntPtr pVarResult { get; }

        /// <summary>
        /// A pointer to an exception information structure, which is filled in only if DISP_E_EXCEPTION is returned.
        /// </summary>
        public IntPtr pExcepInfo { get; }

        /// <summary>
        /// If Invoke returns DISP_E_TYPEMISMATCH, puArgErr indicates the index within rgvarg of the argument with the incorrect type. If more than one argument returns an error, puArgErr indicates only the first argument with an error. This parameter is passed uninitialized.
        /// </summary>
        public int puArgErr { get; }

        public InvokeResult(IntPtr pVarResult, IntPtr pExcepInfo, int puArgErr)
        {
            this.pVarResult = pVarResult;
            this.pExcepInfo = pExcepInfo;
            this.puArgErr = puArgErr;
        }
    }
}
