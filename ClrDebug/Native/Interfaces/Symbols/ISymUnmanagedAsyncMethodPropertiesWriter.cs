using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Allows you to define optional async method information for each method symbol. Always use with an opened method; that is, between calls to the <see cref="ISymUnmanagedWriter.OpenMethod"/> and the <see cref="ISymUnmanagedWriter.CloseMethod"/>.
    /// </summary>
    [Guid("FC073774-1739-4232-BD56-A027294BEC15")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISymUnmanagedAsyncMethodPropertiesWriter
    {
        /// <summary>
        /// Sets the starting method that initiates the async operation.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        HRESULT DefineKickoffMethod(
            [In] int kickoffMethod);

        /// <summary>
        /// Sets the IL offset for the compiler-generated catch handler that wraps an async method. The IL offset of the generated catch is used by the debugger to handle the catch as if it were non-user code even though it might occur in a user code method.<para/>
        /// In particular, it is used in response to a CatchHandlerFound exception event.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        HRESULT DefineCatchHandlerILOffset(
            [In] int catchHandlerOffset);

        /// <summary>
        /// Define a group of async await operations in the current method. Each yield offset matches an await's return instruction, identifying a potential yield.<para/>
        /// Each breakpointMethod/breakpointOffset pair tells us where the asynchronous operation will resume which could be in a different method.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        [PreserveSig]
        HRESULT DefineAsyncStepInfo(
            [In] int count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] yieldOffsets,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] breakpointOffset,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] breakpointMethod);
    }
}
