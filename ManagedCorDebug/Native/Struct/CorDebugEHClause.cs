using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Represents an exception handling (EH) clause for a given piece of intermediate language (IL) code.
    /// </summary>
    /// <remarks>
    /// An array of CoreDebugEHClause values is returned by the <see cref="ICorDebugILCode.GetEHClauses"/> method. The
    /// EH clause information is defined by the CLI specification. For more information, see Standard ECMA-355: Common
    /// Language Infrastructure (CLI), 6th Edition. The flags field can contain the following flags. Note that they are
    /// not defined in CorDebug.idl or CorDebug.h.
    /// </remarks>
    [DebuggerDisplay("flags = {flags}, TryOffset = {TryOffset}, TryLength = {TryLength}, HandlerOffset = {HandlerOffset}, HandlerLength = {HandlerLength}, ClassToken = {ClassToken}, FilterOffset = {FilterOffset}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct CorDebugEHClause
    {
        public int flags;

        /// <summary>
        /// The offset, in bytes, of the try block from the start of the method body.
        /// </summary>
        public int TryOffset;

        /// <summary>
        /// The length, in bytes, of the try block.
        /// </summary>
        public int TryLength;

        /// <summary>
        /// The location of the handler for this try block.
        /// </summary>
        public int HandlerOffset;

        /// <summary>
        /// The size of the handler code in bytes.
        /// </summary>
        public int HandlerLength;

        /// <summary>
        /// The metadata token for a type-based exception handler.
        /// </summary>
        public int ClassToken;

        /// <summary>
        /// The offset, in bytes, from the start of the method body for a filter-based exception handler.
        /// </summary>
        public int FilterOffset;
    }
}
