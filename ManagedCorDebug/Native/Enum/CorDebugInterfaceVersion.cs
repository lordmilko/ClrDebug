namespace ManagedCorDebug
{
    /// <summary>
    /// Specifies an interface, a version of the .NET Framework, or a version of the .NET Framework in which an interface was introduced.
    /// </summary>
    /// <remarks>
    /// A debugger can use the CorDebugInterfaceVersion enumeration in the CreateDebuggingInterfaceFromVersion function
    /// to specify the highest version of the .NET Framework that the debugger supports.
    /// </remarks>
    public enum CorDebugInterfaceVersion
    {
        /// <summary>
        /// The version of the .NET Framework is invalid.
        /// </summary>
        CorDebugInvalidVersion = 0,

        /// <summary>
        /// The version of the .NET Framework, including all its service packs, is 1.0.
        /// </summary>
        CorDebugVersion_1_0 = CorDebugInvalidVersion + 1,

        /// <summary>
        /// <see cref="ICorDebugManagedCallback"/>
        /// </summary>
        ver_ICorDebugManagedCallback = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugUnmanagedCallback"/>
        /// </summary>
        ver_ICorDebugUnmanagedCallback = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebug"/>
        /// </summary>
        ver_ICorDebug = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugController"/>
        /// </summary>
        ver_ICorDebugController = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugAppDomain"/>
        /// </summary>
        ver_ICorDebugAppDomain = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugAssembly"/>
        /// </summary>
        ver_ICorDebugAssembly = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugProcess"/>
        /// </summary>
        ver_ICorDebugProcess = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugBreakpoint"/>
        /// </summary>
        ver_ICorDebugBreakpoint = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugFunctionBreakpoint"/>
        /// </summary>
        ver_ICorDebugFunctionBreakpoint = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugModuleBreakpoint"/>
        /// </summary>
        ver_ICorDebugModuleBreakpoint = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugValueBreakpoint"/>
        /// </summary>
        ver_ICorDebugValueBreakpoint = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugStepper"/>
        /// </summary>
        ver_ICorDebugStepper = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugRegisterSet"/>
        /// </summary>
        ver_ICorDebugRegisterSet = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugThread"/>
        /// </summary>
        ver_ICorDebugThread = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugChain"/>
        /// </summary>
        ver_ICorDebugChain = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugFrame"/>
        /// </summary>
        ver_ICorDebugFrame = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugILFrame"/>
        /// </summary>
        ver_ICorDebugILFrame = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugNativeFrame"/>
        /// </summary>
        ver_ICorDebugNativeFrame = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugModule"/>
        /// </summary>
        ver_ICorDebugModule = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugFunction"/>
        /// </summary>
        ver_ICorDebugFunction = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugCode"/>
        /// </summary>
        ver_ICorDebugCode = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugClass"/>
        /// </summary>
        ver_ICorDebugClass = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugEval"/>
        /// </summary>
        ver_ICorDebugEval = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugValue"/>
        /// </summary>
        ver_ICorDebugValue = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugGenericValue"/>
        /// </summary>
        ver_ICorDebugGenericValue = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugReferenceValue"/>
        /// </summary>
        ver_ICorDebugReferenceValue = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugHeapValue"/>
        /// </summary>
        ver_ICorDebugHeapValue = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugObjectValue"/>
        /// </summary>
        ver_ICorDebugObjectValue = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugBoxValue"/>
        /// </summary>
        ver_ICorDebugBoxValue = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugStringValue"/>
        /// </summary>
        ver_ICorDebugStringValue = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugArrayValue"/>
        /// </summary>
        ver_ICorDebugArrayValue = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugContext"/>
        /// </summary>
        ver_ICorDebugContext = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugEnum"/>
        /// </summary>
        ver_ICorDebugEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugObjectEnum"/>
        /// </summary>
        ver_ICorDebugObjectEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugBreakpointEnum"/>
        /// </summary>
        ver_ICorDebugBreakpointEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugStepperEnum"/>
        /// </summary>
        ver_ICorDebugStepperEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugProcessEnum"/>
        /// </summary>
        ver_ICorDebugProcessEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugThreadEnum"/>
        /// </summary>
        ver_ICorDebugThreadEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugFrameEnum"/>
        /// </summary>
        ver_ICorDebugFrameEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugChainEnum"/>
        /// </summary>
        ver_ICorDebugChainEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugModuleEnum"/>
        /// </summary>
        ver_ICorDebugModuleEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugValueEnum"/>
        /// </summary>
        ver_ICorDebugValueEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugCodeEnum"/>
        /// </summary>
        ver_ICorDebugCodeEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugTypeEnum"/>
        /// </summary>
        ver_ICorDebugTypeEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugErrorInfoEnum"/>
        /// </summary>
        ver_ICorDebugErrorInfoEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugAppDomainEnum"/>
        /// </summary>
        ver_ICorDebugAppDomainEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugAssemblyEnum"/>
        /// </summary>
        ver_ICorDebugAssemblyEnum = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugEditAndContinueErrorInfo"/>
        /// </summary>
        ver_ICorDebugEditAndContinueErrorInfo = CorDebugVersion_1_0,

        /// <summary>
        /// <see cref="ICorDebugEditAndContinueSnapshot"/>
        /// </summary>
        ver_ICorDebugEditAndContinueSnapshot = CorDebugVersion_1_0,

        /// <summary>
        /// The version of the .NET Framework, including all service packs, is 1.1.
        /// </summary>
        CorDebugVersion_1_1 = CorDebugVersion_1_0 + 1,

        /// <summary>
        /// The version of the .NET Framework, including all service packs, is 2.0.
        /// </summary>
        CorDebugVersion_2_0 = CorDebugVersion_1_1 + 1,

        /// <summary>
        /// <see cref="ICorDebugManagedCallback2"/>
        /// </summary>
        ver_ICorDebugManagedCallback2 = CorDebugVersion_2_0,

        /// <summary>
        /// <see cref="ICorDebugAppDomain2"/>
        /// </summary>
        ver_ICorDebugAppDomain2 = CorDebugVersion_2_0,
        ver_ICorDebugAssembly2 = CorDebugVersion_2_0,

        /// <summary>
        /// <see cref="ICorDebugProcess2"/>
        /// </summary>
        ver_ICorDebugProcess2 = CorDebugVersion_2_0,

        /// <summary>
        /// <see cref="ICorDebugStepper2"/>
        /// </summary>
        ver_ICorDebugStepper2 = CorDebugVersion_2_0,

        /// <summary>
        /// <see cref="ICorDebugRegisterSet2"/>
        /// </summary>
        ver_ICorDebugRegisterSet2 = CorDebugVersion_2_0,

        /// <summary>
        /// <see cref="ICorDebugThread2"/>
        /// </summary>
        ver_ICorDebugThread2 = CorDebugVersion_2_0,

        /// <summary>
        /// <see cref="ICorDebugILFrame2"/>
        /// </summary>
        ver_ICorDebugILFrame2 = CorDebugVersion_2_0,
        ver_ICorDebugInternalFrame = CorDebugVersion_2_0,

        /// <summary>
        /// <see cref="ICorDebugModule2"/>
        /// </summary>
        ver_ICorDebugModule2 = CorDebugVersion_2_0,

        /// <summary>
        /// <see cref="ICorDebugFunction2"/>
        /// </summary>
        ver_ICorDebugFunction2 = CorDebugVersion_2_0,

        /// <summary>
        /// <see cref="ICorDebugCode2"/>
        /// </summary>
        ver_ICorDebugCode2 = CorDebugVersion_2_0,

        /// <summary>
        /// "ICorDebugClass2"
        /// </summary>
        ver_ICorDebugClass2 = CorDebugVersion_2_0,

        /// <summary>
        /// "ICorDebugValue2"
        /// </summary>
        ver_ICorDebugValue2 = CorDebugVersion_2_0,

        /// <summary>
        /// The "ICorDebugEval2".
        /// </summary>
        ver_ICorDebugEval2 = CorDebugVersion_2_0,

        /// <summary>
        /// "ICorDebugObjectValue2"
        /// </summary>
        ver_ICorDebugObjectValue2 = CorDebugVersion_2_0,

        /// <summary>
        /// The version of the .NET Framework, including all service packs, is 4.
        /// </summary>
        CorDebugVersion_4_0 = CorDebugVersion_2_0 + 1,

        /// <summary>
        /// <see cref="ICorDebugThread3"/>
        /// </summary>
        ver_ICorDebugThread3 = CorDebugVersion_4_0,

        /// <summary>
        /// <see cref="ICorDebugThread4"/>
        /// </summary>
        ver_ICorDebugThread4 = CorDebugVersion_4_0,

        /// <summary>
        /// <see cref="ICorDebugStackWalk"/>
        /// </summary>
        ver_ICorDebugStackWalk = CorDebugVersion_4_0,

        /// <summary>
        /// <see cref="ICorDebugNativeFrame2"/>
        /// </summary>
        ver_ICorDebugNativeFrame2 = CorDebugVersion_4_0,

        /// <summary>
        /// <see cref="ICorDebugInternalFrame2"/>
        /// </summary>
        ver_ICorDebugInternalFrame2 = CorDebugVersion_4_0,

        /// <summary>
        /// <see cref="ICorDebugRuntimeUnwindableFrame"/>
        /// </summary>
        ver_ICorDebugRuntimeUnwindableFrame = CorDebugVersion_4_0,

        /// <summary>
        /// <see cref="ICorDebugHeapValue3"/>
        /// </summary>
        ver_ICorDebugHeapValue3 = CorDebugVersion_4_0,

        /// <summary>
        /// <see cref="ICorDebugBlockingObjectEnum"/>
        /// </summary>
        ver_ICorDebugBlockingObjectEnum = CorDebugVersion_4_0,

        /// <summary>
        /// <see cref="ICorDebugValue3"/>
        /// </summary>
        ver_ICorDebugValue3 = CorDebugVersion_4_0,

        /// <summary>
        /// The version of the .NET Framework, including all service packs, is 4.5.
        /// </summary>
        CorDebugVersion_4_5 = CorDebugVersion_4_0 + 1,

        /// <summary>
        /// <see cref="ICorDebugComObjectValue"/>
        /// </summary>
        ver_ICorDebugComObjectValue = CorDebugVersion_4_5,

        /// <summary>
        /// <see cref="ICorDebugAppDomain3"/>
        /// </summary>
        ver_ICorDebugAppDomain3 = CorDebugVersion_4_5,

        /// <summary>
        /// <see cref="ICorDebugCode3"/>
        /// </summary>
        ver_ICorDebugCode3 = CorDebugVersion_4_5,

        /// <summary>
        /// <see cref="ICorDebugILFrame3"/>
        /// </summary>
        ver_ICorDebugILFrame3 = CorDebugVersion_4_5,

        /// <summary>
        /// The version of the .NET Framework, including all of its service packs, is the latest version.
        /// </summary>
        CorDebugLatestVersion = CorDebugVersion_4_5
    }
}