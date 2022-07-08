using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("f2df5f53-071f-47bd-9de6-5734c3fed689")]
    [ComImport]
    public interface IDebugAdvanced
    {
        /// <summary>
        /// The GetThreadContext method returns the current thread context.
        /// </summary>
        /// <param name="Context">[out] Receives the current thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer Context must be large enough to hold this structure.</param>
        /// <param name="ContextSize">[in] Specifies the size of the buffer Context.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the thread context, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT GetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);

        /// <summary>
        /// The SetThreadContext method sets the current thread context.
        /// </summary>
        /// <param name="Context">[in] Specifies the thread context. The type of the thread context is the CONTEXT structure for the target's effective processor.<para/>
        /// The buffer Context must be large enough to hold this structure.</param>
        /// <param name="ContextSize">[in] Specifies the size of the buffer Context.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about the thread context, see Scopes and Symbol Groups.
        /// </remarks>
        [PreserveSig]
        HRESULT SetThreadContext(
            [In] IntPtr Context,
            [In] uint ContextSize);
    }
}
