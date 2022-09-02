namespace ClrDebug
{
    /// <summary>
    /// Allows you to define optional async method information for each method symbol. Always use with an opened method; that is, between calls to the <see cref="SymUnmanagedWriter.OpenMethod"/> and the <see cref="SymUnmanagedWriter.CloseMethod"/>.
    /// </summary>
    public class SymUnmanagedAsyncMethodPropertiesWriter : ComObject<ISymUnmanagedAsyncMethodPropertiesWriter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedAsyncMethodPropertiesWriter"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedAsyncMethodPropertiesWriter(ISymUnmanagedAsyncMethodPropertiesWriter raw) : base(raw)
        {
        }

        #region ISymUnmanagedAsyncMethodPropertiesWriter
        #region DefineKickoffMethod

        /// <summary>
        /// Sets the starting method that initiates the async operation.
        /// </summary>
        public void DefineKickoffMethod(int kickoffMethod)
        {
            TryDefineKickoffMethod(kickoffMethod).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the starting method that initiates the async operation.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryDefineKickoffMethod(int kickoffMethod)
        {
            /*HRESULT DefineKickoffMethod(
            [In] int kickoffMethod);*/
            return Raw.DefineKickoffMethod(kickoffMethod);
        }

        #endregion
        #region DefineCatchHandlerILOffset

        /// <summary>
        /// Sets the IL offset for the compiler-generated catch handler that wraps an async method. The IL offset of the generated catch is used by the debugger to handle the catch as if it were non-user code even though it might occur in a user code method.<para/>
        /// In particular, it is used in response to a CatchHandlerFound exception event.
        /// </summary>
        public void DefineCatchHandlerILOffset(int catchHandlerOffset)
        {
            TryDefineCatchHandlerILOffset(catchHandlerOffset).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the IL offset for the compiler-generated catch handler that wraps an async method. The IL offset of the generated catch is used by the debugger to handle the catch as if it were non-user code even though it might occur in a user code method.<para/>
        /// In particular, it is used in response to a CatchHandlerFound exception event.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryDefineCatchHandlerILOffset(int catchHandlerOffset)
        {
            /*HRESULT DefineCatchHandlerILOffset(
            [In] int catchHandlerOffset);*/
            return Raw.DefineCatchHandlerILOffset(catchHandlerOffset);
        }

        #endregion
        #region DefineAsyncStepInfo

        /// <summary>
        /// Define a group of async await operations in the current method. Each yield offset matches an await's return instruction, identifying a potential yield.<para/>
        /// Each breakpointMethod/breakpointOffset pair tells us where the asynchronous operation will resume which could be in a different method.
        /// </summary>
        public void DefineAsyncStepInfo(int count, int[] yieldOffsets, int[] breakpointOffset, int[] breakpointMethod)
        {
            TryDefineAsyncStepInfo(count, yieldOffsets, breakpointOffset, breakpointMethod).ThrowOnNotOK();
        }

        /// <summary>
        /// Define a group of async await operations in the current method. Each yield offset matches an await's return instruction, identifying a potential yield.<para/>
        /// Each breakpointMethod/breakpointOffset pair tells us where the asynchronous operation will resume which could be in a different method.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryDefineAsyncStepInfo(int count, int[] yieldOffsets, int[] breakpointOffset, int[] breakpointMethod)
        {
            /*HRESULT DefineAsyncStepInfo(
            [In] int count,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] yieldOffsets,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] breakpointOffset,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] breakpointMethod);*/
            return Raw.DefineAsyncStepInfo(count, yieldOffsets, breakpointOffset, breakpointMethod);
        }

        #endregion
        #endregion
    }
}
