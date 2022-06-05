using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Logically extends the ICorDebugProcess interface to enable features such as decoding managed debug events that are encoded in native exception debug events and virtual module splitting.
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
        /// <param name="dwFlags">[in] A bit field that depends on the target architecture and that specifies additional information about the debug event. For Windows systems, it can be a member of the <see cref="CorDebugDecodeEventFlagsWindows"/> enumeration.</param>
        /// <param name="dwThreadId">[in] The operating system identifier of the thread on which the exception was thrown.</param>
        /// <param name="ppEvent">[out] A pointer to the address of an <see cref="ICorDebugDebugEvent"/> object that represents a decoded managed debug event.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DecodeEvent(
            [In] byte[] pRecord,
            [In] uint countBytes,
            [In] CorDebugRecordFormat format,
            [In] uint dwFlags,
            [In] uint dwThreadId,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugDebugEvent ppEvent);

        /// <summary>
        /// Notifies <see cref="ICorDebug"/> that the process is running.
        /// </summary>
        /// <param name="change">[in] A member of the <see cref="ICorDebugProcess6.ProcessStateChanged"/> enumeration</param>
        /// <remarks>
        /// The debugger calls this method to notify <see cref="ICorDebug"/> that the process is running.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ProcessStateChanged([In] CorDebugStateChange change);

        /// <summary>
        /// Gets information about the managed code at a particular code address.
        /// </summary>
        /// <param name="codeAddress">[in] A CORDB_ADDRESS value that specifies the starting address of the managed code segment.</param>
        /// <param name="ppCode">[out] A pointer to the address of an "ICorDebugCode" object that represents a segment of managed code.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetCode([In] ulong codeAddress, [MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnableVirtualModuleSplitting(int enableSplitting);

        /// <summary>
        /// Changes the internal state of the debugee so that the System.Diagnostics.Debugger.IsAttached method in the .NET Framework Class Library returns true.
        /// </summary>
        /// <param name="fIsAttached">true if the System.Diagnostics.Debugger.IsAttached method should indicate that a debugger is attached; false otherwise.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT MarkDebuggerAttached(int fIsAttached);

        /// <summary>
        /// Provides information on runtime exported functions to help step through managed code.
        /// </summary>
        /// <param name="pszExportName">[in] The name of a runtime export function as written in the PE export table.</param>
        /// <param name="pInvokeKind">[out] A pointer to a member of the <see cref="CorDebugCodeInvokeKind"/> enumeration that describes how the exported function will invoke managed code.</param>
        /// <param name="pInvokePurpose">[out] A pointer to a member of the <see cref="CorDebugInvokePurpose"/> enumeration that describes why the exported function will call managed code.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetExportStepInfo(
            [MarshalAs(UnmanagedType.LPWStr), In] string pszExportName,
            out CorDebugCodeInvokeKind pInvokeKind,
            out CorDebugCodeInvokePurpose pInvokePurpose);
    }
}