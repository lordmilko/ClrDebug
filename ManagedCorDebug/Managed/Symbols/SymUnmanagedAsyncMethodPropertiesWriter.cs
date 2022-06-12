using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Allows you to define optional async method information for each method symbol. Always use with an opened method; that is, between calls to the <see cref="SymUnmanagedWriter.OpenMethod"/> and the <see cref="SymUnmanagedWriter.CloseMethod"/>.
    /// </summary>
    public class SymUnmanagedAsyncMethodPropertiesWriter : ComObject<ISymUnmanagedAsyncMethodPropertiesWriter>
    {
        public SymUnmanagedAsyncMethodPropertiesWriter(ISymUnmanagedAsyncMethodPropertiesWriter raw) : base(raw)
        {
        }

        #region ISymUnmanagedAsyncMethodPropertiesWriter
        #region DefineKickoffMethod

        /// <summary>
        /// Sets the starting method that initiates the async operation.
        /// </summary>
        public void DefineKickoffMethod(uint kickoffMethod)
        {
            HRESULT hr;

            if ((hr = TryDefineKickoffMethod(kickoffMethod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets the starting method that initiates the async operation.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryDefineKickoffMethod(uint kickoffMethod)
        {
            /*HRESULT DefineKickoffMethod([In] uint kickoffMethod);*/
            return Raw.DefineKickoffMethod(kickoffMethod);
        }

        #endregion
        #region DefineCatchHandlerILOffset

        /// <summary>
        /// Sets the IL offset for the compiler-generated catch handler that wraps an async method. The IL offset of the generated catch is used by the debugger to handle the catch as if it were non-user code even though it might occur in a user code method.<para/>
        /// In particular, it is used in response to a CatchHandlerFound exception event.
        /// </summary>
        public void DefineCatchHandlerILOffset(uint catchHandlerOffset)
        {
            HRESULT hr;

            if ((hr = TryDefineCatchHandlerILOffset(catchHandlerOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets the IL offset for the compiler-generated catch handler that wraps an async method. The IL offset of the generated catch is used by the debugger to handle the catch as if it were non-user code even though it might occur in a user code method.<para/>
        /// In particular, it is used in response to a CatchHandlerFound exception event.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryDefineCatchHandlerILOffset(uint catchHandlerOffset)
        {
            /*HRESULT DefineCatchHandlerILOffset([In] uint catchHandlerOffset);*/
            return Raw.DefineCatchHandlerILOffset(catchHandlerOffset);
        }

        #endregion
        #region DefineAsyncStepInfo

        /// <summary>
        /// Define a group of async await operations in the current method. Each yield offset matches an await's return instruction, identifying a potential yield.<para/>
        /// Each breakpointMethod/breakpointOffset pair tells us where the asynchronous operation will resume which could be in a different method.
        /// </summary>
        public void DefineAsyncStepInfo(uint count, uint yieldOffsets, uint breakpointOffset, uint breakpointMethod)
        {
            HRESULT hr;

            if ((hr = TryDefineAsyncStepInfo(count, yieldOffsets, breakpointOffset, breakpointMethod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Define a group of async await operations in the current method. Each yield offset matches an await's return instruction, identifying a potential yield.<para/>
        /// Each breakpointMethod/breakpointOffset pair tells us where the asynchronous operation will resume which could be in a different method.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryDefineAsyncStepInfo(uint count, uint yieldOffsets, uint breakpointOffset, uint breakpointMethod)
        {
            /*HRESULT DefineAsyncStepInfo(
            [In] uint count,
            [In] ref uint yieldOffsets,
            [In] ref uint breakpointOffset,
            [In] ref uint breakpointMethod);*/
            return Raw.DefineAsyncStepInfo(count, ref yieldOffsets, ref breakpointOffset, ref breakpointMethod);
        }

        #endregion
        #endregion
    }
}