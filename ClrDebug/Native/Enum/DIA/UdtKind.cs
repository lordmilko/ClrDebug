﻿namespace ClrDebug.DIA
{
    /// <summary>
    /// Describes the variety of user-defined type (UDT).
    /// </summary>
    public enum UdtKind
    {
        /// <summary>
        /// UDT is a structure.
        /// </summary>
        UdtStruct,

        /// <summary>
        /// UDT is a class.
        /// </summary>
        UdtClass,

        /// <summary>
        /// UDT is a union.
        /// </summary>
        UdtUnion,

        /// <summary>
        /// UDT is an interface.
        /// </summary>
        UdtInterface,

        UdtTaggedUnion,
    }
}
