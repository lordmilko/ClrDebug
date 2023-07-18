using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to work with arrays, pointers, function pointers, and reference types. This interface is an extension of the <see cref="ICorDebugAppDomain"/> interface.
    /// </summary>
    [Guid("096E81D5-ECDA-4202-83F5-C65980A9EF75")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugAppDomain2
    {
        /// <summary>
        /// Gets an array of the specified type, or a pointer or reference to the specified type.
        /// </summary>
        /// <param name="elementType">[in] A value of the <see cref="CorElementType"/> enumeration that specifies the underlying native type (an array, pointer, or reference) to be created.</param>
        /// <param name="nRank">[in] The rank (that is, number of dimensions) of the array. This value must be 0 if elementType specifies a pointer or reference type.</param>
        /// <param name="pTypeArg">[in] A pointer to an <see cref="ICorDebugType"/> object that represents the type of array, pointer, or reference to be created.</param>
        /// <param name="ppType">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the constructed array, pointer type, or reference type.</param>
        /// <remarks>
        /// The value of elementType must be one of the following: If the value of elementType is ELEMENT_TYPE_PTR or ELEMENT_TYPE_BYREF,
        /// nRank must be zero.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetArrayOrPointerType(
            [In] CorElementType elementType,
            [In] int nRank,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugType pTypeArg,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);

        /// <summary>
        /// Gets a pointer to a function that has a given signature.
        /// </summary>
        /// <param name="nTypeArgs">[in] The number of type arguments for the function.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a type argument of the function.<para/>
        /// The first element is the return type; each of the other elements is a parameter type.</param>
        /// <param name="ppType">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the pointer to the function.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFunctionPointerType(
            [In] int nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In] ref ICorDebugType ppTypeArgs,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugType ppType);
    }
}
