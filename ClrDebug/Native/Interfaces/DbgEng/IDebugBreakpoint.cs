using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5bd9d474-5975-423a-b88b-65a8e7110e65")]
    [ComImport]
    public interface IDebugBreakpoint
    {
        /// <summary>
        /// The GetId method returns a breakpoint ID, which is the engine's unique identifier for a breakpoint.
        /// </summary>
        /// <param name="Id">[out] The breakpoint ID.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The breakpoint ID remains fixed as long as the breakpoint exists. However, after the breakpoint has been removed,
        /// you can use its ID for another breakpoint. The <see cref="GetParameters"/> method also returns the breakpoint ID.
        /// For more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        [PreserveSig]
        HRESULT GetId(
            [Out] out int Id);

        /// <summary>
        /// The GetType method returns the type of the breakpoint and the type of the processor that a breakpoint is set for.
        /// </summary>
        /// <param name="BreakType">[out] The type of the breakpoint. The type can be one of the following values.</param>
        /// <param name="ProcType">[out] The type of the processor that the breakpoint is set for.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// If changes are made to the breakpoint, the processor type might change. The <see cref="GetParameters"/> method
        /// also returns the information that is returned in BreakType and ProcType. For more information about breakpoint
        /// types, see Breakpoints.
        /// </remarks>
        [PreserveSig]
        HRESULT GetType(
            [Out] out DEBUG_BREAKPOINT_TYPE BreakType,
            [Out] out int ProcType);

        /// <summary>
        /// The GetAdder method returns the client that owns the breakpoint.
        /// </summary>
        /// <param name="Adder">[out] An <see cref="IDebugClient"/> interface pointer to the client object that added the breakpoint.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The client that owns the breakpoint is the client that created the breakpoint by using the <see cref="IDebugControl.AddBreakpoint"/>
        /// method. A breakpoint might not have an owner. If a breakpoint does not have an owner, Adder is set to NULL. For
        /// more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        [PreserveSig]
        HRESULT GetAdder(
            [Out, ComAliasName("IDebugClient")] out IntPtr Adder);

        /// <summary>
        /// The GetFlags method returns the flags for a breakpoint.
        /// </summary>
        /// <param name="Flags">[out] The breakpoint's flags. For more information about the flag bit field and an explanation of each flag, see Controlling Breakpoint Flags and Parameters.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The <see cref="GetParameters"/> method also returns the breakpoint's flags. For more information about breakpoint
        /// properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFlags(
            [Out] out DEBUG_BREAKPOINT_FLAG Flags);

        /// <summary>
        /// The AddFlags method adds flags to a breakpoint.
        /// </summary>
        /// <param name="Flags">[in] Additional flags to add to the breakpoint. Flags is a bit field that is combined together with the existing flags by using a bitwise OR.<para/>
        /// For more information about the flag bit field and an explanation of each flag, see Controlling Breakpoint Flags and Parameters.<para/>
        /// You cannot modify the DEBUG_BREAKPOINT_DEFERRED flag in the engine. This bit in Flags must always be zero.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT AddFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        /// <summary>
        /// The RemoveFlags method removes flags from a breakpoint.
        /// </summary>
        /// <param name="Flags">[in] Flags to remove from the breakpoint. Flags is a bit field. The new value of the flags in the engine is the old value and not the value of Flags.<para/>
        /// For more information about the flag bit field and an explanation of each flag, see Controlling Breakpoint Flags and Parameters.<para/>
        /// You cannot modify the DEBUG_BREAKPOINT_DEFERRED flag in the engine. This bit in Flags must always be zero.</param>
        /// <returns>RemoveFlags might return one of the following values: This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT RemoveFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        /// <summary>
        /// The SetFlags method sets the flags for a breakpoint.
        /// </summary>
        /// <param name="Flags">[in] The new flags for the breakpoint. Flags is a bit field. It replaces the existing flag bits. For more information about the flag bit field and an explanation of each flag, see Controlling Breakpoint Flags and Parameters.<para/>
        /// You cannot change the DEBUG_BREAKPOINT_DEFERRED flag in the engine. This bit in Flags must always be zero.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT SetFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);

        /// <summary>
        /// The GetOffset method returns the location that triggers a breakpoint.
        /// </summary>
        /// <param name="Offset">[out] The location on the target that triggers the breakpoint.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The <see cref="GetParameters"/> method also returns the location that triggers a breakpoint. For more information
        /// about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        [PreserveSig]
        HRESULT GetOffset(
            [Out] out long Offset);

        /// <summary>
        /// The SetOffset method sets the location that triggers a breakpoint.
        /// </summary>
        /// <param name="Offset">[in] The location on the target that triggers the breakpoint.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        [PreserveSig]
        HRESULT SetOffset(
            [In] long Offset);

        /// <summary>
        /// The GetDataParameters method returns the parameters for a processor breakpoint.
        /// </summary>
        /// <param name="Size">[out] The size, in bytes, of the memory block whose access triggers the breakpoint. For more information about restrictions on the value of Size based on the processor type, see Valid Parameters for Processor Breakpoints.</param>
        /// <param name="AccessType">[out] The type of access that triggers the breakpoint. For a list of possible values, see Valid Parameters for Processor Breakpoints.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The <see cref="GetParameters"/> method also returns the information that is returned in Size and AccessType. For
        /// more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT GetDataParameters(
            [Out] out int Size,
            [Out] out DEBUG_BREAKPOINT_ACCESS_TYPE AccessType);

        /// <summary>
        /// The SetDataParameters method sets the parameters for a processor breakpoint.
        /// </summary>
        /// <param name="Size">[in] The size, in bytes, of the memory block whose access triggers the breakpoint. For more information about restrictions on the value of Size based on the processor type, see Valid Parameters for Processor Breakpoints.</param>
        /// <param name="AccessType">[in] The type of access that triggers the breakpoint. For a list of possible value, see Valid Parameters for Processor Breakpoints.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT SetDataParameters(
            [In] int Size,
            [In] DEBUG_BREAKPOINT_ACCESS_TYPE AccessType);

        /// <summary>
        /// The GetPassCount method returns the number of times that the target was originally required to reach the breakpoint location before the breakpoint is triggered.
        /// </summary>
        /// <param name="Count">[out] The number of times that the target was originally required to hit the breakpoint before it is triggered.<para/>
        /// The number of times that the target was originally required to pass the breakpoint without triggering it is the value that is returned to Count, minus one.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The GetPassCount method returns the number of hits that were originally required to trigger the breakpoint. The
        /// <see cref="GetCurrentPassCount"/> method returns the number of hits that still must occur to trigger the breakpoint.
        /// For example, if a breakpoint was created with a pass count of 20, and there have been 5 passes so far, this method
        /// GetPassCount returns 20 and GetCurrentPassCount returns 15. After the target has hit the breakpoint enough times
        /// to trigger it, the breakpoint is triggered every time that it is hit, unless you call <see cref="SetPassCount"/>.
        /// You can also call SetPassCount to change the pass count before the breakpoint has been triggered. This call resets
        /// the original pass count and the remaining pass count. If the debugger executes the code at the breakpoint location
        /// while stepping through the code, this execution does not contribute to the number of times that remain before the
        /// breakpoint is triggered. The <see cref="GetParameters"/> method also returns the information that is returned in
        /// Count. For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT GetPassCount(
            [Out] out int Count);

        /// <summary>
        /// The SetPassCount method sets the number of times that the target must reach the breakpoint location before the breakpoint is triggered.
        /// </summary>
        /// <param name="Count">[in] The number of times that the target must hit the breakpoint before it is triggered. The number of times the target must pass the breakpoint without triggering it is the value of Count, minus one.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// Every time that the SetPassCount method is called, the number of times that the target must reach the breakpoint
        /// location before the breakpoint is triggered is reset. After the target has hit the breakpoint enough times to trigger
        /// the breakpoint, the breakpoint is triggered every time that it is hit, unless SetPassCount is called again. If
        /// the debugger executes the code at the breakpoint location while stepping through the code, this execution does
        /// not contribute to the number of times that remain before the breakpoint is triggered. For more information about
        /// breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT SetPassCount(
            [In] int Count);

        /// <summary>
        /// The GetCurrentPassCount method returns the remaining number of times that the target must reach the breakpoint location before the breakpoint is triggered.
        /// </summary>
        /// <param name="Count">[out] The remaining number of times that the target must hit the breakpoint before it is triggered. The number of times that the target must pass the breakpoint without triggering it is the value that is returned to Count, minus one.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The <see cref="GetPassCount"/> method returns the number of hits that were originally required to trigger the breakpoint.
        /// GetCurrentPassCount returns the number of hits that still must occur to trigger the breakpoint. For example, if
        /// a breakpoint was created with a pass count of 20, and there have been 5 passes so far, GetPassCount returns 20
        /// and GetCurrentPassCount returns 15. After the target has hit the breakpoint enough times to trigger it, the breakpoint
        /// is triggered every time that it is hit, unless <see cref="SetPassCount"/> is called again. You can also call SetPassCount
        /// to change the pass count before the breakpoint has been triggered. This call resets the original pass count and
        /// the remaining pass count. If the debugger executes the code at the breakpoint location while stepping through the
        /// code, this execution does not contribute to the number of times that remain before the breakpoint is triggered.
        /// The <see cref="GetParameters"/> method also returns the information that is returned in Count. For more information
        /// about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentPassCount(
            [Out] out int Count);

        /// <summary>
        /// The GetMatchThreadId method returns the engine thread ID of the thread that can trigger a breakpoint.
        /// </summary>
        /// <param name="Id">[out] The engine thread ID of the thread that can trigger this breakpoint.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// If you have set a thread for the breakpoint, the breakpoint can be triggered only if that thread hits the breakpoint.
        /// If you have not set a thread , any thread can trigger the breakpoint and Id receives NULL. The <see cref="GetParameters"/>
        /// method also returns the engine thread ID of the thread that can trigger the breakpoint. For more information about
        /// breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT GetMatchThreadId(
            [Out] out int Id);

        /// <summary>
        /// The SetMatchThreadId method sets the engine thread ID of the thread that can trigger a breakpoint.
        /// </summary>
        /// <param name="Thread">[in] The engine thread ID of the thread that can trigger this breakpoint.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// If you have set a thread for the breakpoint, the breakpoint can be triggered only if that thread hits the breakpoint.
        /// If you have not set a thread, any thread can trigger the breakpoint. If you have set a thread, you can remove the
        /// setting by setting Id to DEBUG_ANY_ID. For more information about breakpoint properties, see Controlling Breakpoint
        /// Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT SetMatchThreadId(
            [In] int Thread);

        /// <summary>
        /// The GetCommand method returns the command string that is executed when a breakpoint is triggered.
        /// </summary>
        /// <param name="Buffer">[out, optional] The command string that is executed when the breakpoint is triggered. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] The size, in characters, of the buffer that Buffer points to.</param>
        /// <param name="CommandSize">[out, optional] The size of the command string. If CommandSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The command string is a list of debugger commands that are separated by semicolons. These commands are executed
        /// every time that the breakpoint is triggered. The commands are executed before the engine informs any event callbacks
        /// that the breakpoint has been triggered. The <see cref="GetParameters"/> method also returns the size of the breakpoint's
        /// command, CommandSize. For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCommand(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int CommandSize);

        /// <summary>
        /// The SetCommand method sets the command that is executed when a breakpoint is triggered.
        /// </summary>
        /// <param name="Command">[in] The command string that is executed when the breakpoint is triggered.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The command string is a list of debugger commands that are separated by semicolons. These commands are executed
        /// every time that the breakpoint is triggered. The commands are executed before the engine informs any event callbacks
        /// that the breakpoint has been triggered. If the command string includes an execution command such as G (Go), this
        /// command should be the last command in the Command string. If a command causes the target to resume execution, the
        /// rest of the command string is ignored. For more information about breakpoint properties, see Controlling Breakpoint
        /// Flags and Parameters.
        /// </remarks>
        [PreserveSig]
        HRESULT SetCommand(
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);

        /// <summary>
        /// The GetOffsetExpression methods return the expression string that evaluates to the location that triggers a breakpoint.
        /// </summary>
        /// <param name="Buffer">[out, optional] The expression string that evaluates to the location on the target that triggers the breakpoint.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] The size, in characters, of the buffer that Buffer points to.</param>
        /// <param name="ExpressionSize">[out, optional] The size, in characters, of the expression string. If ExpressionSize is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The expression is evaluated every time that a module is loaded or unloaded. If the debugger cannot evaluate the
        /// expression (for example, if the expression contains a symbol that cannot be interpreted), the breakpoint is flagged
        /// as deferred. (For more information about deferred breakpoints, see Controlling Breakpoint Flags and Parameters.)
        /// The <see cref="GetParameters"/> method also returns the size of the expression string that specifies the location
        /// that triggers the breakpoint, ExpressionSize. For more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        [PreserveSig]
        HRESULT GetOffsetExpression(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int ExpressionSize);

        /// <summary>
        /// The SetOffsetExpression methods set an expression string that evaluates to the location that triggers a breakpoint.
        /// </summary>
        /// <param name="Expression">[in] The expression string that evaluates to the location on the target that triggers the breakpoint. If the engine icannot evaluate the expression (for example, if the expression contains a symbol that cannot be interpreted), the breakpoint is flagged as deferred.<para/>
        /// (For more information about deferred breakpoints, see Controlling Breakpoint Flags and Parameters.) For more information about the expression syntax, see Using Breakpoints.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        [PreserveSig]
        HRESULT SetOffsetExpression(
            [In, MarshalAs(UnmanagedType.LPStr)] string Expression);

        /// <summary>
        /// The GetParameters method returns the parameters for a breakpoint.
        /// </summary>
        /// <param name="Params">[out] The breakpoint's parameters. For more information about the parameters, see <see cref="DEBUG_BREAKPOINT_PARAMETERS"/>.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The GetParameters method is a convenience method that returns most of the parameters that the other <see cref="IDebugBreakpoint"/>
        /// methods return. For a list of the parameters and flags that this method retrieves, and for other ways to read and
        /// write these parameters and flags, see Controlling Breakpoint Flags and Parameters and Using Breakpoints.
        /// </remarks>
        [PreserveSig]
        HRESULT GetParameters(
            [Out] out DEBUG_BREAKPOINT_PARAMETERS Params);
    }
}
