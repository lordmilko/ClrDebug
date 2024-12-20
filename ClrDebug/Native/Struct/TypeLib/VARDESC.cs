using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Describes a variable, constant, or data member.
    /// </summary>
    [DebuggerDisplay("memid = {memid}, lpstrSchema = {lpstrSchema.ToString(),nq}, desc = {desc.ToString(),nq}, elemdescVar = {elemdescVar.ToString(),nq}, wVarFlags = {wVarFlags}, varkind = {varkind.ToString(),nq}")]
    public struct VARDESC
    {
        /// <summary>
        /// Indicates the member ID of a variable.
        /// </summary>
        public int memid;

        /// <summary>
        /// This field is reserved for future use.
        /// </summary>
        public IntPtr lpstrSchema;

        /// <summary>
        /// Contains information about a variable.
        /// </summary>
        public DESCUNION desc;

        /// <summary>
        /// Contains the variable type.
        /// </summary>
        public ELEMDESC elemdescVar;

        /// <summary>
        /// Defines the properties of a variable.
        /// </summary>
        public VARFLAGS wVarFlags;

        /// <summary>
        /// Defines how to marshal a variable.
        /// </summary>
        public VARKIND varkind;

        /// <summary>
        /// Contains information about a variable.
        /// </summary>
        [DebuggerDisplay("oInst = {oInst}, lpvarValue = {lpvarValue.ToString(),nq}")]
        [StructLayout(LayoutKind.Explicit)]
        public struct DESCUNION
        {
            /// <summary>
            /// Indicates the offset of this variable within the instance.
            /// </summary>
            [FieldOffset(0)]
            public int oInst;

            /// <summary>
            /// Describes a symbolic constant.
            /// </summary>
            [FieldOffset(0)]
            public IntPtr lpvarValue;
        }
    }
}
