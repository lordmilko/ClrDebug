using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// A subclass of "ICorDebugValue" that represents a value that contains an object.
    /// </summary>
    /// <remarks>
    /// An <see cref="ICorDebugObjectValue"/> remains valid until the process being debugged is continued.
    /// </remarks>
    [Guid("18AD3D6E-B7D2-11D2-BD04-0000F80849BD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugObjectValue : ICorDebugValue
    {
        /// <summary>
        /// Gets the primitive type of this "ICorDebugValue" object.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the "CorElementType" enumeration that indicates the value's type.</param>
        /// <remarks>
        /// If the object is a complex run-time type, that type may be examined through the appropriate subclasses of the <see cref="ICorDebugValue"/>
        /// interface. For example, "ICorDebugObjectValue", which inherits from <see cref="ICorDebugValue"/>, represents a complex type.
        /// The GetType and <see cref="ICorDebugObjectValue.GetClass"/> methods each return information about the type of a
        /// value. They are both superseded by the generics-aware <see cref="ICorDebugValue2.GetExactType"/> method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetType(
            [Out] out CorElementType pType);

        /// <summary>
        /// Gets the size, in bytes, of this "ICorDebugValue" object.
        /// </summary>
        /// <param name="pSize">[out] The size, in bytes, of this value object.</param>
        /// <remarks>
        /// If the value's type is a reference type, this method returns the size of the pointer rather than the size of the
        /// object. The <see cref="ICorDebugValue.GetSize"/> method returns COR_E_OVERFLOW for objects that are larger than 4 GB on 64-bit
        /// platforms. Use the <see cref="ICorDebugValue3.GetSize64"/> method instead for objects that are larger than 4 GB.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetSize(
            [Out] out int pSize);

        /// <summary>
        /// Gets the address of this "ICorDebugValue" object, which is in the process of being debugged.
        /// </summary>
        /// <param name="pAddress">[out] Pointer to a <see cref="CORDB_ADDRESS"/> object that specifies the address of this value object.</param>
        /// <remarks>
        /// If the value is unavailable, 0 (zero) is returned. This could happen if the value is at least partly in registers
        /// or stored in a garbage collector handle (GCHandle).
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetAddress(
            [Out] out CORDB_ADDRESS pAddress);

        /// <summary>
        /// The CreateBreakpoint method is currently not implemented.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CreateBreakpoint(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);

        /// <summary>
        /// Gets the class of this object value.
        /// </summary>
        /// <param name="ppClass">[out] A pointer to the address of an "ICorDebugClass" object that represents the class of the object value represented by this "ICorDebugObjectValue" object.</param>
        /// <remarks>
        /// The GetClass and <see cref="ICorDebugValue.GetType(out CorElementType)"/> methods each return information about
        /// the type of a value; they are both superseded by the generics-aware <see cref="ICorDebugValue2.GetExactType"/>.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetClass(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);

        /// <summary>
        /// Gets the value of the specified field of the specified class for this object value.
        /// </summary>
        /// <param name="pClass">[in] A pointer to an "ICorDebugClass" object that represents the class for which to get the field value.</param>
        /// <param name="fieldDef">[in] An <see cref="mdFieldDef"/> token that references the metadata describing the field.</param>
        /// <param name="ppValue">[out] A pointer to an "ICorDebugValue" object that represents the value of the specified field.</param>
        /// <remarks>
        /// The class, specified in the pClass parameter, must be in the hierarchy of the object value's class, and the field
        /// must be a field of that class. The GetFieldValue method will still succeed for generic objects and generic classes.
        /// For example, if MyDictionary&lt;V&gt; inherits from Dictionary&lt;string,V&gt;, and the object value is of type
        /// MyDictionary&lt;int32&gt;, passing the <see cref="ICorDebugClass"/> object for Dictionary&lt;K,V&gt; will successfully get a
        /// field of Dictionary&lt;string,int32&gt;.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFieldValue(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugClass pClass,
            [In] mdFieldDef fieldDef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// GetVirtualMethod is not implemented in this version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVirtualMethod(
            [In] int memberRef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);

        /// <summary>
        /// GetContext is not implemented in this version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugContext ppContext);

        /// <summary>
        /// Gets a value that indicates whether this object value is a value type.
        /// </summary>
        /// <param name="pbIsValueClass">[out] A pointer to a Boolean value that is true if the object value, represented by this "ICorDebugObjectValue", is a value type rather than a reference type; otherwise, pbIsValueClass is false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsValueClass(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbIsValueClass);

        /// <summary>
        /// GetManagedCopy is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetManagedCopy(
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppObject);

        /// <summary>
        /// SetFromManagedCopy is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetFromManagedCopy(
            [MarshalAs(UnmanagedType.Interface), In] object pObject);
    }
}
