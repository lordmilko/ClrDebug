using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a type, either basic or complex (that is, user-defined). If the type is generic, <see cref="ICorDebugType"/> represents the instantiated generic type.
    /// </summary>
    /// <remarks>
    /// If the type is generic, <see cref="ICorDebugClass"/> represents the uninstantiated type. The <see cref="ICorDebugType"/> interface represents
    /// an instantiated generic type. For example, Hashtable&lt;K, V&gt; would be represented by <see cref="ICorDebugClass"/>, whereas
    /// Hashtable&lt;Int32, String&gt; would be represented by <see cref="ICorDebugType"/>. Non-generic types are represented by both
    /// <see cref="ICorDebugClass"/> and <see cref="ICorDebugType"/>. The latter interface was introduced in the .NET Framework version 2.0 to deal
    /// with type instantiation.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D613F0BB-ACE1-4C19-BD72-E4C08D5DA7F5")]
    [ComImport]
    public interface ICorDebugType
    {
        /// <summary>
        /// Gets a <see cref="CorElementType"/> value that describes the native type of the common language runtime (CLR) <see cref="Type"/> represented by this <see cref="ICorDebugType"/>.
        /// </summary>
        /// <param name="ty">[out] A pointer to a value of the <see cref="CorElementType"/> enumeration that indicates the CLR <see cref="Type"/> that this <see cref="ICorDebugType"/> represents.</param>
        /// <remarks>
        /// If the value of ty is either ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE, the <see cref="GetClass"/> method may
        /// be called to get the uninstantiated type for a generic type; otherwise, do not call ICorDebugType::GetClass.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetType(out CorElementType ty);

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugClass"/> that represents the uninstantiated generic type.
        /// </summary>
        /// <param name="ppClass">[out] A pointer to the address of an <see cref="ICorDebugClass"/> interface that represents the uninstantiated generic type.</param>
        /// <remarks>
        /// GetClass can be called only under certain conditions. Call <see cref="GetType"/> before calling GetClass. If ICorDebugType::GetType
        /// returns a <see cref="CorElementType"/> value that is ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE, GetClass can be called to
        /// get the uninstantiated type for a generic type.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetClass([MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugTypeEnum"/> that contains the <see cref="Type"/> parameters of the class referenced by this <see cref="ICorDebugType"/>.
        /// </summary>
        /// <param name="ppTyParEnum">[out] A pointer to the address of an <see cref="ICorDebugTypeEnum"/> that contains the parameters of the type.</param>
        /// <remarks>
        /// You can use EnumerateTypeParameters if the <see cref="CorElementType"/> value returned by <see cref="GetType"/> is ELEMENT_TYPE_CLASS,
        /// ELEMENT_TYPE_VALUETYPE, ELEMENT_TYPE_ARRAY, ELEMENT_TYPE_SZARRAY, ELEMENT_TYPE_BYREF, ELEMENT_TYPE_PTR, or ELEMENT_TYPE_FNPTR.
        /// The number of parameters and their order depends on the type:
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateTypeParameters([MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTyParEnum);

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugType"/> that represents the first <see cref="Type"/> parameter of the type represented by this <see cref="ICorDebugType"/>.
        /// </summary>
        /// <param name="value">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the first parameter.</param>
        /// <remarks>
        /// GetFirstTypeParameter can be called in cases where the additional information about the type involves, at most,
        /// one type parameter. In particular, it can be used if the type is an ELEMENT_TYPE_ARRAY, ELEMENT_TYPE_SZARRAY, ELEMENT_TYPE_BYREF,
        /// or ELEMENT_TYPE_PTR, as indicated by the <see cref="GetType"/> method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFirstTypeParameter([MarshalAs(UnmanagedType.Interface)] out ICorDebugType value);

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugType"/> that represents the base type, if one exists, of the type represented by this <see cref="ICorDebugType"/>.
        /// </summary>
        /// <param name="pBase">[out] A pointer to the address of an <see cref="ICorDebugType"/> object that represents the base type.</param>
        /// <remarks>
        /// Looking up the base type for a type is useful to implement common debugger functionality, such as printing out
        /// all the fields of an object or its parent classes.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetBase([MarshalAs(UnmanagedType.Interface)] out ICorDebugType pBase);

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugValue"/> object that contains the value of the static field referenced by the specified field token in the specified stack frame.
        /// </summary>
        /// <param name="fieldDef">[in] An <see cref="mdFieldDef"/> token that specifies the static field.</param>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> that represents the stack frame.</param>
        /// <param name="ppValue">[out] A pointer to the address of an <see cref="ICorDebugValue"/> that contains the value of the static field.</param>
        /// <remarks>
        /// The GetStaticFieldValue method may be used only if the type is ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE, as
        /// indicated by the <see cref="GetType"/> method. For non-generic types, the operation performed by GetStaticFieldValue
        /// is identical to calling <see cref="ICorDebugClass.GetStaticFieldValue"/> on the <see cref="ICorDebugClass"/> object that is returned
        /// by <see cref="GetClass"/>. For generic types, a static field value will be relative to a particular instantiation.
        /// Also, if the static field could possibly be relative to a thread, a context, or an application domain, then the
        /// stack frame will help the debugger determine the proper value. GetStaticFieldValue can be used only when a call
        /// to <see cref="GetType"/> returns a value of ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStaticFieldValue([In] mdFieldDef fieldDef, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// Gets the number of dimensions in an array type.
        /// </summary>
        /// <param name="pnRank">[out] A pointer to the number of dimensions.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRank(out uint pnRank);
    }
}