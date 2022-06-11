using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class SymUnmanagedAsyncMethod : ComObject<ISymUnmanagedAsyncMethod>
    {
        public SymUnmanagedAsyncMethod(ISymUnmanagedAsyncMethod raw) : base(raw)
        {
        }

        #region ISymUnmanagedAsyncMethod
        #region IsAsyncMethod

        public bool IsAsyncMethod
        {
            get
            {
                HRESULT hr;

                if ((hr = TryIsAsyncMethod()) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return hr == HRESULT.S_OK;
            }
        }

        public HRESULT TryIsAsyncMethod()
        {
            /*HRESULT IsAsyncMethod();*/
            return Raw.IsAsyncMethod();
        }

        #endregion
        #region GetKickoffMethod

        public mdToken KickoffMethod
        {
            get
            {
                HRESULT hr;
                mdToken kickoffMethod;

                if ((hr = TryGetKickoffMethod(out kickoffMethod)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return kickoffMethod;
            }
        }

        public HRESULT TryGetKickoffMethod(out mdToken kickoffMethod)
        {
            /*HRESULT GetKickoffMethod([Out] out mdToken kickoffMethod);*/
            return Raw.GetKickoffMethod(out kickoffMethod);
        }

        #endregion
        #region GetCatchHandlerILOffset

        public uint CatchHandlerILOffset
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

                if ((hr = TryGetCatchHandlerILOffset(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        public HRESULT TryGetCatchHandlerILOffset(out uint pRetVal)
        {
            /*HRESULT GetCatchHandlerILOffset([Out] out uint pRetVal);*/
            return Raw.GetCatchHandlerILOffset(out pRetVal);
        }

        #endregion
        #region GetAsyncStepInfoCount

        public uint AsyncStepInfoCount
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

                if ((hr = TryGetAsyncStepInfoCount(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        public HRESULT TryGetAsyncStepInfoCount(out uint pRetVal)
        {
            /*HRESULT GetAsyncStepInfoCount([Out] out uint pRetVal);*/
            return Raw.GetAsyncStepInfoCount(out pRetVal);
        }

        #endregion
        #region HasCatchHandlerILOffset

        public void HasCatchHandlerILOffset()
        {
            HRESULT hr;

            if ((hr = TryHasCatchHandlerILOffset()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryHasCatchHandlerILOffset()
        {
            /*HRESULT HasCatchHandlerILOffset();*/
            return Raw.HasCatchHandlerILOffset();
        }

        #endregion
        #region GetAsyncStepInfo

        public void GetAsyncStepInfo(uint cStepInfo, uint yieldOffsets, uint breakpointOffset, uint breakpointMethod)
        {
            HRESULT hr;

            if ((hr = TryGetAsyncStepInfo(cStepInfo, yieldOffsets, breakpointOffset, breakpointMethod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryGetAsyncStepInfo(uint cStepInfo, uint yieldOffsets, uint breakpointOffset, uint breakpointMethod)
        {
            /*HRESULT GetAsyncStepInfo(
            [In] uint cStepInfo,
            out uint pcStepInfo,
            [In] ref uint yieldOffsets,
            [In] ref uint breakpointOffset,
            [In] ref uint breakpointMethod);*/
            uint pcStepInfo;

            return Raw.GetAsyncStepInfo(cStepInfo, out pcStepInfo, ref yieldOffsets, ref breakpointOffset, ref breakpointMethod);
        }

        #endregion
        #endregion
    }
}