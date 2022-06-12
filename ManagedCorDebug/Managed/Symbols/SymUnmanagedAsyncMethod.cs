using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// This interface is the reading complement to <see cref="ISymUnmanagedAsyncMethodPropertiesWriter"/>.
    /// </summary>
    public class SymUnmanagedAsyncMethod : ComObject<ISymUnmanagedAsyncMethod>
    {
        public SymUnmanagedAsyncMethod(ISymUnmanagedAsyncMethod raw) : base(raw)
        {
        }

        #region ISymUnmanagedAsyncMethod
        #region IsAsyncMethod

        /// <summary>
        /// Checks if the method has async information or not. If this method returns FALSE then it is invalid to call any other methods in this interface.<para/>
        /// They will all return E_UNEXPECTED in this case.
        /// </summary>
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

        /// <summary>
        /// Checks if the method has async information or not. If this method returns FALSE then it is invalid to call any other methods in this interface.<para/>
        /// They will all return E_UNEXPECTED in this case.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryIsAsyncMethod()
        {
            /*HRESULT IsAsyncMethod();*/
            return Raw.IsAsyncMethod();
        }

        #endregion
        #region GetKickoffMethod

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineKickoffMethod"/>.
        /// </summary>
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

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineKickoffMethod"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetKickoffMethod(out mdToken kickoffMethod)
        {
            /*HRESULT GetKickoffMethod([Out] out mdToken kickoffMethod);*/
            return Raw.GetKickoffMethod(out kickoffMethod);
        }

        #endregion
        #region GetCatchHandlerILOffset

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
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

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetCatchHandlerILOffset(out uint pRetVal)
        {
            /*HRESULT GetCatchHandlerILOffset([Out] out uint pRetVal);*/
            return Raw.GetCatchHandlerILOffset(out pRetVal);
        }

        #endregion
        #region GetAsyncStepInfoCount

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
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

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetAsyncStepInfoCount(out uint pRetVal)
        {
            /*HRESULT GetAsyncStepInfoCount([Out] out uint pRetVal);*/
            return Raw.GetAsyncStepInfoCount(out pRetVal);
        }

        #endregion
        #region HasCatchHandlerILOffset

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        public void HasCatchHandlerILOffset()
        {
            HRESULT hr;

            if ((hr = TryHasCatchHandlerILOffset()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryHasCatchHandlerILOffset()
        {
            /*HRESULT HasCatchHandlerILOffset();*/
            return Raw.HasCatchHandlerILOffset();
        }

        #endregion
        #region GetAsyncStepInfo

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        public void GetAsyncStepInfo(uint cStepInfo, uint yieldOffsets, uint breakpointOffset, uint breakpointMethod)
        {
            HRESULT hr;

            if ((hr = TryGetAsyncStepInfo(cStepInfo, yieldOffsets, breakpointOffset, breakpointMethod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
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