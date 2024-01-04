using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the location for an object. This particular variant of Location is the C-COM access struct. Note that a location only has meaning in conjunction with a host context.<para/>
    /// It is a location within a context. When performing an operation on the location (reading bytes, writing bytes, etc...), a valid host context must be supplied.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Location
    {
        /// <summary>
        /// The HostDefined field has two states that are "Non-Opaque" at the API layer. 0: Indicates that the offset is a pointer into virtual address space of the target.<para/>
        /// Non-Zero: The defined value is proprietary to the host. Clients can propagate and change offset. They cannot legally change the value.This can be determined by the IsVirtualAddress() method if this structure is built from C++ code.
        /// </summary>
        public long HostDefined;

        /// <summary>
        /// The location’s offset into the address space defined by the host context and the HostDefined field of this structure.<para/>
        /// If the HostDefined field is zero, this is the virtual address of the location. If the HostDefined field is non-zero, this is the offset into some other address space.<para/>
        /// It may, for example, indicate where a particular field of a registered structure is located within the containing register.
        /// </summary>
        public long Offset;

        public bool IsVirtualAddress => HostDefined == 0;

        public Location(long virtualAddress)
        {
            HostDefined = 0;
            Offset = virtualAddress;
        }

        public static bool operator== (Location left, Location right) =>
            left.HostDefined == right.HostDefined && left.Offset == right.Offset;

        public static bool operator !=(Location left, Location right) => !(left == right);

        public static Location operator+ (Location left, long offset)
        {
            return new Location
            {
                HostDefined = left.HostDefined,
                Offset = left.Offset + offset
            };
        }

        public static Location operator -(Location left, long offset)
        {
            return new Location
            {
                HostDefined = left.HostDefined,
                Offset = left.Offset - offset
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is Location l)
                return this == l;

            return false;
        }

        public override int GetHashCode()
        {
            return HostDefined.GetHashCode() ^ Offset.GetHashCode();
        }
    }
}
