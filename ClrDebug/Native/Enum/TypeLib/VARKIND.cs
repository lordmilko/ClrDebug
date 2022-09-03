namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Defines the kind of variable.
    /// </summary>
    public enum VARKIND
    {
        /// <summary>
        /// The variable is a field or member of the type. It exists at a fixed offset within each instance of the type.
        /// </summary>
        VAR_PERINSTANCE,

        /// <summary>
        /// There is only one instance of the variable.
        /// </summary>
        VAR_STATIC,

        /// <summary>
        /// The VARDESC structure describes a symbolic constant. There is no memory associated with it.
        /// </summary>
        VAR_CONST,

        /// <summary>
        /// The variable can be accessed only through IDispatch::Invoke.
        /// </summary>
        VAR_DISPATCH,
    }
}