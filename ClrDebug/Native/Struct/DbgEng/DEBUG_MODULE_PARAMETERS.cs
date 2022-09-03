using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_MODULE_PARAMETERS structure contains most of the parameters for describing a module.
    /// </summary>
    /// <remarks>
    /// This structure is returned by <see cref="IDebugSymbols.GetModuleParameters"/>. To locate the different names for
    /// the module, use <see cref="IDebugSymbols2.GetModuleNameString"/>. For more information about modules, see Modules.
    /// For details about the different names for the module, see <see cref="IDebugSymbols2.GetModuleNameString"/>.
    /// </remarks>
    [DebuggerDisplay("Base = {Base}, Size = {Size}, TimeDateStamp = {TimeDateStamp}, Checksum = {Checksum}, Flags = {Flags.ToString(),nq}, SymbolType = {SymbolType.ToString(),nq}, ImageNameSize = {ImageNameSize}, ModuleNameSize = {ModuleNameSize}, LoadedImageNameSize = {LoadedImageNameSize}, SymbolFileNameSize = {SymbolFileNameSize}, MappedImageNameSize = {MappedImageNameSize}, Reserved = {Reserved}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DEBUG_MODULE_PARAMETERS
    {
        /// <summary>
        /// The location in the target's virtual address space of the module's base. If the value of Base is DEBUG_INVALID_OFFSET, the structure is invalid.
        /// </summary>
        public long Base;

        /// <summary>
        /// The size, in bytes, of the memory range that is occupied by the module.
        /// </summary>
        public int Size;

        /// <summary>
        /// The date and time stamp of the module's executable file. This is the number of seconds elapsed since midnight (00:00:00), January 1, 1970 Coordinated Universal Time (UTC) as stored in the image file header.
        /// </summary>
        public int TimeDateStamp;

        /// <summary>
        /// The checksum of the image. This value can be zero.
        /// </summary>
        public int Checksum;

        /// <summary>
        /// A bit-set that contains the module's flags. The bit-flags that can be present are as follows.
        /// </summary>
        public DEBUG_MODULE Flags;

        /// <summary>
        /// The type of symbols that are loaded for the module. This member can have one of the following values.
        /// </summary>
        public DEBUG_SYMTYPE SymbolType;

        /// <summary>
        /// The size of the file name for the module. The size is measured in characters, including the terminator.
        /// </summary>
        public int ImageNameSize;

        /// <summary>
        /// The size of the module name of the module. The size is measured in characters, including the terminator.
        /// </summary>
        public int ModuleNameSize;

        /// <summary>
        /// The size of the loaded image name for the module. The size is measured in characters, including the terminator.
        /// </summary>
        public int LoadedImageNameSize;

        /// <summary>
        /// The size of the symbol file name for the module. The size is measured in characters, including the terminator.
        /// </summary>
        public int SymbolFileNameSize;

        /// <summary>
        /// The size of the mapped image name of the module. The size is measured in characters, including the terminator.
        /// </summary>
        public int MappedImageNameSize;

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        public fixed long Reserved[2];
    }
}
