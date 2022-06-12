using System;
using System.Diagnostics;
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
    /// operations do not complete until the debugger calls <see cref="CorDebugController.Continue"/>, and then receives
    /// an <see cref="CorDebugManagedCallback.EvalComplete"/> callback. If you need to use the evaluation functionality
    /// without allowing other threads to run, suspend the threads by using either <see cref="CorDebugController.SetAllThreadsDebugState"/>
    /// or <see cref="CorDebugController.Stop"/> before calling <see cref="CorDebugController.Continue"/>. Because user
    /// code is running when the evaluation is in progress, any debug events can occur, including class loads and breakpoints.
    /// The debugger will receive callbacks, as normal, for these events. The state of the evaluation will be seen as part
    /// of the inspection of the normal program state. The stack chain will be a CHAIN_FUNC_EVAL chain (see the "CorDebugStepReason"
    /// enumeration and the <see cref="CorDebugChain.Reason"/> property). The full debugger API will continue to operate
    /// as normal. If a deadlocked or infinite looping situation arises, the user code may never complete. In such a case,
    /// you must call <see cref="Abort"/> before resuming the program.
    /// </remarks>
    public class CorDebugEval : ComObject<ICorDebugEval>
    {
        public CorDebugEval(ICorDebugEval raw) : base(raw)
        {
        }

        #region ICorDebugEval
        #region IsActive

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugEval"/> object is currently executing.
        /// </summary>
        public bool IsActive
        {
            get
            {
                HRESULT hr;
                bool pbActiveResult;

                if ((hr = TryIsActive(out pbActiveResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbActiveResult;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugEval"/> object is currently executing.
        /// </summary>
        /// <param name="pbActiveResult">[out] Pointer to a value that indicates whether this evaluation is active.</param>
        public HRESULT TryIsActive(out bool pbActiveResult)
        {
            /*HRESULT IsActive(out int pbActive);*/
            int pbActive;
            HRESULT hr = Raw.IsActive(out pbActive);

            if (hr == HRESULT.S_OK)
                pbActiveResult = pbActive == 1;
            else
                pbActiveResult = default(bool);

            return hr;
        }

        #endregion
        #region Result

        /// <summary>
        /// Gets the results of this evaluation.
        /// </summary>
        public CorDebugValue Result
        {
            get
            {
                HRESULT hr;
                CorDebugValue ppResultResult;

                if ((hr = TryGetResult(out ppResultResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppResultResult;
            }
        }

        /// <summary>
        /// Gets the results of this evaluation.
        /// </summary>
        /// <param name="ppResultResult">[out] Pointer to the address of an <see cref="ICorDebugValue"/> object that represents the results of this evaluation, if the evaluation completes normally.</param>
        /// <remarks>
        /// The GetResult method is valid only after the evaluation is completed. If the evaluation completes normally, ppResult
        /// specifies the results. If it terminates with an exception, the result is the exception thrown. If the evaluation
        /// was for a new object, the result is the reference to the new object.
        /// </remarks>
        public HRESULT TryGetResult(out CorDebugValue ppResultResult)
        {
            /*HRESULT GetResult([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppResult);*/
            ICorDebugValue ppResult;
            HRESULT hr = Raw.GetResult(out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = CorDebugValue.New(ppResult);
            else
                ppResultResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region Thread

        /// <summary>
        /// Gets the thread in which this evaluation is executing or will execute.
        /// </summary>
        public CorDebugThread Thread
        {
            get
            {
                HRESULT hr;
                CorDebugThread ppThreadResult;

                if ((hr = TryGetThread(out ppThreadResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppThreadResult;
            }
        }

        /// <summary>
        /// Gets the thread in which this evaluation is executing or will execute.
        /// </summary>
        /// <param name="ppThreadResult">[out] A pointer to the address of an <see cref="ICorDebugThread"/> object that represents the thread.</param>
        public HRESULT TryGetThread(out CorDebugThread ppThreadResult)
        {
            /*HRESULT GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);*/
            ICorDebugThread ppThread;
            HRESULT hr = Raw.GetThread(out ppThread);

            if (hr == HRESULT.S_OK)
                ppThreadResult = new CorDebugThread(ppThread);
            else
                ppThreadResult = default(CorDebugThread);

            return hr;
        }

        #endregion
        #region CallFunction

        /// <summary>
        /// Sets up a call to the specified function. This method is obsolete in the .NET Framework version 2.0. Use <see cref="CallParameterizedFunction"/> instead.
        /// </summary>
        /// <param name="pFunction">[in] Pointer to an <see cref="ICorDebugFunction"/> object that specifies the function to be called.</param>
        /// <param name="nArgs">[in] The number of arguments for the function.</param>
        /// <param name="ppArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugValue"/> object that specifies an argument to be passed to the function.</param>
        /// <remarks>
        /// If the function is virtual, CallFunction will perform virtual dispatch. If the function is in a different application
        /// domain, a transition will occur as long as all arguments are also in that application domain.
        /// </remarks>
        [Obsolete]
        public void CallFunction(ICorDebugFunction pFunction, int nArgs, ICorDebugValue ppArgs)
        {
            HRESULT hr;

            if ((hr = TryCallFunction(pFunction, nArgs, ppArgs)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets up a call to the specified function. This method is obsolete in the .NET Framework version 2.0. Use <see cref="CallParameterizedFunction"/> instead.
        /// </summary>
        /// <param name="pFunction">[in] Pointer to an <see cref="ICorDebugFunction"/> object that specifies the function to be called.</param>
        /// <param name="nArgs">[in] The number of arguments for the function.</param>
        /// <param name="ppArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugValue"/> object that specifies an argument to be passed to the function.</param>
        /// <remarks>
        /// If the function is virtual, CallFunction will perform virtual dispatch. If the function is in a different application
        /// domain, a transition will occur as long as all arguments are also in that application domain.
        /// </remarks>
        [Obsolete]
        public HRESULT TryCallFunction(ICorDebugFunction pFunction, int nArgs, ICorDebugValue ppArgs)
        {
            /*HRESULT CallFunction([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction, [In] int nArgs, [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);*/
            return Raw.CallFunction(pFunction, nArgs, ref ppArgs);
        }

        #endregion
        #region NewObject

        /// <summary>
        /// Allocates a new object instance and calls the specified constructor method. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="NewParameterizedObject"/> instead.
        /// </summary>
        /// <param name="pConstructor">[in] The constructor to be called.</param>
        /// <param name="nArgs">[in] The size of the ppArgs array.</param>
        /// <param name="ppArgs">[in] An array of <see cref="ICorDebugValue"/> objects, each of which represents an argument to be passed to the constructor.</param>
        [Obsolete]
        public void NewObject(ICorDebugFunction pConstructor, int nArgs, ICorDebugValue ppArgs)
        {
            HRESULT hr;

            if ((hr = TryNewObject(pConstructor, nArgs, ppArgs)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Allocates a new object instance and calls the specified constructor method. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="NewParameterizedObject"/> instead.
        /// </summary>
        /// <param name="pConstructor">[in] The constructor to be called.</param>
        /// <param name="nArgs">[in] The size of the ppArgs array.</param>
        /// <param name="ppArgs">[in] An array of <see cref="ICorDebugValue"/> objects, each of which represents an argument to be passed to the constructor.</param>
        [Obsolete]
        public HRESULT TryNewObject(ICorDebugFunction pConstructor, int nArgs, ICorDebugValue ppArgs)
        {
            /*HRESULT NewObject([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pConstructor, [In] int nArgs, [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);*/
            return Raw.NewObject(pConstructor, nArgs, ref ppArgs);
        }

        #endregion
        #region NewObjectNoConstructor

        /// <summary>
        /// Allocates a new object instance of the specified type, without attempting to call a constructor method. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="NewParameterizedObjectNoConstructor"/> instead.
        /// </summary>
        /// <param name="pClass">[in] Pointer to an <see cref="ICorDebugClass"/> object that represents the type of object to be instantiated.</param>
        [Obsolete]
        public void NewObjectNoConstructor(ICorDebugClass pClass)
        {
            HRESULT hr;

            if ((hr = TryNewObjectNoConstructor(pClass)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Allocates a new object instance of the specified type, without attempting to call a constructor method. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="NewParameterizedObjectNoConstructor"/> instead.
        /// </summary>
        /// <param name="pClass">[in] Pointer to an <see cref="ICorDebugClass"/> object that represents the type of object to be instantiated.</param>
        [Obsolete]
        public HRESULT TryNewObjectNoConstructor(ICorDebugClass pClass)
        {
            /*HRESULT NewObjectNoConstructor([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass);*/
            return Raw.NewObjectNoConstructor(pClass);
        }

        #endregion
        #region NewString

        /// <summary>
        /// Allocates a new string instance with the specified contents.
        /// </summary>
        /// <param name="string">[in] Pointer to the contents for the string.</param>
        /// <remarks>
        /// The string is always created in the application domain in which the thread is currently executing.
        /// </remarks>
        public void NewString(string @string)
        {
            HRESULT hr;

            if ((hr = TryNewString(@string)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Allocates a new string instance with the specified contents.
        /// </summary>
        /// <param name="string">[in] Pointer to the contents for the string.</param>
        /// <remarks>
        /// The string is always created in the application domain in which the thread is currently executing.
        /// </remarks>
        public HRESULT TryNewString(string @string)
        {
            /*HRESULT NewString([MarshalAs(UnmanagedType.LPWStr), In] string @string);*/
            return Raw.NewString(@string);
        }

        #endregion
        #region NewArray

        /// <summary>
        /// Allocates a new array of the specified element type and dimensions. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="NewParameterizedArray"/> instead.
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
        public void NewArray(CorElementType elementType, ICorDebugClass pElementClass, int rank, int dims, int lowBounds)
        {
            HRESULT hr;

            if ((hr = TryNewArray(elementType, pElementClass, rank, dims, lowBounds)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Allocates a new array of the specified element type and dimensions. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="NewParameterizedArray"/> instead.
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
        public HRESULT TryNewArray(CorElementType elementType, ICorDebugClass pElementClass, int rank, int dims, int lowBounds)
        {
            /*HRESULT NewArray(
            [In] CorElementType elementType,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pElementClass,
            [In] int rank,
            [In] ref int dims,
            [In] ref int lowBounds);*/
            return Raw.NewArray(elementType, pElementClass, rank, ref dims, ref lowBounds);
        }

        #endregion
        #region Abort

        /// <summary>
        /// Aborts the computation this <see cref="ICorDebugEval"/> object is currently performing.
        /// </summary>
        /// <remarks>
        /// If the evaluation is nested and it is not the most recent one, the Abort method may fail.
        /// </remarks>
        public void Abort()
        {
            HRESULT hr;

            if ((hr = TryAbort()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Aborts the computation this <see cref="ICorDebugEval"/> object is currently performing.
        /// </summary>
        /// <remarks>
        /// If the evaluation is nested and it is not the most recent one, the Abort method may fail.
        /// </remarks>
        public HRESULT TryAbort()
        {
            /*HRESULT Abort();*/
            return Raw.Abort();
        }

        #endregion
        #region CreateValue

        /// <summary>
        /// Creates a value of the specified type, with an initial value of zero or null. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="CreateValueForType"/> instead.
        /// </summary>
        /// <param name="elementType">[in] A value of the <see cref="CorElementType"/> enumeration that specifies the type of the value.</param>
        /// <param name="pElementClass">[in] Pointer to an <see cref="ICorDebugClass"/> object that specifies the class of the value, if the type is not a primitive type.</param>
        /// <returns>[out] Pointer to the address of an "ICorDebugValue" object that represents the value.</returns>
        /// <remarks>
        /// CreateValue creates an <see cref="ICorDebugValue"/> object of the given type for the sole purpose of using it in a function evaluation.
        /// This value object can be used to pass user constants as parameters. If the type of the value is a primitive type,
        /// its initial value is zero or null. Use <see cref="CorDebugGenericValue.Value"/> to set the value of a primitive
        /// type. If the value of elementType is ELEMENT_TYPE_CLASS, you get an "ICorDebugReferenceValue" (returned in ppValue)
        /// representing the null object reference. You can use this object to pass null to a function evaluation that has
        /// object reference parameters. You cannot set the <see cref="ICorDebugValue"/> to anything; it always remains null.
        /// </remarks>
        [Obsolete]
        public CorDebugValue CreateValue(int elementType, ICorDebugClass pElementClass)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryCreateValue(elementType, pElementClass, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        /// <summary>
        /// Creates a value of the specified type, with an initial value of zero or null. This method is obsolete in the .NET Framework version 2.0.<para/>
        /// Use <see cref="CreateValueForType"/> instead.
        /// </summary>
        /// <param name="elementType">[in] A value of the <see cref="CorElementType"/> enumeration that specifies the type of the value.</param>
        /// <param name="pElementClass">[in] Pointer to an <see cref="ICorDebugClass"/> object that specifies the class of the value, if the type is not a primitive type.</param>
        /// <param name="ppValueResult">[out] Pointer to the address of an "ICorDebugValue" object that represents the value.</param>
        /// <remarks>
        /// CreateValue creates an <see cref="ICorDebugValue"/> object of the given type for the sole purpose of using it in a function evaluation.
        /// This value object can be used to pass user constants as parameters. If the type of the value is a primitive type,
        /// its initial value is zero or null. Use <see cref="CorDebugGenericValue.Value"/> to set the value of a primitive
        /// type. If the value of elementType is ELEMENT_TYPE_CLASS, you get an "ICorDebugReferenceValue" (returned in ppValue)
        /// representing the null object reference. You can use this object to pass null to a function evaluation that has
        /// object reference parameters. You cannot set the <see cref="ICorDebugValue"/> to anything; it always remains null.
        /// </remarks>
        [Obsolete]
        public HRESULT TryCreateValue(int elementType, ICorDebugClass pElementClass, out CorDebugValue ppValueResult)
        {
            /*HRESULT CreateValue([In] int elementType, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pElementClass, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.CreateValue(elementType, pElementClass, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
        #region ICorDebugEval2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICorDebugEval2 Raw2 => (ICorDebugEval2) Raw;

        #region CallParameterizedFunction

        /// <summary>
        /// Sets up a call to the specified <see cref="ICorDebugFunction"/>, which can be nested inside a class whose constructor takes <see cref="Type"/> parameters, or can itself take <see cref="Type"/> parameters.
        /// </summary>
        /// <param name="pFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the function to be called.</param>
        /// <param name="nTypeArgs">[in] The number of arguments that the function takes.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a function argument.</param>
        /// <param name="nArgs">[in] The number of values passed in the function.</param>
        /// <param name="ppArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugValue"/> object that represents a value passed in a function argument.</param>
        /// <remarks>
        /// CallParameterizedFunction is like <see cref="CallFunction"/> except that the function may be inside
        /// a class with type parameters, may itself take type parameters, or both. The type arguments should be given first
        /// for the class, and then for the function. If the function is in a different application domain, a transition will
        /// occur. However, all type and value arguments must be in the target application domain. Function evaluation can
        /// be performed only in limited scenarios. If CallParameterizedFunction or <see cref="CallFunction"/> fails, the
        /// returned <see cref="HRESULT"/> will indicate the most general possible reason for failure.
        /// </remarks>
        public void CallParameterizedFunction(ICorDebugFunction pFunction, int nTypeArgs, ICorDebugType ppTypeArgs, int nArgs, ICorDebugValue ppArgs)
        {
            HRESULT hr;

            if ((hr = TryCallParameterizedFunction(pFunction, nTypeArgs, ppTypeArgs, nArgs, ppArgs)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets up a call to the specified <see cref="ICorDebugFunction"/>, which can be nested inside a class whose constructor takes <see cref="Type"/> parameters, or can itself take <see cref="Type"/> parameters.
        /// </summary>
        /// <param name="pFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the function to be called.</param>
        /// <param name="nTypeArgs">[in] The number of arguments that the function takes.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a function argument.</param>
        /// <param name="nArgs">[in] The number of values passed in the function.</param>
        /// <param name="ppArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugValue"/> object that represents a value passed in a function argument.</param>
        /// <remarks>
        /// CallParameterizedFunction is like <see cref="CallFunction"/> except that the function may be inside
        /// a class with type parameters, may itself take type parameters, or both. The type arguments should be given first
        /// for the class, and then for the function. If the function is in a different application domain, a transition will
        /// occur. However, all type and value arguments must be in the target application domain. Function evaluation can
        /// be performed only in limited scenarios. If CallParameterizedFunction or <see cref="CallFunction"/> fails, the
        /// returned <see cref="HRESULT"/> will indicate the most general possible reason for failure.
        /// </remarks>
        public HRESULT TryCallParameterizedFunction(ICorDebugFunction pFunction, int nTypeArgs, ICorDebugType ppTypeArgs, int nArgs, ICorDebugValue ppArgs)
        {
            /*HRESULT CallParameterizedFunction(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction,
            [In] int nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [In] int nArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);*/
            return Raw2.CallParameterizedFunction(pFunction, nTypeArgs, ref ppTypeArgs, nArgs, ref ppArgs);
        }

        #endregion
        #region CreateValueForType

        /// <summary>
        /// Gets a pointer to a new <see cref="ICorDebugValue"/> of the specified type, with an initial value of zero or null.
        /// </summary>
        /// <param name="pType">[in] Pointer to an <see cref="ICorDebugType"/> object that represents the type.</param>
        /// <returns>[out] Pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value.</returns>
        /// <remarks>
        /// CreateValueForType generalizes <see cref="CreateValue"/> by allowing you to specify an arbitrary
        /// object type, including constructed types such as List&lt;int&gt;. The only purpose of this method is to generate
        /// a value that can be passed to a function evaluation. The type must be a class or a value type. You cannot use this
        /// method to create array values or string values.
        /// </remarks>
        public CorDebugValue CreateValueForType(ICorDebugType pType)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryCreateValueForType(pType, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        /// <summary>
        /// Gets a pointer to a new <see cref="ICorDebugValue"/> of the specified type, with an initial value of zero or null.
        /// </summary>
        /// <param name="pType">[in] Pointer to an <see cref="ICorDebugType"/> object that represents the type.</param>
        /// <param name="ppValueResult">[out] Pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value.</param>
        /// <remarks>
        /// CreateValueForType generalizes <see cref="CreateValue"/> by allowing you to specify an arbitrary
        /// object type, including constructed types such as List&lt;int&gt;. The only purpose of this method is to generate
        /// a value that can be passed to a function evaluation. The type must be a class or a value type. You cannot use this
        /// method to create array values or string values.
        /// </remarks>
        public HRESULT TryCreateValueForType(ICorDebugType pType, out CorDebugValue ppValueResult)
        {
            /*HRESULT CreateValueForType([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugType pType, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw2.CreateValueForType(pType, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region NewParameterizedObject

        /// <summary>
        /// Instantiates a new parameterized type object and calls the object's constructor method.
        /// </summary>
        /// <param name="pConstructor">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the constructor of the object to be instantiated.</param>
        /// <param name="nTypeArgs">[in] The number of type arguments passed.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a type argument for the object that is being instantiated.</param>
        /// <param name="nArgs">[in] The number of arguments passed to the constructor.</param>
        /// <param name="ppArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugValue"/> object that represents an argument value that is passed to the constructor.</param>
        /// <remarks>
        /// The object's constructor may take <see cref="Type"/> parameters.
        /// </remarks>
        public void NewParameterizedObject(ICorDebugFunction pConstructor, int nTypeArgs, ICorDebugType ppTypeArgs, int nArgs, ICorDebugValue ppArgs)
        {
            HRESULT hr;

            if ((hr = TryNewParameterizedObject(pConstructor, nTypeArgs, ppTypeArgs, nArgs, ppArgs)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Instantiates a new parameterized type object and calls the object's constructor method.
        /// </summary>
        /// <param name="pConstructor">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the constructor of the object to be instantiated.</param>
        /// <param name="nTypeArgs">[in] The number of type arguments passed.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a type argument for the object that is being instantiated.</param>
        /// <param name="nArgs">[in] The number of arguments passed to the constructor.</param>
        /// <param name="ppArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugValue"/> object that represents an argument value that is passed to the constructor.</param>
        /// <remarks>
        /// The object's constructor may take <see cref="Type"/> parameters.
        /// </remarks>
        public HRESULT TryNewParameterizedObject(ICorDebugFunction pConstructor, int nTypeArgs, ICorDebugType ppTypeArgs, int nArgs, ICorDebugValue ppArgs)
        {
            /*HRESULT NewParameterizedObject(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pConstructor,
            [In] int nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs,
            [In] int nArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugValue ppArgs);*/
            return Raw2.NewParameterizedObject(pConstructor, nTypeArgs, ref ppTypeArgs, nArgs, ref ppArgs);
        }

        #endregion
        #region NewParameterizedObjectNoConstructor

        /// <summary>
        /// Instantiates a new parameterized type object of the specified class without attempting to call a constructor method.
        /// </summary>
        /// <param name="pClass">[in] A pointer to an <see cref="ICorDebugClass"/> object that represents the class of the object to be instantiated.</param>
        /// <param name="nTypeArgs">[in] The number of type arguments passed.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a type argument for the object that is being instantiated.</param>
        /// <remarks>
        /// The NewParameterizedObjectNoConstructor method will fail if an incorrect number of type arguments or the wrong
        /// types of type arguments are passed.
        /// </remarks>
        public void NewParameterizedObjectNoConstructor(ICorDebugClass pClass, int nTypeArgs, ICorDebugType ppTypeArgs)
        {
            HRESULT hr;

            if ((hr = TryNewParameterizedObjectNoConstructor(pClass, nTypeArgs, ppTypeArgs)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Instantiates a new parameterized type object of the specified class without attempting to call a constructor method.
        /// </summary>
        /// <param name="pClass">[in] A pointer to an <see cref="ICorDebugClass"/> object that represents the class of the object to be instantiated.</param>
        /// <param name="nTypeArgs">[in] The number of type arguments passed.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a type argument for the object that is being instantiated.</param>
        /// <remarks>
        /// The NewParameterizedObjectNoConstructor method will fail if an incorrect number of type arguments or the wrong
        /// types of type arguments are passed.
        /// </remarks>
        public HRESULT TryNewParameterizedObjectNoConstructor(ICorDebugClass pClass, int nTypeArgs, ICorDebugType ppTypeArgs)
        {
            /*HRESULT NewParameterizedObjectNoConstructor(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass pClass,
            [In] int nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugType ppTypeArgs);*/
            return Raw2.NewParameterizedObjectNoConstructor(pClass, nTypeArgs, ref ppTypeArgs);
        }

        #endregion
        #region NewParameterizedArray

        /// <summary>
        /// Allocates a new array of the specified element type and dimensions.
        /// </summary>
        /// <param name="pElementType">[in] A pointer to an <see cref="ICorDebugType"/> object that represents the type of element stored in the array.</param>
        /// <param name="rank">[in] The number of dimensions of the array. In the .NET Framework version 2.0, this value must be 1.</param>
        /// <param name="dims">[in] The size, in bytes, of each dimension of the array.</param>
        /// <param name="lowBounds">[in] Optional. The lower bound of each dimension of the array. If this value is omitted, a lower bound of zero is assumed for each dimension.</param>
        /// <remarks>
        /// The elements of the array may be instances of a generic type. The array is always created in the application domain
        /// in which the thread is currently running. In the .NET Framework 2.0, the value of rank must be 1.
        /// </remarks>
        public void NewParameterizedArray(ICorDebugType pElementType, int rank, int dims, int lowBounds)
        {
            HRESULT hr;

            if ((hr = TryNewParameterizedArray(pElementType, rank, dims, lowBounds)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Allocates a new array of the specified element type and dimensions.
        /// </summary>
        /// <param name="pElementType">[in] A pointer to an <see cref="ICorDebugType"/> object that represents the type of element stored in the array.</param>
        /// <param name="rank">[in] The number of dimensions of the array. In the .NET Framework version 2.0, this value must be 1.</param>
        /// <param name="dims">[in] The size, in bytes, of each dimension of the array.</param>
        /// <param name="lowBounds">[in] Optional. The lower bound of each dimension of the array. If this value is omitted, a lower bound of zero is assumed for each dimension.</param>
        /// <remarks>
        /// The elements of the array may be instances of a generic type. The array is always created in the application domain
        /// in which the thread is currently running. In the .NET Framework 2.0, the value of rank must be 1.
        /// </remarks>
        public HRESULT TryNewParameterizedArray(ICorDebugType pElementType, int rank, int dims, int lowBounds)
        {
            /*HRESULT NewParameterizedArray(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugType pElementType,
            [In] int rank,
            [In] ref int dims,
            [In] ref int lowBounds);*/
            return Raw2.NewParameterizedArray(pElementType, rank, ref dims, ref lowBounds);
        }

        #endregion
        #region NewStringWithLength

        /// <summary>
        /// Creates a string of the specified length, with the specified contents.
        /// </summary>
        /// <param name="string">[in] A pointer to the string value.</param>
        /// <param name="uiLength">[in] Length of the string.</param>
        /// <remarks>
        /// If the string's trailing null character is expected to be in the managed string, the caller of the NewStringWithLength
        /// method must ensure that the string length includes the trailing null character. The string is always created in
        /// the application domain in which the thread is currently executing.
        /// </remarks>
        public void NewStringWithLength(string @string, int uiLength)
        {
            HRESULT hr;

            if ((hr = TryNewStringWithLength(@string, uiLength)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Creates a string of the specified length, with the specified contents.
        /// </summary>
        /// <param name="string">[in] A pointer to the string value.</param>
        /// <param name="uiLength">[in] Length of the string.</param>
        /// <remarks>
        /// If the string's trailing null character is expected to be in the managed string, the caller of the NewStringWithLength
        /// method must ensure that the string length includes the trailing null character. The string is always created in
        /// the application domain in which the thread is currently executing.
        /// </remarks>
        public HRESULT TryNewStringWithLength(string @string, int uiLength)
        {
            /*HRESULT NewStringWithLength([MarshalAs(UnmanagedType.LPWStr), In] string @string, [In] int uiLength);*/
            return Raw2.NewStringWithLength(@string, uiLength);
        }

        #endregion
        #region RudeAbort

        /// <summary>
        /// Aborts the computation that this <see cref="ICorDebugEval2"/> is currently performing.
        /// </summary>
        /// <remarks>
        /// RudeAbort does not release any locks that the evaluator holds, so it leaves the debugging session in an unsafe
        /// state. Call this method with extreme caution.
        /// </remarks>
        public void RudeAbort()
        {
            HRESULT hr;

            if ((hr = TryRudeAbort()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Aborts the computation that this <see cref="ICorDebugEval2"/> is currently performing.
        /// </summary>
        /// <remarks>
        /// RudeAbort does not release any locks that the evaluator holds, so it leaves the debugging session in an unsafe
        /// state. Call this method with extreme caution.
        /// </remarks>
        public HRESULT TryRudeAbort()
        {
            /*HRESULT RudeAbort();*/
            return Raw2.RudeAbort();
        }

        #endregion
        #endregion
    }
}