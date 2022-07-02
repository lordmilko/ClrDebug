using System;

namespace ClrDebug
{
    /// <summary>
    /// Contains values that describe the features of a method.
    /// </summary>
    [Flags]
    public enum CorMethodAttr
    {
        /// <summary>
        /// Specifies member access.
        /// </summary>
        mdMemberAccessMask          =   0x0007,

        /// <summary>
        /// Specifies that the member cannot be referenced.
        /// </summary>
        mdPrivateScope              =   0x0000,     // Member not referenceable.

        /// <summary>
        /// Specifies that the member is accessible only by the parent type.
        /// </summary>
        mdPrivate                   =   0x0001,     // Accessible only by the parent type.

        /// <summary>
        /// Specifies that the member is accessible by subtypes only in this assembly.
        /// </summary>
        mdFamANDAssem               =   0x0002,     // Accessible by sub-types only in this Assembly.

        /// <summary>
        /// Specifies that the member is accessibly by anyone in the assembly.
        /// </summary>
        mdAssem                     =   0x0003,     // Accessibly by anyone in the Assembly.

        /// <summary>
        /// Specifies that the member is accessible only by type and subtypes.
        /// </summary>
        mdFamily                    =   0x0004,     // Accessible only by type and sub-types.

        /// <summary>
        /// Specifies that the member is accessible by derived classes and by other types in its assembly.
        /// </summary>
        mdFamORAssem                =   0x0005,     // Accessibly by sub-types anywhere, plus anyone in assembly.

        /// <summary>
        /// Specifies that the member is accessible by all types with access to the scope.
        /// </summary>
        mdPublic                    =   0x0006,     // Accessibly by anyone who has visibility to this scope.

        /// <summary>
        /// Specifies that the member is defined as part of the type rather than as a member of an instance.
        /// </summary>
        mdStatic                    =   0x0010,     // Defined on type, else per instance.

        /// <summary>
        /// Specifies that the method cannot be overridden.
        /// </summary>
        mdFinal                     =   0x0020,     // Method may not be overridden.

        /// <summary>
        /// Specifies that the method can be overridden.
        /// </summary>
        mdVirtual                   =   0x0040,     // Method virtual.

        /// <summary>
        /// Specifies that the method hides by name and signature, rather than just by name.
        /// </summary>
        mdHideBySig                 =   0x0080,     // Method hides by name+sig, else just by name.

        /// <summary>
        /// Specifies virtual table layout.
        /// </summary>
        mdVtableLayoutMask          =   0x0100,

        /// <summary>
        /// Specifies that the slot used for this method in the virtual table be reused. This is the default.
        /// </summary>
        mdReuseSlot                 =   0x0000,     // The default.

        /// <summary>
        /// Specifies that the method always gets a new slot in the virtual table.
        /// </summary>
        mdNewSlot                   =   0x0100,     // Method always gets a new slot in the vtable.

        /// <summary>
        /// Specifies that the method can be overridden by the same types to which it is visible.
        /// </summary>
        mdCheckAccessOnOverride     =   0x0200,     // Overridability is the same as the visibility.

        /// <summary>
        /// Specifies that the method is not implemented.
        /// </summary>
        mdAbstract                  =   0x0400,     // Method does not provide an implementation.

        /// <summary>
        /// Specifies that the method is special, and that its name describes how.
        /// </summary>
        mdSpecialName               =   0x0800,     // Method is special.  Name describes how.

        /// <summary>
        /// Specifies that the method implementation is forwarded using PInvoke.
        /// </summary>
        mdPinvokeImpl               =   0x2000,     // Implementation is forwarded through pinvoke.

        /// <summary>
        /// Specifies that the method is a managed method exported to unmanaged code.
        /// </summary>
        mdUnmanagedExport           =   0x0008,     // Managed method exported via thunk to unmanaged code.

        /// <summary>
        /// Reserved for internal use by the common language runtime.
        /// </summary>
        mdReservedMask              =   0xd000,

        /// <summary>
        /// Specifies that the common language runtime should check the encoding of the method name.
        /// </summary>
        mdRTSpecialName             =   0x1000,     // Runtime should check name encoding.

        /// <summary>
        /// Specifies that the method has security associated with it.
        /// </summary>
        mdHasSecurity               =   0x4000,     // Method has security associate with it.

        /// <summary>
        /// Specifies that the method calls another method containing security code.
        /// </summary>
        mdRequireSecObject          =   0x8000,     // Method calls another method containing security code.

    }
}
