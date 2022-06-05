using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a context object. This interface has not been implemented yet.
    /// </summary>
    [Guid("CC7BCB00-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugContext : ICorDebugObjectValue
    {
        /// <summary>
        /// Gets the primitive type of this "ICorDebugValue" object.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the "CorElementType" enumeration that indicates the value's type.</param>
        /// <remarks>
        /// If the object is a complex run-time type, that type may be examined through the appropriate subclasses of the ICorDebugValue
        /// interface. For example, "ICorDebugObjectValue", which inherits from ICorDebugValue, represents a complex type.
        /// The GetType and <see cref="ICorDebugObjectValue.GetClass"/> methods each return information about the type of a
        /// value. They are both superseded by the generics-aware <see cref="ICorDebugValue2.GetExactType"/> method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetType(out CorElementType pType);

        /// <summary>
        /// Gets the size, in bytes, of this "ICorDebugValue" object.
        /// </summary>
        /// <param name="pSize">[out] The size, in bytes, of this value object.</param>
        /// <remarks>
        /// If the value's type is a reference type, this method returns the size of the pointer rather than the size of the
        /// object. The ICorDebugValue::GetSize method returns COR_E_OVERFLOW for objects that are larger than 4 GB on 64-bit
        /// platforms. Use the <see cref="ICorDebugValue3.GetSize64"/> method instead for objects that are larger than 4 GB.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetSize(out uint pSize);

        /// <summary>
        /// Gets the address of this "ICorDebugValue" object, which is in the process of being debugged.
        /// </summary>
        /// <param name="pAddress">[out] Pointer to a CORDB_ADDRESS object that specifies the address of this value object.</param>
        /// <remarks>
        /// If the value is unavailable, 0 (zero) is returned. This could happen if the value is at least partly in registers
        /// or stored in a garbage collector handle (GCHandle).
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetAddress(out ulong pAddress);

        /// <summary>
        /// The CreateBreakpoint method is currently not implemented.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CreateBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetClass([MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);

        /// <summary>
        /// Gets the value of the specified field of the specified class for this object value.
        /// </summary>
        /// <param name="pClass">[in] A pointer to an "ICorDebugClass" object that represents the class for which to get the field value.</param>
        /// <param name="fieldDef">[in] An mdFieldDef token that references the metadata describing the field.</param>
        /// <param name="ppValue">[out] A pointer to an "ICorDebugValue" object that represents the value of the specified field.</param>
        /// <remarks>
        /// The class, specified in the pClass parameter, must be in the hierarchy of the object value's class, and the field
        /// must be a field of that class. The GetFieldValue method will still succeed for generic objects and generic classes.
        /// For example, if MyDictionary&lt;V&gt; inherits from Dictionary&lt;string,V&gt;, and the object value is of type
        /// MyDictionary&lt;int32&gt;, passing the ICorDebugClass object for Dictionary&lt;K,V&gt; will successfully get a
        /// field of Dictionary&lt;string,int32&gt;.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetFieldValue([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass, [In] uint fieldDef, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// GetVirtualMethod is not implemented in this version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetVirtualMethod([In] uint memberRef,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        /// <summary>
        /// GetContext is not implemented in this version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetContext([MarshalAs(UnmanagedType.Interface)] out ICorDebugContext ppContext);

        /// <summary>
        /// Gets a value that indicates whether this object value is a value type.
        /// </summary>
        /// <param name="pbIsValueClass">[out] A pointer to a Boolean value that is true if the object value, represented by this "ICorDebugObjectValue", is a value type rather than a reference type; otherwise, pbIsValueClass is false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT IsValueClass(out int pbIsValueClass);

        /// <summary>
        /// GetManagedCopy is obsolete. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetManagedCopy([MarshalAs(UnmanagedType.IUnknown)] out object ppObject);

        /// <summary>
        /// SetFromManagedCopy is obsolete. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT SetFromManagedCopy([MarshalAs(UnmanagedType.IUnknown), In]
            object pObject);
    }
}