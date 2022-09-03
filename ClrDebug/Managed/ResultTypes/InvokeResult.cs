using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="TypeInfo.Invoke"/> method.
    /// </summary>
    [DebuggerDisplay("pDispParams = {pDispParams.ToString(),nq}, puArgErr = {puArgErr}")]
    public struct InvokeResult
    {
        /// <summary>
        /// A reference to a structure that contains an array of arguments, an array of DISPIDs for named arguments, and counts of the number of elements in each array.
        /// </summary>
        public DISPPARAMS pDispParams { get; }

        /// <summary>
        /// If Invoke returns DISP_E_TYPEMISMATCH, puArgErr indicates the index within rgvarg of the argument with the incorrect type. If more than one argument returns an error, puArgErr indicates only the first argument with an error. This parameter is passed uninitialized.
        /// </summary>
        public int puArgErr { get; }

        public InvokeResult(DISPPARAMS pDispParams, int puArgErr)
        {
            this.pDispParams = pDispParams;
            this.puArgErr = puArgErr;
        }
    }
}
