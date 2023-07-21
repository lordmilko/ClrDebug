using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;
using static ClrDebug.Extensions;

namespace ClrDebug.DbgEng
{
    public unsafe partial class DebugClient : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugClient = new Guid("27fe5639-8407-4f47-8364-ee118fb08ac8");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugClientVtbl* Vtbl => (IDebugClientVtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugClient2Vtbl* Vtbl2 => (IDebugClient2Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugClient3Vtbl* Vtbl3 => (IDebugClient3Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugClient4Vtbl* Vtbl4 => (IDebugClient4Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugClient5Vtbl* Vtbl5 => (IDebugClient5Vtbl*) base.Vtbl;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IDebugClient6Vtbl* Vtbl6 => (IDebugClient6Vtbl*) base.Vtbl;

        #endregion

        public DebugClient(IntPtr raw) : base(raw, IID_IDebugClient)
        {
        }

        public DebugClient(IDebugClient raw) : base(raw)
        {
        }

        #region IDebugClient
        #region KernelConnectionOptions

        /// <summary>
        /// The GetKernelConnectionOptions method returns the connection options for the current kernel target.
        /// </summary>
        public string KernelConnectionOptions
        {
            get
            {
                string bufferResult;
                TryGetKernelConnectionOptions(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetKernelConnectionOptions(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetKernelConnectionOptions method returns the connection options for the current kernel target.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Specifies the buffer to receive the connection options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live kernel targets that are not local and not connected through eXDI. The connection
        /// options returned are the same options used to connect to the kernel. For more information about connecting to live
        /// kernel-mode targets, see Live Kernel-Mode Targets.
        /// </remarks>
        public HRESULT TryGetKernelConnectionOptions(out string bufferResult)
        {
            InitDelegate(ref getKernelConnectionOptions, Vtbl->GetKernelConnectionOptions);
            /*HRESULT GetKernelConnectionOptions(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int OptionsSize);*/
            char[] buffer;
            int bufferSize = 0;
            int optionsSize;
            HRESULT hr = getKernelConnectionOptions(Raw, null, bufferSize, out optionsSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = optionsSize;
            buffer = new char[bufferSize];
            hr = getKernelConnectionOptions(Raw, buffer, bufferSize, out optionsSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, optionsSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetKernelConnectionOptions method updates some of the connection options for a live kernel target.
        /// </summary>
        /// <param name="options">[in] Specifies the connection options to update. The possible values are:</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live kernel targets that are not local and not connected through eXDI. This method
        /// is reentrant. For more information about connecting to live kernel-mode targets, see Live Kernel-Mode Targets.
        /// </remarks>
        public HRESULT TrySetKernelConnectionOptions(string options)
        {
            InitDelegate(ref setKernelConnectionOptions, Vtbl->SetKernelConnectionOptions);

            /*HRESULT SetKernelConnectionOptions(
            [In, MarshalAs(UnmanagedType.LPStr)] string Options);*/
            return setKernelConnectionOptions(Raw, options);
        }

        #endregion
        #region ProcessOptions

        /// <summary>
        /// The GetProcessOptions method retrieves the process options affecting the current process.
        /// </summary>
        public DEBUG_PROCESS ProcessOptions
        {
            get
            {
                DEBUG_PROCESS options;
                TryGetProcessOptions(out options).ThrowDbgEngNotOK();

                return options;
            }
            set
            {
                TrySetProcessOptions(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetProcessOptions method retrieves the process options affecting the current process.
        /// </summary>
        /// <param name="options">[out] Receives a set of flags representing the process options for the current process. For details on these options, see DEBUG_PROCESS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in live user-mode debugging. Some of the process options are global options, others
        /// are specific to the current process. For more information about creating and attaching to live user-mode targets,
        /// see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryGetProcessOptions(out DEBUG_PROCESS options)
        {
            InitDelegate(ref getProcessOptions, Vtbl->GetProcessOptions);

            /*HRESULT GetProcessOptions(
            [Out] out DEBUG_PROCESS Options);*/
            return getProcessOptions(Raw, out options);
        }

        /// <summary>
        /// The SetProcessOptions method sets the process options affecting the current process.
        /// </summary>
        /// <param name="options">[in] Specifies a set of flags that will become the new process options for the current process. For details on these options, see DEBUG_PROCESS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only in live user-mode debugging. Some of the process options are global options, others
        /// are specific to the current process. If any process options are modified, the engine will notify the event callbacks
        /// by calling their <see cref="IDebugEventCallbacks.ChangeEngineState"/> method with the DEBUG_CES_PROCESS_OPTIONS
        /// flag set. For more information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TrySetProcessOptions(DEBUG_PROCESS options)
        {
            InitDelegate(ref setProcessOptions, Vtbl->SetProcessOptions);

            /*HRESULT SetProcessOptions(
            [In] DEBUG_PROCESS Options);*/
            return setProcessOptions(Raw, options);
        }

        #endregion
        #region ExitCode

        /// <summary>
        /// The GetExitCode method returns the exit code of the current process if that process has already run through to completion.
        /// </summary>
        public int ExitCode
        {
            get
            {
                int code;
                TryGetExitCode(out code).ThrowDbgEngNotOK();

                return code;
            }
        }

        /// <summary>
        /// The GetExitCode method returns the exit code of the current process if that process has already run through to completion.
        /// </summary>
        /// <param name="code">[out] Receives the exit code of the process. If the process is still running, Code will be set to STILL_ACTIVE.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging.
        /// </remarks>
        public HRESULT TryGetExitCode(out int code)
        {
            InitDelegate(ref getExitCode, Vtbl->GetExitCode);

            /*HRESULT GetExitCode(
            [Out] out int Code);*/
            return getExitCode(Raw, out code);
        }

        #endregion
        #region InputCallbacks

        /// <summary>
        /// The GetInputCallbacks method returns the input callbacks object registered with this client.
        /// </summary>
        public IDebugInputCallbacks InputCallbacks
        {
            get
            {
                IDebugInputCallbacks callbacks;
                TryGetInputCallbacks(out callbacks).ThrowDbgEngNotOK();

                return callbacks;
            }
            set
            {
                TrySetInputCallbacks(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetInputCallbacks method returns the input callbacks object registered with this client.
        /// </summary>
        /// <param name="callbacks">[out] Receives an interface pointer for the <see cref="IDebugInputCallbacks"/> object registered with the client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugInputCallbacks"/> object registered with it to receive requests
        /// for input. If no IDebugInputCallbacks object is registered with the client, the value of Callbacks will be set
        /// to NULL. The IDebugInputCallbacks interface extends the COM interface IUnknown. Before returning the IDebugInputCallbacks
        /// object specified by Callbacks, the engine calls its IUnknown::AddRef method. When this object is no longer needed,
        /// its IUnknown::Release method should be called. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TryGetInputCallbacks(out IDebugInputCallbacks callbacks)
        {
            InitDelegate(ref getInputCallbacks, Vtbl->GetInputCallbacks);

            /*HRESULT GetInputCallbacks(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugInputCallbacks Callbacks);*/
            return getInputCallbacks(Raw, out callbacks);
        }

        /// <summary>
        /// The SetInputCallbacks method registers an input callbacks object with the client.
        /// </summary>
        /// <param name="callbacks">[in, optional] Specifies the interface pointer to the input callbacks object to register with this client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugInputCallbacks"/> object registered with it to receive requests
        /// for input. The IDebugInputCallbacks interface extends the COM interface IUnknown. SetInputCallbacks will call the
        /// IUnknown::AddRef method of the object specified by Callbacks. The IUnknown::Release method of this interface will
        /// be called the next time SetInputCallbacks is called on this client, or when this client is deleted.
        /// </remarks>
        public HRESULT TrySetInputCallbacks(IDebugInputCallbacks callbacks)
        {
            InitDelegate(ref setInputCallbacks, Vtbl->SetInputCallbacks);

            /*HRESULT SetInputCallbacks(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugInputCallbacks Callbacks);*/
            return setInputCallbacks(Raw, callbacks);
        }

        #endregion
        #region OutputCallbacks

        /// <summary>
        /// The GetOutputCallbacks method returns the output callbacks object registered with the client.
        /// </summary>
        public IDebugOutputCallbacks OutputCallbacks
        {
            get
            {
                IDebugOutputCallbacks callbacks;
                TryGetOutputCallbacks(out callbacks).ThrowDbgEngNotOK();

                return callbacks;
            }
            set
            {
                TrySetOutputCallbacks(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetOutputCallbacks method returns the output callbacks object registered with the client.
        /// </summary>
        /// <param name="callbacks">[out] Receives an interface pointer to the <see cref="IDebugOutputCallbacks"/> object registered with the client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugOutputCallbacks"/> or IDebugOutputCallbacksWide object registered
        /// with it for output. If no output callbacks object is registered with the client, the value of Callbacks will be
        /// set to NULL. The IDebugOutputCallbacks interface extends the COM interface IUnknown. Before returning the IDebugOutputCallbacks
        /// object specified by Callbacks, the engine calls its IUnknown::AddRef method. When this object is no longer needed,
        /// its IUnknown::Release method should be called. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TryGetOutputCallbacks(out IDebugOutputCallbacks callbacks)
        {
            InitDelegate(ref getOutputCallbacks, Vtbl->GetOutputCallbacks);

            /*HRESULT GetOutputCallbacks(
            [Out] out IDebugOutputCallbacks Callbacks);*/
            return getOutputCallbacks(Raw, out callbacks);
        }

        /// <summary>
        /// The SetOutputCallbacks method registers an output callbacks object with this client.
        /// </summary>
        /// <param name="callbacks">[in, optional] Specifies the interface pointer to the output callbacks object to register with this client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugOutputCallbacks"/> or IDebugOutputCallbacks object registered
        /// with it for output. The IDebugOutputCallbacks interface extends the COM interface IUnknown. SetOutputCallbacks
        /// and SetOutputCAllbacksWide call the IUnknown::AddRef method in the object specified by Callbacks. The IUnknown::Release
        /// method of this interface will be called the next time SetOutputCallbacks or SetOutputCallbacksWide is called on
        /// this client, or when this client is deleted. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TrySetOutputCallbacks(IDebugOutputCallbacks callbacks)
        {
            InitDelegate(ref setOutputCallbacks, Vtbl->SetOutputCallbacks);

            /*HRESULT SetOutputCallbacks(
            [In] IDebugOutputCallbacks Callbacks);*/
            return setOutputCallbacks(Raw, callbacks);
        }

        #endregion
        #region OutputMask

        /// <summary>
        /// The GetOutputMask method returns the output mask currently set for the client.
        /// </summary>
        public DEBUG_OUTPUT OutputMask
        {
            get
            {
                DEBUG_OUTPUT mask;
                TryGetOutputMask(out mask).ThrowDbgEngNotOK();

                return mask;
            }
            set
            {
                TrySetOutputMask(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetOutputMask method returns the output mask currently set for the client.
        /// </summary>
        /// <param name="mask">[out] Receives the output mask for the client. See DEBUG_OUTPUT_XXX for details on how to interpret this value.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of output in the debugger engine, see Input and Output.
        /// </remarks>
        public HRESULT TryGetOutputMask(out DEBUG_OUTPUT mask)
        {
            InitDelegate(ref getOutputMask, Vtbl->GetOutputMask);

            /*HRESULT GetOutputMask(
            [Out] out DEBUG_OUTPUT Mask);*/
            return getOutputMask(Raw, out mask);
        }

        /// <summary>
        /// The SetOutputMask method sets the output mask for the client.
        /// </summary>
        /// <param name="mask">[in] Specifies the new output mask for the client. See DEBUG_OUTPUT_XXX for a description of the possible values for Mask.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of output in the debugger engine, see Input and Output.
        /// </remarks>
        public HRESULT TrySetOutputMask(DEBUG_OUTPUT mask)
        {
            InitDelegate(ref setOutputMask, Vtbl->SetOutputMask);

            /*HRESULT SetOutputMask(
            [In] DEBUG_OUTPUT Mask);*/
            return setOutputMask(Raw, mask);
        }

        #endregion
        #region OutputWidth

        /// <summary>
        /// Gets or sets the width of an output line forcommands that produce formatted output.
        /// </summary>
        public int OutputWidth
        {
            get
            {
                int columns;
                TryGetOutputWidth(out columns).ThrowDbgEngNotOK();

                return columns;
            }
            set
            {
                TrySetOutputWidth(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// Gets the width of an output line forcommands that produce formatted output.
        /// </summary>
        /// <param name="columns">[out] The number of columns in the output.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This setting is a suggestion that can be overridden by other settings.
        /// </remarks>
        public HRESULT TryGetOutputWidth(out int columns)
        {
            InitDelegate(ref getOutputWidth, Vtbl->GetOutputWidth);

            /*HRESULT GetOutputWidth(
            [Out] out int Columns);*/
            return getOutputWidth(Raw, out columns);
        }

        /// <param name="columns">[in] The number of columns in the output.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This setting is a suggestion that can be overridden by other settings.
        /// </remarks>
        public HRESULT TrySetOutputWidth(int columns)
        {
            InitDelegate(ref setOutputWidth, Vtbl->SetOutputWidth);

            /*HRESULT SetOutputWidth(
            [In] int Columns);*/
            return setOutputWidth(Raw, columns);
        }

        #endregion
        #region OutputLinePrefix

        public string OutputLinePrefix
        {
            get
            {
                string bufferResult;
                TryGetOutputLinePrefix(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetOutputLinePrefix(value).ThrowDbgEngNotOK();
            }
        }

        /// <param name="bufferResult">[out] A pointer to the buffer to get the prefix.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Some of the engine commands producemultiple lines of output. A prefix can be added to each line. The prefix value
        /// is not a general setting for any outputthat contains a newline. Methods which usethe line prefix are marked in
        /// their documentation.
        /// </remarks>
        public HRESULT TryGetOutputLinePrefix(out string bufferResult)
        {
            InitDelegate(ref getOutputLinePrefix, Vtbl->GetOutputLinePrefix);
            /*HRESULT GetOutputLinePrefix(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PrefixSize);*/
            char[] buffer;
            int bufferSize = 0;
            int prefixSize;
            HRESULT hr = getOutputLinePrefix(Raw, null, bufferSize, out prefixSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = prefixSize;
            buffer = new char[bufferSize];
            hr = getOutputLinePrefix(Raw, buffer, bufferSize, out prefixSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, prefixSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <param name="prefix">[in, optional] A pointer to the prefix value.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Some of the engine commands producemultiple lines of output. This function sets a prefix that the engine adds to
        /// each line. This function allows the caller to control indentation or identifying marks. The prefix value is not
        /// a general setting for any outputthat contains a newline. Methods which usethe line prefix are marked in their documentation.
        /// </remarks>
        public HRESULT TrySetOutputLinePrefix(string prefix)
        {
            InitDelegate(ref setOutputLinePrefix, Vtbl->SetOutputLinePrefix);

            /*HRESULT SetOutputLinePrefix(
            [In, MarshalAs(UnmanagedType.LPStr)] string Prefix);*/
            return setOutputLinePrefix(Raw, prefix);
        }

        #endregion
        #region Identity

        /// <summary>
        /// The GetIdentity method returns a string describing the computer and user this client represents.
        /// </summary>
        public string Identity
        {
            get
            {
                string bufferResult;
                TryGetIdentity(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
        }

        /// <summary>
        /// The GetIdentity method returns a string describing the computer and user this client represents.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Specifies the buffer to receive the string. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The specific content of the string varies with the operating system. If the client is remotely connected, some
        /// network information may also be present. For more information about client objects, see Client Objects.
        /// </remarks>
        public HRESULT TryGetIdentity(out string bufferResult)
        {
            InitDelegate(ref getIdentity, Vtbl->GetIdentity);
            /*HRESULT GetIdentity(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int IdentitySize);*/
            char[] buffer;
            int bufferSize = 0;
            int identitySize;
            HRESULT hr = getIdentity(Raw, null, bufferSize, out identitySize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = identitySize;
            buffer = new char[bufferSize];
            hr = getIdentity(Raw, buffer, bufferSize, out identitySize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, identitySize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region EventCallbacks

        /// <summary>
        /// The GetEventCallbacks method returns the event callbacks object registered with this client.
        /// </summary>
        public IDebugEventCallbacks EventCallbacks
        {
            get
            {
                IDebugEventCallbacks callbacks;
                TryGetEventCallbacks(out callbacks).ThrowDbgEngNotOK();

                return callbacks;
            }
            set
            {
                TrySetEventCallbacks(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetEventCallbacks method returns the event callbacks object registered with this client.
        /// </summary>
        /// <param name="callbacks">[out] Receives an interface pointer to the event callbacks object registered with this client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugEventCallbacks"/> or IDebugEventCallbacksWide object registered
        /// with it for receiving events. If no event callbacks object is registered with the client, the value of Callbacks
        /// will be set to NULL. The IDebugEventCallbacks interface extends the COM interface IUnknown. Before returning the
        /// IDebugEventCallbacks object specified by Callbacks, the engine calls its IUnknown::AddRef method. When this object
        /// is no longer needed, its IUnknown::Release method should be called. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TryGetEventCallbacks(out IDebugEventCallbacks callbacks)
        {
            InitDelegate(ref getEventCallbacks, Vtbl->GetEventCallbacks);

            /*HRESULT GetEventCallbacks(
            [Out] out IDebugEventCallbacks Callbacks);*/
            return getEventCallbacks(Raw, out callbacks);
        }

        /// <summary>
        /// The SetEventCallbacks method registers an event callbacks object with this client.
        /// </summary>
        /// <param name="callbacks">[in, optional] Specifies the interface pointer to the event callbacks object to register with this client.</param>
        /// <returns>Depending on the implementation of the method <see cref="IDebugEventCallbacks.GetInterestMask"/> in the object specified by Callbacks, other values may be returned, as described in the Remarks section.</returns>
        /// <remarks>
        /// If the value of Callbacks is not NULL, the method IDebugEventCallbacks::GetInterestMask is called. If the return
        /// value is not S_OK, SetEventCallbacks and SetEventCallbacksWide have no effect and they return this value. Each
        /// client can have at most one <see cref="IDebugEventCallbacks"/> or IDebugEventCallbacksWide object registered with
        /// it for receiving events. The IDebugEventCallbacks interface extends the COM interface IUnknown. When SetEventCallbacks
        /// and SetEventCallbacksWide are successful, they call the IUnknown::AddRef method of the object specified by Callbacks.
        /// The IUnknown::Release method of this object will be called the next time SetEventCallbacks or SetEventCallbacksWide
        /// is called on this client, or when this client is deleted. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TrySetEventCallbacks(IDebugEventCallbacks callbacks)
        {
            InitDelegate(ref setEventCallbacks, Vtbl->SetEventCallbacks);

            /*HRESULT SetEventCallbacks(
            [In] IDebugEventCallbacks Callbacks);*/
            return setEventCallbacks(Raw, callbacks);
        }

        #endregion
        #region AttachKernel

        /// <summary>
        /// The AttachKernel methods connect the debugger engine to a kernel target.
        /// </summary>
        /// <param name="flags">[in] Specifies the flags that control how the debugger attaches to the kernel target. The possible values are:</param>
        /// <param name="connectOptions">[in, optional] Specifies the connection settings for communicating with the computer running the kernel target.<para/>
        /// The interpretation of ConnectOptions depends on the value of Flags. ConnectOptions will be interpreted the same way as the options that follow the -k switch on the WinDbg and KD command lines.<para/>
        /// Environment variables affect ConnectOptions in the same way they affect the -k switch. eXDI drivers are not described in this documentation.<para/>
        /// If you have an eXDI interface to your hardware probe or hardware simulator, please contact Microsoft for debugging information.<para/>
        /// eXDI drivers are not described in this documentation. If you have an eXDI interface to your hardware probe or hardware simulator, please contact Microsoft for debugging information.<para/>
        /// ConnectOptions will be interpreted the same way as the options that follow the -k switch on the WinDbg and KD command lines.<para/>
        /// Environment variables affect ConnectOptions in the same way they affect the -k switch.</param>
        public void AttachKernel(DEBUG_ATTACH flags, string connectOptions)
        {
            TryAttachKernel(flags, connectOptions).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The AttachKernel methods connect the debugger engine to a kernel target.
        /// </summary>
        /// <param name="flags">[in] Specifies the flags that control how the debugger attaches to the kernel target. The possible values are:</param>
        /// <param name="connectOptions">[in, optional] Specifies the connection settings for communicating with the computer running the kernel target.<para/>
        /// The interpretation of ConnectOptions depends on the value of Flags. ConnectOptions will be interpreted the same way as the options that follow the -k switch on the WinDbg and KD command lines.<para/>
        /// Environment variables affect ConnectOptions in the same way they affect the -k switch. eXDI drivers are not described in this documentation.<para/>
        /// If you have an eXDI interface to your hardware probe or hardware simulator, please contact Microsoft for debugging information.<para/>
        /// eXDI drivers are not described in this documentation. If you have an eXDI interface to your hardware probe or hardware simulator, please contact Microsoft for debugging information.<para/>
        /// ConnectOptions will be interpreted the same way as the options that follow the -k switch on the WinDbg and KD command lines.<para/>
        /// Environment variables affect ConnectOptions in the same way they affect the -k switch.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryAttachKernel(DEBUG_ATTACH flags, string connectOptions)
        {
            InitDelegate(ref attachKernel, Vtbl->AttachKernel);

            /*HRESULT AttachKernel(
            [In] DEBUG_ATTACH Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string ConnectOptions);*/
            return attachKernel(Raw, flags, connectOptions);
        }

        #endregion
        #region StartProcessServer

        /// <summary>
        /// The StartProcessServer method starts a process server.
        /// </summary>
        /// <param name="flags">[in] Specifies the class of the targets that will be available through the process server. This must be set to DEBUG_CLASS_USER_WINDOWS.</param>
        /// <param name="options">[in] Specifies the connections options for this process server. These are the same options given to the -t option of the DbgSrv command line.<para/>
        /// For details on the syntax of this string, see Activating a Process Server.</param>
        /// <param name="reserved">[in, optional] Set to NULL.</param>
        /// <remarks>
        /// The process server that is started will be accessible by remote clients through the transport specified in the
        /// Options parameter. To stop the process server from the smart client, use the <see cref="EndProcessServer"/>
        /// method. To shut down the process server from the computer that it is running on, use Task Manager to end the process.
        /// If the instance of the debugger engine that used StartProcessServer is still running, it can use <see cref="DebugControl.Execute"/>
        /// to issue the debugger command .endsrv 0, which will end the process server (this is an exception to the usual behavior
        /// of .endsrv, which generally does not affect process servers). For more information about process servers and remote
        /// debugging, see Process Servers, Kernel Connection Servers, and Smart Clients.
        /// </remarks>
        public void StartProcessServer(DEBUG_CLASS flags, string options, IntPtr reserved)
        {
            TryStartProcessServer(flags, options, reserved).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The StartProcessServer method starts a process server.
        /// </summary>
        /// <param name="flags">[in] Specifies the class of the targets that will be available through the process server. This must be set to DEBUG_CLASS_USER_WINDOWS.</param>
        /// <param name="options">[in] Specifies the connections options for this process server. These are the same options given to the -t option of the DbgSrv command line.<para/>
        /// For details on the syntax of this string, see Activating a Process Server.</param>
        /// <param name="reserved">[in, optional] Set to NULL.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The process server that is started will be accessible by remote clients through the transport specified in the
        /// Options parameter. To stop the process server from the smart client, use the <see cref="EndProcessServer"/>
        /// method. To shut down the process server from the computer that it is running on, use Task Manager to end the process.
        /// If the instance of the debugger engine that used StartProcessServer is still running, it can use <see cref="DebugControl.Execute"/>
        /// to issue the debugger command .endsrv 0, which will end the process server (this is an exception to the usual behavior
        /// of .endsrv, which generally does not affect process servers). For more information about process servers and remote
        /// debugging, see Process Servers, Kernel Connection Servers, and Smart Clients.
        /// </remarks>
        public HRESULT TryStartProcessServer(DEBUG_CLASS flags, string options, IntPtr reserved)
        {
            InitDelegate(ref startProcessServer, Vtbl->StartProcessServer);

            /*HRESULT StartProcessServer(
            [In] DEBUG_CLASS Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Options,
            [In] IntPtr Reserved);*/
            return startProcessServer(Raw, flags, options, reserved);
        }

        #endregion
        #region ConnectProcessServer

        /// <summary>
        /// The ConnectProcessServer methods connect to a process server.
        /// </summary>
        /// <param name="remoteOptions">[in] Specifies how the debugger engine will connect with the process server. These are the same options passed to the -premote option on the WinDbg and CDB command lines.<para/>
        /// For details on the syntax of this string, see Activating a Smart Client.</param>
        /// <returns>[out] Receives a handle for the process server. This handle is used when creating or attaching to processes by using the process server.</returns>
        /// <remarks>
        /// For more information about process servers and remote debugging, see Process Servers, Kernel Connection Servers,
        /// and Smart Clients.
        /// </remarks>
        public long ConnectProcessServer(string remoteOptions)
        {
            long server;
            TryConnectProcessServer(remoteOptions, out server).ThrowDbgEngNotOK();

            return server;
        }

        /// <summary>
        /// The ConnectProcessServer methods connect to a process server.
        /// </summary>
        /// <param name="remoteOptions">[in] Specifies how the debugger engine will connect with the process server. These are the same options passed to the -premote option on the WinDbg and CDB command lines.<para/>
        /// For details on the syntax of this string, see Activating a Smart Client.</param>
        /// <param name="server">[out] Receives a handle for the process server. This handle is used when creating or attaching to processes by using the process server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about process servers and remote debugging, see Process Servers, Kernel Connection Servers,
        /// and Smart Clients.
        /// </remarks>
        public HRESULT TryConnectProcessServer(string remoteOptions, out long server)
        {
            InitDelegate(ref connectProcessServer, Vtbl->ConnectProcessServer);

            /*HRESULT ConnectProcessServer(
            [In, MarshalAs(UnmanagedType.LPStr)] string RemoteOptions,
            [Out] out long Server);*/
            return connectProcessServer(Raw, remoteOptions, out server);
        }

        #endregion
        #region DisconnectProcessServer

        /// <summary>
        /// The DisconnectProcessServer method disconnects the debugger engine from a process server.
        /// </summary>
        /// <param name="server">[in] Specifies the server from which to disconnect. This handle must have been previously returned by <see cref="ConnectProcessServer"/>.</param>
        /// <remarks>
        /// For more information about process servers and remote debugging, see Process Servers, Kernel Connection Servers,
        /// and Smart Clients.
        /// </remarks>
        public void DisconnectProcessServer(long server)
        {
            TryDisconnectProcessServer(server).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The DisconnectProcessServer method disconnects the debugger engine from a process server.
        /// </summary>
        /// <param name="server">[in] Specifies the server from which to disconnect. This handle must have been previously returned by <see cref="ConnectProcessServer"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about process servers and remote debugging, see Process Servers, Kernel Connection Servers,
        /// and Smart Clients.
        /// </remarks>
        public HRESULT TryDisconnectProcessServer(long server)
        {
            InitDelegate(ref disconnectProcessServer, Vtbl->DisconnectProcessServer);

            /*HRESULT DisconnectProcessServer(
            [In] long Server);*/
            return disconnectProcessServer(Raw, server);
        }

        #endregion
        #region GetRunningProcessSystemIds

        /// <summary>
        /// The GetRunningProcessSystemIds method returns the process IDs for each running process.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to query for process IDs. If Server is zero, the engine will return the process IDs of the processes running on the local computer.</param>
        /// <returns>[out, optional] Receives the process IDs. The size of this array is Count. If Ids is NULL, this information is not returned.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public int[] GetRunningProcessSystemIds(long server)
        {
            int[] ids;
            TryGetRunningProcessSystemIds(server, out ids).ThrowDbgEngNotOK();

            return ids;
        }

        /// <summary>
        /// The GetRunningProcessSystemIds method returns the process IDs for each running process.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to query for process IDs. If Server is zero, the engine will return the process IDs of the processes running on the local computer.</param>
        /// <param name="ids">[out, optional] Receives the process IDs. The size of this array is Count. If Ids is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryGetRunningProcessSystemIds(long server, out int[] ids)
        {
            InitDelegate(ref getRunningProcessSystemIds, Vtbl->GetRunningProcessSystemIds);
            /*HRESULT GetRunningProcessSystemIds(
            [In] long Server,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] Ids,
            [In] int Count,
            [Out] out int ActualCount);*/
            ids = null;
            int count = 0;
            int actualCount;
            HRESULT hr = getRunningProcessSystemIds(Raw, server, null, count, out actualCount);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            count = actualCount;
            ids = new int[count];
            hr = getRunningProcessSystemIds(Raw, server, ids, count, out actualCount);
            fail:
            return hr;
        }

        #endregion
        #region GetRunningProcessSystemIdByExecutableName

        /// <summary>
        /// The GetRunningProcessSystemIdByExecutableName method searches for a process with a given executable file name and return its process ID.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to search for the executable name. If Server is zero, the engine will search for the executable name among the processes running on the local computer.</param>
        /// <param name="exeName">[in] Specifies the executable file name for which to search.</param>
        /// <param name="flags">[in] Specifies a bit-set that controls how the executable name is matched. The following flags may be present: If this flag is not set, this method will not use path names when searching for the process.</param>
        /// <returns>[out] Receives the process ID of the first process to match ExeName.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public int GetRunningProcessSystemIdByExecutableName(long server, string exeName, DEBUG_GET_PROC flags)
        {
            int id;
            TryGetRunningProcessSystemIdByExecutableName(server, exeName, flags, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// The GetRunningProcessSystemIdByExecutableName method searches for a process with a given executable file name and return its process ID.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to search for the executable name. If Server is zero, the engine will search for the executable name among the processes running on the local computer.</param>
        /// <param name="exeName">[in] Specifies the executable file name for which to search.</param>
        /// <param name="flags">[in] Specifies a bit-set that controls how the executable name is matched. The following flags may be present: If this flag is not set, this method will not use path names when searching for the process.</param>
        /// <param name="id">[out] Receives the process ID of the first process to match ExeName.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryGetRunningProcessSystemIdByExecutableName(long server, string exeName, DEBUG_GET_PROC flags, out int id)
        {
            InitDelegate(ref getRunningProcessSystemIdByExecutableName, Vtbl->GetRunningProcessSystemIdByExecutableName);

            /*HRESULT GetRunningProcessSystemIdByExecutableName(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string ExeName,
            [In] DEBUG_GET_PROC Flags,
            [Out] out int Id);*/
            return getRunningProcessSystemIdByExecutableName(Raw, server, exeName, flags, out id);
        }

        #endregion
        #region GetRunningProcessDescription

        /// <summary>
        /// The GetRunningProcessDescription method returns a description of the process that includes the executable image name, the service names, the MTS package names, and the command line.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to query for the process description. If Server is zero, the engine will query information about the local process directly.</param>
        /// <param name="systemId">[in] Specifies the process ID of the process whose description is desired.</param>
        /// <param name="flags">[in] Specifies a bit-set containing options that affect the behavior of this method. Flags can contain the following bit flags:</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public GetRunningProcessDescriptionResult GetRunningProcessDescription(long server, int systemId, DEBUG_PROC_DESC flags)
        {
            GetRunningProcessDescriptionResult result;
            TryGetRunningProcessDescription(server, systemId, flags, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetRunningProcessDescription method returns a description of the process that includes the executable image name, the service names, the MTS package names, and the command line.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to query for the process description. If Server is zero, the engine will query information about the local process directly.</param>
        /// <param name="systemId">[in] Specifies the process ID of the process whose description is desired.</param>
        /// <param name="flags">[in] Specifies a bit-set containing options that affect the behavior of this method. Flags can contain the following bit flags:</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryGetRunningProcessDescription(long server, int systemId, DEBUG_PROC_DESC flags, out GetRunningProcessDescriptionResult result)
        {
            InitDelegate(ref getRunningProcessDescription, Vtbl->GetRunningProcessDescription);
            /*HRESULT GetRunningProcessDescription(
            [In] long Server,
            [In] int SystemId,
            [In] DEBUG_PROC_DESC Flags,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] ExeName,
            [In] int ExeNameSize,
            [Out] out int ActualExeNameSize,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 7)] char[] Description,
            [In] int DescriptionSize,
            [Out] out int ActualDescriptionSize);*/
            char[] exeName;
            int exeNameSize = 0;
            int actualExeNameSize;
            char[] description;
            int descriptionSize = 0;
            int actualDescriptionSize;
            HRESULT hr = getRunningProcessDescription(Raw, server, systemId, flags, null, exeNameSize, out actualExeNameSize, null, descriptionSize, out actualDescriptionSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            exeNameSize = actualExeNameSize;
            exeName = new char[exeNameSize];
            descriptionSize = actualDescriptionSize;
            description = new char[descriptionSize];
            hr = getRunningProcessDescription(Raw, server, systemId, flags, exeName, exeNameSize, out actualExeNameSize, description, descriptionSize, out actualDescriptionSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetRunningProcessDescriptionResult(CreateString(exeName, actualExeNameSize), CreateString(description, actualDescriptionSize));

                return hr;
            }

            fail:
            result = default(GetRunningProcessDescriptionResult);

            return hr;
        }

        #endregion
        #region AttachProcess

        /// <summary>
        /// The AttachProcess method connects the debugger engine to a user-modeprocess.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to a local process without using a process server.</param>
        /// <param name="processID">[in] Specifies the process ID of the target process the debugger will attach to.</param>
        /// <param name="attachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see Remarks.</param>
        /// <remarks>
        /// This method is available only for live user-mode debugging. The DEBUG_ATTACH_XXX bit-flags control how the debugger
        /// engine attaches to a user-mode process. For the DEBUG_ATTACH_XXX options used when attaching to a kernel target,
        /// see <see cref="AttachKernel"/>. The following table describes the possible flag values. If this flag is set, then
        /// the flags DEBUG_ATTACH_EXISTING, DEBUG_ATTACH_INVASIVE_NO_INITIAL_BREAK, and DEBUG_ATTACH_INVASIVE_RESUME_PROCESS
        /// must not be set. If this flag is set, then the other DEBUG_ATTACH_XXX flags must not be set. If this flag is set,
        /// then the flag DEBUG_ATTACH_NONINVASIVE must also be set. If this flag is set, then the flags DEBUG_ATTACH_NONINVASIVE
        /// and DEBUG_ATTACH_EXISTING must not be set.
        /// </remarks>
        public void AttachProcess(long server, int processID, DEBUG_ATTACH attachFlags)
        {
            TryAttachProcess(server, processID, attachFlags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The AttachProcess method connects the debugger engine to a user-modeprocess.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to a local process without using a process server.</param>
        /// <param name="processID">[in] Specifies the process ID of the target process the debugger will attach to.</param>
        /// <param name="attachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see Remarks.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. The DEBUG_ATTACH_XXX bit-flags control how the debugger
        /// engine attaches to a user-mode process. For the DEBUG_ATTACH_XXX options used when attaching to a kernel target,
        /// see <see cref="AttachKernel"/>. The following table describes the possible flag values. If this flag is set, then
        /// the flags DEBUG_ATTACH_EXISTING, DEBUG_ATTACH_INVASIVE_NO_INITIAL_BREAK, and DEBUG_ATTACH_INVASIVE_RESUME_PROCESS
        /// must not be set. If this flag is set, then the other DEBUG_ATTACH_XXX flags must not be set. If this flag is set,
        /// then the flag DEBUG_ATTACH_NONINVASIVE must also be set. If this flag is set, then the flags DEBUG_ATTACH_NONINVASIVE
        /// and DEBUG_ATTACH_EXISTING must not be set.
        /// </remarks>
        public HRESULT TryAttachProcess(long server, int processID, DEBUG_ATTACH attachFlags)
        {
            InitDelegate(ref attachProcess, Vtbl->AttachProcess);

            /*HRESULT AttachProcess(
            [In] long Server,
            [In] int ProcessID,
            [In] DEBUG_ATTACH AttachFlags);*/
            return attachProcess(Raw, server, processID, attachFlags);
        }

        #endregion
        #region CreateProcess

        /// <summary>
        /// The CreateProcess method creates a process from the specified command line.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will create a local process without using a process server.</param>
        /// <param name="commandLine">[in] Specifies the command line to execute to create the new process.</param>
        /// <param name="flags">[in] Specifies the flags to use when creating the process. For details on these flags, see the CreateFlags member of the <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CreateFlags contains either of the flags DEBUG_PROCESS
        /// or DEBUG_ONLY_THIS_PROCESS, the engine will also attach to the newly created process; this is similar to the behavior
        /// of <see cref="CreateProcessAndAttach2"/> with its argument ProcessId set to zero. For more information
        /// about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public void CreateProcess(long server, string commandLine, DEBUG_CREATE_PROCESS flags)
        {
            TryCreateProcess(server, commandLine, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CreateProcess method creates a process from the specified command line.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will create a local process without using a process server.</param>
        /// <param name="commandLine">[in] Specifies the command line to execute to create the new process.</param>
        /// <param name="flags">[in] Specifies the flags to use when creating the process. For details on these flags, see the CreateFlags member of the <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CreateFlags contains either of the flags DEBUG_PROCESS
        /// or DEBUG_ONLY_THIS_PROCESS, the engine will also attach to the newly created process; this is similar to the behavior
        /// of <see cref="CreateProcessAndAttach2"/> with its argument ProcessId set to zero. For more information
        /// about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryCreateProcess(long server, string commandLine, DEBUG_CREATE_PROCESS flags)
        {
            InitDelegate(ref createProcess, Vtbl->CreateProcess);

            /*HRESULT CreateProcess(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS Flags);*/
            return createProcess(Raw, server, commandLine, flags);
        }

        #endregion
        #region CreateProcessAndAttach

        /// <summary>
        /// The CreateProcessAndAttach method creates a process from a specified command line, then attach to another user-mode process.<para/>
        /// The created process is suspended and only allowed to execute when the attach has completed. This allows rough synchronization when debugging both, client and server processes.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="commandLine">[in, optional] Specifies the command line to execute to create the new process. If CommandLine is NULL, then no process is created and these methods attach to an existing process, as <see cref="AttachProcess"/> does.</param>
        /// <param name="flags">[in] Specifies the flags to use when creating the process. For details on these flags, see <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/>.CreateFlags.</param>
        /// <param name="processId">[in] Specifies the process ID of the target process the debugger will attach to. If ProcessId is zero, the debugger will attach to the process it created from CommandLine.</param>
        /// <param name="attachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see DEBUG_ATTACH_XXX.</param>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CommandLine is not NULL and ProcessId is not zero,
        /// then the engine will create the process in a suspended state. The engine will resume this newly created process
        /// after it successfully connects to the process specified in ProcessId.
        /// </remarks>
        public void CreateProcessAndAttach(long server, string commandLine, DEBUG_CREATE_PROCESS flags, int processId, DEBUG_ATTACH attachFlags)
        {
            TryCreateProcessAndAttach(server, commandLine, flags, processId, attachFlags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CreateProcessAndAttach method creates a process from a specified command line, then attach to another user-mode process.<para/>
        /// The created process is suspended and only allowed to execute when the attach has completed. This allows rough synchronization when debugging both, client and server processes.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="commandLine">[in, optional] Specifies the command line to execute to create the new process. If CommandLine is NULL, then no process is created and these methods attach to an existing process, as <see cref="AttachProcess"/> does.</param>
        /// <param name="flags">[in] Specifies the flags to use when creating the process. For details on these flags, see <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/>.CreateFlags.</param>
        /// <param name="processId">[in] Specifies the process ID of the target process the debugger will attach to. If ProcessId is zero, the debugger will attach to the process it created from CommandLine.</param>
        /// <param name="attachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see DEBUG_ATTACH_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CommandLine is not NULL and ProcessId is not zero,
        /// then the engine will create the process in a suspended state. The engine will resume this newly created process
        /// after it successfully connects to the process specified in ProcessId.
        /// </remarks>
        public HRESULT TryCreateProcessAndAttach(long server, string commandLine, DEBUG_CREATE_PROCESS flags, int processId, DEBUG_ATTACH attachFlags)
        {
            InitDelegate(ref createProcessAndAttach, Vtbl->CreateProcessAndAttach);

            /*HRESULT CreateProcessAndAttach(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS Flags,
            [In] int ProcessId,
            [In] DEBUG_ATTACH AttachFlags);*/
            return createProcessAndAttach(Raw, server, commandLine, flags, processId, attachFlags);
        }

        #endregion
        #region AddProcessOptions

        /// <summary>
        /// The AddProcessOptions method adds the process options to those options that affect the current process.
        /// </summary>
        /// <param name="options">[in] Specifies the process options to add to those affecting the current process. For details on these process options, see DEBUG_PROCESS_XXX.</param>
        /// <remarks>
        /// This method is available only in live user-mode debugging. Some of the process options are global options, others
        /// are specific to the current process. If any process options are modified, the engine will notify the event callbacks
        /// by calling their <see cref="IDebugEventCallbacks.ChangeEngineState"/> method with the DEBUG_CES_PROCESS_OPTIONS
        /// flag set. For more information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public void AddProcessOptions(DEBUG_PROCESS options)
        {
            TryAddProcessOptions(options).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The AddProcessOptions method adds the process options to those options that affect the current process.
        /// </summary>
        /// <param name="options">[in] Specifies the process options to add to those affecting the current process. For details on these process options, see DEBUG_PROCESS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only in live user-mode debugging. Some of the process options are global options, others
        /// are specific to the current process. If any process options are modified, the engine will notify the event callbacks
        /// by calling their <see cref="IDebugEventCallbacks.ChangeEngineState"/> method with the DEBUG_CES_PROCESS_OPTIONS
        /// flag set. For more information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryAddProcessOptions(DEBUG_PROCESS options)
        {
            InitDelegate(ref addProcessOptions, Vtbl->AddProcessOptions);

            /*HRESULT AddProcessOptions(
            [In] DEBUG_PROCESS Options);*/
            return addProcessOptions(Raw, options);
        }

        #endregion
        #region RemoveProcessOptions

        /// <summary>
        /// The RemoveProcessOptions method removes process options from those options that affect the current process.
        /// </summary>
        /// <param name="options">[in] Specifies the process options to remove from those affecting the current process. For details on these options, see DEBUG_PROCESS_XXX.</param>
        /// <remarks>
        /// This method is available only in live user-mode debugging. Some of the process options are global options, others
        /// are specific to the current process. If any process options are modified, the engine will notify the event callbacks
        /// by calling their <see cref="IDebugEventCallbacks.ChangeEngineState"/> method with the DEBUG_CES_PROCESS_OPTIONS
        /// flag set. For more information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public void RemoveProcessOptions(DEBUG_PROCESS options)
        {
            TryRemoveProcessOptions(options).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The RemoveProcessOptions method removes process options from those options that affect the current process.
        /// </summary>
        /// <param name="options">[in] Specifies the process options to remove from those affecting the current process. For details on these options, see DEBUG_PROCESS_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only in live user-mode debugging. Some of the process options are global options, others
        /// are specific to the current process. If any process options are modified, the engine will notify the event callbacks
        /// by calling their <see cref="IDebugEventCallbacks.ChangeEngineState"/> method with the DEBUG_CES_PROCESS_OPTIONS
        /// flag set. For more information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryRemoveProcessOptions(DEBUG_PROCESS options)
        {
            InitDelegate(ref removeProcessOptions, Vtbl->RemoveProcessOptions);

            /*HRESULT RemoveProcessOptions(
            [In] DEBUG_PROCESS Options);*/
            return removeProcessOptions(Raw, options);
        }

        #endregion
        #region OpenDumpFile

        /// <summary>
        /// The OpenDumpFile method opens a dump file as a debugger target.
        /// </summary>
        /// <param name="dumpFile">[in] Specifies the name of the dump file to open. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// DumpFile can have the form of a file URL, starting with "file://". If DumpFile specifies a cabinet (.cab) file, the cabinet file is searched for the first file with extension .kdmp, then .hdmp, then .mdmp, and finally .dmp.</param>
        /// <remarks>
        /// The Unicode version of this method is <see cref="OpenDumpFileWide"/>.
        /// </remarks>
        public void OpenDumpFile(string dumpFile)
        {
            TryOpenDumpFile(dumpFile).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OpenDumpFile method opens a dump file as a debugger target.
        /// </summary>
        /// <param name="dumpFile">[in] Specifies the name of the dump file to open. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// DumpFile can have the form of a file URL, starting with "file://". If DumpFile specifies a cabinet (.cab) file, the cabinet file is searched for the first file with extension .kdmp, then .hdmp, then .mdmp, and finally .dmp.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The Unicode version of this method is <see cref="OpenDumpFileWide"/>.
        /// </remarks>
        public HRESULT TryOpenDumpFile(string dumpFile)
        {
            InitDelegate(ref openDumpFile, Vtbl->OpenDumpFile);

            /*HRESULT OpenDumpFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile);*/
            return openDumpFile(Raw, dumpFile);
        }

        #endregion
        #region WriteDumpFile

        /// <summary>
        /// The WriteDumpFile method creates a user-mode or kernel-modecrash dump file.
        /// </summary>
        /// <param name="dumpFile">[in] Specifies the name of the dump file to create. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.</param>
        /// <param name="qualifier">[in] Specifies the type of dump file to create. For possible values, see Remarks.</param>
        /// <remarks>
        /// The DEBUG_DUMP_XXX constants are used by the methods WriteDumpFile, <see cref="WriteDumpFile2"/>,
        /// and <see cref="WriteDumpFileWide"/> to specify the type of crash dump file to create. The possible
        /// values include the following. Creates a Complete Memory Dump (kernel-mode only). To specify the formatting of the
        /// file and--for user-mode minidumps--the information to include in the file, use <see cref="WriteDumpFile2"/>
        /// or <see cref="WriteDumpFileWide"/>. For more information about crash dump files, see Dump-File Targets.
        /// Moreover, the following aliases are available for kernel-mode debugging. Additionally, the following aliases are
        /// available for user-mode debugging. For a description of kernel-mode dump files, see Varieties of Kernel-Mode Dump
        /// Files. For a description of user-mode dump files, see Varieties of User-Mode Dump Files.
        /// </remarks>
        public void WriteDumpFile(string dumpFile, DEBUG_DUMP qualifier)
        {
            TryWriteDumpFile(dumpFile, qualifier).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The WriteDumpFile method creates a user-mode or kernel-modecrash dump file.
        /// </summary>
        /// <param name="dumpFile">[in] Specifies the name of the dump file to create. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.</param>
        /// <param name="qualifier">[in] Specifies the type of dump file to create. For possible values, see Remarks.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The DEBUG_DUMP_XXX constants are used by the methods WriteDumpFile, <see cref="WriteDumpFile2"/>,
        /// and <see cref="WriteDumpFileWide"/> to specify the type of crash dump file to create. The possible
        /// values include the following. Creates a Complete Memory Dump (kernel-mode only). To specify the formatting of the
        /// file and--for user-mode minidumps--the information to include in the file, use <see cref="WriteDumpFile2"/>
        /// or <see cref="WriteDumpFileWide"/>. For more information about crash dump files, see Dump-File Targets.
        /// Moreover, the following aliases are available for kernel-mode debugging. Additionally, the following aliases are
        /// available for user-mode debugging. For a description of kernel-mode dump files, see Varieties of Kernel-Mode Dump
        /// Files. For a description of user-mode dump files, see Varieties of User-Mode Dump Files.
        /// </remarks>
        public HRESULT TryWriteDumpFile(string dumpFile, DEBUG_DUMP qualifier)
        {
            InitDelegate(ref writeDumpFile, Vtbl->WriteDumpFile);

            /*HRESULT WriteDumpFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DEBUG_DUMP Qualifier);*/
            return writeDumpFile(Raw, dumpFile, qualifier);
        }

        #endregion
        #region ConnectSession

        /// <summary>
        /// The ConnectSession method joins the client to an existing debugger session.
        /// </summary>
        /// <param name="flags">[in] Specifies a bit-set of option flags for connecting to the session. The possible values of these flags are:</param>
        /// <param name="historyLimit">[in] Specifies the maximum number of characters from the session's history to send to this client's output upon connection.</param>
        /// <remarks>
        /// When the client object connects to a session, the most recent output from the session is sent to the client. If
        /// the session is currently waiting on input, the client object is given the opportunity to provide input. Thus, the
        /// client object synchronizes with the session's input and output. The client becomes a primary client and will appear
        /// among the list of clients in the output of the .clients debugger command. For more information about debugging
        /// clients, see Debugging Server and Debugging Client. For more information about debugger sessions, see Debugging
        /// Session and Execution Model.
        /// </remarks>
        public void ConnectSession(DEBUG_CONNECT_SESSION flags, int historyLimit)
        {
            TryConnectSession(flags, historyLimit).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ConnectSession method joins the client to an existing debugger session.
        /// </summary>
        /// <param name="flags">[in] Specifies a bit-set of option flags for connecting to the session. The possible values of these flags are:</param>
        /// <param name="historyLimit">[in] Specifies the maximum number of characters from the session's history to send to this client's output upon connection.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// When the client object connects to a session, the most recent output from the session is sent to the client. If
        /// the session is currently waiting on input, the client object is given the opportunity to provide input. Thus, the
        /// client object synchronizes with the session's input and output. The client becomes a primary client and will appear
        /// among the list of clients in the output of the .clients debugger command. For more information about debugging
        /// clients, see Debugging Server and Debugging Client. For more information about debugger sessions, see Debugging
        /// Session and Execution Model.
        /// </remarks>
        public HRESULT TryConnectSession(DEBUG_CONNECT_SESSION flags, int historyLimit)
        {
            InitDelegate(ref connectSession, Vtbl->ConnectSession);

            /*HRESULT ConnectSession(
            [In] DEBUG_CONNECT_SESSION Flags,
            [In] int HistoryLimit);*/
            return connectSession(Raw, flags, historyLimit);
        }

        #endregion
        #region StartServer

        /// <summary>
        /// The StartServer method starts a debugging server.
        /// </summary>
        /// <param name="options">[in] Specifies the connections options for this server. These are the same options given to the .server debugger command or the WinDbg and CDB -server command-line option.<para/>
        /// For details on the syntax of this string, see Activating a Debugging Server.</param>
        /// <remarks>
        /// The server that is started will be accessible by other debuggers through the transport specified in the Options
        /// parameter. For more information about debugging servers, see Debugging Server and Debugging Client.
        /// </remarks>
        public void StartServer(string options)
        {
            TryStartServer(options).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The StartServer method starts a debugging server.
        /// </summary>
        /// <param name="options">[in] Specifies the connections options for this server. These are the same options given to the .server debugger command or the WinDbg and CDB -server command-line option.<para/>
        /// For details on the syntax of this string, see Activating a Debugging Server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The server that is started will be accessible by other debuggers through the transport specified in the Options
        /// parameter. For more information about debugging servers, see Debugging Server and Debugging Client.
        /// </remarks>
        public HRESULT TryStartServer(string options)
        {
            InitDelegate(ref startServer, Vtbl->StartServer);

            /*HRESULT StartServer(
            [In, MarshalAs(UnmanagedType.LPStr)] string Options);*/
            return startServer(Raw, options);
        }

        #endregion
        #region OutputServer

        public void OutputServer(DEBUG_OUTCTL outputControl, string machine, DEBUG_SERVERS flags)
        {
            TryOutputServer(outputControl, machine, flags).ThrowDbgEngNotOK();
        }

        public HRESULT TryOutputServer(DEBUG_OUTCTL outputControl, string machine, DEBUG_SERVERS flags)
        {
            InitDelegate(ref outputServer, Vtbl->OutputServer);

            /*HRESULT OutputServer(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPStr)] string Machine,
            [In] DEBUG_SERVERS Flags);*/
            return outputServer(Raw, outputControl, machine, flags);
        }

        #endregion
        #region TerminateProcesses

        /// <summary>
        /// The TerminateProcesses method attempts to terminate all processes in all targets.
        /// </summary>
        /// <remarks>
        /// Only live user-mode processes are terminated by this method. For other targets, the target is detached from the
        /// debugger without terminating. For more information about creating and attaching to live user-mode targets, see
        /// Live User-Mode Targets.
        /// </remarks>
        public void TerminateProcesses()
        {
            TryTerminateProcesses().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The TerminateProcesses method attempts to terminate all processes in all targets.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Only live user-mode processes are terminated by this method. For other targets, the target is detached from the
        /// debugger without terminating. For more information about creating and attaching to live user-mode targets, see
        /// Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryTerminateProcesses()
        {
            InitDelegate(ref terminateProcesses, Vtbl->TerminateProcesses);

            /*HRESULT TerminateProcesses();*/
            return terminateProcesses(Raw);
        }

        #endregion
        #region DetachProcesses

        /// <summary>
        /// The DetachProcesses method detaches the debugger engine from all processes in all targets, resuming all their threads.
        /// </summary>
        /// <remarks>
        /// The targets must be running on Windows XP or a later version of Windows. For more information about creating and
        /// attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public void DetachProcesses()
        {
            TryDetachProcesses().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The DetachProcesses method detaches the debugger engine from all processes in all targets, resuming all their threads.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The targets must be running on Windows XP or a later version of Windows. For more information about creating and
        /// attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryDetachProcesses()
        {
            InitDelegate(ref detachProcesses, Vtbl->DetachProcesses);

            /*HRESULT DetachProcesses();*/
            return detachProcesses(Raw);
        }

        #endregion
        #region EndSession

        /// <summary>
        /// The EndSession method ends the current debugger session.
        /// </summary>
        /// <param name="flags">[in] Specifies how to end the session. Flags can be one of the following values: This flag is intended for when remote clients disconnect.<para/>
        /// It generates a server message about the disconnection.</param>
        /// <remarks>
        /// This method may be called at any time with Flags set to DEBUG_END_REENTRANT. If, for example, the application needs
        /// to exit but another thread is using the engine, this method can be used to perform as much cleanup as possible.
        /// Using DEBUG_END_REENTRANT may leave the engine in an indeterminate state. If this flag is used, no subsequent calls
        /// should be made to the engine. For more information about debugger sessions, see Debugging Session and Execution
        /// Model.
        /// </remarks>
        public void EndSession(DEBUG_END flags)
        {
            TryEndSession(flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The EndSession method ends the current debugger session.
        /// </summary>
        /// <param name="flags">[in] Specifies how to end the session. Flags can be one of the following values: This flag is intended for when remote clients disconnect.<para/>
        /// It generates a server message about the disconnection.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method may be called at any time with Flags set to DEBUG_END_REENTRANT. If, for example, the application needs
        /// to exit but another thread is using the engine, this method can be used to perform as much cleanup as possible.
        /// Using DEBUG_END_REENTRANT may leave the engine in an indeterminate state. If this flag is used, no subsequent calls
        /// should be made to the engine. For more information about debugger sessions, see Debugging Session and Execution
        /// Model.
        /// </remarks>
        public HRESULT TryEndSession(DEBUG_END flags)
        {
            InitDelegate(ref endSession, Vtbl->EndSession);

            /*HRESULT EndSession(
            [In] DEBUG_END Flags);*/
            return endSession(Raw, flags);
        }

        #endregion
        #region DispatchCallbacks

        /// <summary>
        /// The DispatchCallbacks method lets the debugger engine use the current thread for callbacks.
        /// </summary>
        /// <param name="timeout">[in] Specifies how many milliseconds to wait before this method will return. If Timeout is INFINITE, this method will not return until <see cref="ExitDispatch"/> is called or an error occurs.</param>
        /// <remarks>
        /// This method returns when Timeout milliseconds have elapsed, <see cref="ExitDispatch"/> is called, or an error occurs.
        /// Almost all client methods must be called from the thread in which the client was created; callback objects registered
        /// with the client are also called from this thread. When DispatchCallbacks is called the engine can use the current
        /// thread to make callback calls. Client threads should call this method whenever possible to allow the callbacks
        /// to be called, unless the thread was the same thread used to start the debugger session, in which case the callbacks
        /// are called when <see cref="DebugControl.WaitForEvent"/> is called. For more information about callbacks, see Callbacks.
        /// </remarks>
        public void DispatchCallbacks(int timeout)
        {
            TryDispatchCallbacks(timeout).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The DispatchCallbacks method lets the debugger engine use the current thread for callbacks.
        /// </summary>
        /// <param name="timeout">[in] Specifies how many milliseconds to wait before this method will return. If Timeout is INFINITE, this method will not return until <see cref="ExitDispatch"/> is called or an error occurs.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method returns when Timeout milliseconds have elapsed, <see cref="ExitDispatch"/> is called, or an error occurs.
        /// Almost all client methods must be called from the thread in which the client was created; callback objects registered
        /// with the client are also called from this thread. When DispatchCallbacks is called the engine can use the current
        /// thread to make callback calls. Client threads should call this method whenever possible to allow the callbacks
        /// to be called, unless the thread was the same thread used to start the debugger session, in which case the callbacks
        /// are called when <see cref="DebugControl.WaitForEvent"/> is called. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TryDispatchCallbacks(int timeout)
        {
            InitDelegate(ref dispatchCallbacks, Vtbl->DispatchCallbacks);

            /*HRESULT DispatchCallbacks(
            [In] int Timeout);*/
            return dispatchCallbacks(Raw, timeout);
        }

        #endregion
        #region ExitDispatch

        /// <summary>
        /// The ExitDispatch method causes the <see cref="DispatchCallbacks"/> method to return.
        /// </summary>
        /// <param name="client">[in] Specifies the client whose <see cref="DispatchCallbacks"/> method should return.</param>
        /// <remarks>
        /// This method is reentrant and may be called from any thread. This method can be used to interrupt a thread waiting
        /// in <see cref="DispatchCallbacks"/>. For more information about callbacks, see Callbacks.
        /// </remarks>
        public void ExitDispatch(IntPtr client)
        {
            TryExitDispatch(client).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ExitDispatch method causes the <see cref="DispatchCallbacks"/> method to return.
        /// </summary>
        /// <param name="client">[in] Specifies the client whose <see cref="DispatchCallbacks"/> method should return.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is reentrant and may be called from any thread. This method can be used to interrupt a thread waiting
        /// in <see cref="DispatchCallbacks"/>. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TryExitDispatch(IntPtr client)
        {
            InitDelegate(ref exitDispatch, Vtbl->ExitDispatch);

            /*HRESULT ExitDispatch(
            [In] IntPtr Client);*/
            return exitDispatch(Raw, client);
        }

        #endregion
        #region CreateClient

        /// <summary>
        /// The CreateClient method creates a new client object for the current thread.
        /// </summary>
        /// <returns>[out] Receives an interface pointer for the new client.</returns>
        /// <remarks>
        /// This method creates a client that may be used in the current thread. Clients are specific to the thread that created
        /// them. Calls from other threads fail immediately. The CreateClient method is a notable exception; it allows creation
        /// of a new client for a new thread. All callbacks for a client are made in the thread with which the client was created.
        /// For more information about client objects and how they are used in the debugger engine, see Client Objects.
        /// </remarks>
        public DebugClient CreateClient()
        {
            DebugClient clientResult;
            TryCreateClient(out clientResult).ThrowDbgEngNotOK();

            return clientResult;
        }

        /// <summary>
        /// The CreateClient method creates a new client object for the current thread.
        /// </summary>
        /// <param name="clientResult">[out] Receives an interface pointer for the new client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method creates a client that may be used in the current thread. Clients are specific to the thread that created
        /// them. Calls from other threads fail immediately. The CreateClient method is a notable exception; it allows creation
        /// of a new client for a new thread. All callbacks for a client are made in the thread with which the client was created.
        /// For more information about client objects and how they are used in the debugger engine, see Client Objects.
        /// </remarks>
        public HRESULT TryCreateClient(out DebugClient clientResult)
        {
            InitDelegate(ref createClient, Vtbl->CreateClient);
            /*HRESULT CreateClient(
            [Out, ComAliasName("IDebugClient")] out IntPtr Client);*/
            IntPtr client;
            HRESULT hr = createClient(Raw, out client);

            if (hr == HRESULT.S_OK)
                clientResult = new DebugClient(client);
            else
                clientResult = default(DebugClient);

            return hr;
        }

        #endregion
        #region GetOtherOutputMask

        /// <summary>
        /// The GetOtherOutputMask method returns the output mask for another client.
        /// </summary>
        /// <param name="client">[in] Specifies the client whose output mask is desired.</param>
        /// <returns>[out] Receives the output mask for the client. See DEBUG_OUTPUT_XXX for details on how to interpret this value.</returns>
        /// <remarks>
        /// For an overview of output in the debugger engine, see Input and Output.
        /// </remarks>
        public DEBUG_OUTPUT GetOtherOutputMask(IntPtr client)
        {
            DEBUG_OUTPUT mask;
            TryGetOtherOutputMask(client, out mask).ThrowDbgEngNotOK();

            return mask;
        }

        /// <summary>
        /// The GetOtherOutputMask method returns the output mask for another client.
        /// </summary>
        /// <param name="client">[in] Specifies the client whose output mask is desired.</param>
        /// <param name="mask">[out] Receives the output mask for the client. See DEBUG_OUTPUT_XXX for details on how to interpret this value.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of output in the debugger engine, see Input and Output.
        /// </remarks>
        public HRESULT TryGetOtherOutputMask(IntPtr client, out DEBUG_OUTPUT mask)
        {
            InitDelegate(ref getOtherOutputMask, Vtbl->GetOtherOutputMask);

            /*HRESULT GetOtherOutputMask(
            [In] IntPtr Client,
            [Out] out DEBUG_OUTPUT Mask);*/
            return getOtherOutputMask(Raw, client, out mask);
        }

        #endregion
        #region SetOtherOutputMask

        /// <summary>
        /// The SetOtherOutputMask method sets the output mask for another client.
        /// </summary>
        /// <param name="client">[in] Specifies the client whose output mask will be set.</param>
        /// <param name="mask">[in] Specifies the new output mask for the client. See DEBUG_OUTPUT_XXX for a description of the possible values for Mask.</param>
        /// <remarks>
        /// For an overview of output in the debugger engine, see Input and Output.
        /// </remarks>
        public void SetOtherOutputMask(IntPtr client, DEBUG_OUTPUT mask)
        {
            TrySetOtherOutputMask(client, mask).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetOtherOutputMask method sets the output mask for another client.
        /// </summary>
        /// <param name="client">[in] Specifies the client whose output mask will be set.</param>
        /// <param name="mask">[in] Specifies the new output mask for the client. See DEBUG_OUTPUT_XXX for a description of the possible values for Mask.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For an overview of output in the debugger engine, see Input and Output.
        /// </remarks>
        public HRESULT TrySetOtherOutputMask(IntPtr client, DEBUG_OUTPUT mask)
        {
            InitDelegate(ref setOtherOutputMask, Vtbl->SetOtherOutputMask);

            /*HRESULT SetOtherOutputMask(
            [In] IntPtr Client,
            [In] DEBUG_OUTPUT Mask);*/
            return setOtherOutputMask(Raw, client, mask);
        }

        #endregion
        #region OutputIdentity

        /// <summary>
        /// The OutputIdentity method formats and outputs a string describing the computer and user this client represents.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <param name="format">[in] Specifies a format string similar to the printf format string. However, this format string must only contain one formatting directive, %s, which will be replaced by a description of the computer and user this client represents.</param>
        /// <remarks>
        /// The specific content of the string varies with the operating system. If the client is remotely connected, some
        /// network information may also be present. For more information about client objects, see Client Objects.
        /// </remarks>
        public void OutputIdentity(DEBUG_OUTCTL outputControl, int flags, string format)
        {
            TryOutputIdentity(outputControl, flags, format).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputIdentity method formats and outputs a string describing the computer and user this client represents.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <param name="format">[in] Specifies a format string similar to the printf format string. However, this format string must only contain one formatting directive, %s, which will be replaced by a description of the computer and user this client represents.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The specific content of the string varies with the operating system. If the client is remotely connected, some
        /// network information may also be present. For more information about client objects, see Client Objects.
        /// </remarks>
        public HRESULT TryOutputIdentity(DEBUG_OUTCTL outputControl, int flags, string format)
        {
            InitDelegate(ref outputIdentity, Vtbl->OutputIdentity);

            /*HRESULT OutputIdentity(
            [In] DEBUG_OUTCTL OutputControl,
            [In] int Flags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Format);*/
            return outputIdentity(Raw, outputControl, flags, format);
        }

        #endregion
        #region FlushCallbacks

        /// <summary>
        /// The FlushCallbacks method forces any remaining buffered output to be delivered to the <see cref="IDebugOutputCallbacks"/> object registered with this client.
        /// </summary>
        /// <remarks>
        /// The engine sometimes merges compatible callback requests to reduce callback overhead; small pieces of output are
        /// collected into larger groups to reduce the number of <see cref="IDebugOutputCallbacks.Output"/> calls. Using FlushCallbacks
        /// is necessary for a client to guarantee that all pending callbacks have been processed at a particular point. For
        /// example, a caller can flush callbacks before starting a lengthy operation outside of the engine so that pending
        /// callbacks are not delayed until after the operation. For more information about callbacks, see Callbacks.
        /// </remarks>
        public void FlushCallbacks()
        {
            TryFlushCallbacks().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The FlushCallbacks method forces any remaining buffered output to be delivered to the <see cref="IDebugOutputCallbacks"/> object registered with this client.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The engine sometimes merges compatible callback requests to reduce callback overhead; small pieces of output are
        /// collected into larger groups to reduce the number of <see cref="IDebugOutputCallbacks.Output"/> calls. Using FlushCallbacks
        /// is necessary for a client to guarantee that all pending callbacks have been processed at a particular point. For
        /// example, a caller can flush callbacks before starting a lengthy operation outside of the engine so that pending
        /// callbacks are not delayed until after the operation. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TryFlushCallbacks()
        {
            InitDelegate(ref flushCallbacks, Vtbl->FlushCallbacks);

            /*HRESULT FlushCallbacks();*/
            return flushCallbacks(Raw);
        }

        #endregion
        #endregion
        #region IDebugClient2
        #region IsKernelDebuggerEnabled

        /// <summary>
        /// The IsKernelDebuggerEnabled method checks whether kernel debugging is enabled for the local kernel.
        /// </summary>
        public bool IsKernelDebuggerEnabled
        {
            get
            {
                HRESULT hr = TryIsKernelDebuggerEnabled();
                hr.ThrowDbgEngFailed();

                return hr == HRESULT.S_OK;
            }
        }

        /// <summary>
        /// The IsKernelDebuggerEnabled method checks whether kernel debugging is enabled for the local kernel.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Kernel debugging is available for the local computer if the computer was booted by using the /debug boot switch.
        /// In some Windows installations, local kernel debugging is supported when other switches--such as /debugport--are
        /// used, but this is not a guaranteed feature of Windows and should not be relied on. For more information about kernel
        /// debugging on a single computer, see Performing Local Kernel Debugging. For more information about connecting to
        /// live kernel-mode targets, see Live Kernel-Mode Targets.
        /// </remarks>
        public HRESULT TryIsKernelDebuggerEnabled()
        {
            InitDelegate(ref isKernelDebuggerEnabled, Vtbl2->IsKernelDebuggerEnabled);

            /*HRESULT IsKernelDebuggerEnabled();*/
            return isKernelDebuggerEnabled(Raw);
        }

        #endregion
        #region WriteDumpFile2

        /// <summary>
        /// The WriteDumpFile2 method creates a user-mode or kernel-modecrash dump file.
        /// </summary>
        /// <param name="dumpFile">[in] Specifies the name of the dump file to create. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.</param>
        /// <param name="qualifier">[in] Specifies the type of dump file to create. For possible values, see DEBUG_DUMP_XXX.</param>
        /// <param name="formatFlags">[in] Specifies flags that determine the format of the dump file and--for user-mode minidumps--what information to include in the file.<para/>
        /// For details, see Remarks.</param>
        /// <param name="comment">[in, optional] Specifies a comment string to be included in the crash dump file. This string is displayed in the debugger console when the dump file is loaded.<para/>
        /// Some dump file formats do not support the storing of comment strings.</param>
        /// <remarks>
        /// The DEBUG_FORMAT_XXX bit-flags are used by WriteDumpFile2 and <see cref="WriteDumpFileWide"/> to
        /// determine the format of a crash dump file and, for user-mode Minidumps, what information to include in the file.
        /// The following bit-flags apply to all crash dump files. The following bit-flags can also be included for user-mode
        /// Minidumps. For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        public void WriteDumpFile2(string dumpFile, DEBUG_DUMP qualifier, DEBUG_FORMAT formatFlags, string comment)
        {
            TryWriteDumpFile2(dumpFile, qualifier, formatFlags, comment).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The WriteDumpFile2 method creates a user-mode or kernel-modecrash dump file.
        /// </summary>
        /// <param name="dumpFile">[in] Specifies the name of the dump file to create. DumpFile must include the file name extension. DumpFile can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.</param>
        /// <param name="qualifier">[in] Specifies the type of dump file to create. For possible values, see DEBUG_DUMP_XXX.</param>
        /// <param name="formatFlags">[in] Specifies flags that determine the format of the dump file and--for user-mode minidumps--what information to include in the file.<para/>
        /// For details, see Remarks.</param>
        /// <param name="comment">[in, optional] Specifies a comment string to be included in the crash dump file. This string is displayed in the debugger console when the dump file is loaded.<para/>
        /// Some dump file formats do not support the storing of comment strings.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The DEBUG_FORMAT_XXX bit-flags are used by WriteDumpFile2 and <see cref="WriteDumpFileWide"/> to
        /// determine the format of a crash dump file and, for user-mode Minidumps, what information to include in the file.
        /// The following bit-flags apply to all crash dump files. The following bit-flags can also be included for user-mode
        /// Minidumps. For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        public HRESULT TryWriteDumpFile2(string dumpFile, DEBUG_DUMP qualifier, DEBUG_FORMAT formatFlags, string comment)
        {
            InitDelegate(ref writeDumpFile2, Vtbl2->WriteDumpFile2);

            /*HRESULT WriteDumpFile2(
            [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile,
            [In] DEBUG_DUMP Qualifier,
            [In] DEBUG_FORMAT FormatFlags,
            [In, MarshalAs(UnmanagedType.LPStr)] string Comment);*/
            return writeDumpFile2(Raw, dumpFile, qualifier, formatFlags, comment);
        }

        #endregion
        #region AddDumpInformationFile

        /// <summary>
        /// The AddDumpInformationFile method registers additional files containing supporting information that will be used when opening a dump file.<para/>
        /// The Unicode version of this method is <see cref="AddDumpInformationFileWide"/>.
        /// </summary>
        /// <param name="infoFile">[in] Specifies the name of the file containing the supporting information.</param>
        /// <param name="type">[in] Specifies the type of the file InfoFile. Currently, only files containing paging file information are supported, and Type must be set to DEBUG_DUMP_FILE_PAGE_FILE_DUMP.</param>
        /// <remarks>
        /// If supporting information is to be used when opening a dump file, this method or <see cref="AddDumpInformationFileWide"/>
        /// must be called before <see cref="OpenDumpFile"/> is called. If a session has already started, this method cannot
        /// be used. For more information about crash dump files, see Dump File Targets.
        /// </remarks>
        public void AddDumpInformationFile(string infoFile, DEBUG_DUMP_FILE type)
        {
            TryAddDumpInformationFile(infoFile, type).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The AddDumpInformationFile method registers additional files containing supporting information that will be used when opening a dump file.<para/>
        /// The Unicode version of this method is <see cref="AddDumpInformationFileWide"/>.
        /// </summary>
        /// <param name="infoFile">[in] Specifies the name of the file containing the supporting information.</param>
        /// <param name="type">[in] Specifies the type of the file InfoFile. Currently, only files containing paging file information are supported, and Type must be set to DEBUG_DUMP_FILE_PAGE_FILE_DUMP.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If supporting information is to be used when opening a dump file, this method or <see cref="AddDumpInformationFileWide"/>
        /// must be called before <see cref="OpenDumpFile"/> is called. If a session has already started, this method cannot
        /// be used. For more information about crash dump files, see Dump File Targets.
        /// </remarks>
        public HRESULT TryAddDumpInformationFile(string infoFile, DEBUG_DUMP_FILE type)
        {
            InitDelegate(ref addDumpInformationFile, Vtbl2->AddDumpInformationFile);

            /*HRESULT AddDumpInformationFile(
            [In, MarshalAs(UnmanagedType.LPStr)] string InfoFile,
            [In] DEBUG_DUMP_FILE Type);*/
            return addDumpInformationFile(Raw, infoFile, type);
        }

        #endregion
        #region EndProcessServer

        /// <summary>
        /// The EndProcessServer method requests that a process server be shut down.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to shut down. This handle must have been previously returned by <see cref="ConnectProcessServer"/>.</param>
        /// <remarks>
        /// For more information about process servers and remote debugging, see Process Servers, Kernel Connection Servers,
        /// and Smart Clients.
        /// </remarks>
        public void EndProcessServer(long server)
        {
            TryEndProcessServer(server).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The EndProcessServer method requests that a process server be shut down.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to shut down. This handle must have been previously returned by <see cref="ConnectProcessServer"/>.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about process servers and remote debugging, see Process Servers, Kernel Connection Servers,
        /// and Smart Clients.
        /// </remarks>
        public HRESULT TryEndProcessServer(long server)
        {
            InitDelegate(ref endProcessServer, Vtbl2->EndProcessServer);

            /*HRESULT EndProcessServer(
            [In] long Server);*/
            return endProcessServer(Raw, server);
        }

        #endregion
        #region WaitForProcessServerEnd

        /// <summary>
        /// The WaitForProcessServerEnd method waits for a local process server to exit.
        /// </summary>
        /// <param name="timeout">[in] Specifies how long in milliseconds to wait for a process server to exit. If Timeout is INFINITE, this method will not return until a process server has ended.</param>
        /// <remarks>
        /// This method will only wait for the first local process server to end. After a process server has ended, subsequent
        /// calls to this method will return immediately. For more information about process servers and remote debugging,
        /// see Process Servers, Kernel Connection Servers, and Smart Clients. The constant INFINITE is defined in Winbase.h.
        /// </remarks>
        public void WaitForProcessServerEnd(int timeout)
        {
            TryWaitForProcessServerEnd(timeout).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The WaitForProcessServerEnd method waits for a local process server to exit.
        /// </summary>
        /// <param name="timeout">[in] Specifies how long in milliseconds to wait for a process server to exit. If Timeout is INFINITE, this method will not return until a process server has ended.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method will only wait for the first local process server to end. After a process server has ended, subsequent
        /// calls to this method will return immediately. For more information about process servers and remote debugging,
        /// see Process Servers, Kernel Connection Servers, and Smart Clients. The constant INFINITE is defined in Winbase.h.
        /// </remarks>
        public HRESULT TryWaitForProcessServerEnd(int timeout)
        {
            InitDelegate(ref waitForProcessServerEnd, Vtbl2->WaitForProcessServerEnd);

            /*HRESULT WaitForProcessServerEnd(
            [In] int Timeout);*/
            return waitForProcessServerEnd(Raw, timeout);
        }

        #endregion
        #region TerminateCurrentProcess

        /// <summary>
        /// The TerminateCurrentProcess method attempts to terminate the current process.
        /// </summary>
        /// <remarks>
        /// Only live user-modeprocesses are terminated by this method. For other targets, the target is detached from the
        /// debugger engine without terminating. For more information about creating and attaching to live user-mode targets,
        /// see Live User-Mode Targets.
        /// </remarks>
        public void TerminateCurrentProcess()
        {
            TryTerminateCurrentProcess().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The TerminateCurrentProcess method attempts to terminate the current process.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Only live user-modeprocesses are terminated by this method. For other targets, the target is detached from the
        /// debugger engine without terminating. For more information about creating and attaching to live user-mode targets,
        /// see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryTerminateCurrentProcess()
        {
            InitDelegate(ref terminateCurrentProcess, Vtbl2->TerminateCurrentProcess);

            /*HRESULT TerminateCurrentProcess();*/
            return terminateCurrentProcess(Raw);
        }

        #endregion
        #region DetachCurrentProcess

        /// <summary>
        /// The DetachCurrentProcess method detaches the debugger engine from the current process, resuming all its threads.
        /// </summary>
        /// <remarks>
        /// The target must be running on Windows XP or a later versions of Windows. For more information about creating and
        /// attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public void DetachCurrentProcess()
        {
            TryDetachCurrentProcess().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The DetachCurrentProcess method detaches the debugger engine from the current process, resuming all its threads.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The target must be running on Windows XP or a later versions of Windows. For more information about creating and
        /// attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryDetachCurrentProcess()
        {
            InitDelegate(ref detachCurrentProcess, Vtbl2->DetachCurrentProcess);

            /*HRESULT DetachCurrentProcess();*/
            return detachCurrentProcess(Raw);
        }

        #endregion
        #region AbandonCurrentProcess

        /// <summary>
        /// The AbandonCurrentProcess method removes the current process from the debugger engine's process list without detaching or terminating the process.
        /// </summary>
        /// <remarks>
        /// This method is only available for live user-mode debugging. The target must be running on Windows XP or a later
        /// version of Windows. Windows will continue to consider this process as being debugged, and so the process will remain
        /// suspended. This method allows the debugger to be shut down and a new debugger to attach to the process. See Live
        /// User-Mode Targets and Re-attaching to the Target Application for more information.
        /// </remarks>
        public void AbandonCurrentProcess()
        {
            TryAbandonCurrentProcess().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The AbandonCurrentProcess method removes the current process from the debugger engine's process list without detaching or terminating the process.
        /// </summary>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available for live user-mode debugging. The target must be running on Windows XP or a later
        /// version of Windows. Windows will continue to consider this process as being debugged, and so the process will remain
        /// suspended. This method allows the debugger to be shut down and a new debugger to attach to the process. See Live
        /// User-Mode Targets and Re-attaching to the Target Application for more information.
        /// </remarks>
        public HRESULT TryAbandonCurrentProcess()
        {
            InitDelegate(ref abandonCurrentProcess, Vtbl2->AbandonCurrentProcess);

            /*HRESULT AbandonCurrentProcess();*/
            return abandonCurrentProcess(Raw);
        }

        #endregion
        #endregion
        #region IDebugClient3
        #region GetRunningProcessSystemIdByExecutableNameWide

        /// <summary>
        /// The GetRunningProcessSystemIdByExecutableNameWide method searches for a process with a given executable file name and return its process ID.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to search for the executable name. If Server is zero, the engine will search for the executable name among the processes running on the local computer.</param>
        /// <param name="exeName">[in] Specifies the executable file name for which to search.</param>
        /// <param name="flags">[in] Specifies a bit-set that controls how the executable name is matched. The following flags may be present: If this flag is not set, this method will not use path names when searching for the process.</param>
        /// <returns>[out] Receives the process ID of the first process to match ExeName.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public int GetRunningProcessSystemIdByExecutableNameWide(long server, string exeName, DEBUG_GET_PROC flags)
        {
            int id;
            TryGetRunningProcessSystemIdByExecutableNameWide(server, exeName, flags, out id).ThrowDbgEngNotOK();

            return id;
        }

        /// <summary>
        /// The GetRunningProcessSystemIdByExecutableNameWide method searches for a process with a given executable file name and return its process ID.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to search for the executable name. If Server is zero, the engine will search for the executable name among the processes running on the local computer.</param>
        /// <param name="exeName">[in] Specifies the executable file name for which to search.</param>
        /// <param name="flags">[in] Specifies a bit-set that controls how the executable name is matched. The following flags may be present: If this flag is not set, this method will not use path names when searching for the process.</param>
        /// <param name="id">[out] Receives the process ID of the first process to match ExeName.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryGetRunningProcessSystemIdByExecutableNameWide(long server, string exeName, DEBUG_GET_PROC flags, out int id)
        {
            InitDelegate(ref getRunningProcessSystemIdByExecutableNameWide, Vtbl3->GetRunningProcessSystemIdByExecutableNameWide);

            /*HRESULT GetRunningProcessSystemIdByExecutableNameWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ExeName,
            [In] DEBUG_GET_PROC Flags,
            [Out] out int Id);*/
            return getRunningProcessSystemIdByExecutableNameWide(Raw, server, exeName, flags, out id);
        }

        #endregion
        #region GetRunningProcessDescriptionWide

        /// <summary>
        /// The GetRunningProcessDescriptionWide method returns a description of the process that includes the executable image name, the service names, the MTS package names, and the command line.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to query for the process description. If Server is zero, the engine will query information about the local process directly.</param>
        /// <param name="systemId">[in] Specifies the process ID of the process whose description is desired.</param>
        /// <param name="flags">[in] Specifies a bit-set containing options that affect the behavior of this method. Flags can contain the following bit flags:</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public GetRunningProcessDescriptionWideResult GetRunningProcessDescriptionWide(long server, int systemId, DEBUG_PROC_DESC flags)
        {
            GetRunningProcessDescriptionWideResult result;
            TryGetRunningProcessDescriptionWide(server, systemId, flags, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetRunningProcessDescriptionWide method returns a description of the process that includes the executable image name, the service names, the MTS package names, and the command line.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to query for the process description. If Server is zero, the engine will query information about the local process directly.</param>
        /// <param name="systemId">[in] Specifies the process ID of the process whose description is desired.</param>
        /// <param name="flags">[in] Specifies a bit-set containing options that affect the behavior of this method. Flags can contain the following bit flags:</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. For more information about creating and attaching to
        /// live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryGetRunningProcessDescriptionWide(long server, int systemId, DEBUG_PROC_DESC flags, out GetRunningProcessDescriptionWideResult result)
        {
            InitDelegate(ref getRunningProcessDescriptionWide, Vtbl3->GetRunningProcessDescriptionWide);
            /*HRESULT GetRunningProcessDescriptionWide(
            [In] long Server,
            [In] int SystemId,
            [In] DEBUG_PROC_DESC Flags,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] ExeName,
            [In] int ExeNameSize,
            [Out] out int ActualExeNameSize,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 7)] char[] Description,
            [In] int DescriptionSize,
            [Out] out int ActualDescriptionSize);*/
            char[] exeName;
            int exeNameSize = 0;
            int actualExeNameSize;
            char[] description;
            int descriptionSize = 0;
            int actualDescriptionSize;
            HRESULT hr = getRunningProcessDescriptionWide(Raw, server, systemId, flags, null, exeNameSize, out actualExeNameSize, null, descriptionSize, out actualDescriptionSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            exeNameSize = actualExeNameSize;
            exeName = new char[exeNameSize];
            descriptionSize = actualDescriptionSize;
            description = new char[descriptionSize];
            hr = getRunningProcessDescriptionWide(Raw, server, systemId, flags, exeName, exeNameSize, out actualExeNameSize, description, descriptionSize, out actualDescriptionSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetRunningProcessDescriptionWideResult(CreateString(exeName, actualExeNameSize), CreateString(description, actualDescriptionSize));

                return hr;
            }

            fail:
            result = default(GetRunningProcessDescriptionWideResult);

            return hr;
        }

        #endregion
        #region CreateProcessWide

        /// <summary>
        /// The CreateProcessWide method creates a process from the specified command line.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use when attaching to the process. If Server is zero, the engine will create a local process without using a process server.</param>
        /// <param name="commandLine">[in] Specifies the command line to execute to create the new process. The CreateProcessWide method might modify the contents of the string that you supply in this parameter.<para/>
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).<para/>
        /// Passing a constant string in this parameter can lead to an access violation.</param>
        /// <param name="createFlags">[in] Specifies the flags to use when creating the process. For details on these flags, see the CreateFlags member of the <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CreateFlags contains either of the flags DEBUG_PROCESS
        /// or DEBUG_ONLY_THIS_PROCESS, the engine also attaches to the newly created process. This behavior is similar to
        /// that of <see cref="CreateProcessAndAttach2"/> when its argument ProcessId is set to zero. For more
        /// information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public void CreateProcessWide(long server, string commandLine, DEBUG_CREATE_PROCESS createFlags)
        {
            TryCreateProcessWide(server, commandLine, createFlags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CreateProcessWide method creates a process from the specified command line.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use when attaching to the process. If Server is zero, the engine will create a local process without using a process server.</param>
        /// <param name="commandLine">[in] Specifies the command line to execute to create the new process. The CreateProcessWide method might modify the contents of the string that you supply in this parameter.<para/>
        /// Therefore, this parameter cannot be a pointer to read-only memory (such as a const variable or a literal string).<para/>
        /// Passing a constant string in this parameter can lead to an access violation.</param>
        /// <param name="createFlags">[in] Specifies the flags to use when creating the process. For details on these flags, see the CreateFlags member of the <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CreateFlags contains either of the flags DEBUG_PROCESS
        /// or DEBUG_ONLY_THIS_PROCESS, the engine also attaches to the newly created process. This behavior is similar to
        /// that of <see cref="CreateProcessAndAttach2"/> when its argument ProcessId is set to zero. For more
        /// information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryCreateProcessWide(long server, string commandLine, DEBUG_CREATE_PROCESS createFlags)
        {
            InitDelegate(ref createProcessWide, Vtbl3->CreateProcessWide);

            /*HRESULT CreateProcessWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS CreateFlags);*/
            return createProcessWide(Raw, server, commandLine, createFlags);
        }

        #endregion
        #region CreateProcessAndAttachWide

        /// <summary>
        /// The CreateProcessAndAttachWide method creates a process from a specified command line, then attach to another user-mode process.<para/>
        /// The created process is suspended and only allowed to execute when the attach has completed. This allows rough synchronization when debugging both, client and server processes.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="commandLine">[in, optional] Specifies the command line to execute to create the new process. If CommandLine is NULL, then no process is created and these methods attach to an existing process, as <see cref="AttachProcess"/> does.</param>
        /// <param name="createFlags">[in] Specifies the flags to use when creating the process. For details on these flags, see <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/>.CreateFlags.</param>
        /// <param name="processId">[in] Specifies the process ID of the target process the debugger will attach to. If ProcessId is zero, the debugger will attach to the process it created from CommandLine.</param>
        /// <param name="attachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see DEBUG_ATTACH_XXX.</param>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CommandLine is not NULL and ProcessId is not zero,
        /// then the engine will create the process in a suspended state. The engine will resume this newly created process
        /// after it successfully connects to the process specified in ProcessId. The engine does not completely attach to
        /// the process until the <see cref="DebugControl.WaitForEvent"/> method has been called. Only after the process has
        /// generated an event -- for example, the create-process event -- does it become available in the debugger session.
        /// For more information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public void CreateProcessAndAttachWide(long server, string commandLine, DEBUG_CREATE_PROCESS createFlags, int processId, DEBUG_ATTACH attachFlags)
        {
            TryCreateProcessAndAttachWide(server, commandLine, createFlags, processId, attachFlags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CreateProcessAndAttachWide method creates a process from a specified command line, then attach to another user-mode process.<para/>
        /// The created process is suspended and only allowed to execute when the attach has completed. This allows rough synchronization when debugging both, client and server processes.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="commandLine">[in, optional] Specifies the command line to execute to create the new process. If CommandLine is NULL, then no process is created and these methods attach to an existing process, as <see cref="AttachProcess"/> does.</param>
        /// <param name="createFlags">[in] Specifies the flags to use when creating the process. For details on these flags, see <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/>.CreateFlags.</param>
        /// <param name="processId">[in] Specifies the process ID of the target process the debugger will attach to. If ProcessId is zero, the debugger will attach to the process it created from CommandLine.</param>
        /// <param name="attachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see DEBUG_ATTACH_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CommandLine is not NULL and ProcessId is not zero,
        /// then the engine will create the process in a suspended state. The engine will resume this newly created process
        /// after it successfully connects to the process specified in ProcessId. The engine does not completely attach to
        /// the process until the <see cref="DebugControl.WaitForEvent"/> method has been called. Only after the process has
        /// generated an event -- for example, the create-process event -- does it become available in the debugger session.
        /// For more information about creating and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryCreateProcessAndAttachWide(long server, string commandLine, DEBUG_CREATE_PROCESS createFlags, int processId, DEBUG_ATTACH attachFlags)
        {
            InitDelegate(ref createProcessAndAttachWide, Vtbl3->CreateProcessAndAttachWide);

            /*HRESULT CreateProcessAndAttachWide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] DEBUG_CREATE_PROCESS CreateFlags,
            [In] int ProcessId,
            [In] DEBUG_ATTACH AttachFlags);*/
            return createProcessAndAttachWide(Raw, server, commandLine, createFlags, processId, attachFlags);
        }

        #endregion
        #endregion
        #region IDebugClient4
        #region NumberDumpFiles

        /// <summary>
        /// The GetNumberDumpFiles method returns the number of files containing supporting information that were used when opening the current dump target.
        /// </summary>
        public int NumberDumpFiles
        {
            get
            {
                int number;
                TryGetNumberDumpFiles(out number).ThrowDbgEngNotOK();

                return number;
            }
        }

        /// <summary>
        /// The GetNumberDumpFiles method returns the number of files containing supporting information that were used when opening the current dump target.
        /// </summary>
        /// <param name="number">[out] Receives the number of files.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        public HRESULT TryGetNumberDumpFiles(out int number)
        {
            InitDelegate(ref getNumberDumpFiles, Vtbl4->GetNumberDumpFiles);

            /*HRESULT GetNumberDumpFiles(
            [Out] out int Number);*/
            return getNumberDumpFiles(Raw, out number);
        }

        #endregion
        #region OpenDumpFileWide

        /// <summary>
        /// The OpenDumpFileWide method opens a dump file as a debugger target.
        /// </summary>
        /// <param name="fileName">[in, optional] Specifies the name of the dump file to open -- unless FileHandle is not zero, in which case FileName is used only when the engine is queried for the name of the dump file.<para/>
        /// FileName must include the file name extension. FileName can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// FileName can also be in the form of a file URL, starting with "file://". If FileName specifies a cabinet (.cab) file, the cabinet file is searched for the first file with extension .kdmp, then .hdmp, then .mdmp, and finally .dmp.</param>
        /// <param name="fileHandle">[in] Specifies the file handle of the dump file to open. If FileHandle is zero, FileName is used to open the dump file.<para/>
        /// Otherwise, if FileName is not NULL, the engine returns it when queried for the name of the dump file. If FileHandle is not zero and FileName is NULL, the engine will return HandleOnly for the file name.</param>
        /// <remarks>
        /// The ASCII version of this method is <see cref="OpenDumpFile"/>.
        /// </remarks>
        public void OpenDumpFileWide(string fileName, long fileHandle)
        {
            TryOpenDumpFileWide(fileName, fileHandle).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OpenDumpFileWide method opens a dump file as a debugger target.
        /// </summary>
        /// <param name="fileName">[in, optional] Specifies the name of the dump file to open -- unless FileHandle is not zero, in which case FileName is used only when the engine is queried for the name of the dump file.<para/>
        /// FileName must include the file name extension. FileName can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// FileName can also be in the form of a file URL, starting with "file://". If FileName specifies a cabinet (.cab) file, the cabinet file is searched for the first file with extension .kdmp, then .hdmp, then .mdmp, and finally .dmp.</param>
        /// <param name="fileHandle">[in] Specifies the file handle of the dump file to open. If FileHandle is zero, FileName is used to open the dump file.<para/>
        /// Otherwise, if FileName is not NULL, the engine returns it when queried for the name of the dump file. If FileHandle is not zero and FileName is NULL, the engine will return HandleOnly for the file name.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The ASCII version of this method is <see cref="OpenDumpFile"/>.
        /// </remarks>
        public HRESULT TryOpenDumpFileWide(string fileName, long fileHandle)
        {
            InitDelegate(ref openDumpFileWide, Vtbl4->OpenDumpFileWide);

            /*HRESULT OpenDumpFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string FileName,
            [In] long FileHandle);*/
            return openDumpFileWide(Raw, fileName, fileHandle);
        }

        #endregion
        #region WriteDumpFileWide

        /// <summary>
        /// The WriteDumpFileWide method creates a user-mode or kernel-modecrash dump file.
        /// </summary>
        /// <param name="dumpFile">[in, optional] Specifies the name of the dump file to create. FileName must include the file name extension. FileName can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// If FileHandle is not NULL, FileName is ignored (except when writing status messages to the debugger console).</param>
        /// <param name="fileHandle">[in] Specifies the file handle of the file to write the crash dump to. If FileHandle is NULL, the file specified in FileName is used instead.</param>
        /// <param name="qualifier">[in] Specifies the type of dump to create. For possible values, see DEBUG_DUMP_XXX.</param>
        /// <param name="formatFlags">[in] Specifies flags that determine the format of the dump file and--for user-mode minidumps--what information to include in the file.<para/>
        /// For details, see DEBUG_FORMAT_XXX.</param>
        /// <param name="comment">[in, optional] Specifies a comment string to be included in the crash dump file. This string is displayed in the debugger console when the dump file is loaded.</param>
        /// <remarks>
        /// For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        public void WriteDumpFileWide(string dumpFile, long fileHandle, DEBUG_DUMP qualifier, DEBUG_FORMAT formatFlags, string comment)
        {
            TryWriteDumpFileWide(dumpFile, fileHandle, qualifier, formatFlags, comment).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The WriteDumpFileWide method creates a user-mode or kernel-modecrash dump file.
        /// </summary>
        /// <param name="dumpFile">[in, optional] Specifies the name of the dump file to create. FileName must include the file name extension. FileName can include a relative or absolute path; relative paths are relative to the directory in which the debugger was started.<para/>
        /// If FileHandle is not NULL, FileName is ignored (except when writing status messages to the debugger console).</param>
        /// <param name="fileHandle">[in] Specifies the file handle of the file to write the crash dump to. If FileHandle is NULL, the file specified in FileName is used instead.</param>
        /// <param name="qualifier">[in] Specifies the type of dump to create. For possible values, see DEBUG_DUMP_XXX.</param>
        /// <param name="formatFlags">[in] Specifies flags that determine the format of the dump file and--for user-mode minidumps--what information to include in the file.<para/>
        /// For details, see DEBUG_FORMAT_XXX.</param>
        /// <param name="comment">[in, optional] Specifies a comment string to be included in the crash dump file. This string is displayed in the debugger console when the dump file is loaded.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        public HRESULT TryWriteDumpFileWide(string dumpFile, long fileHandle, DEBUG_DUMP qualifier, DEBUG_FORMAT formatFlags, string comment)
        {
            InitDelegate(ref writeDumpFileWide, Vtbl4->WriteDumpFileWide);

            /*HRESULT WriteDumpFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string DumpFile,
            [In] long FileHandle,
            [In] DEBUG_DUMP Qualifier,
            [In] DEBUG_FORMAT FormatFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Comment);*/
            return writeDumpFileWide(Raw, dumpFile, fileHandle, qualifier, formatFlags, comment);
        }

        #endregion
        #region AddDumpInformationFileWide

        /// <summary>
        /// The AddDumpInformationFileWide method registers additional files containing supporting information that will be used when opening a dump file.<para/>
        /// The ASCII version of this method is <see cref="AddDumpInformationFile"/>.
        /// </summary>
        /// <param name="fileName">[in, optional] Specifies the name of the file containing the supporting information. If FileHandle is not zero, FileName is used only for informational purposes.</param>
        /// <param name="fileHandle">[in] Specifies the handle of the file containing the supporting information. If FileHandle is zero, the file named in FileName is used.</param>
        /// <param name="type">[in] Specifies the type of the file in FileName or FileHandle. Currently, only files containing paging file information are supported, and Type must be set to DEBUG_DUMP_FILE_PAGE_FILE_DUMP.</param>
        /// <remarks>
        /// If supporting information is to be used when opening a dump file, this method or <see cref="AddDumpInformationFile"/>
        /// must be called before <see cref="OpenDumpFile"/> is called. If a session has already started, this method cannot
        /// be used. For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        public void AddDumpInformationFileWide(string fileName, long fileHandle, DEBUG_DUMP_FILE type)
        {
            TryAddDumpInformationFileWide(fileName, fileHandle, type).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The AddDumpInformationFileWide method registers additional files containing supporting information that will be used when opening a dump file.<para/>
        /// The ASCII version of this method is <see cref="AddDumpInformationFile"/>.
        /// </summary>
        /// <param name="fileName">[in, optional] Specifies the name of the file containing the supporting information. If FileHandle is not zero, FileName is used only for informational purposes.</param>
        /// <param name="fileHandle">[in] Specifies the handle of the file containing the supporting information. If FileHandle is zero, the file named in FileName is used.</param>
        /// <param name="type">[in] Specifies the type of the file in FileName or FileHandle. Currently, only files containing paging file information are supported, and Type must be set to DEBUG_DUMP_FILE_PAGE_FILE_DUMP.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// If supporting information is to be used when opening a dump file, this method or <see cref="AddDumpInformationFile"/>
        /// must be called before <see cref="OpenDumpFile"/> is called. If a session has already started, this method cannot
        /// be used. For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        public HRESULT TryAddDumpInformationFileWide(string fileName, long fileHandle, DEBUG_DUMP_FILE type)
        {
            InitDelegate(ref addDumpInformationFileWide, Vtbl4->AddDumpInformationFileWide);

            /*HRESULT AddDumpInformationFileWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string FileName,
            [In] long FileHandle,
            [In] DEBUG_DUMP_FILE Type);*/
            return addDumpInformationFileWide(Raw, fileName, fileHandle, type);
        }

        #endregion
        #region GetDumpFile

        /// <summary>
        /// The GetDumpFile method describes the files containing supporting information that were used when opening the current dump target.
        /// </summary>
        /// <param name="index">[in] Specifies which file to describe. Index can take values between zero and the number of files minus one; the number of files can be found by using <see cref="NumberDumpFiles"/>.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        public GetDumpFileResult GetDumpFile(int index)
        {
            GetDumpFileResult result;
            TryGetDumpFile(index, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetDumpFile method describes the files containing supporting information that were used when opening the current dump target.
        /// </summary>
        /// <param name="index">[in] Specifies which file to describe. Index can take values between zero and the number of files minus one; the number of files can be found by using <see cref="NumberDumpFiles"/>.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        public HRESULT TryGetDumpFile(int index, out GetDumpFileResult result)
        {
            InitDelegate(ref getDumpFile, Vtbl4->GetDumpFile);
            /*HRESULT GetDumpFile(
            [In] int Index,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize,
            [Out] out long Handle,
            [Out] out int Type);*/
            char[] buffer;
            int bufferSize = 0;
            int nameSize;
            long handle;
            int type;
            HRESULT hr = getDumpFile(Raw, index, null, bufferSize, out nameSize, out handle, out type);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = nameSize;
            buffer = new char[bufferSize];
            hr = getDumpFile(Raw, index, buffer, bufferSize, out nameSize, out handle, out type);

            if (hr == HRESULT.S_OK)
            {
                result = new GetDumpFileResult(CreateString(buffer, nameSize), handle, type);

                return hr;
            }

            fail:
            result = default(GetDumpFileResult);

            return hr;
        }

        #endregion
        #region GetDumpFileWide

        /// <summary>
        /// The GetDumpFileWide method describes the files containing supporting information that were used when opening the current dump target.
        /// </summary>
        /// <param name="index">[in] Specifies which file to describe. Index can take values between zero and the number of files minus one; the number of files can be found by using <see cref="NumberDumpFiles"/>.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        public GetDumpFileWideResult GetDumpFileWide(int index)
        {
            GetDumpFileWideResult result;
            TryGetDumpFileWide(index, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetDumpFileWide method describes the files containing supporting information that were used when opening the current dump target.
        /// </summary>
        /// <param name="index">[in] Specifies which file to describe. Index can take values between zero and the number of files minus one; the number of files can be found by using <see cref="NumberDumpFiles"/>.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about crash dump files, see Dump-File Targets.
        /// </remarks>
        public HRESULT TryGetDumpFileWide(int index, out GetDumpFileWideResult result)
        {
            InitDelegate(ref getDumpFileWide, Vtbl4->GetDumpFileWide);
            /*HRESULT GetDumpFileWide(
            [In] int Index,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int NameSize,
            [Out] out long Handle,
            [Out] out int Type);*/
            char[] buffer;
            int bufferSize = 0;
            int nameSize;
            long handle;
            int type;
            HRESULT hr = getDumpFileWide(Raw, index, null, bufferSize, out nameSize, out handle, out type);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = nameSize;
            buffer = new char[bufferSize];
            hr = getDumpFileWide(Raw, index, buffer, bufferSize, out nameSize, out handle, out type);

            if (hr == HRESULT.S_OK)
            {
                result = new GetDumpFileWideResult(CreateString(buffer, nameSize), handle, type);

                return hr;
            }

            fail:
            result = default(GetDumpFileWideResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugClient5
        #region KernelConnectionOptionsWide

        /// <summary>
        /// The GetKernelConnectionOptionsWide method returns the connection options for the current kernel target.
        /// </summary>
        public string KernelConnectionOptionsWide
        {
            get
            {
                string bufferResult;
                TryGetKernelConnectionOptionsWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetKernelConnectionOptionsWide(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetKernelConnectionOptionsWide method returns the connection options for the current kernel target.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Specifies the buffer to receive the connection options.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live kernel targets that are not local and not connected through eXDI. The connection
        /// options returned are the same options used to connect to the kernel. For more information about connecting to live
        /// kernel-mode targets, see Live Kernel-Mode Targets.
        /// </remarks>
        public HRESULT TryGetKernelConnectionOptionsWide(out string bufferResult)
        {
            InitDelegate(ref getKernelConnectionOptionsWide, Vtbl5->GetKernelConnectionOptionsWide);
            /*HRESULT GetKernelConnectionOptionsWide(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int OptionsSize);*/
            char[] buffer;
            int bufferSize = 0;
            int optionsSize;
            HRESULT hr = getKernelConnectionOptionsWide(Raw, null, bufferSize, out optionsSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = optionsSize;
            buffer = new char[bufferSize];
            hr = getKernelConnectionOptionsWide(Raw, buffer, bufferSize, out optionsSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, optionsSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// The SetKernelConnectionOptionsWide method updates some of the connection options for a live kernel target.
        /// </summary>
        /// <param name="options">[in] Specifies the connection options to update. The possible values are:</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live kernel targets that are not local and not connected through eXDI. This method
        /// is reentrant. For more information about connecting to live kernel-mode targets, see Live Kernel-Mode Targets.
        /// </remarks>
        public HRESULT TrySetKernelConnectionOptionsWide(string options)
        {
            InitDelegate(ref setKernelConnectionOptionsWide, Vtbl5->SetKernelConnectionOptionsWide);

            /*HRESULT SetKernelConnectionOptionsWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Options);*/
            return setKernelConnectionOptionsWide(Raw, options);
        }

        #endregion
        #region OutputCallbacksWide

        /// <summary>
        /// The GetOutputCallbacksWide method returns the output callbacks object registered with the client.
        /// </summary>
        public IDebugOutputCallbacksWide OutputCallbacksWide
        {
            get
            {
                IDebugOutputCallbacksWide callbacks;
                TryGetOutputCallbacksWide(out callbacks).ThrowDbgEngNotOK();

                return callbacks;
            }
            set
            {
                TrySetOutputCallbacksWide(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetOutputCallbacksWide method returns the output callbacks object registered with the client.
        /// </summary>
        /// <param name="callbacks">[out] Receives an interface pointer to the <see cref="IDebugOutputCallbacks"/> object registered with the client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugOutputCallbacks"/> or IDebugOutputCallbacksWide object registered
        /// with it for output. If no output callbacks object is registered with the client, the value of Callbacks will be
        /// set to NULL. The IDebugOutputCallbacksWide interface extends the COM interface IUnknown. Before returning the IDebugOutputCallbacksWide
        /// object specified by Callbacks, the engine calls its IUnknown::AddRef method. When this object is no longer needed,
        /// its IUnknown::Release method should be called. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TryGetOutputCallbacksWide(out IDebugOutputCallbacksWide callbacks)
        {
            InitDelegate(ref getOutputCallbacksWide, Vtbl5->GetOutputCallbacksWide);

            /*HRESULT GetOutputCallbacksWide(
            [Out] out IDebugOutputCallbacksWide Callbacks);*/
            return getOutputCallbacksWide(Raw, out callbacks);
        }

        /// <summary>
        /// The SetOutputCallbacksWide method registers an output callbacks object with this client.
        /// </summary>
        /// <param name="callbacks">[in] Specifies the interface pointer to the output callbacks object to register with this client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugOutputCallbacks"/> or IDebugOutputCallbacksWide object registered
        /// with it for output. The IDebugOutputCallbacksWide interface extends the COM interface IUnknown. SetOutputCallbacks
        /// and SetOutputCAllbacksWide call the IUnknown::AddRef method in the object specified by Callbacks. The IUnknown::Release
        /// method of this interface will be called the next time SetOutputCallbacks or SetOutputCallbacksWide is called on
        /// this client, or when this client is deleted. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TrySetOutputCallbacksWide(IDebugOutputCallbacksWide callbacks)
        {
            InitDelegate(ref setOutputCallbacksWide, Vtbl5->SetOutputCallbacksWide);

            /*HRESULT SetOutputCallbacksWide(
            [In] IDebugOutputCallbacksWide Callbacks);*/
            return setOutputCallbacksWide(Raw, callbacks);
        }

        #endregion
        #region OutputLinePrefixWide

        /// <summary>
        /// Gets or sets a Unicode character string prefix for output lines.
        /// </summary>
        public string OutputLinePrefixWide
        {
            get
            {
                string bufferResult;
                TryGetOutputLinePrefixWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetOutputLinePrefixWide(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// Gets a Unicode character string prefix for output lines.
        /// </summary>
        /// <param name="bufferResult">[out] The pointer to the buffer of the prefix.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryGetOutputLinePrefixWide(out string bufferResult)
        {
            InitDelegate(ref getOutputLinePrefixWide, Vtbl5->GetOutputLinePrefixWide);
            /*HRESULT GetOutputLinePrefixWide(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int PrefixSize);*/
            char[] buffer;
            int bufferSize = 0;
            int prefixSize;
            HRESULT hr = getOutputLinePrefixWide(Raw, null, bufferSize, out prefixSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = prefixSize;
            buffer = new char[bufferSize];
            hr = getOutputLinePrefixWide(Raw, buffer, bufferSize, out prefixSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, prefixSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// Sets a wide string prefix for output lines.
        /// </summary>
        /// <param name="prefix">[in, optional] The pointer to a Unicode character prefix string.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TrySetOutputLinePrefixWide(string prefix)
        {
            InitDelegate(ref setOutputLinePrefixWide, Vtbl5->SetOutputLinePrefixWide);

            /*HRESULT SetOutputLinePrefixWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Prefix);*/
            return setOutputLinePrefixWide(Raw, prefix);
        }

        #endregion
        #region IdentityWide

        /// <summary>
        /// The GetIdentityWide method returns a string describing the computer and user this client represents.
        /// </summary>
        public string IdentityWide
        {
            get
            {
                string bufferResult;
                TryGetIdentityWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
        }

        /// <summary>
        /// The GetIdentityWide method returns a string describing the computer and user this client represents.
        /// </summary>
        /// <param name="bufferResult">[out, optional] Specifies the buffer to receive the string. If Buffer is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The specific content of the string varies with the operating system. If the client is remotely connected, some
        /// network information may also be present. For more information about client objects, see Client Objects.
        /// </remarks>
        public HRESULT TryGetIdentityWide(out string bufferResult)
        {
            InitDelegate(ref getIdentityWide, Vtbl5->GetIdentityWide);
            /*HRESULT GetIdentityWide(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int IdentitySize);*/
            char[] buffer;
            int bufferSize = 0;
            int identitySize;
            HRESULT hr = getIdentityWide(Raw, null, bufferSize, out identitySize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = identitySize;
            buffer = new char[bufferSize];
            hr = getIdentityWide(Raw, buffer, bufferSize, out identitySize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, identitySize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        #endregion
        #region EventCallbacksWide

        /// <summary>
        /// The GetEventCallbacksWide method returns the event callbacks object registered with this client.
        /// </summary>
        public IDebugEventCallbacksWide EventCallbacksWide
        {
            get
            {
                IDebugEventCallbacksWide callbacks;
                TryGetEventCallbacksWide(out callbacks).ThrowDbgEngNotOK();

                return callbacks;
            }
            set
            {
                TrySetEventCallbacksWide(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// The GetEventCallbacksWide method returns the event callbacks object registered with this client.
        /// </summary>
        /// <param name="callbacks">[out] Receives an interface pointer to the event callbacks object registered with this client.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one <see cref="IDebugEventCallbacks"/> or IDebugEventCallbacksWide object registered
        /// with it for receiving events. If no event callbacks object is registered with the client, the value of Callbacks
        /// will be set to NULL. The IDebugEventCallbacksWide interface extends the COM interface IUnknown. Before returning
        /// the IDebugEventCallbacksWide object specified by Callbacks, the engine calls its IUnknown::AddRef method. When
        /// this object is no longer needed, its IUnknown::Release method should be called. For more information about callbacks,
        /// see Callbacks.
        /// </remarks>
        public HRESULT TryGetEventCallbacksWide(out IDebugEventCallbacksWide callbacks)
        {
            InitDelegate(ref getEventCallbacksWide, Vtbl5->GetEventCallbacksWide);

            /*HRESULT GetEventCallbacksWide(
            [Out] out IDebugEventCallbacksWide Callbacks);*/
            return getEventCallbacksWide(Raw, out callbacks);
        }

        /// <summary>
        /// The SetEventCallbacksWide method registers an event callbacks object with this client.
        /// </summary>
        /// <param name="callbacks">[in] Specifies the interface pointer to the event callbacks object to register with this client.</param>
        /// <returns>Depending on the implementation of the method <see cref="IDebugEventCallbacks.GetInterestMask"/> in the object specified by Callbacks, other values may be returned, as described in the Remarks section.</returns>
        /// <remarks>
        /// If the value of Callbacks is not NULL, the method IDebugEventCallbacks::GetInterestMask is called. If the return
        /// value is not S_OK, SetEventCallbacks and SetEventCallbacksWide have no effect and they return this value. Each
        /// client can have at most one <see cref="IDebugEventCallbacks"/> or IDebugEventCallbacksWide object registered with
        /// it for receiving events. The IDebugEventCallbacksWide interface extends the COM interface IUnknown. When SetEventCallbacks
        /// and SetEventCallbacksWide are successful, they call the IUnknown::AddRef method of the object specified by Callbacks.
        /// The IUnknown::Release method of this object will be called the next time SetEventCallbacks or SetEventCallbacksWide
        /// is called on this client, or when this client is deleted. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TrySetEventCallbacksWide(IDebugEventCallbacksWide callbacks)
        {
            InitDelegate(ref setEventCallbacksWide, Vtbl5->SetEventCallbacksWide);

            /*HRESULT SetEventCallbacksWide(
            [In] IDebugEventCallbacksWide Callbacks);*/
            return setEventCallbacksWide(Raw, callbacks);
        }

        #endregion
        #region NumberInputCallbacks

        /// <summary>
        /// The GetNumberInputCallbacks method returns the number of input callbacks registered over all clients.
        /// </summary>
        public int NumberInputCallbacks
        {
            get
            {
                int count;
                TryGetNumberInputCallbacks(out count).ThrowDbgEngNotOK();

                return count;
            }
        }

        /// <summary>
        /// The GetNumberInputCallbacks method returns the number of input callbacks registered over all clients.
        /// </summary>
        /// <param name="count">[out] Receives the number of input callbacks that have been registered.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one input callback registered with it. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TryGetNumberInputCallbacks(out int count)
        {
            InitDelegate(ref getNumberInputCallbacks, Vtbl5->GetNumberInputCallbacks);

            /*HRESULT GetNumberInputCallbacks(
            [Out] out int Count);*/
            return getNumberInputCallbacks(Raw, out count);
        }

        #endregion
        #region NumberOutputCallbacks

        /// <summary>
        /// The GetNumberOutputCallbacks method returns the number of output callbacks registered over all clients.
        /// </summary>
        public int NumberOutputCallbacks
        {
            get
            {
                int count;
                TryGetNumberOutputCallbacks(out count).ThrowDbgEngNotOK();

                return count;
            }
        }

        /// <summary>
        /// The GetNumberOutputCallbacks method returns the number of output callbacks registered over all clients.
        /// </summary>
        /// <param name="count">[out] Receives the number of output callbacks that have been registered.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one output callback registered with it. For more information about callbacks, see
        /// Callbacks.
        /// </remarks>
        public HRESULT TryGetNumberOutputCallbacks(out int count)
        {
            InitDelegate(ref getNumberOutputCallbacks, Vtbl5->GetNumberOutputCallbacks);

            /*HRESULT GetNumberOutputCallbacks(
            [Out] out int Count);*/
            return getNumberOutputCallbacks(Raw, out count);
        }

        #endregion
        #region QuitLockString

        /// <summary>
        /// Gets or sets a quit lock string.
        /// </summary>
        public string QuitLockString
        {
            get
            {
                string bufferResult;
                TryGetQuitLockString(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetQuitLockString(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// Gets a quit lock string.
        /// </summary>
        /// <param name="bufferResult">[out] The buffer in which to write the string.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        /// <remarks>
        /// The quit lock stringcannot be retrieved from a secure session.
        /// </remarks>
        public HRESULT TryGetQuitLockString(out string bufferResult)
        {
            InitDelegate(ref getQuitLockString, Vtbl5->GetQuitLockString);
            /*HRESULT GetQuitLockString(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);*/
            char[] buffer;
            int bufferSize = 0;
            int stringSize;
            HRESULT hr = getQuitLockString(Raw, null, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringSize;
            buffer = new char[bufferSize];
            hr = getQuitLockString(Raw, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, stringSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// Sets a quit lock string.
        /// </summary>
        /// <param name="lockString">[in] A pointer to the quit lock string.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TrySetQuitLockString(string lockString)
        {
            InitDelegate(ref setQuitLockString, Vtbl5->SetQuitLockString);

            /*HRESULT SetQuitLockString(
            [In, MarshalAs(UnmanagedType.LPStr)] string LockString);*/
            return setQuitLockString(Raw, lockString);
        }

        #endregion
        #region QuitLockStringWide

        /// <summary>
        /// Gets or sets a Unicode character quit lock string.
        /// </summary>
        public string QuitLockStringWide
        {
            get
            {
                string bufferResult;
                TryGetQuitLockStringWide(out bufferResult).ThrowDbgEngNotOK();

                return bufferResult;
            }
            set
            {
                TrySetQuitLockStringWide(value).ThrowDbgEngNotOK();
            }
        }

        /// <summary>
        /// Gets a Unicode character quit lock string.
        /// </summary>
        /// <param name="bufferResult">[out] The buffer in which to write the Unicode character string.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        /// <remarks>
        /// The quit lock stringcannot be retrieved from a secure session.
        /// </remarks>
        public HRESULT TryGetQuitLockStringWide(out string bufferResult)
        {
            InitDelegate(ref getQuitLockStringWide, Vtbl5->GetQuitLockStringWide);
            /*HRESULT GetQuitLockStringWide(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int StringSize);*/
            char[] buffer;
            int bufferSize = 0;
            int stringSize;
            HRESULT hr = getQuitLockStringWide(Raw, null, bufferSize, out stringSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            bufferSize = stringSize;
            buffer = new char[bufferSize];
            hr = getQuitLockStringWide(Raw, buffer, bufferSize, out stringSize);

            if (hr == HRESULT.S_OK)
            {
                bufferResult = CreateString(buffer, stringSize);

                return hr;
            }

            fail:
            bufferResult = default(string);

            return hr;
        }

        /// <summary>
        /// Sets a quit lock Unicode character string.
        /// </summary>
        /// <param name="lockString">[in] A pointer to the quit lock Unicode character string.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TrySetQuitLockStringWide(string lockString)
        {
            InitDelegate(ref setQuitLockStringWide, Vtbl5->SetQuitLockStringWide);

            /*HRESULT SetQuitLockStringWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string LockString);*/
            return setQuitLockStringWide(Raw, lockString);
        }

        #endregion
        #region AttachKernelWide

        /// <summary>
        /// The AttachKernelWide method connects the debugger engine to a kernel target.
        /// </summary>
        /// <param name="flags">[in] Specifies the flags that control how the debugger attaches to the kernel target. The possible values are:</param>
        /// <param name="connectOptions">[in, optional] Specifies the connection settings for communicating with the computer running the kernel target.<para/>
        /// The interpretation of ConnectOptions depends on the value of Flags. ConnectOptions will be interpreted the same way as the options that follow the -k switch on the WinDbg and KD command lines.<para/>
        /// Environment variables affect ConnectOptions in the same way they affect the -k switch. eXDI drivers are not described in this documentation.<para/>
        /// If you have an eXDI interface to your hardware probe or hardware simulator, please contact Microsoft for debugging information.</param>
        public void AttachKernelWide(DEBUG_ATTACH flags, string connectOptions)
        {
            TryAttachKernelWide(flags, connectOptions).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The AttachKernelWide method connects the debugger engine to a kernel target.
        /// </summary>
        /// <param name="flags">[in] Specifies the flags that control how the debugger attaches to the kernel target. The possible values are:</param>
        /// <param name="connectOptions">[in, optional] Specifies the connection settings for communicating with the computer running the kernel target.<para/>
        /// The interpretation of ConnectOptions depends on the value of Flags. ConnectOptions will be interpreted the same way as the options that follow the -k switch on the WinDbg and KD command lines.<para/>
        /// Environment variables affect ConnectOptions in the same way they affect the -k switch. eXDI drivers are not described in this documentation.<para/>
        /// If you have an eXDI interface to your hardware probe or hardware simulator, please contact Microsoft for debugging information.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        public HRESULT TryAttachKernelWide(DEBUG_ATTACH flags, string connectOptions)
        {
            InitDelegate(ref attachKernelWide, Vtbl5->AttachKernelWide);

            /*HRESULT AttachKernelWide(
            [In] DEBUG_ATTACH Flags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string ConnectOptions);*/
            return attachKernelWide(Raw, flags, connectOptions);
        }

        #endregion
        #region StartProcessServerWide

        /// <summary>
        /// The StartProcessServerWide method starts a process server.
        /// </summary>
        /// <param name="flags">[in] Specifies the class of the targets that will be available through the process server. This must be set to DEBUG_CLASS_USER_WINDOWS.</param>
        /// <param name="options">[in] Specifies the connections options for this process server. These are the same options given to the -t option of the DbgSrv command line.<para/>
        /// For details on the syntax of this string, see Activating a Process Server.</param>
        /// <param name="reserved">[in, optional] Set to NULL.</param>
        /// <remarks>
        /// The process server that is started will be accessible by remote clients through the transport specified in the
        /// Options parameter. To stop the process server from the smart client, use the <see cref="EndProcessServer"/> method.
        /// To shut down the process server from the computer that it is running on, use Task Manager to end the process. If
        /// the instance of the debugger engine that used StartProcessServer is still running, it can use <see cref="DebugControl.Execute"/>
        /// to issue the debugger command .endsrv 0, which will end the process server (this is an exception to the usual behavior
        /// of .endsrv, which generally does not affect process servers). For more information about process servers and remote
        /// debugging, see Process Servers, Kernel Connection Servers, and Smart Clients.
        /// </remarks>
        public void StartProcessServerWide(DEBUG_CLASS flags, string options, IntPtr reserved)
        {
            TryStartProcessServerWide(flags, options, reserved).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The StartProcessServerWide method starts a process server.
        /// </summary>
        /// <param name="flags">[in] Specifies the class of the targets that will be available through the process server. This must be set to DEBUG_CLASS_USER_WINDOWS.</param>
        /// <param name="options">[in] Specifies the connections options for this process server. These are the same options given to the -t option of the DbgSrv command line.<para/>
        /// For details on the syntax of this string, see Activating a Process Server.</param>
        /// <param name="reserved">[in, optional] Set to NULL.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The process server that is started will be accessible by remote clients through the transport specified in the
        /// Options parameter. To stop the process server from the smart client, use the <see cref="EndProcessServer"/> method.
        /// To shut down the process server from the computer that it is running on, use Task Manager to end the process. If
        /// the instance of the debugger engine that used StartProcessServer is still running, it can use <see cref="DebugControl.Execute"/>
        /// to issue the debugger command .endsrv 0, which will end the process server (this is an exception to the usual behavior
        /// of .endsrv, which generally does not affect process servers). For more information about process servers and remote
        /// debugging, see Process Servers, Kernel Connection Servers, and Smart Clients.
        /// </remarks>
        public HRESULT TryStartProcessServerWide(DEBUG_CLASS flags, string options, IntPtr reserved)
        {
            InitDelegate(ref startProcessServerWide, Vtbl5->StartProcessServerWide);

            /*HRESULT StartProcessServerWide(
            [In] DEBUG_CLASS Flags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Options,
            [In] IntPtr Reserved);*/
            return startProcessServerWide(Raw, flags, options, reserved);
        }

        #endregion
        #region ConnectProcessServerWide

        /// <summary>
        /// The ConnectProcessServerWide method connects to a process server.
        /// </summary>
        /// <param name="remoteOptions">[in] Specifies how the debugger engine will connect with the process server. These are the same options passed to the -premote option on the WinDbg and CDB command lines.<para/>
        /// For details on the syntax of this string, see Activating a Smart Client.</param>
        /// <returns>[out] Receives a handle for the process server. This handle is used when creating or attaching to processes by using the process server.</returns>
        /// <remarks>
        /// For more information about process servers and remote debugging, see Process Servers, Kernel Connection Servers,
        /// and Smart Clients.
        /// </remarks>
        public long ConnectProcessServerWide(string remoteOptions)
        {
            long server;
            TryConnectProcessServerWide(remoteOptions, out server).ThrowDbgEngNotOK();

            return server;
        }

        /// <summary>
        /// The ConnectProcessServerWide method connects to a process server.
        /// </summary>
        /// <param name="remoteOptions">[in] Specifies how the debugger engine will connect with the process server. These are the same options passed to the -premote option on the WinDbg and CDB command lines.<para/>
        /// For details on the syntax of this string, see Activating a Smart Client.</param>
        /// <param name="server">[out] Receives a handle for the process server. This handle is used when creating or attaching to processes by using the process server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about process servers and remote debugging, see Process Servers, Kernel Connection Servers,
        /// and Smart Clients.
        /// </remarks>
        public HRESULT TryConnectProcessServerWide(string remoteOptions, out long server)
        {
            InitDelegate(ref connectProcessServerWide, Vtbl5->ConnectProcessServerWide);

            /*HRESULT ConnectProcessServerWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string RemoteOptions,
            [Out] out long Server);*/
            return connectProcessServerWide(Raw, remoteOptions, out server);
        }

        #endregion
        #region StartServerWide

        /// <summary>
        /// The StartServerWide method starts a debugging server.
        /// </summary>
        /// <param name="options">[in] Specifies the connections options for this server. These are the same options given to the .server debugger command or the WinDbg and CDB -server command-line option.<para/>
        /// For details on the syntax of this string, see Activating a Debugging Server.</param>
        /// <remarks>
        /// The server that is started will be accessible by other debuggers through the transport specified in the Options
        /// parameter. For more information about debugging servers, see Debugging Server and Debugging Client.
        /// </remarks>
        public void StartServerWide(string options)
        {
            TryStartServerWide(options).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The StartServerWide method starts a debugging server.
        /// </summary>
        /// <param name="options">[in] Specifies the connections options for this server. These are the same options given to the .server debugger command or the WinDbg and CDB -server command-line option.<para/>
        /// For details on the syntax of this string, see Activating a Debugging Server.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The server that is started will be accessible by other debuggers through the transport specified in the Options
        /// parameter. For more information about debugging servers, see Debugging Server and Debugging Client.
        /// </remarks>
        public HRESULT TryStartServerWide(string options)
        {
            InitDelegate(ref startServerWide, Vtbl5->StartServerWide);

            /*HRESULT StartServerWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string Options);*/
            return startServerWide(Raw, options);
        }

        #endregion
        #region OutputServersWide

        /// <summary>
        /// The OutputServersWide method lists the servers running on a given computer.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control to use while outputting the servers. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="machine">[in] Specifies the name of the computer whose servers will be listed. Machine has the following form: \computername</param>
        /// <param name="flags">[in] Specifies a bit-set that determines which servers to output. The possible bit flags are:</param>
        /// <remarks>
        /// For more information about remote debugging, see Remote Debugging.
        /// </remarks>
        public void OutputServersWide(DEBUG_OUTCTL outputControl, string machine, DEBUG_SERVERS flags)
        {
            TryOutputServersWide(outputControl, machine, flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputServersWide method lists the servers running on a given computer.
        /// </summary>
        /// <param name="outputControl">[in] Specifies the output control to use while outputting the servers. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="machine">[in] Specifies the name of the computer whose servers will be listed. Machine has the following form: \computername</param>
        /// <param name="flags">[in] Specifies a bit-set that determines which servers to output. The possible bit flags are:</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about remote debugging, see Remote Debugging.
        /// </remarks>
        public HRESULT TryOutputServersWide(DEBUG_OUTCTL outputControl, string machine, DEBUG_SERVERS flags)
        {
            InitDelegate(ref outputServersWide, Vtbl5->OutputServersWide);

            /*HRESULT OutputServersWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Machine,
            [In] DEBUG_SERVERS Flags);*/
            return outputServersWide(Raw, outputControl, machine, flags);
        }

        #endregion
        #region OutputIdentityWide

        /// <summary>
        /// The OutputIdentityWide method formats and outputs a string describing the computer and user this client represents.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <param name="machine">[in] Specifies a format string similar to the printf format string. However, this format string must only contain one formatting directive, %s, which will be replaced by a description of the computer and user this client represents.</param>
        /// <remarks>
        /// The specific content of the string varies with the operating system. If the client is remotely connected, some
        /// network information may also be present. For more information about client objects, see Client Objects.
        /// </remarks>
        public void OutputIdentityWide(DEBUG_OUTCTL outputControl, int flags, string machine)
        {
            TryOutputIdentityWide(outputControl, flags, machine).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OutputIdentityWide method formats and outputs a string describing the computer and user this client represents.
        /// </summary>
        /// <param name="outputControl">[in] Specifies where to send the output. For possible values, see DEBUG_OUTCTL_XXX.</param>
        /// <param name="flags">[in] Set to zero.</param>
        /// <param name="machine">[in] Specifies a format string similar to the printf format string. However, this format string must only contain one formatting directive, %s, which will be replaced by a description of the computer and user this client represents.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The specific content of the string varies with the operating system. If the client is remotely connected, some
        /// network information may also be present. For more information about client objects, see Client Objects.
        /// </remarks>
        public HRESULT TryOutputIdentityWide(DEBUG_OUTCTL outputControl, int flags, string machine)
        {
            InitDelegate(ref outputIdentityWide, Vtbl5->OutputIdentityWide);

            /*HRESULT OutputIdentityWide(
            [In] DEBUG_OUTCTL OutputControl,
            [In] int Flags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Machine);*/
            return outputIdentityWide(Raw, outputControl, flags, machine);
        }

        #endregion
        #region CreateProcess2

        /// <summary>
        /// The CreateProcess2 method executes the given command to create a new process.
        /// </summary>
        /// <param name="server">[in] Specifies the process server that will be attached to the process. If Server is zero, the engine will create the local process without using a process server.</param>
        /// <param name="commandLine">[in] Specifies the command line to execute to create the new process.</param>
        /// <param name="optionsBuffer">[in] Specifies the process creation options. OptionsBuffer is a pointer to a <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <param name="optionsBufferSize">[in] Specifies the size of the buffer OptionsBuffer. This should be set to sizeof(DEBUG_CREATE_PROCESS_OPTIONS).</param>
        /// <param name="initialDirectory">[in, optional] Specifies the starting directory for the process. If InitialDirectory is NULL, the current directory for the process server is used.</param>
        /// <param name="environment">[in, optional] Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings.<para/>
        /// Each string is of the form: Note that the last two characters of the environment block are both NULL: one to terminate the string and one to terminate the block.<para/>
        /// If Environment is set to NULL, the new process inherits the environment block of the process server. If the DEBUG_CREATE_PROCESS_THROUGH_RTL flag is set in OptionsBuffer, then Environment must be NULL.</param>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CreateFlags contains either of the flags DEBUG_PROCESS
        /// or DEBUG_ONLY_THIS_PROCESS, the engine will also attach to the newly created process. This is similar to the behavior
        /// of <see cref="CreateProcessAndAttach2"/> with its argument ProcessId set to zero. For more information about creating
        /// and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public void CreateProcess2(long server, string commandLine, DEBUG_CREATE_PROCESS_OPTIONS optionsBuffer, int optionsBufferSize, string initialDirectory, string environment)
        {
            TryCreateProcess2(server, commandLine, optionsBuffer, optionsBufferSize, initialDirectory, environment).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CreateProcess2 method executes the given command to create a new process.
        /// </summary>
        /// <param name="server">[in] Specifies the process server that will be attached to the process. If Server is zero, the engine will create the local process without using a process server.</param>
        /// <param name="commandLine">[in] Specifies the command line to execute to create the new process.</param>
        /// <param name="optionsBuffer">[in] Specifies the process creation options. OptionsBuffer is a pointer to a <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <param name="optionsBufferSize">[in] Specifies the size of the buffer OptionsBuffer. This should be set to sizeof(DEBUG_CREATE_PROCESS_OPTIONS).</param>
        /// <param name="initialDirectory">[in, optional] Specifies the starting directory for the process. If InitialDirectory is NULL, the current directory for the process server is used.</param>
        /// <param name="environment">[in, optional] Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings.<para/>
        /// Each string is of the form: Note that the last two characters of the environment block are both NULL: one to terminate the string and one to terminate the block.<para/>
        /// If Environment is set to NULL, the new process inherits the environment block of the process server. If the DEBUG_CREATE_PROCESS_THROUGH_RTL flag is set in OptionsBuffer, then Environment must be NULL.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CreateFlags contains either of the flags DEBUG_PROCESS
        /// or DEBUG_ONLY_THIS_PROCESS, the engine will also attach to the newly created process. This is similar to the behavior
        /// of <see cref="CreateProcessAndAttach2"/> with its argument ProcessId set to zero. For more information about creating
        /// and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryCreateProcess2(long server, string commandLine, DEBUG_CREATE_PROCESS_OPTIONS optionsBuffer, int optionsBufferSize, string initialDirectory, string environment)
        {
            InitDelegate(ref createProcess2, Vtbl5->CreateProcess2);

            /*HRESULT CreateProcess2(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] int OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPStr)] string InitialDirectory,
            [In, MarshalAs(UnmanagedType.LPStr)] string Environment);*/
            return createProcess2(Raw, server, commandLine, ref optionsBuffer, optionsBufferSize, initialDirectory, environment);
        }

        #endregion
        #region CreateProcess2Wide

        /// <summary>
        /// The CreateProcess2Wide method executes the specified command to create a new process.
        /// </summary>
        /// <param name="server">[in] Specifies the process server that will be attached to the process. If Server is zero, the engine will create the local process without using a process server.</param>
        /// <param name="commandLine">[in] Specifies the command line to execute to create the new process.</param>
        /// <param name="optionsBuffer">[in] Specifies the process creation options. OptionsBuffer is a pointer to a <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <param name="optionsBufferSize">[in] Specifies the size of the buffer OptionsBuffer. This should be set to sizeof(DEBUG_CREATE_PROCESS_OPTIONS).</param>
        /// <param name="initialDirectory">[in, optional] Specifies the starting directory for the process. If InitialDirectory is NULL, the current directory for the process server is used.</param>
        /// <param name="environment">[in, optional] Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings.<para/>
        /// Each string is of the form: Note that the last two characters of the environment block are both NULL: one to terminate the string and one to terminate the block.<para/>
        /// If Environment is set to NULL, the new process inherits the environment block of the process server. If the DEBUG_CREATE_PROCESS_THROUGH_RTL flag is set in OptionsBuffer, then Environment must be NULL.</param>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CreateFlags contains either of the flags DEBUG_PROCESS
        /// or DEBUG_ONLY_THIS_PROCESS, the engine will also attach to the newly created process. This is similar to the behavior
        /// of <see cref="CreateProcessAndAttach2"/> with its argument ProcessId set to zero. For more information about creating
        /// and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public void CreateProcess2Wide(long server, string commandLine, DEBUG_CREATE_PROCESS_OPTIONS optionsBuffer, int optionsBufferSize, string initialDirectory, string environment)
        {
            TryCreateProcess2Wide(server, commandLine, optionsBuffer, optionsBufferSize, initialDirectory, environment).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CreateProcess2Wide method executes the specified command to create a new process.
        /// </summary>
        /// <param name="server">[in] Specifies the process server that will be attached to the process. If Server is zero, the engine will create the local process without using a process server.</param>
        /// <param name="commandLine">[in] Specifies the command line to execute to create the new process.</param>
        /// <param name="optionsBuffer">[in] Specifies the process creation options. OptionsBuffer is a pointer to a <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <param name="optionsBufferSize">[in] Specifies the size of the buffer OptionsBuffer. This should be set to sizeof(DEBUG_CREATE_PROCESS_OPTIONS).</param>
        /// <param name="initialDirectory">[in, optional] Specifies the starting directory for the process. If InitialDirectory is NULL, the current directory for the process server is used.</param>
        /// <param name="environment">[in, optional] Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings.<para/>
        /// Each string is of the form: Note that the last two characters of the environment block are both NULL: one to terminate the string and one to terminate the block.<para/>
        /// If Environment is set to NULL, the new process inherits the environment block of the process server. If the DEBUG_CREATE_PROCESS_THROUGH_RTL flag is set in OptionsBuffer, then Environment must be NULL.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CreateFlags contains either of the flags DEBUG_PROCESS
        /// or DEBUG_ONLY_THIS_PROCESS, the engine will also attach to the newly created process. This is similar to the behavior
        /// of <see cref="CreateProcessAndAttach2"/> with its argument ProcessId set to zero. For more information about creating
        /// and attaching to live user-mode targets, see Live User-Mode Targets.
        /// </remarks>
        public HRESULT TryCreateProcess2Wide(long server, string commandLine, DEBUG_CREATE_PROCESS_OPTIONS optionsBuffer, int optionsBufferSize, string initialDirectory, string environment)
        {
            InitDelegate(ref createProcess2Wide, Vtbl5->CreateProcess2Wide);

            /*HRESULT CreateProcess2Wide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] int OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string InitialDirectory,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Environment);*/
            return createProcess2Wide(Raw, server, commandLine, ref optionsBuffer, optionsBufferSize, initialDirectory, environment);
        }

        #endregion
        #region CreateProcessAndAttach2

        /// <summary>
        /// The CreateProcessAndAttach2 method creates a process from a specified command line, then attaches to that process or another user-mode process.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="commandLine">[in, optional] Specifies the command line to execute to create the new process. If CommandLine is NULL, no process is created and these methods will use ProcessId to attach to an existing process.</param>
        /// <param name="optionsBuffer">[in] Specifies the process creation options. OptionsBuffer is a pointer to a <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <param name="optionsBufferSize">[in] Specifies the size of the buffer OptionsBuffer. This should be set to sizeof(DEBUG_CREATE_PROCESS_OPTIONS).</param>
        /// <param name="initialDirectory">[in, optional] Specifies the starting directory for the process. This parameter is used only if CommandLine is not NULL.<para/>
        /// If InitialDirectory is NULL, the current directory for the process server is used.</param>
        /// <param name="environment">[in, optional] Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings.<para/>
        /// Each string is of the form: Note that the last two characters of the environment block are both NULL: one to terminate the string and one to terminate the block.<para/>
        /// If Environment is set to NULL, the new process inherits the environment block of the process server. If the DEBUG_CREATE_PROCESS_THROUGH_RTL flag is set in OptionsBuffer, then Environment must be NULL.</param>
        /// <param name="processId">[in] Specifies the process ID of the target process to which the debugger will attach. If ProcessID is zero, the debugger will attach to the process it created from CommandLine.</param>
        /// <param name="attachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see DEBUG_ATTACH_XXX.</param>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CommandLine is not NULL and ProcessId is not zero,
        /// then the engine will create the process in a suspended state. The engine will resume this newly created process
        /// after it successfully connects to the process specified in ProcessId.
        /// </remarks>
        public void CreateProcessAndAttach2(long server, string commandLine, DEBUG_CREATE_PROCESS_OPTIONS optionsBuffer, int optionsBufferSize, string initialDirectory, string environment, int processId, DEBUG_ATTACH attachFlags)
        {
            TryCreateProcessAndAttach2(server, commandLine, optionsBuffer, optionsBufferSize, initialDirectory, environment, processId, attachFlags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CreateProcessAndAttach2 method creates a process from a specified command line, then attaches to that process or another user-mode process.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="commandLine">[in, optional] Specifies the command line to execute to create the new process. If CommandLine is NULL, no process is created and these methods will use ProcessId to attach to an existing process.</param>
        /// <param name="optionsBuffer">[in] Specifies the process creation options. OptionsBuffer is a pointer to a <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <param name="optionsBufferSize">[in] Specifies the size of the buffer OptionsBuffer. This should be set to sizeof(DEBUG_CREATE_PROCESS_OPTIONS).</param>
        /// <param name="initialDirectory">[in, optional] Specifies the starting directory for the process. This parameter is used only if CommandLine is not NULL.<para/>
        /// If InitialDirectory is NULL, the current directory for the process server is used.</param>
        /// <param name="environment">[in, optional] Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings.<para/>
        /// Each string is of the form: Note that the last two characters of the environment block are both NULL: one to terminate the string and one to terminate the block.<para/>
        /// If Environment is set to NULL, the new process inherits the environment block of the process server. If the DEBUG_CREATE_PROCESS_THROUGH_RTL flag is set in OptionsBuffer, then Environment must be NULL.</param>
        /// <param name="processId">[in] Specifies the process ID of the target process to which the debugger will attach. If ProcessID is zero, the debugger will attach to the process it created from CommandLine.</param>
        /// <param name="attachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see DEBUG_ATTACH_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CommandLine is not NULL and ProcessId is not zero,
        /// then the engine will create the process in a suspended state. The engine will resume this newly created process
        /// after it successfully connects to the process specified in ProcessId.
        /// </remarks>
        public HRESULT TryCreateProcessAndAttach2(long server, string commandLine, DEBUG_CREATE_PROCESS_OPTIONS optionsBuffer, int optionsBufferSize, string initialDirectory, string environment, int processId, DEBUG_ATTACH attachFlags)
        {
            InitDelegate(ref createProcessAndAttach2, Vtbl5->CreateProcessAndAttach2);

            /*HRESULT CreateProcessAndAttach2(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] int OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPStr)] string InitialDirectory,
            [In, MarshalAs(UnmanagedType.LPStr)] string Environment,
            [In] int ProcessId,
            [In] DEBUG_ATTACH AttachFlags);*/
            return createProcessAndAttach2(Raw, server, commandLine, ref optionsBuffer, optionsBufferSize, initialDirectory, environment, processId, attachFlags);
        }

        #endregion
        #region CreateProcessAndAttach2Wide

        /// <summary>
        /// The CreateProcessAndAttach2Wide method creates a process from a specified command line, then attach to that process or another user-mode process.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="commandLine">[in, optional] Specifies the command line to execute to create the new process. If CommandLine is NULL, no process is created and these methods will use ProcessId to attach to an existing process.</param>
        /// <param name="optionsBuffer">[in] Specifies the process creation options. OptionsBuffer is a pointer to a <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <param name="optionsBufferSize">[in] Specifies the size of the buffer OptionsBuffer. This should be set to sizeof(DEBUG_CREATE_PROCESS_OPTIONS).</param>
        /// <param name="initialDirectory">[in, optional] Specifies the starting directory for the process. This parameter is used only if CommandLine is not NULL.<para/>
        /// If InitialDirectory is NULL, the current directory for the process server is used.</param>
        /// <param name="environment">[in, optional] Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings.<para/>
        /// Each string is of the form: Note that the last two characters of the environment block are both NULL: one to terminate the string and one to terminate the block.<para/>
        /// If Environment is set to NULL, the new process inherits the environment block of the process server. If the DEBUG_CREATE_PROCESS_THROUGH_RTL flag is set in OptionsBuffer, then Environment must be NULL.</param>
        /// <param name="processId">[in] Specifies the process ID of the target process to which the debugger will attach. If ProcessID is zero, the debugger will attach to the process it created from CommandLine.</param>
        /// <param name="attachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see DEBUG_ATTACH_XXX.</param>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CommandLine is not NULL and ProcessId is not zero,
        /// then the engine will create the process in a suspended state. The engine will resume this newly created process
        /// after it successfully connects to the process specified in ProcessId.
        /// </remarks>
        public void CreateProcessAndAttach2Wide(long server, string commandLine, DEBUG_CREATE_PROCESS_OPTIONS optionsBuffer, int optionsBufferSize, string initialDirectory, string environment, int processId, DEBUG_ATTACH attachFlags)
        {
            TryCreateProcessAndAttach2Wide(server, commandLine, optionsBuffer, optionsBufferSize, initialDirectory, environment, processId, attachFlags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The CreateProcessAndAttach2Wide method creates a process from a specified command line, then attach to that process or another user-mode process.
        /// </summary>
        /// <param name="server">[in] Specifies the process server to use to attach to the process. If Server is zero, the engine will connect to the local process without using a process server.</param>
        /// <param name="commandLine">[in, optional] Specifies the command line to execute to create the new process. If CommandLine is NULL, no process is created and these methods will use ProcessId to attach to an existing process.</param>
        /// <param name="optionsBuffer">[in] Specifies the process creation options. OptionsBuffer is a pointer to a <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/> structure.</param>
        /// <param name="optionsBufferSize">[in] Specifies the size of the buffer OptionsBuffer. This should be set to sizeof(DEBUG_CREATE_PROCESS_OPTIONS).</param>
        /// <param name="initialDirectory">[in, optional] Specifies the starting directory for the process. This parameter is used only if CommandLine is not NULL.<para/>
        /// If InitialDirectory is NULL, the current directory for the process server is used.</param>
        /// <param name="environment">[in, optional] Specifies an environment block for the new process. An environment block consists of a null-terminated block of null-terminated strings.<para/>
        /// Each string is of the form: Note that the last two characters of the environment block are both NULL: one to terminate the string and one to terminate the block.<para/>
        /// If Environment is set to NULL, the new process inherits the environment block of the process server. If the DEBUG_CREATE_PROCESS_THROUGH_RTL flag is set in OptionsBuffer, then Environment must be NULL.</param>
        /// <param name="processId">[in] Specifies the process ID of the target process to which the debugger will attach. If ProcessID is zero, the debugger will attach to the process it created from CommandLine.</param>
        /// <param name="attachFlags">[in] Specifies the flags that control how the debugger attaches to the target process. For details on these flags, see DEBUG_ATTACH_XXX.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is available only for live user-mode debugging. If CommandLine is not NULL and ProcessId is not zero,
        /// then the engine will create the process in a suspended state. The engine will resume this newly created process
        /// after it successfully connects to the process specified in ProcessId.
        /// </remarks>
        public HRESULT TryCreateProcessAndAttach2Wide(long server, string commandLine, DEBUG_CREATE_PROCESS_OPTIONS optionsBuffer, int optionsBufferSize, string initialDirectory, string environment, int processId, DEBUG_ATTACH attachFlags)
        {
            InitDelegate(ref createProcessAndAttach2Wide, Vtbl5->CreateProcessAndAttach2Wide);

            /*HRESULT CreateProcessAndAttach2Wide(
            [In] long Server,
            [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine,
            [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer,
            [In] int OptionsBufferSize,
            [In, MarshalAs(UnmanagedType.LPWStr)] string InitialDirectory,
            [In, MarshalAs(UnmanagedType.LPWStr)] string Environment,
            [In] int ProcessId,
            [In] DEBUG_ATTACH AttachFlags);*/
            return createProcessAndAttach2Wide(Raw, server, commandLine, ref optionsBuffer, optionsBufferSize, initialDirectory, environment, processId, attachFlags);
        }

        #endregion
        #region PushOutputLinePrefix

        /// <param name="newPrefix">[in, optional] A pointer to the new output line prefix.</param>
        /// <returns>[out] The handle of the previous output line prefix.</returns>
        public long PushOutputLinePrefix(string newPrefix)
        {
            long handle;
            TryPushOutputLinePrefix(newPrefix, out handle).ThrowDbgEngNotOK();

            return handle;
        }

        /// <param name="newPrefix">[in, optional] A pointer to the new output line prefix.</param>
        /// <param name="handle">[out] The handle of the previous output line prefix.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryPushOutputLinePrefix(string newPrefix, out long handle)
        {
            InitDelegate(ref pushOutputLinePrefix, Vtbl5->PushOutputLinePrefix);

            /*HRESULT PushOutputLinePrefix(
            [In, MarshalAs(UnmanagedType.LPStr)] string NewPrefix,
            [Out] out long Handle);*/
            return pushOutputLinePrefix(Raw, newPrefix, out handle);
        }

        #endregion
        #region PushOutputLinePrefixWide

        /// <param name="newPrefix">[in, optional] A pointer to the new output line Unicode character prefix.</param>
        /// <returns>[out] The handle of the previous output line prefix.</returns>
        public long PushOutputLinePrefixWide(string newPrefix)
        {
            long handle;
            TryPushOutputLinePrefixWide(newPrefix, out handle).ThrowDbgEngNotOK();

            return handle;
        }

        /// <param name="newPrefix">[in, optional] A pointer to the new output line Unicode character prefix.</param>
        /// <param name="handle">[out] The handle of the previous output line prefix.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryPushOutputLinePrefixWide(string newPrefix, out long handle)
        {
            InitDelegate(ref pushOutputLinePrefixWide, Vtbl5->PushOutputLinePrefixWide);

            /*HRESULT PushOutputLinePrefixWide(
            [In, MarshalAs(UnmanagedType.LPWStr)] string NewPrefix,
            [Out] out long Handle);*/
            return pushOutputLinePrefixWide(Raw, newPrefix, out handle);
        }

        #endregion
        #region PopOutputLinePrefix

        /// <summary>
        /// Restores a previously saved output line prefix.
        /// </summary>
        /// <param name="handle">[in] The handle of a previously pushed prefix.</param>
        public void PopOutputLinePrefix(long handle)
        {
            TryPopOutputLinePrefix(handle).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Restores a previously saved output line prefix.
        /// </summary>
        /// <param name="handle">[in] The handle of a previously pushed prefix.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryPopOutputLinePrefix(long handle)
        {
            InitDelegate(ref popOutputLinePrefix, Vtbl5->PopOutputLinePrefix);

            /*HRESULT PopOutputLinePrefix(
            [In] long Handle);*/
            return popOutputLinePrefix(Raw, handle);
        }

        #endregion
        #region GetNumberEventCallbacks

        /// <summary>
        /// The GetNumberEventCallbacks method returns the number of event callbacks that are interested in the given events.
        /// </summary>
        /// <param name="flags">[in] Specifies a set of events used to filter out some of the event callbacks; only event callbacks that have indicated an interest in one of the events in EventFlags will be counted.<para/>
        /// See DEBUG_EVENT_XXX for a list of the events.</param>
        /// <returns>[out] Receives the number of event callbacks that are interested in at least one of the events in EventFlags.</returns>
        /// <remarks>
        /// Each client can have at most one event callback registered with it. When a callback is registered with a client,
        /// its <see cref="IDebugEventCallbacks.GetInterestMask"/> method is called to allow the client to specify which events
        /// it is interested in. For more information about callbacks, see Callbacks.
        /// </remarks>
        public int GetNumberEventCallbacks(DEBUG_EVENT_TYPE flags)
        {
            int count;
            TryGetNumberEventCallbacks(flags, out count).ThrowDbgEngNotOK();

            return count;
        }

        /// <summary>
        /// The GetNumberEventCallbacks method returns the number of event callbacks that are interested in the given events.
        /// </summary>
        /// <param name="flags">[in] Specifies a set of events used to filter out some of the event callbacks; only event callbacks that have indicated an interest in one of the events in EventFlags will be counted.<para/>
        /// See DEBUG_EVENT_XXX for a list of the events.</param>
        /// <param name="count">[out] Receives the number of event callbacks that are interested in at least one of the events in EventFlags.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// Each client can have at most one event callback registered with it. When a callback is registered with a client,
        /// its <see cref="IDebugEventCallbacks.GetInterestMask"/> method is called to allow the client to specify which events
        /// it is interested in. For more information about callbacks, see Callbacks.
        /// </remarks>
        public HRESULT TryGetNumberEventCallbacks(DEBUG_EVENT_TYPE flags, out int count)
        {
            InitDelegate(ref getNumberEventCallbacks, Vtbl5->GetNumberEventCallbacks);

            /*HRESULT GetNumberEventCallbacks(
            [In] DEBUG_EVENT_TYPE Flags,
            [Out] out int Count);*/
            return getNumberEventCallbacks(Raw, flags, out count);
        }

        #endregion
        #endregion
        #region IDebugClient6
        #region SetEventContextCallbacks

        /// <summary>
        /// Registers an event callbacks object with this client.
        /// </summary>
        /// <param name="callbacks">[in, optional] The interface pointer to the event callbacks object.</param>
        public void SetEventContextCallbacks(IDebugEventContextCallbacks callbacks)
        {
            TrySetEventContextCallbacks(callbacks).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Registers an event callbacks object with this client.
        /// </summary>
        /// <param name="callbacks">[in, optional] The interface pointer to the event callbacks object.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code. This event interface replaces the use of <see cref="EventCallbacks"/>.</returns>
        public HRESULT TrySetEventContextCallbacks(IDebugEventContextCallbacks callbacks)
        {
            InitDelegate(ref setEventContextCallbacks, Vtbl6->SetEventContextCallbacks);

            /*HRESULT SetEventContextCallbacks(
            [In] IDebugEventContextCallbacks Callbacks);*/
            return setEventContextCallbacks(Raw, callbacks);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugClient

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetKernelConnectionOptionsDelegate getKernelConnectionOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetKernelConnectionOptionsDelegate setKernelConnectionOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetProcessOptionsDelegate getProcessOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetProcessOptionsDelegate setProcessOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetExitCodeDelegate getExitCode;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetInputCallbacksDelegate getInputCallbacks;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetInputCallbacksDelegate setInputCallbacks;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOutputCallbacksDelegate getOutputCallbacks;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetOutputCallbacksDelegate setOutputCallbacks;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOutputMaskDelegate getOutputMask;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetOutputMaskDelegate setOutputMask;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOutputWidthDelegate getOutputWidth;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetOutputWidthDelegate setOutputWidth;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOutputLinePrefixDelegate getOutputLinePrefix;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetOutputLinePrefixDelegate setOutputLinePrefix;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetIdentityDelegate getIdentity;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventCallbacksDelegate getEventCallbacks;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetEventCallbacksDelegate setEventCallbacks;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AttachKernelDelegate attachKernel;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StartProcessServerDelegate startProcessServer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ConnectProcessServerDelegate connectProcessServer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DisconnectProcessServerDelegate disconnectProcessServer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetRunningProcessSystemIdsDelegate getRunningProcessSystemIds;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetRunningProcessSystemIdByExecutableNameDelegate getRunningProcessSystemIdByExecutableName;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetRunningProcessDescriptionDelegate getRunningProcessDescription;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AttachProcessDelegate attachProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateProcessDelegate createProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateProcessAndAttachDelegate createProcessAndAttach;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddProcessOptionsDelegate addProcessOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private RemoveProcessOptionsDelegate removeProcessOptions;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenDumpFileDelegate openDumpFile;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteDumpFileDelegate writeDumpFile;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ConnectSessionDelegate connectSession;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StartServerDelegate startServer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputServerDelegate outputServer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private TerminateProcessesDelegate terminateProcesses;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DetachProcessesDelegate detachProcesses;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EndSessionDelegate endSession;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DispatchCallbacksDelegate dispatchCallbacks;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ExitDispatchDelegate exitDispatch;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateClientDelegate createClient;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOtherOutputMaskDelegate getOtherOutputMask;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetOtherOutputMaskDelegate setOtherOutputMask;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputIdentityDelegate outputIdentity;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FlushCallbacksDelegate flushCallbacks;

        #endregion
        #region IDebugClient2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IsKernelDebuggerEnabledDelegate isKernelDebuggerEnabled;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteDumpFile2Delegate writeDumpFile2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddDumpInformationFileDelegate addDumpInformationFile;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EndProcessServerDelegate endProcessServer;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WaitForProcessServerEndDelegate waitForProcessServerEnd;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private TerminateCurrentProcessDelegate terminateCurrentProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DetachCurrentProcessDelegate detachCurrentProcess;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AbandonCurrentProcessDelegate abandonCurrentProcess;

        #endregion
        #region IDebugClient3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetRunningProcessSystemIdByExecutableNameWideDelegate getRunningProcessSystemIdByExecutableNameWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetRunningProcessDescriptionWideDelegate getRunningProcessDescriptionWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateProcessWideDelegate createProcessWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateProcessAndAttachWideDelegate createProcessAndAttachWide;

        #endregion
        #region IDebugClient4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberDumpFilesDelegate getNumberDumpFiles;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenDumpFileWideDelegate openDumpFileWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteDumpFileWideDelegate writeDumpFileWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddDumpInformationFileWideDelegate addDumpInformationFileWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDumpFileDelegate getDumpFile;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetDumpFileWideDelegate getDumpFileWide;

        #endregion
        #region IDebugClient5

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetKernelConnectionOptionsWideDelegate getKernelConnectionOptionsWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetKernelConnectionOptionsWideDelegate setKernelConnectionOptionsWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOutputCallbacksWideDelegate getOutputCallbacksWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetOutputCallbacksWideDelegate setOutputCallbacksWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetOutputLinePrefixWideDelegate getOutputLinePrefixWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetOutputLinePrefixWideDelegate setOutputLinePrefixWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetIdentityWideDelegate getIdentityWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEventCallbacksWideDelegate getEventCallbacksWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetEventCallbacksWideDelegate setEventCallbacksWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberInputCallbacksDelegate getNumberInputCallbacks;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberOutputCallbacksDelegate getNumberOutputCallbacks;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetQuitLockStringDelegate getQuitLockString;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetQuitLockStringDelegate setQuitLockString;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetQuitLockStringWideDelegate getQuitLockStringWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetQuitLockStringWideDelegate setQuitLockStringWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AttachKernelWideDelegate attachKernelWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StartProcessServerWideDelegate startProcessServerWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ConnectProcessServerWideDelegate connectProcessServerWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private StartServerWideDelegate startServerWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputServersWideDelegate outputServersWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OutputIdentityWideDelegate outputIdentityWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateProcess2Delegate createProcess2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateProcess2WideDelegate createProcess2Wide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateProcessAndAttach2Delegate createProcessAndAttach2;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CreateProcessAndAttach2WideDelegate createProcessAndAttach2Wide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PushOutputLinePrefixDelegate pushOutputLinePrefix;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PushOutputLinePrefixWideDelegate pushOutputLinePrefixWide;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PopOutputLinePrefixDelegate popOutputLinePrefix;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetNumberEventCallbacksDelegate getNumberEventCallbacks;

        #endregion
        #region IDebugClient6

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SetEventContextCallbacksDelegate setEventContextCallbacks;

        #endregion
        #endregion
        #region Delegates
        #region IDebugClient

        private delegate HRESULT GetKernelConnectionOptionsDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int OptionsSize);
        private delegate HRESULT SetKernelConnectionOptionsDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Options);
        private delegate HRESULT GetProcessOptionsDelegate(IntPtr self, [Out] out DEBUG_PROCESS Options);
        private delegate HRESULT SetProcessOptionsDelegate(IntPtr self, [In] DEBUG_PROCESS Options);
        private delegate HRESULT GetExitCodeDelegate(IntPtr self, [Out] out int Code);
        private delegate HRESULT GetInputCallbacksDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.Interface)] out IDebugInputCallbacks Callbacks);
        private delegate HRESULT SetInputCallbacksDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.Interface)] IDebugInputCallbacks Callbacks);
        private delegate HRESULT GetOutputCallbacksDelegate(IntPtr self, [Out] out IDebugOutputCallbacks Callbacks);
        private delegate HRESULT SetOutputCallbacksDelegate(IntPtr self, [In] IDebugOutputCallbacks Callbacks);
        private delegate HRESULT GetOutputMaskDelegate(IntPtr self, [Out] out DEBUG_OUTPUT Mask);
        private delegate HRESULT SetOutputMaskDelegate(IntPtr self, [In] DEBUG_OUTPUT Mask);
        private delegate HRESULT GetOutputWidthDelegate(IntPtr self, [Out] out int Columns);
        private delegate HRESULT SetOutputWidthDelegate(IntPtr self, [In] int Columns);
        private delegate HRESULT GetOutputLinePrefixDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int PrefixSize);
        private delegate HRESULT SetOutputLinePrefixDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Prefix);
        private delegate HRESULT GetIdentityDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int IdentitySize);
        private delegate HRESULT GetEventCallbacksDelegate(IntPtr self, [Out] out IDebugEventCallbacks Callbacks);
        private delegate HRESULT SetEventCallbacksDelegate(IntPtr self, [In] IDebugEventCallbacks Callbacks);
        private delegate HRESULT AttachKernelDelegate(IntPtr self, [In] DEBUG_ATTACH Flags, [In, MarshalAs(UnmanagedType.LPStr)] string ConnectOptions);
        private delegate HRESULT StartProcessServerDelegate(IntPtr self, [In] DEBUG_CLASS Flags, [In, MarshalAs(UnmanagedType.LPStr)] string Options, [In] IntPtr Reserved);
        private delegate HRESULT ConnectProcessServerDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string RemoteOptions, [Out] out long Server);
        private delegate HRESULT DisconnectProcessServerDelegate(IntPtr self, [In] long Server);
        private delegate HRESULT GetRunningProcessSystemIdsDelegate(IntPtr self, [In] long Server, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] Ids, [In] int Count, [Out] out int ActualCount);
        private delegate HRESULT GetRunningProcessSystemIdByExecutableNameDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPStr)] string ExeName, [In] DEBUG_GET_PROC Flags, [Out] out int Id);
        private delegate HRESULT GetRunningProcessDescriptionDelegate(IntPtr self, [In] long Server, [In] int SystemId, [In] DEBUG_PROC_DESC Flags, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 4)] char[] ExeName, [In] int ExeNameSize, [Out] out int ActualExeNameSize, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 7)] char[] Description, [In] int DescriptionSize, [Out] out int ActualDescriptionSize);
        private delegate HRESULT AttachProcessDelegate(IntPtr self, [In] long Server, [In] int ProcessID, [In] DEBUG_ATTACH AttachFlags);
        private delegate HRESULT CreateProcessDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine, [In] DEBUG_CREATE_PROCESS Flags);
        private delegate HRESULT CreateProcessAndAttachDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine, [In] DEBUG_CREATE_PROCESS Flags, [In] int ProcessId, [In] DEBUG_ATTACH AttachFlags);
        private delegate HRESULT AddProcessOptionsDelegate(IntPtr self, [In] DEBUG_PROCESS Options);
        private delegate HRESULT RemoveProcessOptionsDelegate(IntPtr self, [In] DEBUG_PROCESS Options);
        private delegate HRESULT OpenDumpFileDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile);
        private delegate HRESULT WriteDumpFileDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile, [In] DEBUG_DUMP Qualifier);
        private delegate HRESULT ConnectSessionDelegate(IntPtr self, [In] DEBUG_CONNECT_SESSION Flags, [In] int HistoryLimit);
        private delegate HRESULT StartServerDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string Options);
        private delegate HRESULT OutputServerDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPStr)] string Machine, [In] DEBUG_SERVERS Flags);
        private delegate HRESULT TerminateProcessesDelegate(IntPtr self);
        private delegate HRESULT DetachProcessesDelegate(IntPtr self);
        private delegate HRESULT EndSessionDelegate(IntPtr self, [In] DEBUG_END Flags);
        private delegate HRESULT DispatchCallbacksDelegate(IntPtr self, [In] int Timeout);
        private delegate HRESULT ExitDispatchDelegate(IntPtr self, [In] IntPtr Client);
        private delegate HRESULT CreateClientDelegate(IntPtr self, [Out, ComAliasName("IDebugClient")] out IntPtr Client);
        private delegate HRESULT GetOtherOutputMaskDelegate(IntPtr self, [In] IntPtr Client, [Out] out DEBUG_OUTPUT Mask);
        private delegate HRESULT SetOtherOutputMaskDelegate(IntPtr self, [In] IntPtr Client, [In] DEBUG_OUTPUT Mask);
        private delegate HRESULT OutputIdentityDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] int Flags, [In, MarshalAs(UnmanagedType.LPStr)] string Format);
        private delegate HRESULT FlushCallbacksDelegate(IntPtr self);

        #endregion
        #region IDebugClient2

        private delegate HRESULT IsKernelDebuggerEnabledDelegate(IntPtr self);
        private delegate HRESULT WriteDumpFile2Delegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string DumpFile, [In] DEBUG_DUMP Qualifier, [In] DEBUG_FORMAT FormatFlags, [In, MarshalAs(UnmanagedType.LPStr)] string Comment);
        private delegate HRESULT AddDumpInformationFileDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string InfoFile, [In] DEBUG_DUMP_FILE Type);
        private delegate HRESULT EndProcessServerDelegate(IntPtr self, [In] long Server);
        private delegate HRESULT WaitForProcessServerEndDelegate(IntPtr self, [In] int Timeout);
        private delegate HRESULT TerminateCurrentProcessDelegate(IntPtr self);
        private delegate HRESULT DetachCurrentProcessDelegate(IntPtr self);
        private delegate HRESULT AbandonCurrentProcessDelegate(IntPtr self);

        #endregion
        #region IDebugClient3

        private delegate HRESULT GetRunningProcessSystemIdByExecutableNameWideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string ExeName, [In] DEBUG_GET_PROC Flags, [Out] out int Id);
        private delegate HRESULT GetRunningProcessDescriptionWideDelegate(IntPtr self, [In] long Server, [In] int SystemId, [In] DEBUG_PROC_DESC Flags, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4)] char[] ExeName, [In] int ExeNameSize, [Out] out int ActualExeNameSize, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 7)] char[] Description, [In] int DescriptionSize, [Out] out int ActualDescriptionSize);
        private delegate HRESULT CreateProcessWideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine, [In] DEBUG_CREATE_PROCESS CreateFlags);
        private delegate HRESULT CreateProcessAndAttachWideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine, [In] DEBUG_CREATE_PROCESS CreateFlags, [In] int ProcessId, [In] DEBUG_ATTACH AttachFlags);

        #endregion
        #region IDebugClient4

        private delegate HRESULT GetNumberDumpFilesDelegate(IntPtr self, [Out] out int Number);
        private delegate HRESULT OpenDumpFileWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string FileName, [In] long FileHandle);
        private delegate HRESULT WriteDumpFileWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string DumpFile, [In] long FileHandle, [In] DEBUG_DUMP Qualifier, [In] DEBUG_FORMAT FormatFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string Comment);
        private delegate HRESULT AddDumpInformationFileWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string FileName, [In] long FileHandle, [In] DEBUG_DUMP_FILE Type);
        private delegate HRESULT GetDumpFileDelegate(IntPtr self, [In] int Index, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] char[] Buffer, [In] int BufferSize, [Out] out int NameSize, [Out] out long Handle, [Out] out int Type);
        private delegate HRESULT GetDumpFileWideDelegate(IntPtr self, [In] int Index, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2)] char[] Buffer, [In] int BufferSize, [Out] out int NameSize, [Out] out long Handle, [Out] out int Type);

        #endregion
        #region IDebugClient5

        private delegate HRESULT GetKernelConnectionOptionsWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int OptionsSize);
        private delegate HRESULT SetKernelConnectionOptionsWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Options);
        private delegate HRESULT GetOutputCallbacksWideDelegate(IntPtr self, [Out] out IDebugOutputCallbacksWide Callbacks);
        private delegate HRESULT SetOutputCallbacksWideDelegate(IntPtr self, [In] IDebugOutputCallbacksWide Callbacks);
        private delegate HRESULT GetOutputLinePrefixWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int PrefixSize);
        private delegate HRESULT SetOutputLinePrefixWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Prefix);
        private delegate HRESULT GetIdentityWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int IdentitySize);
        private delegate HRESULT GetEventCallbacksWideDelegate(IntPtr self, [Out] out IDebugEventCallbacksWide Callbacks);
        private delegate HRESULT SetEventCallbacksWideDelegate(IntPtr self, [In] IDebugEventCallbacksWide Callbacks);
        private delegate HRESULT GetNumberInputCallbacksDelegate(IntPtr self, [Out] out int Count);
        private delegate HRESULT GetNumberOutputCallbacksDelegate(IntPtr self, [Out] out int Count);
        private delegate HRESULT GetQuitLockStringDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int StringSize);
        private delegate HRESULT SetQuitLockStringDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string LockString);
        private delegate HRESULT GetQuitLockStringWideDelegate(IntPtr self, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] Buffer, [In] int BufferSize, [Out] out int StringSize);
        private delegate HRESULT SetQuitLockStringWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string LockString);
        private delegate HRESULT AttachKernelWideDelegate(IntPtr self, [In] DEBUG_ATTACH Flags, [In, MarshalAs(UnmanagedType.LPWStr)] string ConnectOptions);
        private delegate HRESULT StartProcessServerWideDelegate(IntPtr self, [In] DEBUG_CLASS Flags, [In, MarshalAs(UnmanagedType.LPWStr)] string Options, [In] IntPtr Reserved);
        private delegate HRESULT ConnectProcessServerWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string RemoteOptions, [Out] out long Server);
        private delegate HRESULT StartServerWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string Options);
        private delegate HRESULT OutputServersWideDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In, MarshalAs(UnmanagedType.LPWStr)] string Machine, [In] DEBUG_SERVERS Flags);
        private delegate HRESULT OutputIdentityWideDelegate(IntPtr self, [In] DEBUG_OUTCTL OutputControl, [In] int Flags, [In, MarshalAs(UnmanagedType.LPWStr)] string Machine);
        private delegate HRESULT CreateProcess2Delegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine, [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer, [In] int OptionsBufferSize, [In, MarshalAs(UnmanagedType.LPStr)] string InitialDirectory, [In, MarshalAs(UnmanagedType.LPStr)] string Environment);
        private delegate HRESULT CreateProcess2WideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine, [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer, [In] int OptionsBufferSize, [In, MarshalAs(UnmanagedType.LPWStr)] string InitialDirectory, [In, MarshalAs(UnmanagedType.LPWStr)] string Environment);
        private delegate HRESULT CreateProcessAndAttach2Delegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPStr)] string CommandLine, [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer, [In] int OptionsBufferSize, [In, MarshalAs(UnmanagedType.LPStr)] string InitialDirectory, [In, MarshalAs(UnmanagedType.LPStr)] string Environment, [In] int ProcessId, [In] DEBUG_ATTACH AttachFlags);
        private delegate HRESULT CreateProcessAndAttach2WideDelegate(IntPtr self, [In] long Server, [In, MarshalAs(UnmanagedType.LPWStr)] string CommandLine, [In] ref DEBUG_CREATE_PROCESS_OPTIONS OptionsBuffer, [In] int OptionsBufferSize, [In, MarshalAs(UnmanagedType.LPWStr)] string InitialDirectory, [In, MarshalAs(UnmanagedType.LPWStr)] string Environment, [In] int ProcessId, [In] DEBUG_ATTACH AttachFlags);
        private delegate HRESULT PushOutputLinePrefixDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPStr)] string NewPrefix, [Out] out long Handle);
        private delegate HRESULT PushOutputLinePrefixWideDelegate(IntPtr self, [In, MarshalAs(UnmanagedType.LPWStr)] string NewPrefix, [Out] out long Handle);
        private delegate HRESULT PopOutputLinePrefixDelegate(IntPtr self, [In] long Handle);
        private delegate HRESULT GetNumberEventCallbacksDelegate(IntPtr self, [In] DEBUG_EVENT_TYPE Flags, [Out] out int Count);

        #endregion
        #region IDebugClient6

        private delegate HRESULT SetEventContextCallbacksDelegate(IntPtr self, [In] IDebugEventContextCallbacks Callbacks);

        #endregion
        #endregion
    }
}
