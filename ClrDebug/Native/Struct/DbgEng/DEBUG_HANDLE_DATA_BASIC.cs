using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_HANDLE_DATA_BASIC structure contains handle-related information about a system object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_HANDLE_DATA_BASIC
    {
        /// <summary>
        /// The size, in characters, of the object-type name. This size includes the space for the '\0' terminating character.
        /// </summary>
        public uint TypeNameSize;

        /// <summary>
        /// The size, in characters, of the object's name. This size includes the space for the '\0' terminating character.
        /// </summary>
        public uint ObjectNameSize;

        /// <summary>
        /// A bit-set that contains the handle's attributes. For possible values, see "Handle" in the Windows Driver Kit (WDK).
        /// </summary>
        public uint Attributes;

        /// <summary>
        /// A bit-set that specifies the access mask for the object that is represented by the handle. For details, see ACCESS_MASK in the Platform SDK documentation.
        /// </summary>
        public uint GrantedAccess;

        /// <summary>
        /// The number of handle references for the object.
        /// </summary>
        public uint HandleCount;

        /// <summary>
        /// The number of pointer references for the object.
        /// </summary>
        public uint PointerCount;
    }
}