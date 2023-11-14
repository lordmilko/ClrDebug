namespace ClrDebug.DIA
{
    /// <summary>
    /// Indicates the particular scope of a data value.
    /// </summary>
    public enum DataKind
    {
        /// <summary>
        /// Data symbol cannot be determined.
        /// </summary>
        DataIsUnknown,

        /// <summary>
        /// Data item is a local variable.
        /// </summary>
        DataIsLocal,

        /// <summary>
        /// Data item is a static local variable.
        /// </summary>
        DataIsStaticLocal,

        /// <summary>
        /// Data item is a formal parameter.
        /// </summary>
        DataIsParam,

        /// <summary>
        /// Data item is an object pointer (this).
        /// </summary>
        DataIsObjectPtr,

        /// <summary>
        /// Data item is a file-scoped variable.
        /// </summary>
        DataIsFileStatic,

        /// <summary>
        /// Data item is a global variable.
        /// </summary>
        DataIsGlobal,

        /// <summary>
        /// Data item is an object member variable.
        /// </summary>
        DataIsMember,

        /// <summary>
        /// Data item is a class static variable.
        /// </summary>
        DataIsStaticMember,

        /// <summary>
        /// Data item is a constant value.
        /// </summary>
        DataIsConstant,
    }
}
