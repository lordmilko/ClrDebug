using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Serves as a logical extension to the <see cref="ICorDebugThread"/> interface.
    /// </summary>
    [Guid("2BD956D9-7B07-4BEF-8A98-12AA862417C5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugThread2
    {
        /// <summary>
        /// Gets information about the active function in each of this thread's frames.
        /// </summary>
        /// <param name="cFunctions">[in] The size of the pFunctions array.</param>
        /// <param name="pcFunctions">[out] A pointer to the number of objects returned in the pFunctions array. The number of objects returned will be equal to the number of managed frames on the stack.</param>
        /// <param name="pFunctions">[in, out] An array of <see cref="COR_ACTIVE_FUNCTION"/> objects, each of which contains information about the active functions in this thread's frames.<para/>
        /// The first element will be used for the leaf frame, and so on back to the root of the stack.</param>
        /// <remarks>
        /// If pFunctions is null on input, GetActiveFunctions returns only the number of functions that are on the stack.
        /// That is, If pFunctions is null on input, GetActiveFunctions returns a value only in pcFunctions. The GetActiveFunctions
        /// method is intended as an optimization over getting the same information from frames in a stack trace, and includes
        /// only frames that would have had an <see cref="ICorDebugILFrame"/> object for them in the full stack trace.
        /// </remarks>
        [PreserveSig]
        HRESULT GetActiveFunctions(
            [In] int cFunctions,
            [Out] out int pcFunctions,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), In, SRI.Out] COR_ACTIVE_FUNCTION[] pFunctions);

        /// <summary>
        /// Gets the connection identifier for this <see cref="ICorDebugThread2"/> object.
        /// </summary>
        /// <param name="pdwConnectionId">[out] A CONNID that represents the connection identifier.</param>
        /// <remarks>
        /// The GetConnectionID method returns zero in the pdwConnectionId parameter, if this thread is not part of a connection.
        /// If this thread is connected to an instance of Microsoft SQL Server 2005 Analysis Services (SSAS), the CONNID maps
        /// to a server process identifier (SPID).
        /// </remarks>
        [PreserveSig]
        HRESULT GetConnectionID(
            [Out] out int pdwConnectionId);

        /// <summary>
        /// Gets the identifier of the task running on this thread.
        /// </summary>
        /// <param name="pTaskId">[out] A pointer to the identifier of the task running on the thread represented by this <see cref="ICorDebugThread2"/> object.</param>
        /// <remarks>
        /// A task can only be running on the thread if the thread is associated with a connection. GetTaskID returns zero
        /// in pTaskId if the thread is not associated with a connection.
        /// </remarks>
        [PreserveSig]
        HRESULT GetTaskID(
            [Out] out long pTaskId);

        /// <summary>
        /// Gets the operating system thread identifier for this <see cref="ICorDebugThread2"/>.
        /// </summary>
        /// <param name="pdwTid">[out] The operating system thread identifier for this thread.</param>
        [PreserveSig]
        HRESULT GetVolatileOSThreadID(
            [Out] out int pdwTid);

        /// <summary>
        /// Allows a debugger to intercept the current exception on this thread.
        /// </summary>
        /// <param name="pFrame">[in] A pointer to an <see cref="ICorDebugFrame"/> that represents the active stack frame.</param>
        /// <remarks>
        /// The InterceptCurrentException method can be called between an exception callback (<see cref="ICorDebugManagedCallback.Exception"/>
        /// or <see cref="ICorDebugManagedCallback2.Exception"/>) and the associated call to <see cref="ICorDebugController.Continue"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT InterceptCurrentException(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugFrame pFrame);
    }
}
