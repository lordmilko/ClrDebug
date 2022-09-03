using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_SYMBOL_ENTRY structure describes a symbol in a symbol group.
    /// </summary>
    [DebuggerDisplay("ModuleBase = {ModuleBase}, Offset = {Offset}, Id = {Id}, Arg64 = {Arg64}, Size = {Size}, Flags = {Flags}, TypeId = {TypeId}, NameSize = {NameSize}, Token = {Token}, Tag = {Tag.ToString(),nq}, Arg32 = {Arg32}, Reserved = {Reserved}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_SYMBOL_ENTRY
    {
        /// <summary>
        /// The base address of the module in the target's virtual address space.
        /// </summary>
        public long ModuleBase;

        /// <summary>
        /// The location of the symbol in the target's virtual address space.
        /// </summary>
        public long Offset;

        /// <summary>
        /// The symbol ID of the symbol. If the symbol ID is not known, Id is DEBUG_INVALID_OFFSET.
        /// </summary>
        public long Id;

        /// <summary>
        /// The interpretation of Arg64 depends on the type of the symbol. If the value is not known, Arg64 is zero.
        /// </summary>
        public long Arg64;

        /// <summary>
        /// The size, in bytes, of the symbol's value. This might not be known or might not completely represent all of the data for a symbol.<para/>
        /// For example, a function's code might be split among multiple regions and the size only describes one region.
        /// </summary>
        public int Size;

        /// <summary>
        /// Symbol entry flags. Currently, no flags are defined.
        /// </summary>
        public int Flags;

        /// <summary>
        /// The type ID of the symbol.
        /// </summary>
        public int TypeId;

        /// <summary>
        /// The size, in characters, of the symbol's name. If the size is not known, NameSize is zero.
        /// </summary>
        public int NameSize;

        /// <summary>
        /// The managed token of the symbol. If the token value is not known or the symbol does not have a token, Token is zero.
        /// </summary>
        public int Token;

        /// <summary>
        /// The symbol tag for the type of the symbol. This is a value from the SymTagEnum enumeration.
        /// </summary>
        public SymTag Tag;

        /// <summary>
        /// The interpretation of Arg32 depends on the type of the symbol. Currently, the value of Arg32 is the register that holds the value or a pointer to the value of the symbol.<para/>
        /// If the symbol is not held in a register, or the register is not known, Arg32 is zero.
        /// </summary>
        public int Arg32;

        /// <summary>
        /// Set to zero.
        /// </summary>
        public int Reserved;
    }
}
