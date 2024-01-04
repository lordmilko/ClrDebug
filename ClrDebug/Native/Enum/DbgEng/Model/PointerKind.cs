namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the kind of a pointer type.
    /// </summary>
    public enum PointerKind : uint
    {
        /// <summary>
        /// Indicates a standard C/C++ pointer -- a *
        /// </summary>
        PointerStandard,

        /// <summary>
        /// Indicates a C/C++ reference (whether const or not) -- a &amp;
        /// </summary>
        PointerReference,

        /// <summary>
        /// Indicates a C/C++ rvalue reference (whether const or not) -- a &amp;&amp;
        /// </summary>
        PointerRValueReference,

        /// <summary>
        /// Indicates a C++/CX hat managed pointer (whether const or not) -- a ^
        /// </summary>
        PointerCXHat,

        /// <summary>
        /// Indicates a managed pointer reference
        /// </summary>
        PointerManagedReference
    }
}
