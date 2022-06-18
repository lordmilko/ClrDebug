using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMembersWithName"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rMembers = {rMembers}")]
    public struct EnumMembersWithNameResult
    {
        /// <summary>
        /// A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the MemberDef tokens.
        /// </summary>
        public mdToken[] rMembers { get; }

        public EnumMembersWithNameResult(IntPtr phEnum, mdToken[] rMembers)
        {
            this.phEnum = phEnum;
            this.rMembers = rMembers;
        }
    }
}