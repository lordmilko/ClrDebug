using System.Diagnostics;
using ClrDebug.TypeLib;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostType.IntrinsicType"/> property.
    /// </summary>
    [DebuggerDisplay("intrinsicKind = {intrinsicKind.ToString(),nq}, carrierType = {carrierType.ToString(),nq}")]
    public struct GetIntrinsicTypeResult
    {
        /// <summary>
        /// The kind of intrinsic will be returned here. This will indicate the overall type of the intrinsic -- whether it is an integer, unsigned, floating point, etc...<para/>
        /// It will not indicate the size of the intrinsic. 8, 16, 32, and 64 bit integers will be reported as signed integers -- nothing more.
        /// </summary>
        public IntrinsicKind intrinsicKind { get; }

        /// <summary>
        /// A VT_* constant indicating how the intrinsic will pack into a VARIANT structure is returned here. This, combined with the value returned in the intrinsicKind argument gives the full information necessary to understand the nature of the intrinsic.
        /// </summary>
        public VARENUM carrierType { get; }

        public GetIntrinsicTypeResult(IntrinsicKind intrinsicKind, VARENUM carrierType)
        {
            this.intrinsicKind = intrinsicKind;
            this.carrierType = carrierType;
        }
    }
}
