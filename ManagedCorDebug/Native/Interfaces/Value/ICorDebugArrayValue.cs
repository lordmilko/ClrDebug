using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// A subclass of <see cref="ICorDebugHeapValue"/> that represents a single-dimensional or multi-dimensional array.
    /// </summary>
    /// <remarks>
    /// <see cref="ICorDebugArrayValue"/> supports both single-dimensional and multi-dimensional arrays.
    /// </remarks>
    [Guid("0405B0DF-A660-11D2-BD02-0000F80849BD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugArrayValue : ICorDebugHeapValue
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
        new HRESULT GetType(out CorElementType pType);

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
        new HRESULT GetSize(out uint pSize);

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
        new HRESULT GetAddress(out CORDB_ADDRESS pAddress);

        /// <summary>
        /// The CreateBreakpoint method is currently not implemented.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CreateBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);

        /// <summary>
        /// Gets a value that indicates whether the object represented by this <see cref="ICorDebugHeapValue"/> is valid. This method has been deprecated in the .NET Framework version 2.0.
        /// </summary>
        /// <param name="pbValid">[out] A pointer to a Boolean value that indicates whether this value on the heap is valid.</param>
        /// <remarks>
        /// The value is invalid if it has been reclaimed by the garbage collector. This method has been deprecated. In the
        /// .NET Framework 2.0, all values are valid until <see cref="ICorDebugController.Continue"/> is called, at which time
        /// the values are invalidated.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT IsValid(out int pbValid);

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CreateRelocBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);

        /// <summary>
        /// Gets a value that indicates the simple type of the elements in the array.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the <see cref="CorElementType"/> enumeration that indicates the type.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetElementType(out CorElementType pType);

        /// <summary>
        /// Gets the number of dimensions in the array.
        /// </summary>
        /// <param name="pnRank">[out] A pointer to the number of dimensions in this <see cref="ICorDebugArrayValue"/> object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRank(out uint pnRank);

        /// <summary>
        /// Gets the total number of elements in the array.
        /// </summary>
        /// <param name="pnCount">[out] A pointer to the total number of elements in the array.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCount(out uint pnCount);

        /// <summary>
        /// Gets the number of elements in each dimension of this array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the dims array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="dims">[out] An array of integers, each of which specifies the number of elements in a dimension in this <see cref="ICorDebugArrayValue"/> object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDimensions([In] uint cdim, [MarshalAs(UnmanagedType.LPArray), Out] uint[] dims);

        /// <summary>
        /// Gets a value that indicates whether any dimensions of this array have a base index of non-zero.
        /// </summary>
        /// <param name="pbHasBaseIndicies">[out] A pointer to a Boolean value that is true if one or more dimensions of this <see cref="ICorDebugArrayValue"/> object have a base index of non-zero; otherwise, the Boolean value is false.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT HasBaseIndicies(out int pbHasBaseIndicies);

        /// <summary>
        /// Gets the base index of each dimension in the array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the indicies array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="indicies">[out] An array of integers, each of which is the base index (that is, the starting index) of a dimension of this <see cref="ICorDebugArrayValue"/> object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetBaseIndicies([In] uint cdim, [MarshalAs(UnmanagedType.LPArray), Out] uint[] indicies);

        /// <summary>
        /// Gets the value of the given array element.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the indices array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="indices">[in] An array of index values, each of which specifies a position within a dimension of the <see cref="ICorDebugArrayValue"/> object.<para/>
        /// This value must not be null.</param>
        /// <param name="ppValue">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the specified element.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetElement(
            [In] uint cdim,
            [MarshalAs(UnmanagedType.LPArray), In] uint indices,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

        /// <summary>
        /// Gets the element at the given position, treating the array as a zero-based, single-dimensional array.
        /// </summary>
        /// <param name="nPosition">[in] The position of the element to be retrieved.</param>
        /// <param name="ppValue">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the element.</param>
        /// <remarks>
        /// The layout of a multi-dimension array follows the C++ style of array layout.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetElementAtPosition([In] uint nPosition, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}