using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetMemberRefProps"/> method.
    /// </summary>
    [DebuggerDisplay("ptk = {ptk}, szMember = {szMember}, ppvSigBlob = {ppvSigBlob}, pbSig = {pbSig}")]
    public struct GetMemberRefPropsResult
    {
        /// <summary>
        /// A TypeDef or TypeRef, or TypeSpec token that represents the class that declares the member, or a ModuleRef token that represents the module class that declares the member, or a MethodDef that represents the member.
        /// </summary>
        public mdToken ptk { get; }

        /// <summary>
        /// A string buffer for the member's name.
        /// </summary>
        public string szMember { get; }

        /// <summary>
        /// A pointer to the binary metadata signature for the member.
        /// </summary>
        public IntPtr ppvSigBlob { get; }

        /// <summary>
        /// The size in bytes of ppvSigBlob.
        /// </summary>
        public int pbSig { get; }

        public GetMemberRefPropsResult(mdToken ptk, string szMember, IntPtr ppvSigBlob, int pbSig)
        {
            this.ptk = ptk;
            this.szMember = szMember;
            this.ppvSigBlob = ppvSigBlob;
            this.pbSig = pbSig;
        }
    }
}