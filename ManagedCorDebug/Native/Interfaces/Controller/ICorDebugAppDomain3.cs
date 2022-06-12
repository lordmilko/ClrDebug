using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to retrieve information about the managed representations of Windows Runtime types currently loaded in an application domain.<para/>
    /// This interface is an extension of the <see cref="ICorDebugAppDomain"/> and <see cref="ICorDebugAppDomain2"/> interfaces.
    /// </summary>
    /// <remarks>
    /// This interface is meant to be used by a debugger in conjunction with a function evaluation call to M:System.Runtime.InteropServices.Marshal.GetInspectableIIDs(System.Object).
    /// When the method retrieves the interface identifiers supported by a Windows Runtime server object, the debugger
    /// may use the methods defined in this interface to map them to managed types that correspond to those interfaces.
    /// To retrieve an instance of this interface, run QueryInterface on an instance of the <see cref="ICorDebugAppDomain"/> or <see cref="ICorDebugAppDomain2"/>
    /// interface.
    /// </remarks>
    [Guid("8CB96A16-B588-42E2-B71C-DD849FC2ECCC")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugAppDomain3
    {
        /// <summary>
        /// Gets an enumerator for cached Windows Runtime types in an application domain based on their interface identifiers.
        /// </summary>
        /// <param name="cReqTypes">[in] The number of required types.</param>
        /// <param name="iidsToResolve">[in] A pointer to an array that contains the interface identifiers corresponding to the managed representations of the Windows Runtime types to be retrieved.</param>
        /// <param name="ppTypesEnum">[out] A pointer to the address of an "ICorDebugTypeEnum" interface object that allows enumeration of the cached managed representations of the Windows Runtime types retrieved, based on the interface identifiers in iidsToResolve.</param>
        /// <remarks>
        /// If the method fails to retrieve information for a specific interface identifier, the corresponding entry in the
        /// "ICorDebugTypeEnum" collection will have a type of ELEMENT_TYPE_END for errors due to data retrieval issues, or
        /// ELEMENT_TYPE_VOID for unknown interface identifiers.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCachedWinRTTypesForIIDs(
            [In] int cReqTypes,
            [In] ref Guid iidsToResolve,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppTypesEnum);

        /// <summary>
        /// Gets an enumerator for all cached Windows Runtime types.
        /// </summary>
        /// <param name="ppGuidToTypeEnum">[out] A pointer to an <see cref="ICorDebugGuidToTypeEnum"/> interface object that can enumerate the managed representations of Windows Runtime types currently loaded in the application domain.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCachedWinRTTypes([MarshalAs(UnmanagedType.Interface)] out ICorDebugGuidToTypeEnum ppGuidToTypeEnum);
    }
}