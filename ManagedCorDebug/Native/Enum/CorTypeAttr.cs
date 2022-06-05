using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that indicate type metadata.
    /// </summary>
    [Flags]
    public enum CorTypeAttr
    {
        /// <summary>
        /// Used for type visibility information.
        /// </summary>
        tdVisibilityMask        =   0x00000007,

        /// <summary>
        /// Specifies that the type is not in public scope.
        /// </summary>
        tdNotPublic             =   0x00000000,     // Class is not public scope.

        /// <summary>
        /// Specifies that the type is in public scope.
        /// </summary>
        tdPublic                =   0x00000001,     // Class is public scope.

        /// <summary>
        /// Specifies that the type is nested with public visibility.
        /// </summary>
        tdNestedPublic          =   0x00000002,     // Class is nested with public visibility.

        /// <summary>
        /// Specifies that the type is nested with private visibility.
        /// </summary>
        tdNestedPrivate         =   0x00000003,     // Class is nested with private visibility.

        /// <summary>
        /// Specifies that the type is nested with family visibility.
        /// </summary>
        tdNestedFamily          =   0x00000004,     // Class is nested with family visibility.

        /// <summary>
        /// Specifies that the type is nested with assembly visibility.
        /// </summary>
        tdNestedAssembly        =   0x00000005,     // Class is nested with assembly visibility.

        /// <summary>
        /// Specifies that the type is nested with family and assembly visibility.
        /// </summary>
        tdNestedFamANDAssem     =   0x00000006,     // Class is nested with family and assembly visibility.

        /// <summary>
        /// Specifies that the type is nested with family or assembly visibility.
        /// </summary>
        tdNestedFamORAssem      =   0x00000007,     // Class is nested with family or assembly visibility.

        /// <summary>
        /// Gets layout information for the type.
        /// </summary>
        tdLayoutMask            =   0x00000018,

        /// <summary>
        /// Specifies that the fields of this type are laid out automatically.
        /// </summary>
        tdAutoLayout            =   0x00000000,     // Class fields are auto-laid out

        /// <summary>
        /// Specifies that the fields of this type are laid out sequentially.
        /// </summary>
        tdSequentialLayout      =   0x00000008,     // Class fields are laid out sequentially

        /// <summary>
        /// Specifies that field layout is supplied explicitly.
        /// </summary>
        tdExplicitLayout        =   0x00000010,     // Layout is supplied explicitly

        /// <summary>
        /// Gets semantic information about the type.
        /// </summary>
        tdClassSemanticsMask    =   0x00000020,

        /// <summary>
        /// Specifies that the type is a class.
        /// </summary>
        tdClass                 =   0x00000000,     // Type is a class.

        /// <summary>
        /// Specifies that the type is an interface.
        /// </summary>
        tdInterface             =   0x00000020,     // Type is an interface.

        /// <summary>
        /// Specifies that the type is abstract.
        /// </summary>
        tdAbstract              =   0x00000080,     // Class is abstract

        /// <summary>
        /// Specifies that the type cannot be extended.
        /// </summary>
        tdSealed                =   0x00000100,     // Class is concrete and may not be extended

        /// <summary>
        /// Specifies that the class name is special. Its name describes how.
        /// </summary>
        tdSpecialName           =   0x00000400,     // Class name is special.  Name describes how.

        /// <summary>
        /// Specifies that the type is imported.
        /// </summary>
        tdImport                =   0x00001000,     // Class / interface is imported

        /// <summary>
        /// Specifies that the type is serializable.
        /// </summary>
        tdSerializable          =   0x00002000,     // The class is Serializable.

        /// <summary>
        /// Specifies that this type is a Windows Runtime type.
        /// </summary>
        tdWindowsRuntime        =   0x00004000,     // The type is a Windows Runtime type

        /// <summary>
        /// Gets information about how strings are encoded and formatted.
        /// </summary>
        tdStringFormatMask      =   0x00030000,

        /// <summary>
        /// Specifies that this type interprets an LPTSTR as ANSI.
        /// </summary>
        tdAnsiClass             =   0x00000000,     // LPTSTR is interpreted as ANSI in this class

        /// <summary>
        /// Specifies that this type interprets an LPTSTR as Unicode.
        /// </summary>
        tdUnicodeClass          =   0x00010000,     // LPTSTR is interpreted as UNICODE

        /// <summary>
        /// Specifies that this type interprets an LPTSTR automatically.
        /// </summary>
        tdAutoClass             =   0x00020000,     // LPTSTR is interpreted automatically

        /// <summary>
        /// Specifies that the type has a non-standard encoding, as specified by CustomFormatMask.
        /// </summary>
        tdCustomFormatClass     =   0x00030000,     // A non-standard encoding specified by CustomFormatMask

        /// <summary>
        /// Use this mask to get non-standard encoding information for native interop. The meaning of the values of these two bits is unspecified.
        /// </summary>
        tdCustomFormatMask      =   0x00C00000,     // Use this mask to retrieve non-standard encoding information for native interop. The meaning of the values of these 2 bits is unspecified.

        /// <summary>
        /// Specifies that the type must be initialized before the first attempt to access a static field.
        /// </summary>
        tdBeforeFieldInit       =   0x00100000,     // Initialize the class any time before first static field access.

        /// <summary>
        /// Specifies that the type is exported, and a type forwarder.
        /// </summary>
        tdForwarder             =   0x00200000,     // This ExportedType is a type forwarder.

        /// <summary>
        /// This flag and the flags below are used internally by the common language runtime.
        /// </summary>
        tdReservedMask          =   0x00040800,

        /// <summary>
        /// Specifies that the common language runtime should check the name encoding.
        /// </summary>
        tdRTSpecialName         =   0x00000800,     // Runtime should check name encoding.

        /// <summary>
        /// Specifies that the type has security associated with it.
        /// </summary>
        tdHasSecurity           =   0x00040000,     // Class has security associate with it.
    }
}