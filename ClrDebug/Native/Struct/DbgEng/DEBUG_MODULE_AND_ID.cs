using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_MODULE_AND_ID structure describes a symbol within a module.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_MODULE_AND_ID
    {
        /// <summary>
        /// The location in the target's virtual address space of the module's base address.
        /// </summary>
        public long ModuleBase;

        /// <summary>
        /// The symbol ID of the symbol within the module.
        /// </summary>
        public long Id;
    }
}
