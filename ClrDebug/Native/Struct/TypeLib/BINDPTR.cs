using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Contains a pointer to a bound-to <see cref="FUNCDESC"/> structure, <see cref="VARDESC"/> structure, or an ITypeComp interface.
    /// </summary>
    [DebuggerDisplay("lpfuncdesc = {lpfuncdesc}, lpvardesc = {lpvardesc}, lptcomp = {lptcomp}")]
    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct BINDPTR
    {
        /// <summary>
        /// Represents a pointer to a <see cref="FUNCDESC"/> structure.
        /// </summary>
        [FieldOffset(0)]
        public FUNCDESC* lpfuncdesc;

        /// <summary>
        /// Represents a pointer to a <see cref="VARDESC"/> structure.
        /// </summary>
        [FieldOffset(0)]
        public VARDESC* lpvardesc;

        /// <summary>
        /// Represents a pointer to an <see cref="ITypeComp"/> interface.
        /// </summary>
        [FieldOffset(0)]
        public ITypeComp lptcomp;
    }
}
