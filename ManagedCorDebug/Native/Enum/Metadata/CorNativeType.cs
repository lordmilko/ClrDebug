namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that describe native unmanaged types.
    /// </summary>
    public enum CorNativeType
    {
        /// <summary>
        /// Obsolete.
        /// </summary>
        NATIVE_TYPE_END = 0x0,    //DEPRECATED

        /// <summary>
        /// Obsolete.
        /// </summary>
        NATIVE_TYPE_VOID = 0x1,    //DEPRECATED

        /// <summary>
        /// A 4-byte Boolean value, where TRUE is non-zero and FALSE is zero.
        /// </summary>
        NATIVE_TYPE_BOOLEAN = 0x2,    // (4 byte boolean value: TRUE = non-zero, FALSE = 0)

        /// <summary>
        /// A signed 8-bit integer value.
        /// </summary>
        NATIVE_TYPE_I1 = 0x3,

        /// <summary>
        /// An unsigned 8-bit integer value.
        /// </summary>
        NATIVE_TYPE_U1 = 0x4,

        /// <summary>
        /// A signed 16-bit integer value.
        /// </summary>
        NATIVE_TYPE_I2 = 0x5,

        /// <summary>
        /// An unsigned 16-bit integer value.
        /// </summary>
        NATIVE_TYPE_U2 = 0x6,

        /// <summary>
        /// A signed 32-bit integer value.
        /// </summary>
        NATIVE_TYPE_I4 = 0x7,

        /// <summary>
        /// An unsigned 32-bit integer value.
        /// </summary>
        NATIVE_TYPE_U4 = 0x8,

        /// <summary>
        /// A signed 64-bit integer value.
        /// </summary>
        NATIVE_TYPE_I8 = 0x9,

        /// <summary>
        /// An unsigned 64-bit integer value.
        /// </summary>
        NATIVE_TYPE_U8 = 0xa,

        /// <summary>
        /// A 4-byte floating-point numeric value.
        /// </summary>
        NATIVE_TYPE_R4 = 0xb,

        /// <summary>
        /// An 8-byte floating-point numeric value.
        /// </summary>
        NATIVE_TYPE_R8 = 0xc,

        /// <summary>
        /// Obsolete.
        /// </summary>
        NATIVE_TYPE_SYSCHAR = 0xd,    //DEPRECATED

        /// <summary>
        /// Obsolete.
        /// </summary>
        NATIVE_TYPE_VARIANT = 0xe,    //DEPRECATED

        /// <summary>
        /// A numeric COM type that corresponds to the managed <see cref="decimal"/> type.
        /// </summary>
        NATIVE_TYPE_CURRENCY = 0xf,

        /// <summary>
        /// Obsolete.
        /// </summary>
        NATIVE_TYPE_PTR = 0x10,   //DEPRECATED

        /// <summary>
        /// Obsolete.
        /// </summary>
        NATIVE_TYPE_DECIMAL = 0x11,   //DEPRECATED

        /// <summary>
        /// Obsolete.
        /// </summary>
        NATIVE_TYPE_DATE = 0x12,   //DEPRECATED

        /// <summary>
        /// COM Interop.
        /// </summary>
        NATIVE_TYPE_BSTR = 0x13,   //COMINTEROP

        /// <summary>
        /// An LPSTR string value.
        /// </summary>
        NATIVE_TYPE_LPSTR = 0x14,

        /// <summary>
        /// An LPWSTR string value.
        /// </summary>
        NATIVE_TYPE_LPWSTR = 0x15,

        /// <summary>
        /// An LPTSTR string value.
        /// </summary>
        NATIVE_TYPE_LPTSTR = 0x16,

        /// <summary>
        /// A fixed, system-defined string value.
        /// </summary>
        NATIVE_TYPE_FIXEDSYSSTRING = 0x17,

        /// <summary>
        /// Obsolete.
        /// </summary>
        NATIVE_TYPE_OBJECTREF = 0x18,   //DEPRECATED

        /// <summary>
        /// COM Interop.
        /// </summary>
        NATIVE_TYPE_IUNKNOWN = 0x19,   //COMINTEROP

        /// <summary>
        /// COM Interop.
        /// </summary>
        NATIVE_TYPE_IDISPATCH = 0x1a,   //COMINTEROP

        /// <summary>
        /// A native structure value.
        /// </summary>
        NATIVE_TYPE_STRUCT = 0x1b,

        /// <summary>
        /// COM Interop.
        /// </summary>
        NATIVE_TYPE_INTF = 0x1c,   //COMINTEROP

        /// <summary>
        /// COM Interop.
        /// </summary>
        NATIVE_TYPE_SAFEARRAY = 0x1d,   //COMINTEROP

        /// <summary>
        /// A fixed-length array value.
        /// </summary>
        NATIVE_TYPE_FIXEDARRAY = 0x1e,

        /// <summary>
        /// A native 16-bit signed integer value.
        /// </summary>
        NATIVE_TYPE_INT = 0x1f,

        /// <summary>
        /// A native 16-bit unsigned integer value.
        /// </summary>
        NATIVE_TYPE_UINT = 0x20,

        /// <summary>
        /// Obsolete. Use NATIVE_TYPE_STRUCT.
        /// </summary>
        NATIVE_TYPE_NESTEDSTRUCT = 0x21, //DEPRECATED (use NATIVE_TYPE_STRUCT)

        /// <summary>
        /// COM Interop.
        /// </summary>
        NATIVE_TYPE_BYVALSTR = 0x22,   //COMINTEROP

        /// <summary>
        /// COM Interop.
        /// </summary>
        NATIVE_TYPE_ANSIBSTR = 0x23,   //COMINTEROP

        /// <summary>
        /// COM Interop. Select BSTR or ANSIBSTR depending on the platform.
        /// </summary>
        NATIVE_TYPE_TBSTR = 0x24, // select BSTR or ANSIBSTR depending on platform

        /// <summary>
        /// A 2-byte Boolean value, where TRUE is -1 and FALSE is zero.
        /// </summary>
        NATIVE_TYPE_VARIANTBOOL = 0x25, // (2-byte boolean value: TRUE = -1, FALSE = 0)

        /// <summary>
        /// A function pointer.
        /// </summary>
        NATIVE_TYPE_FUNC = 0x26,

        /// <summary>
        /// A reference to any native type.
        /// </summary>
        NATIVE_TYPE_ASANY = 0x28,

        /// <summary>
        /// A reference to an array with members of an unspecified type.
        /// </summary>
        NATIVE_TYPE_ARRAY = 0x2a,

        /// <summary>
        /// A 32-bit integer pointer to a structure.
        /// </summary>
        NATIVE_TYPE_LPSTRUCT = 0x2b,

        /// <summary>
        /// A custom marshaller native type. This must be followed by a string of the following format: "Native type name/0Custom marshaller type name/0Optional cookie/0" or "/0Custom marshaller type name/0Optional cookie/0"
        /// </summary>
        NATIVE_TYPE_CUSTOMMARSHALER = 0x2c,  // Custom marshaler native type. This must be followed

        /// <summary>
        /// COM Interop. With ELEMENT_TYPE_I4 this type maps to VT_HRESULT.
        /// </summary>
        NATIVE_TYPE_ERROR = 0x2d, // This native type coupled with ELEMENT_TYPE_I4 will map to VT_HRESULT

        /// <summary>
        /// A native IInspectable type.
        /// </summary>
        NATIVE_TYPE_IINSPECTABLE = 0x2e,

        /// <summary>
        /// A native HString.
        /// </summary>
        NATIVE_TYPE_HSTRING = 0x2f,
        NATIVE_TYPE_LPUTF8STR = 0x30, // utf-8 string

        /// <summary>
        /// An invalid value.
        /// </summary>
        NATIVE_TYPE_MAX = 0x50, // first invalid element type
    }
}