using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.ReadBugCheckData"/> method.
    /// </summary>
    [DebuggerDisplay("Code = {Code}, Arg1 = {Arg1}, Arg2 = {Arg2}, Arg3 = {Arg3}, Arg4 = {Arg4}")]
    public struct ReadBugCheckDataResult
    {
        /// <summary>
        /// Receives the bug check code.
        /// </summary>
        public uint Code { get; }

        /// <summary>
        /// Receives the first parameter associated with the bug check. The interpretation of this parameter depends on the bug check code.
        /// </summary>
        public ulong Arg1 { get; }

        /// <summary>
        /// Receives the second parameter associated with the bug check. The interpretation of this parameter depends on the bug check code.
        /// </summary>
        public ulong Arg2 { get; }

        /// <summary>
        /// Receives the third parameter associated with the bug check. The interpretation of this parameter depends on the bug check code.
        /// </summary>
        public ulong Arg3 { get; }

        /// <summary>
        /// Receives the fourth parameter associated with the bug check. The interpretation of this parameter depends on the bug check code.
        /// </summary>
        public ulong Arg4 { get; }

        public ReadBugCheckDataResult(uint code, ulong arg1, ulong arg2, ulong arg3, ulong arg4)
        {
            Code = code;
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Arg4 = arg4;
        }
    }
}
