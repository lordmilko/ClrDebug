using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface to a stack in the script. The script provider implements this interface to expose the notion of a call stack to the script debugger.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("051364DD-E449-443E-9762-FE578F4A5473")]
    [ComImport]
    public interface IDataModelScriptDebugStack
    {
        /// <summary>
        /// The GetFrameCount method returns the number of stack frames in this segment of the call stack. If the provider can detect frames in different script contexts or of different providers, it should indicate this to the caller by implementation of the IsTransitionPoint and GetTransition methods on the entry frame into this stack segment.
        /// </summary>
        /// <returns>This method returns ULONG64. The value is the number of stack frames in the current stack segment.</returns>
        [PreserveSig]
        long GetFrameCount();

        /// <summary>
        /// The GetStackFrame gets a particular stack frame from the stack segment. The call stack has a zero based indexing system: the current stack frame where the break event occurred is frame 0.<para/>
        /// The caller of the current method is frame 1 (and so forth).
        /// </summary>
        /// <param name="frameNumber">The zero based index of the stack frame within this stack segment to retrieve. The top frame representing the current point where the debugger broke is frame 0.<para/>
        /// It's caller is frame 1 (and so forth).</param>
        /// <param name="stackFrame">An interface to the given stack frame will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetStackFrame(
            [In] long frameNumber,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugStackFrame stackFrame);
    }
}
