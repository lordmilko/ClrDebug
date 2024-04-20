namespace ClrDebug
{
    public enum ReadyToRunFixupKind
    {
        READYTORUN_FIXUP_ThisObjDictionaryLookup = 0x07,
        READYTORUN_FIXUP_TypeDictionaryLookup = 0x08,
        READYTORUN_FIXUP_MethodDictionaryLookup = 0x09,

        READYTORUN_FIXUP_TypeHandle = 0x10,
        READYTORUN_FIXUP_MethodHandle = 0x11,
        READYTORUN_FIXUP_FieldHandle = 0x12,

        READYTORUN_FIXUP_MethodEntry = 0x13, /* For calling a method entry point */
        READYTORUN_FIXUP_MethodEntry_DefToken = 0x14, /* Smaller version of MethodEntry - method is def token */
        READYTORUN_FIXUP_MethodEntry_RefToken = 0x15, /* Smaller version of MethodEntry - method is ref token */

        READYTORUN_FIXUP_VirtualEntry = 0x16, /* For invoking a virtual method */
        READYTORUN_FIXUP_VirtualEntry_DefToken = 0x17, /* Smaller version of VirtualEntry - method is def token */
        READYTORUN_FIXUP_VirtualEntry_RefToken = 0x18, /* Smaller version of VirtualEntry - method is ref token */
        READYTORUN_FIXUP_VirtualEntry_Slot = 0x19, /* Smaller version of VirtualEntry - type & slot */

        READYTORUN_FIXUP_Helper = 0x1A, /* Helper */
        READYTORUN_FIXUP_StringHandle = 0x1B, /* String handle */

        READYTORUN_FIXUP_NewObject = 0x1C, /* Dynamically created new helper */
        READYTORUN_FIXUP_NewArray = 0x1D,

        READYTORUN_FIXUP_IsInstanceOf = 0x1E, /* Dynamically created casting helper */
        READYTORUN_FIXUP_ChkCast = 0x1F,

        READYTORUN_FIXUP_FieldAddress = 0x20, /* For accessing a cross-module static fields */
        READYTORUN_FIXUP_CctorTrigger = 0x21, /* Static constructor trigger */

        READYTORUN_FIXUP_StaticBaseNonGC = 0x22, /* Dynamically created static base helpers */
        READYTORUN_FIXUP_StaticBaseGC = 0x23,
        READYTORUN_FIXUP_ThreadStaticBaseNonGC = 0x24,
        READYTORUN_FIXUP_ThreadStaticBaseGC = 0x25,

        READYTORUN_FIXUP_FieldBaseOffset = 0x26, /* Field base offset */
        READYTORUN_FIXUP_FieldOffset = 0x27, /* Field offset */

        READYTORUN_FIXUP_TypeDictionary = 0x28,
        READYTORUN_FIXUP_MethodDictionary = 0x29,

        READYTORUN_FIXUP_Check_TypeLayout = 0x2A, /* size, alignment, HFA, reference map */
        READYTORUN_FIXUP_Check_FieldOffset = 0x2B,

        READYTORUN_FIXUP_DelegateCtor = 0x2C, /* optimized delegate ctor */
        READYTORUN_FIXUP_DeclaringTypeHandle = 0x2D,

        READYTORUN_FIXUP_IndirectPInvokeTarget = 0x2E, /* Target (indirect) of an inlined pinvoke */
        READYTORUN_FIXUP_PInvokeTarget = 0x2F, /* Target of an inlined pinvoke */

        READYTORUN_FIXUP_Check_InstructionSetSupport = 0x30, /* Define the set of instruction sets that must be supported/unsupported to use the fixup */

        READYTORUN_FIXUP_Verify_FieldOffset = 0x31, /* Generate a runtime check to ensure that the field offset matches between compile and runtime. Unlike Check_FieldOffset, this will generate a runtime failure instead of silently dropping the method */
        READYTORUN_FIXUP_Verify_TypeLayout = 0x32, /* Generate a runtime check to ensure that the type layout (size, alignment, HFA, reference map) matches between compile and runtime. Unlike Check_TypeLayout, this will generate a runtime failure instead of silently dropping the method */

        READYTORUN_FIXUP_Check_VirtualFunctionOverride = 0x33, /* Generate a runtime check to ensure that virtual function resolution has equivalent behavior at runtime as at compile time. If not equivalent, code will not be used */
        READYTORUN_FIXUP_Verify_VirtualFunctionOverride = 0x34, /* Generate a runtime check to ensure that virtual function resolution has equivalent behavior at runtime as at compile time. If not equivalent, generate runtime failure. */

        READYTORUN_FIXUP_Check_IL_Body = 0x35, /* Check to see if an IL method is defined the same at runtime as at compile time. A failed match will cause code not to be used. */
        READYTORUN_FIXUP_Verify_IL_Body = 0x36, /* Verify an IL body is defined the same at compile time and runtime. A failed match will cause a hard runtime failure. */
    }
}
