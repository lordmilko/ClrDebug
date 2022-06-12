using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMembersWithName"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rMembers = {rMembers}, pcTokens = {pcTokens}")]
    public struct EnumMembersWithNameResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array used to store the MemberDef tokens.
        /// </summary>
        public mdToken[] rMembers { get; }

        /// <summary>
        /// [out] The actual number of MemberDef tokens returned in rMembers.
        /// </summary>
        public int pcTokens { get; }

        public EnumMembersWithNameResult(IntPtr phEnum, mdToken[] rMembers, int pcTokens)
        {
            this.phEnum = phEnum;
            this.rMembers = rMembers;
            this.pcTokens = pcTokens;
        }
    }
}