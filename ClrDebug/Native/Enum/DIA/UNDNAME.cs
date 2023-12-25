using System;

namespace ClrDebug.DIA
{
    [Flags]
    public enum UNDNAME
    {
        /// <summary>
        /// Enables full undecoration.
        /// </summary>
        UNDNAME_COMPLETE = 0x0000,

        /// <summary>
        /// Removes leading underscores from Microsoft extended keywords.
        /// </summary>
        UNDNAME_NO_LEADING_UNDERSCORES = 0x0001,

        /// <summary>
        /// Disables expansion of Microsoft extended keywords.
        /// </summary>
        UNDNAME_NO_MS_KEYWORDS = 0x0002,

        /// <summary>
        /// Disables expansion of return type for primary declaration.
        /// </summary>
        UNDNAME_NO_FUNCTION_RETURNS = 0x0004,

        /// <summary>
        /// Disables expansion of the declaration model.
        /// </summary>
        UNDNAME_NO_ALLOCATION_MODEL = 0x0008,

        /// <summary>
        /// Disables expansion of the declaration language specifier.
        /// </summary>
        UNDNAME_NO_ALLOCATION_LANGUAGE = 0x0010,

        /// <summary>
        /// RESERVED.
        /// </summary>
        UNDNAME_RESERVED1 = 0x0020,

        /// <summary>
        /// RESERVED.
        /// </summary>
        UNDNAME_RESERVED2 = 0x0040,

        /// <summary>
        /// Disables all modifiers on the this type.
        /// </summary>
        UNDNAME_NO_THISTYPE = 0x0060,

        /// <summary>
        /// Disables expansion of access specifiers for members.
        /// </summary>
        UNDNAME_NO_ACCESS_SPECIFIERS = 0x0080,

        /// <summary>
        /// Disables expansion of "throw-signatures" for functions and pointers to functions.
        /// </summary>
        UNDNAME_NO_THROW_SIGNATURES = 0x0100,

        /// <summary>
        /// Disables expansion of static or virtual members.
        /// </summary>
        UNDNAME_NO_MEMBER_TYPE = 0x0200,

        /// <summary>
        /// Disables expansion of the Microsoft model for UDT returns.
        /// </summary>
        UNDNAME_NO_RETURN_UDT_MODEL = 0x0400,

        /// <summary>
        /// Undecorates 32-bit decorated names.
        /// </summary>
        UNDNAME_32_BIT_DECODE = 0x0800,

        /// <summary>
        /// Gets only the name for primary declaration; returns just[scope::]name.Expands template params.
        /// </summary>
        UNDNAME_NAME_ONLY = 0x1000,

        /// <summary>
        /// Input is just a type encoding; composes an abstract declarator.
        /// </summary>
        UNDNAME_TYPE_ONLY = 0x2000,

        /// <summary>
        /// The real template parameters are available.
        /// </summary>
        UNDNAME_HAVE_PARAMETERS = 0x4000,

        /// <summary>
        /// Suppresses enum/class/struct/union.
        /// </summary>
        UNDNAME_NO_ECSU = 0x8000,

        /// <summary>
        /// Suppresses check for valid identifier characters.
        /// </summary>
        UNDNAME_NO_IDENT_CHAR_CHECK = 0x10000,

        /// <summary>
        /// Does not include ptr64 in output.
        /// </summary>
        UNDNAME_NO_PTR64 = 0x20000,
    }
}
