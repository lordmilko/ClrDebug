using System;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Specifies how to invoke a function by IDispatch::Invoke.
    /// </summary>
    [Flags]
    public enum INVOKEKIND
    {
        /// <summary>
        /// The member is called using a normal function invocation syntax.
        /// </summary>
        INVOKE_FUNC = 1,

        /// <summary>
        /// The function is invoked using a normal property access syntax.
        /// </summary>
        INVOKE_PROPERTYGET = 2,

        /// <summary>
        /// The function is invoked using a property value assignment syntax.
        /// </summary>
        INVOKE_PROPERTYPUT = 4,

        /// <summary>
        /// The function is invoked using a property reference assignment syntax.
        /// </summary>
        INVOKE_PROPERTYPUTREF = 8,
    }
}
