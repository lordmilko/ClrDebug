using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a type, either basic or complex (that is, user-defined). If the type is generic, ICorDebugType represents the instantiated generic type.
    /// </summary>
    /// <remarks>
    /// If the type is generic, ICorDebugClass represents the uninstantiated type. The ICorDebugType interface represents
    /// an instantiated generic type. For example, Hashtable&lt;K, V&gt; would be represented by ICorDebugClass, whereas
    /// Hashtable&lt;Int32, String&gt; would be represented by ICorDebugType. Non-generic types are represented by both
    /// ICorDebugClass and ICorDebugType. The latter interface was introduced in the .NET Framework version 2.0 to deal
    /// with type instantiation.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D613F0BB-ACE1-4C19-BD72-E4C08D5DA7F5")]
    [ComImport]
    public interface ICorDebugType
    {
        /// <summary>
        /// Gets a CorElementType value that describes the native type of the common language runtime (CLR) System.Type represented by this ICorDebugType.
        /// </summary>
        /// <param name="ty">[out] A pointer to a value of the CorElementType enumeration that indicates the CLR System.Type that this ICorDebugType represents.</param>
        /// <remarks>
        /// If the value of ty is either ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE, the <see cref="ICorDebugType.GetClass"/>
        /// method may be called to get the uninstantiated type for a generic type; otherwise, do not call ICorDebugType::GetClass.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetType(out CorElementType ty);

        /// <summary>
        /// Gets an interface pointer to an ICorDebugClass that represents the uninstantiated generic type.
        /// </summary>
        /// <param name="ppClass">[out] A pointer to the address of an ICorDebugClass interface that represents the uninstantiated generic type.</param>
        /// <remarks>
        /// GetClass can be called only under certain conditions. Call <see cref="ICorDebugType.GetType"/> before calling GetClass.
        /// If ICorDebugType::GetType returns a CorElementType value that is ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE,
        /// GetClass can be called to get the uninstantiated type for a generic type.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetClass([MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateTypeParameters([MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTyParEnum);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFirstTypeParameter([MarshalAs(UnmanagedType.Interface)] out ICorDebugType value);

        /// <summary>
        /// Gets an interface pointer to an ICorDebugType that represents the base type, if one exists, of the type represented by this ICorDebugType.
        /// </summary>
        /// <param name="pBase">[out] A pointer to the address of an ICorDebugType object that represents the base type.</param>
        /// <remarks>
        /// Looking up the base type for a type is useful to implement common debugger functionality, such as printing out
        /// all the fields of an object or its parent classes.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetBase([MarshalAs(UnmanagedType.Interface)] out ICorDebugType pBase);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStaticFieldValue([In] uint fieldDef, [MarshalAs(UnmanagedType.Interface), In]
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