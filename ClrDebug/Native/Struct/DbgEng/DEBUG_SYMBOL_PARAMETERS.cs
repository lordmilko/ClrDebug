﻿using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_SYMBOL_PARAMETERS structure describes a symbol in a symbol group.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_SYMBOL_PARAMETERS
    {
        /// <summary>
        /// The location in the target's virtual address space of the base of the module to which the symbol belongs.
        /// </summary>
        public ulong Module;

        /// <summary>
        /// The type ID of the symbol.
        /// </summary>
        public uint TypeId;

        /// <summary>
        /// The index within the symbol group of the symbol's parent symbol. If the parent symbol is not known, ParentSymbol is DEBUG_ANY_ID.
        /// </summary>
        public uint ParentSymbol;

        /// <summary>
        /// The number of children of the symbol. If this symbol has never been expanded within this symbol group, this number will be an estimate that is based on the symbol's type.
        /// </summary>
        public uint SubElements;

        /// <summary>
        /// The symbol flags. See DEBUG_SYMBOL_XXX for details.
        /// </summary>
        public DEBUG_SYMBOL Flags;

        /// <summary>
        /// Set to zero.
        /// </summary>
        public ulong Reserved;
    }
}