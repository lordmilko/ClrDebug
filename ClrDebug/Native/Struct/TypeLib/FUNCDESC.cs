using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Defines a function description.
    /// </summary>
    [DebuggerDisplay("memid = {memid}, lprgscode = {lprgscode->ToString(),nq}, lprgelemdescParam = {lprgelemdescParam->ToString(),nq}, funckind = {funckind.ToString(),nq}, invkind = {invkind.ToString(),nq}, callconv = {callconv.ToString(),nq}, cParams = {cParams}, cParamsOpt = {cParamsOpt}, oVft = {oVft}, cScodes = {cScodes}, elemdescFunc = {elemdescFunc.ToString(),nq}, wFuncFlags = {wFuncFlags.ToString(),nq}")]
    public unsafe struct FUNCDESC
    {
        /// <summary>
        /// Identifies the function member ID.
        /// </summary>
        public int memid;

        /// <summary>
        /// Stores the count of errors a function can return on a 16-bit system.
        /// </summary>
        public HRESULT* lprgscode;

        /// <summary>
        /// Description of the element.
        /// </summary>
        public ELEMDESC* lprgelemdescParam;

        /// <summary>
        /// Specifies whether the function is virtual, static, or dispatch-only.
        /// </summary>
        public FUNCKIND funckind;

        /// <summary>
        /// Specifies the type of a property function.
        /// </summary>
        public INVOKEKIND invkind;

        /// <summary>
        /// Specifies the calling convention of a function.
        /// </summary>
        public CALLCONV callconv;

        /// <summary>
        /// Counts the total number of parameters.
        /// </summary>
        public short cParams;

        /// <summary>
        /// Counts the optional parameters.
        /// </summary>
        public short cParamsOpt;

        /// <summary>
        /// Specifies the offset in the VTBL for <see cref="FUNCKIND.FUNC_VIRTUAL"/>.
        /// </summary>
        public short oVft;

        /// <summary>
        /// Counts the permitted return values.
        /// </summary>
        public short cScodes;

        /// <summary>
        /// Contains the return type of the function.
        /// </summary>
        public ELEMDESC elemdescFunc;

        /// <summary>
        /// Indicates the <see cref="FUNCFLAGS"/> of a function.
        /// </summary>
        public FUNCFLAGS wFuncFlags;
    }
}
