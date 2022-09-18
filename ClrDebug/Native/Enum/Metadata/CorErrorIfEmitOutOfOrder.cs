using System;

namespace ClrDebug
{
    /// <summary>
    /// Contains flag values that indicate the conditions under which an error message should be generated when metadata is emitted out of order.<para/>
    /// Used with <see cref="MetaDataDispenserOption.MetaDataErrorIfEmitOutOfOrder"/>.
    /// </summary>
    [Flags]
    public enum CorErrorIfEmitOutOfOrder : uint
    {
        /// <summary>
        /// Indicates the default behavior, which does not generate error messages.
        /// </summary>
        MDErrorOutOfOrderDefault = 0x00000000,   // default not to generate any error

        /// <summary>
        /// Indicates that the compiler should not generate error messages.
        /// </summary>
        MDErrorOutOfOrderNone = 0x00000000,   // do not generate error for out of order emit

        /// <summary>
        /// Indicates that the compiler should generate an error message when a field, property, event, method, or parameter is emitted out of order.
        /// </summary>
        MDErrorOutOfOrderAll = 0xffffffff,   // generate out of order emit for method, field, param, property, and event

        /// <summary>
        /// Indicates that the compiler should generate an error message when a method is emitted out of order.
        /// </summary>
        MDMethodOutOfOrder = 0x00000001,   // generate error when methods are emitted out of order

        /// <summary>
        /// Indicates that the compiler should generate an error message when a field is emitted out of order.
        /// </summary>
        MDFieldOutOfOrder = 0x00000002,   // generate error when fields are emitted out of order

        /// <summary>
        /// Indicates that the compiler should generate an error message when a parameter is emitted out of order.
        /// </summary>
        MDParamOutOfOrder = 0x00000004,   // generate error when params are emitted out of order

        /// <summary>
        /// Indicates that the compiler should generate an error message when a property is emitted out of order.
        /// </summary>
        MDPropertyOutOfOrder = 0x00000008,   // generate error when properties are emitted out of order

        /// <summary>
        /// Indicates that the compiler should generate an error message when an event is emitted out of order.
        /// </summary>
        MDEventOutOfOrder = 0x00000010,   // generate error when events are emitted out of order
    }
}
