using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Logically extends the <see cref="ICorDebugProcess"/> interface to enable features such as decoding managed debug events that are encoded in native exception debug events and virtual module splitting.
    /// </summary>
    [Guid("11588775-7205-4CEB-A41A-93753C3153E9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugProcess6
    {
        /// <summary>
        /// Decodes managed debug events that have been encapsulated in the payload of specially crafted native exception debug events.
        /// </summary>
        /// <param name="pRecord">[in] A pointer to a byte array from a native exception debug event that includes information about a managed debug event.</param>
        /// <param name="countBytes">[in] The number of elements in the pRecord byte array.</param>
        /// <param name="format">[in] A <see cref="CorDebugRecordFormat"/> enumeration member that specifies the format of the unmanaged debug event.</param>
        /// <param name="dwFlags">[in] A bit field that depends on the target architecture and that specifies additional information about the debug event.<para/>
        /// For Windows systems, it can be a member of the <see cref="CorDebugDecodeEventFlagsWindows"/> enumeration.</param>
        /// <param name="dwThreadId">[in] The operating system identifier of the thread on which the exception was thrown.</param>
        /// <param name="ppEvent">[out] A pointer to the address of an <see cref="ICorDebugDebugEvent"/> object that represents a decoded managed debug event.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DecodeEvent(
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pRecord,
            [In] int countBytes,
            [In] CorDebugRecordFormat format,
            [In] CorDebugDecodeEventFlagsWindows dwFlags,
            [In] int dwThreadId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugDebugEvent ppEvent);

        /// <summary>
        /// Notifies <see cref="ICorDebug"/> that the process is running.
        /// </summary>
        /// <param name="change">[in] A member of the <see cref="ProcessStateChanged"/> enumeration</param>
        /// <remarks>
        /// The debugger calls this method to notify <see cref="ICorDebug"/> that the process is running.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ProcessStateChanged(
            [In] CorDebugStateChange change);

        /// <summary>
        /// Gets information about the managed code at a particular code address.
        /// </summary>
        /// <param name="codeAddress">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the starting address of the managed code segment.</param>
        /// <param name="ppCode">[out] A pointer to the address of an "ICorDebugCode" object that represents a segment of managed code.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCode(
            [In] CORDB_ADDRESS codeAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        /// <summary>
        /// Enables or disables virtual module splitting.
        /// </summary>
        /// <param name="enableSplitting">true to enable virtual module splitting; false to disable it.</param>
        /// <remarks>
        /// Virtual module splitting causes <see cref="ICorDebug"/> to recognize modules that were merged together during the
        /// build process and present them as a group of separate modules rather than a single large module. Doing this changes
        /// the behavior of various <see cref="ICorDebug"/> methods described below. This method can be called and the value
        /// of enableSplitting can be changed at any time. It does not cause any stateful functional changes in an <see cref="ICorDebug"/>
        /// object, other than altering the behavior of the methods listed in the Virtual module splitting and the unmanaged
        /// debugging APIs section at the time they are called. Using virtual modules does incur a performance penalty when
        /// calling those methods. In addition, significant in-memory caching of the virtualized metadata may be required to
        /// correctly implement the <see cref="IMetaDataImport"/> APIs, and these caches may be retained even after virtual
        /// module splitting has been turned off.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnableVirtualModuleSplitting(
            [In] int enableSplitting);

        /// <summary>
        /// Changes the internal state of the debugee so that the <see cref="Debugger.IsAttached"/> method in the .NET Framework Class Library returns true.
        /// </summary>
        /// <param name="fIsAttached">true if the <see cref="Debugger.IsAttached"/> method should indicate that a debugger is attached; false otherwise.</param>
        /// <returns>
        /// The method can return the values listed in the following table.
        /// 
        /// | Return value                  | Description                                                                                                                                                                                                                                                                      |
        /// | ----------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                          | The debuggee was successfully updated.                                                                                                                                                                                                                                           |
        /// | CORDBG_E_MODULE_NOT_LOADED    | The assembly that contains the <see cref="Debugger.IsAttached"/> method is not loaded, or some other error, such as missing metadata, is preventing it from being recognized. This error is common and benign. You should call the method again when additional assemblies load. |
        /// | Other failing HRESULT values. | Other values likely indicate misbehaving debugger or compiler components.                                                                                                                                                                                                        |
        /// </returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT MarkDebuggerAttached(
            [In] bool fIsAttached);

        /// <summary>
        /// Provides information on runtime exported functions to help step through managed code.
        /// </summary>
        /// <param name="pszExportName">[in] The name of a runtime export function as written in the PE export table.</param>
        /// <param name="pInvokeKind">[out] A pointer to a member of the <see cref="CorDebugCodeInvokeKind"/> enumeration that describes how the exported function will invoke managed code.</param>
        /// <param name="pInvokePurpose">[out] A pointer to a member of the <see cref="CorDebugCodeInvokePurpose"/> enumeration that describes why the exported function will call managed code.</param>
        /// <returns>
        /// The method can return the values listed in the following table.
        /// 
        /// | Return value                  | Description                            |
        /// | ----------------------------- | -------------------------------------- |
        /// | S_OK                          | The method call was successful.        |
        /// | E_POINTER                     | pInvokeKind or pInvokePurpose is null. |
        /// | Other failing HRESULT values. | As appropriate.                        |
        /// </returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetExportStepInfo(
            [MarshalAs(UnmanagedType.LPWStr), In] string pszExportName,
            [Out] out CorDebugCodeInvokeKind pInvokeKind,
            [Out] out CorDebugCodeInvokePurpose pInvokePurpose);
    }
}
