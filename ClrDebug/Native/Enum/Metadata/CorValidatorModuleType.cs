namespace ClrDebug
{
    /// <summary>
    /// Specifies the type of a module.
    /// </summary>
    public enum CorValidatorModuleType
    {
        /// <summary>
        /// The module is an invalid type.
        /// </summary>
        ValidatorModuleTypeInvalid = 0x0,

        /// <summary>
        /// The minimum value of the <see cref="CorValidatorModuleType"/> enum.
        /// </summary>
        ValidatorModuleTypeMin = 0x00000001,

        /// <summary>
        /// The module is a portable executable (PE) file.
        /// </summary>
        ValidatorModuleTypePE = 0x00000001,

        /// <summary>
        /// The module is a .obj file.
        /// </summary>
        ValidatorModuleTypeObj = 0x00000002,

        /// <summary>
        /// The module is an edit-and-continue debugger session.
        /// </summary>
        ValidatorModuleTypeEnc = 0x00000003,

        /// <summary>
        /// The module is one that has been incrementally built.
        /// </summary>
        ValidatorModuleTypeIncr = 0x00000004,

        /// <summary>
        /// The maximum value of the <see cref="CorValidatorModuleType"/> enum.
        /// </summary>
        ValidatorModuleTypeMax = 0x00000004,
    }
}