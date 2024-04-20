namespace ClrDebug.DIA
{
    /// <summary>
    /// Specifies the symbol's basic type.
    /// </summary>
    /// <remarks>
    /// The values in this enumeration are returned by the <see cref="IDiaSymbol.get_baseType"/> method.
    /// </remarks>
    public enum BasicType
    {
        /// <summary>
        /// No basic type is specified.
        /// </summary>
        btNoType = 0,

        /// <summary>
        /// Basic type is a void.
        /// </summary>
        btVoid = 1,

        /// <summary>
        /// Basic type is a char (C/C++ type).
        /// </summary>
        btChar = 2,

        /// <summary>
        /// Basic type is a wide (Unicode) character (WCHAR).
        /// </summary>
        btWChar = 3,

        /// <summary>
        /// Basic type is signed int (C/C++ type).
        /// </summary>
        btInt = 6,

        /// <summary>
        /// Basic type is unsigned int (C/C++ type).
        /// </summary>
        btUInt = 7,

        /// <summary>
        /// Basic type is a floating-point number (FLOAT).
        /// </summary>
        btFloat = 8,

        /// <summary>
        /// Basic type is a binary-coded decimal (BCD).
        /// </summary>
        btBCD = 9,

        /// <summary>
        /// Basic type is a Boolean (BOOL).
        /// </summary>
        btBool = 10,

        /// <summary>
        /// Basic type is a long int (C/C++ type).
        /// </summary>
        btLong = 13,

        /// <summary>
        /// Basic type is an unsigned long int (C/C++ type).
        /// </summary>
        btULong = 14,

        /// <summary>
        /// Basic type is currency.
        /// </summary>
        btCurrency = 25,

        /// <summary>
        /// Basic type is date/time (DATE).
        /// </summary>
        btDate = 26,

        /// <summary>
        /// Basic type is a variable type structure (VARIANT).
        /// </summary>
        btVariant = 27,

        /// <summary>
        /// Basic type is a complex number.
        /// </summary>
        btComplex = 28,

        /// <summary>
        /// Basic type is a bit.
        /// </summary>
        btBit = 29,

        /// <summary>
        /// Basic type is a basic or binary string (BSTR).
        /// </summary>
        btBSTR = 30,

        /// <summary>
        /// Basic type is an HRESULT.
        /// </summary>
        btHresult = 31,

        btChar16 = 32,
        btChar32 = 33,
        btChar8 = 34,
    }
}
