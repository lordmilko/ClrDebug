namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Specifies various types of data and functions.
    /// </summary>
    public enum TYPEKIND
    {
        /// <summary>
        /// A set of enumerators.
        /// </summary>
        TKIND_ENUM,

        /// <summary>
        /// A structure with no methods.
        /// </summary>
        TKIND_RECORD,

        /// <summary>
        /// A module that can have only static functions and data (for example, a DLL).
        /// </summary>
        TKIND_MODULE,

        /// <summary>
        /// A type that has virtual functions, all of which are pure.
        /// </summary>
        TKIND_INTERFACE,

        /// <summary>
        /// A set of methods and properties that are accessible through IDispatch::Invoke. By default, dual interfaces return TKIND_DISPATCH.
        /// </summary>
        TKIND_DISPATCH,

        /// <summary>
        /// A set of implemented components interfaces.
        /// </summary>
        TKIND_COCLASS,

        /// <summary>
        /// A type that is an alias for another type.
        /// </summary>
        TKIND_ALIAS,

        /// <summary>
        /// A union of all members that have an offset of zero.
        /// </summary>
        TKIND_UNION,

        /// <summary>
        /// End-of-enumeration marker.
        /// </summary>
        TKIND_MAX,
    }
}
