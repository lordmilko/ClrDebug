using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMembers"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rMembers = {rMembers}")]
    public struct EnumMembersResult
    {
        /// <summary>
        /// A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to hold the MemberDef tokens.
        /// </summary>
        public mdToken[] rMembers { get; }

        public EnumMembersResult(IntPtr phEnum, mdToken[] rMembers)
        {
            this.phEnum = phEnum;
            this.rMembers = rMembers;
        }
    }
}