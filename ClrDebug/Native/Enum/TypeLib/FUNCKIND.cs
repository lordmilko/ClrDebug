namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Defines how to access a function.
    /// </summary>
    public enum FUNCKIND
    {
        /// <summary>
        /// The function is accessed in the same way as <see cref="FUNCKIND.FUNC_PUREVIRTUAL"/>, except the function has an implementation.
        /// </summary>
        FUNC_VIRTUAL,

        /// <summary>
        /// The function is accessed through the virtual function table (VTBL), and takes an implicit this pointer.
        /// </summary>
        FUNC_PUREVIRTUAL,

        /// <summary>
        /// The function is accessed by static address and takes an implicit this pointer.
        /// </summary>
        FUNC_NONVIRTUAL,

        /// <summary>
        /// The function is accessed by static address and does not take an implicit this pointer.
        /// </summary>
        FUNC_STATIC,

        /// <summary>
        /// The function can be accessed only through IDispatch.
        /// </summary>
        FUNC_DISPATCH,
    }
}
