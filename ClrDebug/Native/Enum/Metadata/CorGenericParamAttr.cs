using System;

namespace ClrDebug
{
    /// <summary>
    /// Contains values that describe the <see cref="Type"/> parameters for generic types, as used in calls to <see cref="IMetaDataEmit2.DefineGenericParam"/>.
    /// </summary>
    [Flags]
    public enum CorGenericParamAttr
    {
        /// <summary>
        /// Parameter variance applies only to generic parameters for interfaces and delegates.
        /// </summary>
        gpVarianceMask = 0x0003,

        /// <summary>
        /// Indicates the absence of variance.
        /// </summary>
        gpNonVariant = 0x0000,

        /// <summary>
        /// Indicates covariance.
        /// </summary>
        gpCovariant = 0x0001,

        /// <summary>
        /// Indicates contravariance.
        /// </summary>
        gpContravariant = 0x0002,

        /// <summary>
        /// Special constraints can apply to any <see cref="Type"/> parameter.
        /// </summary>
        gpSpecialConstraintMask = 0x001C,

        /// <summary>
        /// Indicates that no constraint applies to the <see cref="Type"/> parameter.
        /// </summary>
        gpNoSpecialConstraint = 0x0000,

        /// <summary>
        /// Indicates that the <see cref="Type"/> parameter must be a reference type.
        /// </summary>
        gpReferenceTypeConstraint = 0x0004,

        /// <summary>
        /// Indicates that the <see cref="Type"/> parameter must be a value type that cannot be a null value.
        /// </summary>
        gpNotNullableValueTypeConstraint = 0x0008,

        /// <summary>
        /// Indicates that the <see cref="Type"/> parameter must have a default public constructor that takes no parameters.
        /// </summary>
        gpDefaultConstructorConstraint = 0x0010
    }
}