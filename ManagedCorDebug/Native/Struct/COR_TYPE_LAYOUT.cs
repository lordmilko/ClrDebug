using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides information about the layout of an object in memory.
    /// </summary>
    /// <remarks>
    /// If numFields is greater than zero, you can call the <see cref="ICorDebugProcess5.GetTypeFields"/> method to obtain
    /// information about the fields in this type. If type is ELEMENT_TYPE_STRING, ELEMENT_TYPE_ARRAY, or ELEMENT_TYPE_SZARRAY,
    /// the size of objects of this type is variable, and you can pass the <see cref="COR_TYPEID"/> structure to the <see
    /// cref="ICorDebugProcess5.GetArrayLayout"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_TYPE_LAYOUT
    {
        /// <summary>
        /// The identifier of the parent type to this type. This will be the NULL type id (token1= 0, token2 = 0) if the type id corresponds to <see cref="object"/>.
        /// </summary>
        public COR_TYPEID parentID;

        /// <summary>
        /// The base size of an object of this type. This is the total size for non-variable sized objects.
        /// </summary>
        public uint objectSize;

        /// <summary>
        /// The number of fields included in objects of this type.
        /// </summary>
        public uint numFields;

        /// <summary>
        /// If this type is boxed, the beginning offset of an object's fields. This field is valid only for value types such as primitives and structures.
        /// </summary>
        public uint boxOffset;

        /// <summary>
        /// The CorElementType to which this type belongs.
        /// </summary>
        public uint type;
    }
}