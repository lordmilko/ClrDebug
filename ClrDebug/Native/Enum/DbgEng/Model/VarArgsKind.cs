namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the style of variable arguments that a function definition takes.
    /// </summary>
    public enum VarArgsKind : uint
    {
        /// <summary>
        /// The function does not take any variable arguments.
        /// </summary>
        VarArgsNone,

        /// <summary>
        /// The function is a C-style varargs function (returnType(arg1, arg2, ...)). The number of arguments reported by the function does not include the ellipsis argument.<para/>
        /// Any variable argument passing occurs after the number of arguments returned by the GetFunctionParameterTypeCount method.
        /// </summary>
        VarArgsCStyle
    }
}
