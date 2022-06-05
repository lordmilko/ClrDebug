﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides an enumerator for call stack information that is embedded in an exception object. This interface is a subclass of the ICorDebugEnum interface.
    /// </summary>
    /// <remarks>
    /// The ICorDebugExceptionObjectCallStackEnum interface implements the ICorDebugEnum interface. An ICorDebugExceptionObjectCallStackEnum
    /// instance is populated with <see cref="CorDebugExceptionObjectStackFrame"/> objects by calling the <see cref="ICorDebugExceptionObjectValue.EnumerateExceptionCallStack"/>
    /// method. The call stack items in the collection can be enumerated by calling the <see cref="Next"/> method
    /// </remarks>
    [Guid("ED775530-4DC4-41F7-86D0-9E2DEF7DFC66")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugExceptionObjectCallStackEnum : ICorDebugEnum
    {
        /// <summary>
        /// Moves the cursor forward in the enumeration by the specified number of items.
        /// </summary>
        /// <param name="celt">[in] The number of items by which to move the cursor forward.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Skip([In] uint celt);

        /// <summary>
        /// Moves the cursor to the beginning of the enumeration.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Reset();

        /// <summary>
        /// Creates a copy of this ICorDebugEnum object.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the address of an ICorDebugEnum object that is a copy of this ICorDebugEnum object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Clone([MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);

        /// <summary>
        /// Gets the number of items in the enumeration.
        /// </summary>
        /// <param name="pcelt">[out] A pointer to the number of items in the enumeration.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCount(out uint pcelt);

        /// <summary>
        /// Gets the specified number of <see cref="CorDebugExceptionObjectStackFrame"/> instances that contain information from an exception object's call stack.
        /// </summary>
        /// <param name="celt">[in] The number of <see cref="CorDebugExceptionObjectStackFrame"/> instances to be retrieved.</param>
        /// <param name="values">[out] An array of pointers, each of which points to a <see cref="CorDebugExceptionObjectStackFrame"/> object.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of <see cref="CorDebugExceptionObjectStackFrame"/> instances actually returned.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next([In] uint celt, [MarshalAs(UnmanagedType.Interface), Out] out CorDebugExceptionObjectStackFrame values, out uint pceltFetched);
    }
}