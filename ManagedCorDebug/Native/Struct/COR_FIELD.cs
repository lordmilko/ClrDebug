using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides information about a field in an object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_FIELD
    {
        /// <summary>
        /// An <see cref="mdFieldDef"/> token that can be used to get field information.
        /// </summary>
        public uint token;

        /// <summary>
        /// The offset, in bytes, to the field data in the object.
        /// </summary>
        public uint offset;

        /// <summary>
        /// A <see cref="COR_TYPEID"/> value that identifies the type of this field.
        /// </summary>
        public COR_TYPEID id;

        /// <summary>
        /// A <see cref="CorElementType"/> enumeration value that indicates the type of the field.
        /// </summary>
        public uint fieldType;
    }
}