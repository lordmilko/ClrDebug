using System;

namespace ClrDebug
{
    /// <summary>
    /// Specifies flags to control which referenced items are converted to their definitions in order to optimize the code.
    /// </summary>
    [Flags]
    public enum CorRefToDefCheck : uint
    {
        /// <summary>
        /// Specifies that type references and member references should be converted to definitions. This is the default value (MDTypeRefToDef MDMemberRefToDef).
        /// </summary>
        MDRefToDefDefault = 0x00000003,

        /// <summary>
        /// Specifies that all referenced items should be converted to definitions.
        /// </summary>
        MDRefToDefAll = 0xffffffff,

        /// <summary>
        /// Specifies that no referenced items should be converted to definitions.
        /// </summary>
        MDRefToDefNone = 0x00000000,

        /// <summary>
        /// Specifies that only type references should be converted to type definitions.
        /// </summary>
        MDTypeRefToDef = 0x00000001,

        /// <summary>
        /// Specifies that only member references should be converted to definitions. That is, member references should be converted to either method definitions or field definitions.
        /// </summary>
        MDMemberRefToDef = 0x00000002
    }
}