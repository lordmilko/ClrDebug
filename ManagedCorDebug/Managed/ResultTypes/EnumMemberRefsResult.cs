using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumMemberRefs"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rMemberRefs = {rMemberRefs}")]
    public struct EnumMemberRefsResult
    {
        /// <summary>
        /// A pointer to the enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store MemberRef tokens.
        /// </summary>
        public mdMemberRef[] rMemberRefs { get; }

        public EnumMemberRefsResult(IntPtr phEnum, mdMemberRef[] rMemberRefs)
        {
            this.phEnum = phEnum;
            this.rMemberRefs = rMemberRefs;
        }
    }
}