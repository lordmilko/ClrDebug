using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides an enumerator that defines the mapping between a set of GUIDs and their corresponding types, which are represented by <see cref="ICorDebugType"/> instances.<para/>
    /// This interface inherits the methods from the <see cref="ICorDebugEnum"/> interface.
    /// </summary>
    /// <remarks>
    /// An <see cref="ICorDebugGuidToTypeEnum"/> interface object can be retrieved by calling the <see cref="ICorDebugAppDomain3.GetCachedWinRTTypes"/>
    /// method. A debugger can call this interface's <see cref="Next"/> method to retrieve <see cref="CorDebugGuidToTypeMapping"/>
    /// objects that represent mappings of managed representations of Windows Runtime types loaded in the application domain
    /// used for the call to the <see cref="ICorDebugAppDomain3.GetCachedWinRTTypes"/> method.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6164D242-1015-4BD6-8CBE-D0DBD4B8275A")]
    [ComImport]
    public interface ICorDebugGuidToTypeEnum : ICorDebugEnum
    {
        /// <summary>
        /// Moves the cursor forward in the enumeration by the specified number of items.
        /// </summary>
        /// <param name="celt">[in] The number of items by which to move the cursor forward.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Skip(
            [In] int celt);

        /// <summary>
        /// Moves the cursor to the beginning of the enumeration.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Reset();

        /// <summary>
        /// Creates a copy of this <see cref="ICorDebugEnum"/> object.
        /// </summary>
        /// <param name="ppEnum">[out] A pointer to the address of an <see cref="ICorDebugEnum"/> object that is a copy of this <see cref="ICorDebugEnum"/> object.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugEnum ppEnum);

        /// <summary>
        /// Gets the number of items in the enumeration.
        /// </summary>
        /// <param name="pcelt">[out] A pointer to the number of items in the enumeration.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCount(
            [Out] out int pcelt);

        /// <summary>
        /// Gets the specified number of <see cref="CorDebugGuidToTypeMapping"/> instances that map GUIDs to type information.
        /// </summary>
        /// <param name="celt">[in] The number of GUID-to-type mapping objects to be retrieved.</param>
        /// <param name="values">[out] An array of pointers, each of which points to a <see cref="CorDebugGuidToTypeMapping"/> object that maps a Windows Runtime GUID to its corresponding <see cref="ICorDebugType"/> object.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of <see cref="CorDebugGuidToTypeMapping"/> objects actually returned in values.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Next(
            [In] int celt,
            [Out] out CorDebugGuidToTypeMapping values,
            [Out] out int pceltFetched);
    }
}
