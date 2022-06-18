using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to enable the debugger to execute code within the context of the code being debugged.
    /// </summary>
    /// <remarks>
    /// An <see cref="ICorDebugEval"/> object is created in the context of a specific thread that is used to perform the evaluations.
    /// All objects and types used in a given evaluation must reside within the same application domain. That application
    /// domain need not be the same as the current application domain of the thread. Evaluations can be nested. The evaluation's
    /// operations do not complete until the debugger calls <see cref="ICorDebugController.Continue"/>, and then receives
    /// an <see cref="ICorDebugManagedCallback.EvalComplete"/> callback. If you need to use the evaluation functionality
    /// without allowing other threads to run, suspend the threads by using either <see cref="ICorDebugController.SetAllThreadsDebugState"/>
    /// or <see cref="ICorDebugController.Stop"/> before calling <see cref="ICorDebugController.Continue"/>. Because user
    /// code is running when the evaluation is in progress, any debug events can occur, including class loads and breakpoints.
    /// The debugger will receive callbacks, as normal, for these events. The state of the evaluation will be seen as part
    /// of the inspection of the normal program state. The stack chain will be a CHAIN_FUNC_EVAL chain (see the "CorDebugStepReason"
    /// enumeration and the <see cref="ICorDebugChain.GetReason"/> method). The full debugger API will continue to operate
    /// as normal. If a deadlocked or infinite looping situation arises, the user code may never complete. In such a case,
    /// you must call <see cref="Abort"/> before resuming the program.
    /// </remarks>
    [Guid("CC7BCAF6-8A68-11D2-983C-0000F808342D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugEval
    {
        /// <summary>
        /// Sets up a call to the specified function. This method is obsolete in the .NET Framework version 2.0. Use <see cref="ICorDebugEval2.CallParameterizedFunction"/> instead.
        /// </summary>
        /// <param name="pFunction">[in] Pointer to an <see cref="ICorDebugFunction"/> object that specifies the function to be called.</param>
        /// <param name="nArgs">[in] The number of arguments for the function.</param>
        /// <param name="ppArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugValue"/> object that specifies an argument to be passed to the function.</param>
        /// <remarks>
        /// If the function is virtual, CallFunction will perform virtual dispatch. If the function is in a different application
        /// domain, a transition will occur as long as all arguments are also in that application domain.
        /// </remarks>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CallFunction([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction, [In] int nArgs, [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);

        /// <summary>
        /// Allocates a new object instance and calls the specified constructor method. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="ICorDebugEval2.NewParameterizedObject"/> instead.
        /// </summary>
        /// <param name="pConstructor">[in] The constructor to be called.</param>
        /// <param name="nArgs">[in] The size of the ppArgs array.</param>
        /// <param name="ppArgs">[in] An array of <see cref="ICorDebugValue"/> objects, each of which represents an argument to be passed to the constructor.</param>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT NewObject([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pConstructor, [In] int nArgs, [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);

        /// <summary>
        /// Allocates a new object instance of the specified type, without attempting to call a constructor method. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="ICorDebugEval2.NewParameterizedObjectNoConstructor"/> instead.
        /// </summary>
        /// <param name="pClass">[in] Pointer to an <see cref="ICorDebugClass"/> object that represents the type of object to be instantiated.</param>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT NewObjectNoConstructor([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass);

        /// <summary>
        /// Allocates a new string instance with the specified contents.
        /// </summary>
        /// <param name="string">[in] Pointer to the contents for the string.</param>
        /// <remarks>
        /// The string is always created in the application domain in which the thread is currently executing.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT NewString([MarshalAs(UnmanagedType.LPWStr), In] string @string);

        /// <summary>
        /// Allocates a new array of the specified element type and dimensions. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="ICorDebugEval2.NewParameterizedArray"/> instead.
        /// </summary>
        /// <param name="elementType">[in] A value of the <see cref="CorElementType"/> enumeration that specifies the element type of the array.</param>
        /// <param name="pElementClass">[in] A pointer to a <see cref="ICorDebugClass"/> object that specifies the class of the element. This value may be null if the element type is a primitive type.</param>
        /// <param name="rank">[in] The number of dimensions of the array. In the .NET Framework 2.0, this value must be 1.</param>
        /// <param name="dims">[in] The size, in bytes, of each dimension of the array.</param>
        /// <param name="lowBounds">[in] Optional. The lower bound of each dimension of the array. If this value is omitted, a lower bound of zero is assumed for each dimension.</param>
        /// <remarks>
        /// The array is always created in the application domain in which the thread is currently executing.
        /// </remarks>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT NewArray(
            [In] CorElementType elementType,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pElementClass,
            [In] int rank,
            [In] ref int dims,
            [In] ref int lowBounds);

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugEval"/> object is currently executing.
        /// </summary>
        /// <param name="pbActive">[out] Pointer to a value that indicates whether this evaluation is active.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsActive([Out] out int pbActive);

        /// <summary>
        /// Aborts the computation this <see cref="ICorDebugEval"/> object is currently performing.
        /// </summary>
        /// <remarks>
        /// If the evaluation is nested and it is not the most recent one, the Abort method may fail.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Abort();

        /// <summary>
        /// Gets the results of this evaluation.
        /// </summary>
        /// <param name="ppResult">[out] Pointer to the address of an <see cref="ICorDebugValue"/> object that represents the results of this evaluation, if the evaluation completes normally.</param>
        /// <remarks>
        /// The GetResult method is valid only after the evaluation is completed. If the evaluation completes normally, ppResult
        /// specifies the results. If it terminates with an exception, the result is the exception thrown. If the evaluation
        /// was for a new object, the result is the reference to the new object.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetResult([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppResult);

        /// <summary>
        /// Gets the thread in which this evaluation is executing or will execute.
        /// </summary>
        /// <param name="ppThread">[out] A pointer to the address of an <see cref="ICorDebugThread"/> object that represents the thread.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThread([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        /// <summary>
        /// Creates a value of the specified type, with an initial value of zero or null. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="ICorDebugEval2.CreateValueForType"/> instead.
        /// </summary>
        /// <param name="elementType">[in] A value of the <see cref="CorElementType"/> enumeration that specifies the type of the value.</param>
        /// <param name="pElementClass">[in] Pointer to an <see cref="ICorDebugClass"/> object that specifies the class of the value, if the type is not a primitive type.</param>
        /// <param name="ppValue">[out] Pointer to the address of an "ICorDebugValue" object that represents the value.</param>
        /// <remarks>
        /// CreateValue creates an <see cref="ICorDebugValue"/> object of the given type for the sole purpose of using it in a function evaluation.
        /// This value object can be used to pass user constants as parameters. If the type of the value is a primitive type,
        /// its initial value is zero or null. Use <see cref="ICorDebugGenericValue.SetValue"/> to set the value of a primitive
        /// type. If the value of elementType is ELEMENT_TYPE_CLASS, you get an "ICorDebugReferenceValue" (returned in ppValue)
        /// representing the null object reference. You can use this object to pass null to a function evaluation that has
        /// object reference parameters. You cannot set the <see cref="ICorDebugValue"/> to anything; it always remains null.
        /// </remarks>
        [Obsolete]
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateValue([In] int elementType, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pElementClass, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);
    }
}