using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Contains information about the default value of a parameter.
    /// </summary>
    [DebuggerDisplay("Bytes = {Bytes}, varDefaultValue = {varDefaultValue}")]
    public struct PARAMDESCEX
    {
        /// <summary>
        /// The size of the structure.
        /// </summary>
        public int Bytes;

        /// <summary>
        /// The default value of the parameter.
        /// </summary>
        [MarshalAs(UnmanagedType.Struct)]
        public object varDefaultValue;
    }
}
