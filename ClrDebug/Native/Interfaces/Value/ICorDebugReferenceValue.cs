﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that manage a value that is a reference to an object. (That is, this interface provides methods that manage a pointer.) This interface implements "ICorDebugValue".
    /// </summary>
    /// <remarks>
    /// The common language runtime (CLR) may do a garbage collection on objects when the debugged process is continued.
    /// The garbage collection may move objects around in memory. An <see cref="ICorDebugReferenceValue"/> will either cooperate with
    /// the garbage collection so that its information is updated after the garbage collection, or it will be invalidated
    /// implicitly before the garbage collection. The <see cref="ICorDebugReferenceValue"/> object may be implicitly invalidated after
    /// the debugged process has been continued. The derived "ICorDebugHandleValue" is not invalidated until it is explicitly
    /// released or exposed.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCAF9-8A68-11D2-983C-0000F808342D")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugReferenceValue : ICorDebugValue
    {
#if !GENERATED_MARSHALLING
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
        new HRESULT GetAddress(
            [Out] out CORDB_ADDRESS pAddress);

        /// <summary>
        /// The CreateBreakpoint method is currently not implemented.
        /// </summary>
        [PreserveSig]
        new HRESULT CreateBreakpoint(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);
#endif

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugReferenceValue"/> is a null value, in which case the <see cref="ICorDebugReferenceValue"/> does not point to an object.
        /// </summary>
        /// <param name="pbNull">[out] A pointer to a Boolean value that is true if this <see cref="ICorDebugReferenceValue"/> object is null; otherwise, pbNull is false.</param>
        [PreserveSig]
        HRESULT IsNull(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbNull);

        /// <summary>
        /// Gets the current memory address of the referenced object.
        /// </summary>
        /// <param name="pValue">[out] A pointer to a <see cref="CORDB_ADDRESS"/> value that specifies the address of the object to which this <see cref="ICorDebugReferenceValue"/> object points.</param>
        [PreserveSig]
        HRESULT GetValue(
            [Out] out CORDB_ADDRESS pValue);

        /// <summary>
        /// Sets the specified memory address. That is, this method sets this <see cref="ICorDebugReferenceValue"/> to point to an object.
        /// </summary>
        /// <param name="value">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the address of the object to which this <see cref="ICorDebugReferenceValue"/> points.</param>
        [PreserveSig]
        HRESULT SetValue(
            [In] CORDB_ADDRESS value);

        /// <summary>
        /// Gets the object that is referenced.
        /// </summary>
        /// <param name="ppValue">[out] A pointer to the address of an <see cref="ICorDebugValue"/> that represents the object to which this <see cref="ICorDebugReferenceValue"/> object points.</param>
        /// <remarks>
        /// The <see cref="ICorDebugValue"/> object is valid only while its reference has not yet been disabled.
        /// </remarks>
        [PreserveSig]
        HRESULT Dereference(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// DereferenceStrong is not implemented. Do not call this method.
        /// </summary>
        [PreserveSig]
        HRESULT DereferenceStrong(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}
