#if !NETSTANDARD

using System;
using System.Runtime.CompilerServices;

//Facilities for enabling COM generated marshalling in .NET 8.0+ builds of ClrDebug

//Required to support doing "out Guid"
[assembly: DisableRuntimeMarshalling]

namespace ClrDebug
{
    /// <summary>
    /// Represents a fake <see cref="System.Runtime.InteropServices.InAttribute"/> for compatibility
    /// with <see cref="System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute"/>
    /// which does not allow this attribute.
    /// </summary>
    internal class InAttribute : Attribute
    {
    }

    /// <summary>
    /// Represents a fake <see cref="System.Runtime.InteropServices.OutAttribute"/> for compatibility
    /// with <see cref="System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute"/>
    /// which does not allow this attribute.
    /// </summary>
    internal class OutAttribute : Attribute
    {
    }
}

#endif
