using System;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Defines the properties and attributes of a type description.
    /// </summary>
    [Flags]
    public enum TYPEFLAGS : short
    {
        /// <summary>
        /// The class supports aggregation.
        /// </summary>
        TYPEFLAG_FAGGREGATABLE = 1024, // 0x0400

        /// <summary>
        /// A type description that describes an Application object.
        /// </summary>
        TYPEFLAG_FAPPOBJECT = 1,

        /// <summary>
        /// Instances of the type can be created by ITypeInfo::CreateInstance.
        /// </summary>
        TYPEFLAG_FCANCREATE = 2,

        /// <summary>
        /// The type is a control from which other types will be derived and should not be displayed to users.
        /// </summary>
        TYPEFLAG_FCONTROL = 32, // 0x0020

        /// <summary>
        /// Indicates that the interface derives from IDispatch, either directly or indirectly. This flag is computed; there is no Object Description Language for the flag.
        /// </summary>
        TYPEFLAG_FDISPATCHABLE = 4096, // 0x1000

        /// <summary>
        /// The interface supplies both IDispatch and VTBL binding.
        /// </summary>
        TYPEFLAG_FDUAL = 64, // 0x0040

        /// <summary>
        /// The type should not be displayed to browsers.
        /// </summary>
        TYPEFLAG_FHIDDEN = 16, // 0x0010

        /// <summary>
        /// The type is licensed.
        /// </summary>
        TYPEFLAG_FLICENSED = 4,

        /// <summary>
        /// The interface cannot add members at run time.
        /// </summary>
        TYPEFLAG_FNONEXTENSIBLE = 128, // 0x0080

        /// <summary>
        /// The types used in the interface are fully compatible with Automation, including VTBL binding support. Setting dual on an interface sets both this flag and the  <see cref="TYPEFLAG_FDUAL"/>. This flag is not allowed on dispinterfaces.
        /// </summary>
        TYPEFLAG_FOLEAUTOMATION = 256, // 0x0100

        /// <summary>
        /// The type is predefined. The client application should automatically create a single instance of the object that has this attribute. The name of the variable that points to the object is the same as the class name of the object.
        /// </summary>
        TYPEFLAG_FPREDECLID = 8,

        /// <summary>
        /// Indicates that the interface will be using a proxy/stub dynamic link library. This flag specifies that the type library proxy should not be unregistered when the type library is unregistered.
        /// </summary>
        TYPEFLAG_FPROXY = 16384, // 0x4000

        /// <summary>
        /// The object supports IConnectionPointWithDefault, and has default behaviors.
        /// </summary>
        TYPEFLAG_FREPLACEABLE = 2048, // 0x0800

        /// <summary>
        /// Should not be accessible from macro languages. This flag is intended for system-level types or types that type browsers should not display.
        /// </summary>
        TYPEFLAG_FRESTRICTED = 512, // 0x0200

        /// <summary>
        /// Indicates base interfaces should be checked for name resolution before checking children, which is the reverse of the default behavior.
        /// </summary>
        TYPEFLAG_FREVERSEBIND = 8192, // 0x2000
    }
}
