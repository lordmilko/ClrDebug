using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// A subclass of <see cref="ICorDebugReferenceValue"/> that represents a reference value to which the debugger has created a handle for garbage collection.
    /// </summary>
    /// <remarks>
    /// An <see cref="ICorDebugReferenceValue"/> object is invalidated by a break in the execution of debugged code. An <see cref="ICorDebugHandleValue"/>
    /// maintains its reference through breaks and continuations, until it is explicitly released.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("029596E8-276B-46A1-9821-732E96BBB00B")]
    [ComImport]
    public interface ICorDebugHandleValue : ICorDebugReferenceValue
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
        new HRESULT GetType([Out] out CorElementType pType);

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
        new HRESULT GetSize([Out] out int pSize);

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
        new HRESULT GetAddress([Out] out CORDB_ADDRESS pAddress);

        /// <summary>
        /// The CreateBreakpoint method is currently not implemented.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CreateBreakpoint([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugReferenceValue"/> is a null value, in which case the <see cref="ICorDebugReferenceValue"/> does not point to an object.
        /// </summary>
        /// <param name="pbNull">[out] A pointer to a Boolean value that is true if this <see cref="ICorDebugReferenceValue"/> object is null; otherwise, pbNull is false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT IsNull([Out] out bool pbNull);

        /// <summary>
        /// Gets the current memory address of the referenced object.
        /// </summary>
        /// <param name="pValue">[out] A pointer to a <see cref="CORDB_ADDRESS"/> value that specifies the address of the object to which this <see cref="ICorDebugReferenceValue"/> object points.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetValue([Out] out CORDB_ADDRESS pValue);

        /// <summary>
        /// Sets the specified memory address. That is, this method sets this <see cref="ICorDebugReferenceValue"/> to point to an object.
        /// </summary>
        /// <param name="value">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the address of the object to which this <see cref="ICorDebugReferenceValue"/> points.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT SetValue([In] CORDB_ADDRESS value);

        /// <summary>
        /// Gets the object that is referenced.
        /// </summary>
        /// <param name="ppValue">[out] A pointer to the address of an <see cref="ICorDebugValue"/> that represents the object to which this <see cref="ICorDebugReferenceValue"/> object points.</param>
        /// <remarks>
        /// The <see cref="ICorDebugValue"/> object is valid only while its reference has not yet been disabled.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Dereference([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// DereferenceStrong is not implemented. Do not call this method.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT DereferenceStrong([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// Gets a value that indicates the kind of handle referenced by this <see cref="ICorDebugHandleValue"/> object.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the <see cref="CorDebugHandleType"/> enumeration that indicates the type of this handle.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetHandleType([Out] out CorDebugHandleType pType);

        /// <summary>
        /// Releases the handle referenced by this <see cref="ICorDebugHandleValue"/> object without explicitly releasing the interface pointer.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Dispose();
    }
}