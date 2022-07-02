using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents a generic class or a class with a method parameter of type <see cref="Type"/>. This interface extends <see cref="ICorDebugClass"/>.
    /// </summary>
    [Guid("B008EA8D-7AB1-43F7-BB20-FBB5A04038AE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugClass2
    {
        /// <summary>
        /// Gets the type declaration for this class.
        /// </summary>
        /// <param name="elementType">[in] A value of the <see cref="CorElementType"/> enumeration that specifies the element type for this class: Set this value to ELEMENT_TYPE_VALUETYPE if this <see cref="ICorDebugClass2"/> represents a value type.<para/>
        /// Set this value to ELEMENT_TYPE_CLASS if this <see cref="ICorDebugClass2"/> represents a complex type.</param>
        /// <param name="nTypeArgs">[in] The number of type parameters, if the type is generic. The number of type parameters (if any) must match the number required by the class.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a type parameter. If the class is non-generic, this value is null.</param>
        /// <param name="ppType">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the type declaration. This object is equivalent to a <see cref="Type"/> object in managed code.</param>
        /// <remarks>
        /// If the class is non-generic, that is, if it has no type parameters, GetParameterizedType simply gets the runtime
        /// type object corresponding to the class. The elementType parameter should be set to the correct element type for
        /// the class: ELEMENT_TYPE_VALUETYPE if the class is a value type; otherwise, ELEMENT_TYPE_CLASS. If the class accepts
        /// type parameters (for example, ArrayList&lt;T&gt;), you can use GetParameterizedType to construct a type object
        /// for an instantiated type such as ArrayList&lt;int&gt;.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetParameterizedType(
            [In] CorElementType elementType,
            [In] int nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);

        /// <summary>
        /// For each method of the class, sets a value that indicates whether the method is user-defined code.
        /// </summary>
        /// <param name="bIsJustMyCode">[in] Set to true to indicate that the method is user-defined code; otherwise, set to false.</param>
        /// <remarks>
        /// A just-my-code (JMC) stepper will skip non-user-defined code. User-defined code must be a subset of debuggable
        /// code. SetJMCStatus returns an <see cref="HRESULT"/> value of S_FALSE if it fails to set the value for any method, even if it
        /// successfully sets the value for all other methods.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetJMCStatus([In] bool bIsJustMyCode);
    }
}