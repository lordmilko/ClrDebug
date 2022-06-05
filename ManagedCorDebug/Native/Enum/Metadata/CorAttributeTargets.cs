using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Specifies the application elements on which it is valid to apply an attribute.
    /// </summary>
    /// <remarks>
    /// The CorAttributeTargets enumeration values can be combined with a bitwise OR operation to get the preferred combination.
    /// The CorAttributeTargets parallels the managed <see cref="AttributeTargets"/> enumeration.
    /// </remarks>
    public enum CorAttributeTargets
    {
        /// <summary>
        /// Attribute can be applied to an assembly.
        /// </summary>
        catAssembly = 0x0001,

        /// <summary>
        /// Attribute can be applied to a portable executable (.dll or .exe) module.
        /// </summary>
        catModule = 0x0002,

        /// <summary>
        /// Attribute can be applied to a class.
        /// </summary>
        catClass = 0x0004,

        /// <summary>
        /// Attribute can be applied to a structure; that is, a value type.
        /// </summary>
        catStruct = 0x0008,

        /// <summary>
        /// Attribute can be applied to an enumeration.
        /// </summary>
        catEnum = 0x0010,

        /// <summary>
        /// Attribute can be applied to a constructor.
        /// </summary>
        catConstructor = 0x0020,

        /// <summary>
        /// Attribute can be applied to a method.
        /// </summary>
        catMethod = 0x0040,

        /// <summary>
        /// Attribute can be applied to a property.
        /// </summary>
        catProperty = 0x0080,

        /// <summary>
        /// Attribute can be applied to a field.
        /// </summary>
        catField = 0x0100,

        /// <summary>
        /// Attribute can be applied to an event.
        /// </summary>
        catEvent = 0x0200,

        /// <summary>
        /// Attribute can be applied to an interface.
        /// </summary>
        catInterface = 0x0400,

        /// <summary>
        /// Attribute can be applied to a parameter.
        /// </summary>
        catParameter = 0x0800,

        /// <summary>
        /// Attribute can be applied to a delegate.
        /// </summary>
        catDelegate = 0x1000,

        /// <summary>
        /// Attribute can be applied to a generic parameter.
        /// </summary>
        catGenericParameter = 0x4000,

        /// <summary>
        /// Attribute can be applied to any application element.
        /// </summary>
        catAll = catAssembly | catModule | catClass | catStruct | catEnum | catConstructor |
                 catMethod | catProperty | catField | catEvent | catInterface | catParameter | catDelegate | catGenericParameter,

        /// <summary>
        /// Attribute can be applied to a member of a class.
        /// </summary>
        catClassMembers = catClass | catStruct | catEnum | catConstructor | catMethod | catProperty | catField | catEvent | catDelegate | catInterface,

    }
}