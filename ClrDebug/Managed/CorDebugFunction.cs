using System.Diagnostics;
using System.Linq;

namespace ClrDebug
{
    /// <summary>
    /// Represents a managed function or method.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugFunction"/> interface does not represent a function with generic type parameters. For example, an <see cref="ICorDebugFunction"/>
    /// instance would represent Func&lt;T&gt; but not Func&lt;string&gt;. Call <see cref="CorDebugILFrame.EnumerateTypeParameters"/>
    /// to get the generic type parameters. The relationship between a method's metadata token, <see cref="mdMethodDef"/>, and a method's
    /// <see cref="ICorDebugFunction"/> object is dependent upon whether Edit and Continue is allowed on the function:
    /// </remarks>
    public class CorDebugFunction : ComObject<ICorDebugFunction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugFunction"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugFunction(ICorDebugFunction raw) : base(raw)
        {
        }

        #region ICorDebugFunction
        #region Module

        /// <summary>
        /// Gets the module in which this function is defined.
        /// </summary>
        public CorDebugModule Module
        {
            get
            {
                CorDebugModule ppModuleResult;
                TryGetModule(out ppModuleResult).ThrowOnNotOK();

                return ppModuleResult;
            }
        }

        /// <summary>
        /// Gets the module in which this function is defined.
        /// </summary>
        /// <param name="ppModuleResult">[out] A pointer to the address of an <see cref="ICorDebugModule"/> object that represents the module in which this function is defined.</param>
        public HRESULT TryGetModule(out CorDebugModule ppModuleResult)
        {
            /*HRESULT GetModule([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);*/
            ICorDebugModule ppModule;
            HRESULT hr = Raw.GetModule(out ppModule);

            if (hr == HRESULT.S_OK)
                ppModuleResult = new CorDebugModule(ppModule);
            else
                ppModuleResult = default(CorDebugModule);

            return hr;
        }

        #endregion
        #region Class

        /// <summary>
        /// Gets an <see cref="ICorDebugClass"/> object that represents the class this function is a member of.
        /// </summary>
        public CorDebugClass Class
        {
            get
            {
                CorDebugClass ppClassResult;
                TryGetClass(out ppClassResult).ThrowOnNotOK();

                return ppClassResult;
            }
        }

        /// <summary>
        /// Gets an <see cref="ICorDebugClass"/> object that represents the class this function is a member of.
        /// </summary>
        /// <param name="ppClassResult">[out] A pointer to the address of the <see cref="ICorDebugClass"/> object that represents the class, or null, if this function is not a member of a class.</param>
        public HRESULT TryGetClass(out CorDebugClass ppClassResult)
        {
            /*HRESULT GetClass([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugClass ppClass);*/
            ICorDebugClass ppClass;
            HRESULT hr = Raw.GetClass(out ppClass);

            if (hr == HRESULT.S_OK)
                ppClassResult = new CorDebugClass(ppClass);
            else
                ppClassResult = default(CorDebugClass);

            return hr;
        }

        #endregion
        #region Token

        /// <summary>
        /// Gets the metadata token for this function.
        /// </summary>
        public mdMethodDef Token
        {
            get
            {
                mdMethodDef pMethodDef;
                TryGetToken(out pMethodDef).ThrowOnNotOK();

                return pMethodDef;
            }
        }

        /// <summary>
        /// Gets the metadata token for this function.
        /// </summary>
        /// <param name="pMethodDef">[out] A pointer to an <see cref="mdMethodDef"/> token that references the metadata for this function.</param>
        public HRESULT TryGetToken(out mdMethodDef pMethodDef)
        {
            /*HRESULT GetToken([Out] out mdMethodDef pMethodDef);*/
            return Raw.GetToken(out pMethodDef);
        }

        #endregion
        #region ILCode

        /// <summary>
        /// Gets the <see cref="ICorDebugCode"/> instance that represents the Microsoft intermediate language (MSIL) code associated with this <see cref="ICorDebugFunction"/> object.
        /// </summary>
        public CorDebugCode ILCode
        {
            get
            {
                CorDebugCode ppCodeResult;
                TryGetILCode(out ppCodeResult).ThrowOnNotOK();

                return ppCodeResult;
            }
        }

        /// <summary>
        /// Gets the <see cref="ICorDebugCode"/> instance that represents the Microsoft intermediate language (MSIL) code associated with this <see cref="ICorDebugFunction"/> object.
        /// </summary>
        /// <param name="ppCodeResult">[out] A pointer to the <see cref="ICorDebugCode"/> instance, or null, if the function was not compiled into MSIL.</param>
        /// <remarks>
        /// If Edit and Continue has been allowed on this function, the GetILCode method will get the MSIL code corresponding
        /// to this function's edited version of the code in the common language runtime (CLR).
        /// </remarks>
        public HRESULT TryGetILCode(out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetILCode([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
            ICorDebugCode ppCode;
            HRESULT hr = Raw.GetILCode(out ppCode);

            if (hr == HRESULT.S_OK)
                ppCodeResult = new CorDebugCode(ppCode);
            else
                ppCodeResult = default(CorDebugCode);

            return hr;
        }

        #endregion
        #region NativeCode

        /// <summary>
        /// Gets the native code for the function that is represented by this <see cref="ICorDebugFunction"/> instance.
        /// </summary>
        public CorDebugCode NativeCode
        {
            get
            {
                CorDebugCode ppCodeResult;
                TryGetNativeCode(out ppCodeResult).ThrowOnNotOK();

                return ppCodeResult;
            }
        }

        /// <summary>
        /// Gets the native code for the function that is represented by this <see cref="ICorDebugFunction"/> instance.
        /// </summary>
        /// <param name="ppCodeResult">[out] A pointer to the <see cref="ICorDebugCode"/> instance that represents the native code for this function, or null, if this function is Microsoft intermediate language (MSIL) code that has not been just-in-time (JIT) compiled.</param>
        /// <remarks>
        /// If the function that is represented by this <see cref="ICorDebugFunction"/> instance has been JIT-compiled more than once, as
        /// in the case of generic types, GetNativeCode returns a random native code object.
        /// </remarks>
        public HRESULT TryGetNativeCode(out CorDebugCode ppCodeResult)
        {
            /*HRESULT GetNativeCode([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCode ppCode);*/
            ICorDebugCode ppCode;
            HRESULT hr = Raw.GetNativeCode(out ppCode);

            if (hr == HRESULT.S_OK)
                ppCodeResult = new CorDebugCode(ppCode);
            else
                ppCodeResult = default(CorDebugCode);

            return hr;
        }

        #endregion
        #region LocalVarSigToken

        /// <summary>
        /// Gets the metadata token for the local variable signature of the function that is represented by this <see cref="ICorDebugFunction"/> instance.
        /// </summary>
        public mdSignature LocalVarSigToken
        {
            get
            {
                mdSignature pmdSig;
                TryGetLocalVarSigToken(out pmdSig).ThrowOnNotOK();

                return pmdSig;
            }
        }

        /// <summary>
        /// Gets the metadata token for the local variable signature of the function that is represented by this <see cref="ICorDebugFunction"/> instance.
        /// </summary>
        /// <param name="pmdSig">[out] A pointer to the <see cref="mdSignature"/> token for the local variable signature of this function, or mdSignatureNil, if this function has no local variables.</param>
        public HRESULT TryGetLocalVarSigToken(out mdSignature pmdSig)
        {
            /*HRESULT GetLocalVarSigToken([Out] out mdSignature pmdSig);*/
            return Raw.GetLocalVarSigToken(out pmdSig);
        }

        #endregion
        #region CurrentVersionNumber

        /// <summary>
        /// Gets the version number of the latest edit made to the function represented by this <see cref="ICorDebugFunction"/> object.
        /// </summary>
        public int CurrentVersionNumber
        {
            get
            {
                int pnCurrentVersion;
                TryGetCurrentVersionNumber(out pnCurrentVersion).ThrowOnNotOK();

                return pnCurrentVersion;
            }
        }

        /// <summary>
        /// Gets the version number of the latest edit made to the function represented by this <see cref="ICorDebugFunction"/> object.
        /// </summary>
        /// <param name="pnCurrentVersion">[out] A pointer to an integer value that is the version number of the latest edit made to this function.</param>
        /// <remarks>
        /// The version number of the latest edit made to this function may be greater than the version number of the function
        /// itself. Use either the <see cref="VersionNumber"/> property or the <see cref="CorDebugCode.VersionNumber"/>
        /// property to retrieve the version number of the function.
        /// </remarks>
        public HRESULT TryGetCurrentVersionNumber(out int pnCurrentVersion)
        {
            /*HRESULT GetCurrentVersionNumber([Out] out int pnCurrentVersion);*/
            return Raw.GetCurrentVersionNumber(out pnCurrentVersion);
        }

        #endregion
        #region CreateBreakpoint

        /// <summary>
        /// Creates a breakpoint at the beginning of this function.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugFunctionBreakpoint"/> object that represents the new breakpoint for the function.</returns>
        public CorDebugFunctionBreakpoint CreateBreakpoint()
        {
            CorDebugFunctionBreakpoint ppBreakpointResult;
            TryCreateBreakpoint(out ppBreakpointResult).ThrowOnNotOK();

            return ppBreakpointResult;
        }

        /// <summary>
        /// Creates a breakpoint at the beginning of this function.
        /// </summary>
        /// <param name="ppBreakpointResult">[out] A pointer to the address of an <see cref="ICorDebugFunctionBreakpoint"/> object that represents the new breakpoint for the function.</param>
        public HRESULT TryCreateBreakpoint(out CorDebugFunctionBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateBreakpoint([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunctionBreakpoint ppBreakpoint);*/
            ICorDebugFunctionBreakpoint ppBreakpoint;
            HRESULT hr = Raw.CreateBreakpoint(out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = new CorDebugFunctionBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(CorDebugFunctionBreakpoint);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugFunction2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugFunction2 Raw2 => (ICorDebugFunction2) Raw;

        #region JMCStatus

        /// <summary>
        /// Gets or sets a value that indicates whether the function that is represented by this <see cref="ICorDebugFunction2"/> object is marked as user code.
        /// </summary>
        public bool JMCStatus
        {
            get
            {
                bool pbIsJustMyCode;
                TryGetJMCStatus(out pbIsJustMyCode).ThrowOnNotOK();

                return pbIsJustMyCode;
            }
            set
            {
                TrySetJMCStatus(value).ThrowOnNotOK();
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the function that is represented by this <see cref="ICorDebugFunction2"/> object is marked as user code.
        /// </summary>
        /// <param name="pbIsJustMyCode">[out] A pointer to a Boolean value that is true, if this function is marked as user code; otherwise, the value is false.</param>
        /// <remarks>
        /// If the function represented by this <see cref="ICorDebugFunction2"/> cannot be debugged, pbIsJustMyCode will always be false.
        /// </remarks>
        public HRESULT TryGetJMCStatus(out bool pbIsJustMyCode)
        {
            /*HRESULT GetJMCStatus([Out] out bool pbIsJustMyCode);*/
            return Raw2.GetJMCStatus(out pbIsJustMyCode);
        }

        /// <summary>
        /// Marks the function represented by this <see cref="ICorDebugFunction2"/> for Just My Code stepping.
        /// </summary>
        /// <param name="bIsJustMyCode">[in] Set to true to mark the function as user code; otherwise, set to false.</param>
        /// <returns>
        /// | HRESULT                          | Description                                                                  |
        /// | -------------------------------- | ---------------------------------------------------------------------------- |
        /// | S_OK                             | The function was successfully marked.                                        |
        /// | CORDBG_E_FUNCTION_NOT_DEBUGGABLE | The function could not be marked as user code because it cannot be debugged. |
        /// </returns>
        /// <remarks>
        /// A Just My Code stepper will skip non-user code. User code must be a subset of debuggable code.
        /// </remarks>
        public HRESULT TrySetJMCStatus(bool bIsJustMyCode)
        {
            /*HRESULT SetJMCStatus([In] bool bIsJustMyCode);*/
            return Raw2.SetJMCStatus(bIsJustMyCode);
        }

        #endregion
        #region VersionNumber

        /// <summary>
        /// Gets the Edit and Continue version of this function.
        /// </summary>
        public int VersionNumber
        {
            get
            {
                int pnVersion;
                TryGetVersionNumber(out pnVersion).ThrowOnNotOK();

                return pnVersion;
            }
        }

        /// <summary>
        /// Gets the Edit and Continue version of this function.
        /// </summary>
        /// <param name="pnVersion">[out] A pointer to an integer that is the version number of the function that is represented by this <see cref="ICorDebugFunction2"/> object.</param>
        /// <remarks>
        /// The runtime keeps track of the number of edits that have taken place to each module during a debug session. The
        /// version number of a function is one more than the number of the edit that introduced the function. The function's
        /// original version is version 1. The number is incremented for a module every time <see cref="CorDebugModule.ApplyChanges"/>
        /// is called on that module. Thus, if a function’s body was replaced in the first and third call to <see cref="CorDebugModule.ApplyChanges"/>,
        /// GetVersionNumber may return version 1, 2, or 4 for that function, but not version 3. (That function would have
        /// no version 3.) The version number is tracked separately for each module. So, if you perform four edits on Module
        /// 1, and none on Module 2, your next edit on Module 1 will assign a version number of 6 to all the edited functions
        /// in Module 1. If the same edit touches Module 2, the functions in Module 2 will get a version number of 2. The version
        /// number obtained by the GetVersionNumber method may be lower than that obtained by <see cref="CurrentVersionNumber"/>.
        /// The <see cref="CorDebugCode.VersionNumber"/> property performs the same operation as ICorDebugFunction2::GetVersionNumber.
        /// </remarks>
        public HRESULT TryGetVersionNumber(out int pnVersion)
        {
            /*HRESULT GetVersionNumber([Out] out int pnVersion);*/
            return Raw2.GetVersionNumber(out pnVersion);
        }

        #endregion
        #region EnumerateNativeCode

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugCodeEnum"/> object that contains the native code statements in the function referenced by this <see cref="ICorDebugFunction2"/> object.
        /// </summary>
        public CorDebugCode[] NativeCodes => EnumerateNativeCode().ToArray();

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugCodeEnum"/> object that contains the native code statements in the function referenced by this <see cref="ICorDebugFunction2"/> object.
        /// </summary>
        public CorDebugCodeEnum EnumerateNativeCode()
        {
            CorDebugCodeEnum ppCodeEnumResult;
            TryEnumerateNativeCode(out ppCodeEnumResult).ThrowOnNotOK();

            return ppCodeEnumResult;
        }

        /// <summary>
        /// Gets an interface pointer to an <see cref="ICorDebugCodeEnum"/> object that contains the native code statements in the function referenced by this <see cref="ICorDebugFunction2"/> object.
        /// </summary>
        public HRESULT TryEnumerateNativeCode(out CorDebugCodeEnum ppCodeEnumResult)
        {
            /*HRESULT EnumerateNativeCode([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugCodeEnum ppCodeEnum);*/
            ICorDebugCodeEnum ppCodeEnum;
            HRESULT hr = Raw2.EnumerateNativeCode(out ppCodeEnum);

            if (hr == HRESULT.S_OK)
                ppCodeEnumResult = new CorDebugCodeEnum(ppCodeEnum);
            else
                ppCodeEnumResult = default(CorDebugCodeEnum);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugFunction3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugFunction3 Raw3 => (ICorDebugFunction3) Raw;

        #region ActiveReJitRequestILCode

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets an interface pointer to an <see cref="ICorDebugILCode"/> that contains the IL from an active ReJIT request.
        /// </summary>
        public CorDebugILCode ActiveReJitRequestILCode
        {
            get
            {
                CorDebugILCode ppReJitedILCodeResult;
                TryGetActiveReJitRequestILCode(out ppReJitedILCodeResult).ThrowOnNotOK();

                return ppReJitedILCodeResult;
            }
        }

        /// <summary>
        /// [Supported in the .NET Framework 4.5.2 and later versions] Gets an interface pointer to an <see cref="ICorDebugILCode"/> that contains the IL from an active ReJIT request.
        /// </summary>
        /// <param name="ppReJitedILCodeResult">A pointer to the IL from an active ReJIT request.</param>
        /// <remarks>
        /// If the method represented by this <see cref="ICorDebugFunction3"/> object has an active ReJIT request, ppReJitedILCode returns
        /// a pointer to its IL. If there is no active request, which is a common case, then ppReJitedILCode is null. A ReJIT
        /// request becomes active just after execution returns from the ICorProfilerCallback4.GetReJITParameters method call.
        /// It may not yet be JIT-compiled, and threads may still be executing in the original version of the code. A ReJIT
        /// request becomes inactive during the profiler's call to the ICorProfilerInfo4.RequestRevert method. Even after the
        /// IL is reverted, a thread can still be executing in the JIT-recompiled (ReJIT) code.
        /// </remarks>
        public HRESULT TryGetActiveReJitRequestILCode(out CorDebugILCode ppReJitedILCodeResult)
        {
            /*HRESULT GetActiveReJitRequestILCode([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugILCode ppReJitedILCode);*/
            ICorDebugILCode ppReJitedILCode;
            HRESULT hr = Raw3.GetActiveReJitRequestILCode(out ppReJitedILCode);

            if (hr == HRESULT.S_OK)
                ppReJitedILCodeResult = new CorDebugILCode(ppReJitedILCode);
            else
                ppReJitedILCodeResult = default(CorDebugILCode);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugFunction4

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugFunction4 Raw4 => (ICorDebugFunction4) Raw;

        #region CreateNativeBreakpoint

        public CorDebugFunctionBreakpoint CreateNativeBreakpoint()
        {
            CorDebugFunctionBreakpoint ppBreakpointResult;
            TryCreateNativeBreakpoint(out ppBreakpointResult).ThrowOnNotOK();

            return ppBreakpointResult;
        }

        public HRESULT TryCreateNativeBreakpoint(out CorDebugFunctionBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateNativeBreakpoint([MarshalAs(UnmanagedType.Interface)] out ICorDebugFunctionBreakpoint ppBreakpoint);*/
            ICorDebugFunctionBreakpoint ppBreakpoint;
            HRESULT hr = Raw4.CreateNativeBreakpoint(out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = new CorDebugFunctionBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(CorDebugFunctionBreakpoint);

            return hr;
        }

        #endregion
        #endregion
    }
}
