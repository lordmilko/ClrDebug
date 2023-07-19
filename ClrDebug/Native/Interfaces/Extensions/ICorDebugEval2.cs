using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Extends "ICorDebugEval" to provide support for generic types.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FB0D9CE7-BE66-4683-9D32-A42A04E2FD91")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugEval2
    {
        /// <summary>
        /// Sets up a call to the specified <see cref="ICorDebugFunction"/>, which can be nested inside a class whose constructor takes <see cref="Type"/> parameters, or can itself take <see cref="Type"/> parameters.
        /// </summary>
        /// <param name="pFunction">[in] A pointer to an <see cref="ICorDebugFunction"/> object that represents the function to be called.</param>
        /// <param name="nTypeArgs">[in] The number of arguments that the function takes.</param>
        /// <param name="ppTypeArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugType"/> object that represents a function argument.</param>
        /// <param name="nArgs">[in] The number of values passed in the function.</param>
        /// <param name="ppArgs">[in] An array of pointers, each of which points to an <see cref="ICorDebugValue"/> object that represents a value passed in a function argument.</param>
        /// <remarks>
        /// CallParameterizedFunction is like <see cref="ICorDebugEval.CallFunction"/> except that the function may be inside
        /// a class with type parameters, may itself take type parameters, or both. The type arguments should be given first
        /// for the class, and then for the function. If the function is in a different application domain, a transition will
        /// occur. However, all type and value arguments must be in the target application domain. Function evaluation can
        /// be performed only in limited scenarios. If CallParameterizedFunction or <see cref="ICorDebugEval.CallFunction"/> fails, the
        /// returned <see cref="HRESULT"/> will indicate the most general possible reason for failure.
        /// </remarks>
        [PreserveSig]
        HRESULT CallParameterizedFunction(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugFunction pFunction,
            [In] int nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In] ref ICorDebugType ppTypeArgs,
            [In] int nArgs,
            [MarshalAs(UnmanagedType.Interface), In] ref ICorDebugValue ppArgs);

        /// <summary>
        /// Gets a pointer to a new <see cref="ICorDebugValue"/> of the specified type, with an initial value of zero or null.
        /// </summary>
        /// <param name="pType">[in] Pointer to an <see cref="ICorDebugType"/> object that represents the type.</param>
        /// <param name="ppValue">[out] Pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value.</param>
        /// <remarks>
        /// CreateValueForType generalizes <see cref="ICorDebugEval.CreateValue"/> by allowing you to specify an arbitrary
        /// object type, including constructed types such as List&lt;int&gt;. The only purpose of this method is to generate
        /// a value that can be passed to a function evaluation. The type must be a class or a value type. You cannot use this
        /// method to create array values or string values.
        /// </remarks>
        [PreserveSig]
        HRESULT CreateValueForType(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugType pType,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);

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
        [PreserveSig]
        HRESULT NewParameterizedObject(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugFunction pConstructor,
            [In] int nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In] ref ICorDebugType ppTypeArgs,
            [In] int nArgs,
            [MarshalAs(UnmanagedType.Interface), In] ref ICorDebugValue ppArgs);

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
        [PreserveSig]
        HRESULT NewParameterizedObjectNoConstructor(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugClass pClass,
            [In] int nTypeArgs,
            [MarshalAs(UnmanagedType.Interface), In] ref ICorDebugType ppTypeArgs);

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
        [PreserveSig]
        HRESULT NewParameterizedArray(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugType pElementType,
            [In] int rank,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] dims,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] lowBounds);

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
        [PreserveSig]
        HRESULT NewStringWithLength(
            [MarshalAs(UnmanagedType.LPWStr), In] string @string,
            [In] int uiLength);

        /// <summary>
        /// Aborts the computation that this <see cref="ICorDebugEval2"/> is currently performing.
        /// </summary>
        /// <remarks>
        /// RudeAbort does not release any locks that the evaluator holds, so it leaves the debugging session in an unsafe
        /// state. Call this method with extreme caution.
        /// </remarks>
        [PreserveSig]
        HRESULT RudeAbort();
    }
}
