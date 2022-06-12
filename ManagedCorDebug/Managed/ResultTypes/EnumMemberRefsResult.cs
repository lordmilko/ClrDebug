using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMemberRefs"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rMemberRefs = {rMemberRefs}, pcTokens = {pcTokens}")]
    public struct EnumMemberRefsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array used to store MemberRef tokens.
        /// </summary>
        public mdMemberRef[] rMemberRefs { get; }

        /// <summary>
        /// [out] The actual number of MemberRef tokens returned in rMemberRefs.
        /// </summary>
        public int pcTokens { get; }

        public EnumMemberRefsResult(IntPtr phEnum, mdMemberRef[] rMemberRefs, int pcTokens)
        {
            this.phEnum = phEnum;
            this.rMemberRefs = rMemberRefs;
            this.pcTokens = pcTokens;
        }
    }
}