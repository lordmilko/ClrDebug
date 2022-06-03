using System;

namespace ManagedCorDebug
{
    [Flags]
    public enum CorTypeAttr
    {
        // Use this mask to retrieve the type visibility information.
        tdVisibilityMask        =   0x00000007,
        tdNotPublic             =   0x00000000,     // Class is not public scope.
        tdPublic                =   0x00000001,     // Class is public scope.
        tdNestedPublic          =   0x00000002,     // Class is nested with public visibility.
        tdNestedPrivate         =   0x00000003,     // Class is nested with private visibility.
        tdNestedFamily          =   0x00000004,     // Class is nested with family visibility.
        tdNestedAssembly        =   0x00000005,     // Class is nested with assembly visibility.
        tdNestedFamANDAssem     =   0x00000006,     // Class is nested with family and assembly visibility.
        tdNestedFamORAssem      =   0x00000007,     // Class is nested with family or assembly visibility.

        // Use this mask to retrieve class layout information
        tdLayoutMask            =   0x00000018,
        tdAutoLayout            =   0x00000000,     // Class fields are auto-laid out
        tdSequentialLayout      =   0x00000008,     // Class fields are laid out sequentially
        tdExplicitLayout        =   0x00000010,     // Layout is supplied explicitly
        // end layout mask

        // Use this mask to retrieve class semantics information.
        tdClassSemanticsMask    =   0x00000020,
        tdClass                 =   0x00000000,     // Type is a class.
        tdInterface             =   0x00000020,     // Type is an interface.
        // end semantics mask

        // Special semantics in addition to class semantics.
        tdAbstract              =   0x00000080,     // Class is abstract
        tdSealed                =   0x00000100,     // Class is concrete and may not be extended
        tdSpecialName           =   0x00000400,     // Class name is special.  Name describes how.

        // Implementation attributes.
        tdImport                =   0x00001000,     // Class / interface is imported
        tdSerializable          =   0x00002000,     // The class is Serializable.
        tdWindowsRuntime        =   0x00004000,     // The type is a Windows Runtime type

        // Use tdStringFormatMask to retrieve string information for native interop
        tdStringFormatMask      =   0x00030000,
        tdAnsiClass             =   0x00000000,     // LPTSTR is interpreted as ANSI in this class
        tdUnicodeClass          =   0x00010000,     // LPTSTR is interpreted as UNICODE
        tdAutoClass             =   0x00020000,     // LPTSTR is interpreted automatically
        tdCustomFormatClass     =   0x00030000,     // A non-standard encoding specified by CustomFormatMask
        tdCustomFormatMask      =   0x00C00000,     // Use this mask to retrieve non-standard encoding information for native interop. The meaning of the values of these 2 bits is unspecified.

        // end string format mask

        tdBeforeFieldInit       =   0x00100000,     // Initialize the class any time before first static field access.
        tdForwarder             =   0x00200000,     // This ExportedType is a type forwarder.

        // Flags reserved for runtime use.
        tdReservedMask          =   0x00040800,
        tdRTSpecialName         =   0x00000800,     // Runtime should check name encoding.
        tdHasSecurity           =   0x00040000,     // Class has security associate with it.
    }
}