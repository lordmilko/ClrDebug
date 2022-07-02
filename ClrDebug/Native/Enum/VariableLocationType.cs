namespace ClrDebug
{
    /// <summary>
    /// Indicates the native location type of a variable.
    /// </summary>
    /// <remarks>
    /// A member of the <see cref="VariableLocationType"/> enumeration is returned by the <see cref="ICorDebugVariableHome.GetLocationType"/>
    /// method.
    /// </remarks>
    public enum VariableLocationType
    {
        /// <summary>
        /// The variable is in a register.
        /// </summary>
        VLT_REGISTER,

        /// <summary>
        /// The variable is in a register-relative memory location.
        /// </summary>
        VLT_REGISTER_RELATIVE,

        /// <summary>
        /// The variable is not stored in a register or a register-relative memory location.
        /// </summary>
        VLT_INVALID
    }
}