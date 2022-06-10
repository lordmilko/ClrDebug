using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to retrieve information associated with a runtime callable wrapper (RCW).
    /// </summary>
    /// <remarks>
    /// To check whether an instance of an "ICorDebugValue" interface represents an RCW, a debugger calls QueryInterface
    /// on "ICorDebugValue" with IID_ICorDebugComObjectValue.
    /// </remarks>
    [Guid("5F69C5E5-3E12-42DF-B371-F9D761D6EE24")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugComObjectValue
    {
        /// <summary>
        /// Provides an enumerator for the interface types that the current object has been cast to or used as.
        /// </summary>
        /// <param name="bIInspectableOnly">[in] A value that indicates whether the method returns only Windows Runtime interfaces (IInspectable interfaces) or all COM interfaces cached by the runtime callable wrapper (RCW).</param>
        /// <param name="ppInterfacesEnum">[out] A pointer to the address of an ICorDebugTypeEnum enumerator that provides access to ICorDebugType objects that represent cached interface types filtered according to bIInspectableOnly.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCachedInterfaceTypes([In] int bIInspectableOnly,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppInterfacesEnum);

        /// <summary>
        /// Gets the raw interface pointers cached on the current runtime callable wrapper (RCW).
        /// </summary>
        /// <param name="bIInspectableOnly">[in] A value that indicates whether the method will return only Windows Runtime interfaces (IInspectable interfaces) or all COM interfaces that are cached by the runtime callable wrapper (RCW).</param>
        /// <param name="celt">[in] The number of objects whose addresses are to be retrieved.</param>
        /// <param name="pceltFetched">[out] A pointer to the number of CORDB_ADDRESS values actually returned in ptrs.</param>
        /// <param name="ptrs">A pointer to the starting address of an array of CORDB_ADDRESS values that contain the addresses of cached interface objects.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCachedInterfacePointers(
            [In] int bIInspectableOnly,
            [In] uint celt,
            out uint pceltFetched,
            out CORDB_ADDRESS[] ptrs);
    }
}