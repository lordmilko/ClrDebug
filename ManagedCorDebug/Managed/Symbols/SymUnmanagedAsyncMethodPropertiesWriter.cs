using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class SymUnmanagedAsyncMethodPropertiesWriter : ComObject<ISymUnmanagedAsyncMethodPropertiesWriter>
    {
        public SymUnmanagedAsyncMethodPropertiesWriter(ISymUnmanagedAsyncMethodPropertiesWriter raw) : base(raw)
        {
        }

        #region ISymUnmanagedAsyncMethodPropertiesWriter
        #region DefineKickoffMethod

        public void DefineKickoffMethod(uint kickoffMethod)
        {
            HRESULT hr;

            if ((hr = TryDefineKickoffMethod(kickoffMethod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineKickoffMethod(uint kickoffMethod)
        {
            /*HRESULT DefineKickoffMethod([In] uint kickoffMethod);*/
            return Raw.DefineKickoffMethod(kickoffMethod);
        }

        #endregion
        #region DefineCatchHandlerILOffset

        public void DefineCatchHandlerILOffset(uint catchHandlerOffset)
        {
            HRESULT hr;

            if ((hr = TryDefineCatchHandlerILOffset(catchHandlerOffset)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineCatchHandlerILOffset(uint catchHandlerOffset)
        {
            /*HRESULT DefineCatchHandlerILOffset([In] uint catchHandlerOffset);*/
            return Raw.DefineCatchHandlerILOffset(catchHandlerOffset);
        }

        #endregion
        #region DefineAsyncStepInfo

        public void DefineAsyncStepInfo(uint count, uint yieldOffsets, uint breakpointOffset, uint breakpointMethod)
        {
            HRESULT hr;

            if ((hr = TryDefineAsyncStepInfo(count, yieldOffsets, breakpointOffset, breakpointMethod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

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