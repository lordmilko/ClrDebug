using System;

namespace ClrDebug
{
    /// <summary>
    /// Contains values that describe metadata about a field.
    /// </summary>
    [Flags]
    public enum CorFieldAttr
    {
        /// <summary>
        /// Specifies accessibility information.
        /// </summary>
        fdFieldAccessMask           =   0x0007,

        /// <summary>
        /// Specifies that the field cannot be referenced.
        /// </summary>
        fdPrivateScope              =   0x0000,     // Member not referenceable.

        /// <summary>
        /// Specifies that the field is accessible only by its parent type.
        /// </summary>
        fdPrivate                   =   0x0001,     // Accessible only by the parent type.

        /// <summary>
        /// Specifies that the field is accessible by derived classes in its assembly.
        /// </summary>
        fdFamANDAssem               =   0x0002,     // Accessible by sub-types only in this Assembly.

        /// <summary>
        /// Specifies that the field is accessible by all types in its assembly.
        /// </summary>
        fdAssembly                  =   0x0003,     // Accessibly by anyone in the Assembly.

        /// <summary>
        /// Specifies that the field is accessible only by its type and derived classes.
        /// </summary>
        fdFamily                    =   0x0004,     // Accessible only by type and sub-types.

        /// <summary>
        /// Specifies that the field is accessible by derived classes and by all types in its assembly.
        /// </summary>
        fdFamORAssem                =   0x0005,     // Accessibly by sub-types anywhere, plus anyone in assembly.

        /// <summary>
        /// Specifies that the field is accessible by all types with visibility of this scope.
        /// </summary>
        fdPublic                    =   0x0006,     // Accessibly by anyone who has visibility to this scope.

        /// <summary>
        /// Specifies that the field is a member of its type rather than an instance member.
        /// </summary>
        fdStatic                    =   0x0010,     // Defined on type, else per instance.

        /// <summary>
        /// Specifies that the field cannot be changed after it is initialized.
        /// </summary>
        fdInitOnly                  =   0x0020,     // Field may only be initialized, not written to after init.

        /// <summary>
        /// Specifies that the field value is a compile-time constant.
        /// </summary>
        fdLiteral                   =   0x0040,     // Value is compile time constant.

        /// <summary>
        /// Specifies that the field is not serialized when its type is remoted.
        /// </summary>
        fdNotSerialized             =   0x0080,     // Field does not have to be serialized when type is remoted.

        /// <summary>
        /// Specifies that the field is special, and that its name describes how.
        /// </summary>
        fdSpecialName               =   0x0200,     // field is special.  Name describes how.

        /// <summary>
        /// Specifies that the field implementation is forwarded through PInvoke.
        /// </summary>
        fdPinvokeImpl               =   0x2000,     // Implementation is forwarded through pinvoke.

        /// <summary>
        /// Reserved for internal use by the common language runtime.
        /// </summary>
        fdReservedMask              =   0x9500,

        /// <summary>
        /// Specifies that the common language runtime metadata internal APIs should check the encoding of the name.
        /// </summary>
        fdRTSpecialName             =   0x0400,     // Runtime(metadata internal APIs) should check name encoding.

        /// <summary>
        /// Specifies that the field contains marshalling information.
        /// </summary>
        fdHasFieldMarshal           =   0x1000,     // Field has marshalling information.

        /// <summary>
        /// Specifies that the field has a default value.
        /// </summary>
        fdHasDefault                =   0x8000,     // Field has default.

        /// <summary>
        /// Specifies that the field has a relative virtual address.
        /// </summary>
        fdHasFieldRVA               =   0x0100,     // Field has RVA.
    }
}