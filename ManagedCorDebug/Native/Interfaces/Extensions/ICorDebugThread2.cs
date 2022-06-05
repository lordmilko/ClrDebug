using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Serves as a logical extension to the ICorDebugThread interface.
    /// </summary>
    [Guid("2BD956D9-7B07-4BEF-8A98-12AA862417C5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugThread2
    {
        /// <summary>
        /// Gets information about the active function in each of this thread's frames.
        /// </summary>
        /// <param name="cFunctions">[in] The size of the pFunctions array.</param>
        /// <param name="pcFunctions">[out] A pointer to the number of objects returned in the pFunctions array. The number of objects returned will be equal to the number of managed frames on the stack.</param>
        /// <param name="pFunctions">[in, out] An array of COR_ACTIVE_FUNCTION objects, each of which contains information about the active functions in this thread's frames.
        /// The first element will be used for the leaf frame, and so on back to the root of the stack.</param>
        /// <remarks>
        /// If pFunctions is null on input, GetActiveFunctions returns only the number of functions that are on the stack.
        /// That is, If pFunctions is null on input, GetActiveFunctions returns a value only in pcFunctions. The GetActiveFunctions
        /// method is intended as an optimization over getting the same information from frames in a stack trace, and includes
        /// only frames that would have had an ICorDebugILFrame object for them in the full stack trace.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetActiveFunctions([In] uint cFunctions, out uint pcFunctions,
            [MarshalAs(UnmanagedType.LPArray), In, Out] COR_ACTIVE_FUNCTION[] pFunctions);

        /// <summary>
        /// Gets the connection identifier for this ICorDebugThread2 object.
        /// </summary>
        /// <param name="pdwConnectionId">[out] A CONNID that represents the connection identifier.</param>
        /// <remarks>
        /// The GetConnectionID method returns zero in the pdwConnectionId parameter, if this thread is not part of a connection.
        /// If this thread is connected to an instance of Microsoft SQL Server 2005 Analysis Services (SSAS), the CONNID maps
        /// to a server process identifier (SPID).
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetConnectionID(out uint pdwConnectionId);

        /// <summary>
        /// Gets the identifier of the task running on this thread.
        /// </summary>
        /// <param name="pTaskId">[out] A pointer to the identifier of the task running on the thread represented by this ICorDebugThread2 object.</param>
        /// <remarks>
        /// A task can only be running on the thread if the thread is associated with a connection. GetTaskID returns zero
        /// in pTaskId if the thread is not associated with a connection.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetTaskID(out ulong pTaskId);

        /// <summary>
        /// Gets the operating system thread identifier for this ICorDebugThread2.
        /// </summary>
        /// <param name="pdwTid">[out] The operating system thread identifier for this thread.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVolatileOSThreadID(out uint pdwTid);

        /// <summary>
        /// Allows a debugger to intercept the current exception on this thread.
        /// </summary>
        /// <param name="pFrame">[in] A pointer to an ICorDebugFrame that represents the active stack frame.</param>
        /// <remarks>
        /// The InterceptCurrentException method can be called between an exception callback (<see cref="ICorDebugManagedCallback.Exception"/>
        /// or <see cref="ICorDebugManagedCallback2.Exception"/>) and the associated call to <see cref="ICorDebugController.Continue"/>.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT InterceptCurrentException([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFrame pFrame);
    }
}