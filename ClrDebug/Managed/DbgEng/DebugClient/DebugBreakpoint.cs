﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;
using static ClrDebug.Extensions;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugBreakpoint : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugBreakpoint = new Guid("5bd9d474-5975-423a-b88b-65a8e7110e65");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugBreakpointVtbl* Vtbl => (IDebugBreakpointVtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugBreakpoint2Vtbl* Vtbl2 => (IDebugBreakpoint2Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugBreakpoint3Vtbl* Vtbl3 => (IDebugBreakpoint3Vtbl*) base.Vtbl;

        #endregion

        public DebugBreakpoint(IntPtr raw) : base(raw, IID_IDebugBreakpoint)
        {
        }

        public DebugBreakpoint(IDebugBreakpoint raw) : base(raw)
        {
        }

        #region IDebugBreakpoint
        #region Id

        /// <summary>
        /// The GetId method returns a breakpoint ID, which is the engine's unique identifier for a breakpoint.
        /// </summary>
        public int Id
        {
            get
            {
                int id;
                TryGetId(out id).ThrowDbgEngNotOK();

                return id;
            }
        }

        /// <summary>
        /// The GetId method returns a breakpoint ID, which is the engine's unique identifier for a breakpoint.
        /// </summary>
        /// <param name="id">[out] The breakpoint ID.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The breakpoint ID remains fixed as long as the breakpoint exists. However, after the breakpoint has been removed,
        /// you can use its ID for another breakpoint. The <see cref="Parameters"/> property also returns the breakpoint ID.
        /// For more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        public HRESULT TryGetId(out int id)
        {
            InitDelegate(ref getId, Vtbl->GetId);

            /*HRESULT GetId(
            [Out] out int Id);*/
            return getId(Raw, out id);
        }

        #endregion
        #region Type

        /// <summary>
        /// The GetType method returns the type of the breakpoint and the type of the processor that a breakpoint is set for.
        /// </summary>
        public GetTypeResult Type
        {
            get
            {
                GetTypeResult result;
                TryGetType(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetType method returns the type of the breakpoint and the type of the processor that a breakpoint is set for.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// If changes are made to the breakpoint, the processor type might change. The <see cref="Parameters"/> property
        /// also returns the information that is returned in BreakType and ProcType. For more information about breakpoint
        /// types, see Breakpoints.
        /// </remarks>
        public HRESULT TryGetType(out GetTypeResult result)
        {
            InitDelegate(ref getType, Vtbl->GetType);
            /*HRESULT GetType(
            [Out] out DEBUG_BREAKPOINT_TYPE BreakType,
            [Out] out int ProcType);*/
            DEBUG_BREAKPOINT_TYPE breakType;
            int procType;
            HRESULT hr = getType(Raw, out breakType, out procType);

            if (hr == HRESULT.S_OK)
                result = new GetTypeResult(breakType, procType);
            else
                result = default(GetTypeResult);

            return hr;
        }

        #endregion
        #region Adder

        /// <summary>
        /// The GetAdder method returns the client that owns the breakpoint.
        /// </summary>
        public DebugClient Adder
        {
            get
            {
                DebugClient adderResult;
                TryGetAdder(out adderResult).ThrowDbgEngNotOK();

                return adderResult;
            }
        }

        /// <summary>
        /// The GetAdder method returns the client that owns the breakpoint.
        /// </summary>
        /// <param name="adderResult">[out] An <see cref="IDebugClient"/> interface pointer to the client object that added the breakpoint.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The client that owns the breakpoint is the client that created the breakpoint by using the <see cref="DebugControl.AddBreakpoint"/>
        /// method. A breakpoint might not have an owner. If a breakpoint does not have an owner, Adder is set to NULL. For
        /// more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        public HRESULT TryGetAdder(out DebugClient adderResult)
        {
            InitDelegate(ref getAdder, Vtbl->GetAdder);
            /*HRESULT GetAdder(
            [Out, ComAliasName("IDebugClient")] out IntPtr Adder);*/
            IntPtr adder;
            HRESULT hr = getAdder(Raw, out adder);

            if (hr == HRESULT.S_OK)
                adderResult = adder == IntPtr.Zero ? null : new DebugClient(adder);
            else
                adderResult = default(DebugClient);

            return hr;
        }

        #endregion
        #region Flags

        /// <summary>
        /// The GetFlags method returns the flags for a breakpoint.
        /// </summary>
        public DEBUG_BREAKPOINT_FLAG Flags
        {
            get
            {
                DEBUG_BREAKPOINT_FLAG flags;
                TryGetFlags(out flags).ThrowDbgEngNotOK();

                return flags;
            }
            set
            {
                TrySetFlags(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetFlags method returns the flags for a breakpoint.
        /// </summary>
        /// <param name="flags">[out] The breakpoint's flags. For more information about the flag bit field and an explanation of each flag, see Controlling Breakpoint Flags and Parameters.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The <see cref="Parameters"/> property also returns the breakpoint's flags. For more information about breakpoint
        /// properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TryGetFlags(out DEBUG_BREAKPOINT_FLAG flags)
        {
            InitDelegate(ref getFlags, Vtbl->GetFlags);

            /*HRESULT GetFlags(
            [Out] out DEBUG_BREAKPOINT_FLAG Flags);*/
            return getFlags(Raw, out flags);
        }

        /// <summary>
        /// The SetFlags method sets the flags for a breakpoint.
        /// </summary>
        /// <param name="flags">[in] The new flags for the breakpoint. Flags is a bit field. It replaces the existing flag bits. For more information about the flag bit field and an explanation of each flag, see Controlling Breakpoint Flags and Parameters.<para/>
        /// You cannot change the DEBUG_BREAKPOINT_DEFERRED flag in the engine. This bit in Flags must always be zero.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TrySetFlags(DEBUG_BREAKPOINT_FLAG flags)
        {
            InitDelegate(ref setFlags, Vtbl->SetFlags);

            /*HRESULT SetFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);*/
            return setFlags(Raw, flags);
        }

        #endregion
        #region Offset

        /// <summary>
        /// The GetOffset method returns the location that triggers a breakpoint.
        /// </summary>
        public long Offset
        {
            get
            {
                long offset;
                TryGetOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
            set
            {
                TrySetOffset(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetOffset method returns the location that triggers a breakpoint.
        /// </summary>
        /// <param name="offset">[out] The location on the target that triggers the breakpoint.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The <see cref="Parameters"/> property also returns the location that triggers a breakpoint. For more information
        /// about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        public HRESULT TryGetOffset(out long offset)
        {
            InitDelegate(ref getOffset, Vtbl->GetOffset);

            /*HRESULT GetOffset(
            [Out] out long Offset);*/
            return getOffset(Raw, out offset);
        }

        /// <summary>
        /// The SetOffset method sets the location that triggers a breakpoint.
        /// </summary>
        /// <param name="offset">[in] The location on the target that triggers the breakpoint.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        public HRESULT TrySetOffset(long offset)
        {
            InitDelegate(ref setOffset, Vtbl->SetOffset);

            /*HRESULT SetOffset(
            [In] long Offset);*/
            return setOffset(Raw, offset);
        }

        #endregion
        #region DataParameters

        /// <summary>
        /// The GetDataParameters method returns the parameters for a processor breakpoint.
        /// </summary>
        public GetDataParametersResult DataParameters
        {
            get
            {
                GetDataParametersResult result;
                TryGetDataParameters(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetDataParameters method returns the parameters for a processor breakpoint.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The <see cref="Parameters"/> property also returns the information that is returned in Size and AccessType. For
        /// more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TryGetDataParameters(out GetDataParametersResult result)
        {
            InitDelegate(ref getDataParameters, Vtbl->GetDataParameters);
            /*HRESULT GetDataParameters(
            [Out] out int Size,
            [Out] out DEBUG_BREAK AccessType);*/
            int size;
            DEBUG_BREAK accessType;
            HRESULT hr = getDataParameters(Raw, out size, out accessType);

            if (hr == HRESULT.S_OK)
                result = new GetDataParametersResult(size, accessType);
            else
                result = default(GetDataParametersResult);

            return hr;
        }

        #endregion
        #region PassCount

        /// <summary>
        /// The GetPassCount method returns the number of times that the target was originally required to reach the breakpoint location before the breakpoint is triggered.
        /// </summary>
        public int PassCount
        {
            get
            {
                int count;
                TryGetPassCount(out count).ThrowDbgEngNotOK();

                return count;
            }
            set
            {
                TrySetPassCount(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetPassCount method returns the number of times that the target was originally required to reach the breakpoint location before the breakpoint is triggered.
        /// </summary>
        /// <param name="count">[out] The number of times that the target was originally required to hit the breakpoint before it is triggered.<para/>
        /// The number of times that the target was originally required to pass the breakpoint without triggering it is the value that is returned to Count, minus one.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The GetPassCount method returns the number of hits that were originally required to trigger the breakpoint. The
        /// <see cref="CurrentPassCount"/> property returns the number of hits that still must occur to trigger the breakpoint.
        /// For example, if a breakpoint was created with a pass count of 20, and there have been 5 passes so far, this method
        /// GetPassCount returns 20 and GetCurrentPassCount returns 15. After the target has hit the breakpoint enough times
        /// to trigger it, the breakpoint is triggered every time that it is hit, unless you call <see cref="PassCount"/>.
        /// You can also call SetPassCount to change the pass count before the breakpoint has been triggered. This call resets
        /// the original pass count and the remaining pass count. If the debugger executes the code at the breakpoint location
        /// while stepping through the code, this execution does not contribute to the number of times that remain before the
        /// breakpoint is triggered. The <see cref="Parameters"/> property also returns the information that is returned in
        /// Count. For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TryGetPassCount(out int count)
        {
            InitDelegate(ref getPassCount, Vtbl->GetPassCount);

            /*HRESULT GetPassCount(
            [Out] out int Count);*/
            return getPassCount(Raw, out count);
        }

        /// <summary>
        /// The SetPassCount method sets the number of times that the target must reach the breakpoint location before the breakpoint is triggered.
        /// </summary>
        /// <param name="count">[in] The number of times that the target must hit the breakpoint before it is triggered. The number of times the target must pass the breakpoint without triggering it is the value of Count, minus one.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// Every time that the SetPassCount method is called, the number of times that the target must reach the breakpoint
        /// location before the breakpoint is triggered is reset. After the target has hit the breakpoint enough times to trigger
        /// the breakpoint, the breakpoint is triggered every time that it is hit, unless SetPassCount is called again. If
        /// the debugger executes the code at the breakpoint location while stepping through the code, this execution does
        /// not contribute to the number of times that remain before the breakpoint is triggered. For more information about
        /// breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TrySetPassCount(int count)
        {
            InitDelegate(ref setPassCount, Vtbl->SetPassCount);

            /*HRESULT SetPassCount(
            [In] int Count);*/
            return setPassCount(Raw, count);
        }

        #endregion
        #region CurrentPassCount

        /// <summary>
        /// The GetCurrentPassCount method returns the remaining number of times that the target must reach the breakpoint location before the breakpoint is triggered.
        /// </summary>
        public int CurrentPassCount
        {
            get
            {
                int count;
                TryGetCurrentPassCount(out count).ThrowDbgEngNotOK();

                return count;
            }
        }

        /// <summary>
        /// The GetCurrentPassCount method returns the remaining number of times that the target must reach the breakpoint location before the breakpoint is triggered.
        /// </summary>
        /// <param name="count">[out] The remaining number of times that the target must hit the breakpoint before it is triggered. The number of times that the target must pass the breakpoint without triggering it is the value that is returned to Count, minus one.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The <see cref="PassCount"/> property returns the number of hits that were originally required to trigger the breakpoint.
        /// GetCurrentPassCount returns the number of hits that still must occur to trigger the breakpoint. For example, if
        /// a breakpoint was created with a pass count of 20, and there have been 5 passes so far, GetPassCount returns 20
        /// and GetCurrentPassCount returns 15. After the target has hit the breakpoint enough times to trigger it, the breakpoint
        /// is triggered every time that it is hit, unless <see cref="PassCount"/> is called again. You can also call SetPassCount
        /// to change the pass count before the breakpoint has been triggered. This call resets the original pass count and
        /// the remaining pass count. If the debugger executes the code at the breakpoint location while stepping through the
        /// code, this execution does not contribute to the number of times that remain before the breakpoint is triggered.
        /// The <see cref="Parameters"/> property also returns the information that is returned in Count. For more information
        /// about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TryGetCurrentPassCount(out int count)
        {
            InitDelegate(ref getCurrentPassCount, Vtbl->GetCurrentPassCount);

            /*HRESULT GetCurrentPassCount(
            [Out] out int Count);*/
            return getCurrentPassCount(Raw, out count);
        }

        #endregion
        #region MatchThreadId

        /// <summary>
        /// The GetMatchThreadId method returns the engine thread ID of the thread that can trigger a breakpoint.
        /// </summary>
        public int MatchThreadId
        {
            get
            {
                int id;
                TryGetMatchThreadId(out id).ThrowDbgEngNotOK();

                return id;
            }
            set
            {
                TrySetMatchThreadId(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetMatchThreadId method returns the engine thread ID of the thread that can trigger a breakpoint.
        /// </summary>
        /// <param name="id">[out] The engine thread ID of the thread that can trigger this breakpoint.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// If you have set a thread for the breakpoint, the breakpoint can be triggered only if that thread hits the breakpoint.
        /// If you have not set a thread, any thread can trigger the breakpoint and Id receives NULL. The <see cref="Parameters"/>
        /// property also returns the engine thread ID of the thread that can trigger the breakpoint. For more information about
        /// breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TryGetMatchThreadId(out int id)
        {
            InitDelegate(ref getMatchThreadId, Vtbl->GetMatchThreadId);

            /*HRESULT GetMatchThreadId(
            [Out] out int Id);*/
            return getMatchThreadId(Raw, out id);
        }

        /// <summary>
        /// The SetMatchThreadId method sets the engine thread ID of the thread that can trigger a breakpoint.
        /// </summary>
        /// <param name="thread">[in] The engine thread ID of the thread that can trigger this breakpoint.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// If you have set a thread for the breakpoint, the breakpoint can be triggered only if that thread hits the breakpoint.
        /// If you have not set a thread, any thread can trigger the breakpoint. If you have set a thread, you can remove the
        /// setting by setting Id to DEBUG_ANY_ID. For more information about breakpoint properties, see Controlling Breakpoint
        /// Flags and Parameters.
        /// </remarks>
        public HRESULT TrySetMatchThreadId(int thread)
        {
            InitDelegate(ref setMatchThreadId, Vtbl->SetMatchThreadId);

            /*HRESULT SetMatchThreadId(
            [In] int Thread);*/
            return setMatchThreadId(Raw, thread);
        }

        #endregion
        #region Command

        /// <summary>
        /// The GetCommand method returns the command string that is executed when a breakpoint is triggered.
        /// </summary>
        public string Command
        {
            get
            {
                string bufferResult;
                TryGetCommand(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetCommand(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetCommand method returns the command string that is executed when a breakpoint is triggered.
        /// </summary>
        /// <param name="bufferResult">[out, optional] The command string that is executed when the breakpoint is triggered. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The command string is a list of debugger commands that are separated by semicolons. These commands are executed
        /// every time that the breakpoint is triggered. The commands are executed before the engine informs any event callbacks
        /// that the breakpoint has been triggered. The <see cref="Parameters"/> property also returns the size of the breakpoint's
        /// command, CommandSize. For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TryGetCommand(out string bufferResult)
        {
            InitDelegate(ref getCommand, Vtbl->GetCommand);
            /*HRESULT GetCommand(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int CommandSize);*/
            char[] buffer;
            int bufferSize = 0;
            int commandSize;
            HRESULT hr = getCommand(Raw, null, bufferSize, out commandSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = commandSize;
            buffer = new char[bufferSize];
            hr = getCommand(Raw, buffer, bufferSize, out commandSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, commandSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetCommand method sets the command that is executed when a breakpoint is triggered.
        /// </summary>
        /// <param name="command">[in] The command string that is executed when the breakpoint is triggered.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The command string is a list of debugger commands that are separated by semicolons. These commands are executed
        /// every time that the breakpoint is triggered. The commands are executed before the engine informs any event callbacks
        /// that the breakpoint has been triggered. If the command string includes an execution command such as G (Go), this
        /// command should be the last command in the Command string. If a command causes the target to resume execution, the
        /// rest of the command string is ignored. For more information about breakpoint properties, see Controlling Breakpoint
        /// Flags and Parameters.
        /// </remarks>
        public HRESULT TrySetCommand(string command)
        {
            InitDelegate(ref setCommand, Vtbl->SetCommand);

            /*HRESULT SetCommand(
            [In, MarshalAs(UnmanagedType.LPStr)] string Command);*/
            return setCommand(Raw, command);
        }

        #endregion
        #region OffsetExpression

        /// <summary>
        /// The GetOffsetExpression methods return the expression string that evaluates to the location that triggers a breakpoint.
        /// </summary>
        public string OffsetExpression
        {
            get
            {
                string bufferResult;
                TryGetOffsetExpression(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetOffsetExpression(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetOffsetExpression methods return the expression string that evaluates to the location that triggers a breakpoint.
        /// </summary>
        /// <param name="bufferResult">[out, optional] The expression string that evaluates to the location on the target that triggers the breakpoint.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The expression is evaluated every time that a module is loaded or unloaded. If the debugger cannot evaluate the
        /// expression (for example, if the expression contains a symbol that cannot be interpreted), the breakpoint is flagged
        /// as deferred. (For more information about deferred breakpoints, see Controlling Breakpoint Flags and Parameters.)
        /// The <see cref="Parameters"/> property also returns the size of the expression string that specifies the location
        /// that triggers the breakpoint, ExpressionSize. For more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        public HRESULT TryGetOffsetExpression(out string bufferResult)
        {
            InitDelegate(ref getOffsetExpression, Vtbl->GetOffsetExpression);
            /*HRESULT GetOffsetExpression(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int ExpressionSize);*/
            char[] buffer;
            int bufferSize = 0;
            int expressionSize;
            HRESULT hr = getOffsetExpression(Raw, null, bufferSize, out expressionSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = expressionSize;
            buffer = new char[bufferSize];
            hr = getOffsetExpression(Raw, buffer, bufferSize, out expressionSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, expressionSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetOffsetExpression methods set an expression string that evaluates to the location that triggers a breakpoint.
        /// </summary>
        /// <param name="expression">[in] The expression string that evaluates to the location on the target that triggers the breakpoint. If the engine cannot evaluate the expression (for example, if the expression contains a symbol that cannot be interpreted), the breakpoint is flagged as deferred.<para/>
        /// (For more information about deferred breakpoints, see Controlling Breakpoint Flags and Parameters.) For more information about the expression syntax, see Using Breakpoints.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        public HRESULT TrySetOffsetExpression(string expression)
        {
            InitDelegate(ref setOffsetExpression, Vtbl->SetOffsetExpression);

            /*HRESULT SetOffsetExpression(
            [In, MarshalAs(UnmanagedType.LPStr)] string Expression);*/
            return setOffsetExpression(Raw, expression);
        }

        #endregion
        #region Parameters

        /// <summary>
        /// The GetParameters method returns the parameters for a breakpoint.
        /// </summary>
        public DEBUG_BREAKPOINT_PARAMETERS Parameters
        {
            get
            {
                DEBUG_BREAKPOINT_PARAMETERS @params;
                TryGetParameters(out @params).ThrowDbgEngNotOK();

                return @params;
            }
        }

        /// <summary>
        /// The GetParameters method returns the parameters for a breakpoint.
        /// </summary>
        /// <param name="params">[out] The breakpoint's parameters. For more information about the parameters, see <see cref="DEBUG_BREAKPOINT_PARAMETERS"/>.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The GetParameters method is a convenience method that returns most of the parameters that the other <see cref="IDebugBreakpoint"/>
        /// methods return. For a list of the parameters and flags that this method retrieves, and for other ways to read and
        /// write these parameters and flags, see Controlling Breakpoint Flags and Parameters and Using Breakpoints.
        /// </remarks>
        public HRESULT TryGetParameters(out DEBUG_BREAKPOINT_PARAMETERS @params)
        {
            InitDelegate(ref getParameters, Vtbl->GetParameters);

            /*HRESULT GetParameters(
            [Out] out DEBUG_BREAKPOINT_PARAMETERS Params);*/
            return getParameters(Raw, out @params);
        }

        #endregion
        #region AddFlags

        /// <summary>
        /// The AddFlags method adds flags to a breakpoint.
        /// </summary>
        /// <param name="flags">[in] Additional flags to add to the breakpoint. Flags is a bit field that is combined together with the existing flags by using a bitwise OR.<para/>
        /// For more information about the flag bit field and an explanation of each flag, see Controlling Breakpoint Flags and Parameters.<para/>
        /// You cannot modify the DEBUG_BREAKPOINT_DEFERRED flag in the engine. This bit in Flags must always be zero.</param>
        /// <remarks>
        /// For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public void AddFlags(DEBUG_BREAKPOINT_FLAG flags)
        {
            TryAddFlags(flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The AddFlags method adds flags to a breakpoint.
        /// </summary>
        /// <param name="flags">[in] Additional flags to add to the breakpoint. Flags is a bit field that is combined together with the existing flags by using a bitwise OR.<para/>
        /// For more information about the flag bit field and an explanation of each flag, see Controlling Breakpoint Flags and Parameters.<para/>
        /// You cannot modify the DEBUG_BREAKPOINT_DEFERRED flag in the engine. This bit in Flags must always be zero.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TryAddFlags(DEBUG_BREAKPOINT_FLAG flags)
        {
            InitDelegate(ref addFlags, Vtbl->AddFlags);

            /*HRESULT AddFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);*/
            return addFlags(Raw, flags);
        }

        #endregion
        #region RemoveFlags

        /// <summary>
        /// The RemoveFlags method removes flags from a breakpoint.
        /// </summary>
        /// <param name="flags">[in] Flags to remove from the breakpoint. Flags is a bit field. The new value of the flags in the engine is the old value and not the value of Flags.<para/>
        /// For more information about the flag bit field and an explanation of each flag, see Controlling Breakpoint Flags and Parameters.<para/>
        /// You cannot modify the DEBUG_BREAKPOINT_DEFERRED flag in the engine. This bit in Flags must always be zero.</param>
        /// <remarks>
        /// For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public void RemoveFlags(DEBUG_BREAKPOINT_FLAG flags)
        {
            TryRemoveFlags(flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RemoveFlags method removes flags from a breakpoint.
        /// </summary>
        /// <param name="flags">[in] Flags to remove from the breakpoint. Flags is a bit field. The new value of the flags in the engine is the old value and not the value of Flags.<para/>
        /// For more information about the flag bit field and an explanation of each flag, see Controlling Breakpoint Flags and Parameters.<para/>
        /// You cannot modify the DEBUG_BREAKPOINT_DEFERRED flag in the engine. This bit in Flags must always be zero.</param>
        /// <returns>RemoveFlags might return one of the following values: This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TryRemoveFlags(DEBUG_BREAKPOINT_FLAG flags)
        {
            InitDelegate(ref removeFlags, Vtbl->RemoveFlags);

            /*HRESULT RemoveFlags(
            [In] DEBUG_BREAKPOINT_FLAG Flags);*/
            return removeFlags(Raw, flags);
        }

        #endregion
        #region SetDataParameters

        /// <summary>
        /// The SetDataParameters method sets the parameters for a processor breakpoint.
        /// </summary>
        /// <param name="size">[in] The size, in bytes, of the memory block whose access triggers the breakpoint. For more information about restrictions on the value of Size based on the processor type, see Valid Parameters for Processor Breakpoints.</param>
        /// <param name="accessType">[in] The type of access that triggers the breakpoint. For a list of possible value, see Valid Parameters for Processor Breakpoints.</param>
        /// <remarks>
        /// For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public void SetDataParameters(int size, DEBUG_BREAK accessType)
        {
            TrySetDataParameters(size, accessType).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetDataParameters method sets the parameters for a processor breakpoint.
        /// </summary>
        /// <param name="size">[in] The size, in bytes, of the memory block whose access triggers the breakpoint. For more information about restrictions on the value of Size based on the processor type, see Valid Parameters for Processor Breakpoints.</param>
        /// <param name="accessType">[in] The type of access that triggers the breakpoint. For a list of possible value, see Valid Parameters for Processor Breakpoints.</param>
        /// <returns>This method can also return other error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TrySetDataParameters(int size, DEBUG_BREAK accessType)
        {
            InitDelegate(ref setDataParameters, Vtbl->SetDataParameters);

            /*HRESULT SetDataParameters(
            [In] int Size,
            [In] DEBUG_BREAK AccessType);*/
            return setDataParameters(Raw, size, accessType);
        }

        #endregion
        #endregion
        #region IDebugBreakpoint2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntPtr raw2;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IntPtr Raw2
        {
            get
            {
                InitInterface(typeof(IDebugBreakpoint2).GUID, ref raw2);

                return raw2;
            }
        }

        #region CommandWide

        /// <summary>
        /// The GetCommand method returns the command string that is executed when a breakpoint is triggered.
        /// </summary>
        public string CommandWide
        {
            get
            {
                string bufferResult;
                TryGetCommandWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetCommandWide(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetCommand method returns the command string that is executed when a breakpoint is triggered.
        /// </summary>
        /// <param name="bufferResult">[out, optional] The command string that is executed when the breakpoint is triggered. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The command string is a list of debugger commands that are separated by semicolons. These commands are executed
        /// every time that the breakpoint is triggered. The commands are executed before the engine informs any event callbacks
        /// that the breakpoint has been triggered. The <see cref="Parameters"/> property also returns the size of the breakpoint's
        /// command, CommandSize. For more information about breakpoint properties, see Controlling Breakpoint Flags and Parameters.
        /// </remarks>
        public HRESULT TryGetCommandWide(out string bufferResult)
        {
            InitDelegate(ref getCommandWide, Vtbl2->GetCommandWide);
            /*HRESULT GetCommandWide(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int CommandSize);*/
            char[] buffer;
            int bufferSize = 0;
            int commandSize;
            HRESULT hr = getCommandWide(Raw2, null, bufferSize, out commandSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = commandSize;
            buffer = new char[bufferSize];
            hr = getCommandWide(Raw2, buffer, bufferSize, out commandSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, commandSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetCommandWide method sets the command that is executed when a breakpoint is triggered.
        /// </summary>
        /// <param name="command">[in] The command string that is executed when the breakpoint is triggered.</param>
        /// <returns>SetCommandWide might return one of the following values:</returns>
        /// <remarks>
        /// The command string is a list of debugger commands that are separated by semicolons. These commands are executed
        /// every time that the breakpoint is triggered. The commands are executed before the engine informs any event callbacks
        /// that the breakpoint has been triggered. If the command string includes an execution command such as G (Go), this
        /// command should be the last command in the Command string. If a command causes the target to resume execution, the
        /// rest of the command string is ignored. For more information about breakpoint properties, see Controlling Breakpoint
        /// Flags and Parameters.
        /// </remarks>
        public HRESULT TrySetCommandWide(string command)
        {
            InitDelegate(ref setCommandWide, Vtbl2->SetCommandWide);

            /*HRESULT SetCommandWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);*/
            return setCommandWide(Raw2, command);
        }

        #endregion
        #region OffsetExpressionWide

        /// <summary>
        /// The GetOffsetExpressionWide method returns the expression string that evaluates to the location that triggers a breakpoint.
        /// </summary>
        public string OffsetExpressionWide
        {
            get
            {
                string bufferResult;
                TryGetOffsetExpressionWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetOffsetExpressionWide(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetOffsetExpressionWide method returns the expression string that evaluates to the location that triggers a breakpoint.
        /// </summary>
        /// <param name="bufferResult">[out, optional] The expression string that evaluates to the location on the target that triggers the breakpoint.<para/>
        /// If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method can also return error values. For more information, see Return Values.</returns>
        /// <remarks>
        /// The expression is evaluated every time that a module is loaded or unloaded. If the debugger cannot evaluate the
        /// expression (for example, if the expression contains a symbol that cannot be interpreted), the breakpoint is flagged
        /// as deferred. (For more information about deferred breakpoints, see Controlling Breakpoint Flags and Parameters.)
        /// The <see cref="Parameters"/> property also returns the size of the expression string that specifies the location
        /// that triggers the breakpoint, ExpressionSize. For more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        public HRESULT TryGetOffsetExpressionWide(out string bufferResult)
        {
            InitDelegate(ref getOffsetExpressionWide, Vtbl2->GetOffsetExpressionWide);
            /*HRESULT GetOffsetExpressionWide(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int ExpressionSize);*/
            char[] buffer;
            int bufferSize = 0;
            int expressionSize;
            HRESULT hr = getOffsetExpressionWide(Raw2, null, bufferSize, out expressionSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = expressionSize;
            buffer = new char[bufferSize];
            hr = getOffsetExpressionWide(Raw2, buffer, bufferSize, out expressionSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, expressionSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetOffsetExpressionWide methods set an expression string that evaluates to the location that triggers a breakpoint.
        /// </summary>
        /// <param name="command">[in] The expression string that evaluates to the location on the target that triggers the breakpoint. If the engine scannot evaluate the expression (for example, if the expression contains a symbol that cannot be interpreted), the breakpoint is flagged as deferred.<para/>
        /// (For more information about deferred breakpoints, see Controlling Breakpoint Flags and Parameters.) For more information about the expression syntax, see Using Breakpoints.</param>
        /// <remarks>
        /// For more information about how to use breakpoints, see Using Breakpoints.
        /// </remarks>
        public HRESULT TrySetOffsetExpressionWide(string command)
        {
            InitDelegate(ref setOffsetExpressionWide, Vtbl2->SetOffsetExpressionWide);

            /*HRESULT SetOffsetExpressionWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Command);*/
            return setOffsetExpressionWide(Raw2, command);
        }

        #endregion
        #endregion
        #region IDebugBreakpoint3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IntPtr raw3;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IntPtr Raw3
        {
            get
            {
                InitInterface(typeof(IDebugBreakpoint3).GUID, ref raw3);

                return raw3;
            }
        }

        #region Guid

        /// <summary>
        /// Returns a GUID for the breakpoint.
        /// </summary>
        public Guid Guid
        {
            get
            {
                Guid guid;
                TryGetGuid(out guid).ThrowDbgEngNotOK();

                return guid;
            }
        }

        /// <summary>
        /// Returns a GUID for the breakpoint.
        /// </summary>
        /// <param name="guid">[out] A unique ID returned for the breakpoint.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetGuid(out Guid guid)
        {
            InitDelegate(ref getGuid, Vtbl3->GetGuid);

            /*HRESULT GetGuid(
            [Out] out Guid Guid);*/
            return getGuid(Raw3, out guid);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugBreakpoint

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetIdDelegate getId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetTypeDelegate getType;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetAdderDelegate getAdder;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetFlagsDelegate getFlags;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetFlagsDelegate setFlags;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOffsetDelegate getOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetOffsetDelegate setOffset;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDataParametersDelegate getDataParameters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetPassCountDelegate getPassCount;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetPassCountDelegate setPassCount;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCurrentPassCountDelegate getCurrentPassCount;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetMatchThreadIdDelegate getMatchThreadId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetMatchThreadIdDelegate setMatchThreadId;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCommandDelegate getCommand;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetCommandDelegate setCommand;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOffsetExpressionDelegate getOffsetExpression;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetOffsetExpressionDelegate setOffsetExpression;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetParametersDelegate getParameters;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddFlagsDelegate addFlags;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveFlagsDelegate removeFlags;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetDataParametersDelegate setDataParameters;

        #endregion
        #region IDebugBreakpoint2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetCommandWideDelegate getCommandWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetCommandWideDelegate setCommandWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOffsetExpressionWideDelegate getOffsetExpressionWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetOffsetExpressionWideDelegate setOffsetExpressionWide;

        #endregion
        #region IDebugBreakpoint3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetGuidDelegate getGuid;

        #endregion
        #endregion
        #region Delegates
        #region IDebugBreakpoint

        private delegate HRESULT GetIdDelegate(IntPtr self, [Out] out int Id);
        private delegate HRESULT GetTypeDelegate(IntPtr self, [Out] out DEBUG_BREAKPOINT_TYPE BreakType, [Out] out int ProcType);
        private delegate HRESULT GetAdderDelegate(IntPtr self, [Out, ComAliasName("IDebugClient")] out IntPtr Adder);
        private delegate HRESULT GetFlagsDelegate(IntPtr self, [Out] out DEBUG_BREAKPOINT_FLAG Flags);
        private delegate HRESULT SetFlagsDelegate(IntPtr self, [In] DEBUG_BREAKPOINT_FLAG Flags);
        private delegate HRESULT GetOffsetDelegate(IntPtr self, [Out] out long Offset);
        private delegate HRESULT SetOffsetDelegate(IntPtr self, [In] long Offset);
        private delegate HRESULT GetDataParametersDelegate(IntPtr self, [Out] out int Size, [Out] out DEBUG_BREAK AccessType);
        private delegate HRESULT GetPassCountDelegate(IntPtr self, [Out] out int Count);
        private delegate HRESULT SetPassCountDelegate(IntPtr self, [In] int Count);
        private delegate HRESULT GetCurrentPassCountDelegate(IntPtr self, [Out] out int Count);
        private delegate HRESULT GetMatchThreadIdDelegate(IntPtr self, [Out] out int Id);
        private delegate HRESULT SetMatchThreadIdDelegate(IntPtr self, [In] int Thread);
        private delegate HRESULT GetCommandDelegate(IntPtr self, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int CommandSize);
        private delegate HRESULT SetCommandDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Command);
        private delegate HRESULT GetOffsetExpressionDelegate(IntPtr self, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int ExpressionSize);
        private delegate HRESULT SetOffsetExpressionDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Expression);
        private delegate HRESULT GetParametersDelegate(IntPtr self, [Out] out DEBUG_BREAKPOINT_PARAMETERS Params);
        private delegate HRESULT AddFlagsDelegate(IntPtr self, [In] DEBUG_BREAKPOINT_FLAG Flags);
        private delegate HRESULT RemoveFlagsDelegate(IntPtr self, [In] DEBUG_BREAKPOINT_FLAG Flags);
        private delegate HRESULT SetDataParametersDelegate(IntPtr self, [In] int Size, [In] DEBUG_BREAK AccessType);

        #endregion
        #region IDebugBreakpoint2

        private delegate HRESULT GetCommandWideDelegate(IntPtr self, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int CommandSize);
        private delegate HRESULT SetCommandWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Command);
        private delegate HRESULT GetOffsetExpressionWideDelegate(IntPtr self, [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int ExpressionSize);
        private delegate HRESULT SetOffsetExpressionWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Command);

        #endregion
        #region IDebugBreakpoint3

        private delegate HRESULT GetGuidDelegate(IntPtr self, [Out] out Guid Guid);

        #endregion
        #endregion

        protected override void ReleaseSubInterfaces()
        {
            ReleaseInterface(ref raw2);
            ReleaseInterface(ref raw3);
        }
    }
}
