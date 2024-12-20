﻿namespace ClrDebug
{
    /// <summary>
    /// This interface is the reading complement to <see cref="ISymUnmanagedAsyncMethodPropertiesWriter"/>.
    /// </summary>
    public class SymUnmanagedAsyncMethod : ComObject<ISymUnmanagedAsyncMethod>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedAsyncMethod"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
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
                bool pRetVal;
                TryIsAsyncMethod(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Checks if the method has async information or not. If this method returns FALSE then it is invalid to call any other methods in this interface.<para/>
        /// They will all return E_UNEXPECTED in this case.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryIsAsyncMethod(out bool pRetVal)
        {
            /*HRESULT IsAsyncMethod(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.IsAsyncMethod(out pRetVal);
        }

        #endregion
        #region KickoffMethod

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineKickoffMethod"/>.
        /// </summary>
        public mdMethodDef KickoffMethod
        {
            get
            {
                mdMethodDef kickoffMethod;
                TryGetKickoffMethod(out kickoffMethod).ThrowOnNotOK();

                return kickoffMethod;
            }
        }

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineKickoffMethod"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetKickoffMethod(out mdMethodDef kickoffMethod)
        {
            /*HRESULT GetKickoffMethod(
            [Out] out mdMethodDef kickoffMethod);*/
            return Raw.GetKickoffMethod(out kickoffMethod);
        }

        #endregion
        #region CatchHandlerILOffset

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        public int CatchHandlerILOffset
        {
            get
            {
                int pRetVal;
                TryGetCatchHandlerILOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetCatchHandlerILOffset(out int pRetVal)
        {
            /*HRESULT GetCatchHandlerILOffset(
            [Out] out int pRetVal);*/
            return Raw.GetCatchHandlerILOffset(out pRetVal);
        }

        #endregion
        #region AsyncStepInfoCount

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        public int AsyncStepInfoCount
        {
            get
            {
                int pRetVal;
                TryGetAsyncStepInfoCount(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetAsyncStepInfoCount(out int pRetVal)
        {
            /*HRESULT GetAsyncStepInfoCount(
            [Out] out int pRetVal);*/
            return Raw.GetAsyncStepInfoCount(out pRetVal);
        }

        #endregion
        #region AsyncStepInfo

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        public GetAsyncStepInfoResult AsyncStepInfo
        {
            get
            {
                GetAsyncStepInfoResult result;
                TryGetAsyncStepInfo(out result).ThrowOnNotOK();

                return result;
            }
        }

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetAsyncStepInfo(out GetAsyncStepInfoResult result)
        {
            /*HRESULT GetAsyncStepInfo(
            [In] int cStepInfo,
            [Out] out int pcStepInfo,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] yieldOffsets,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] breakpointOffset,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] breakpointMethod);*/
            int cStepInfo = 0;
            int pcStepInfo;
            int[] yieldOffsets;
            int[] breakpointOffset;
            int[] breakpointMethod;
            HRESULT hr = Raw.GetAsyncStepInfo(cStepInfo, out pcStepInfo, null, null, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cStepInfo = pcStepInfo;
            yieldOffsets = new int[cStepInfo];
            breakpointOffset = new int[cStepInfo];
            breakpointMethod = new int[cStepInfo];
            hr = Raw.GetAsyncStepInfo(cStepInfo, out pcStepInfo, yieldOffsets, breakpointOffset, breakpointMethod);

            if (hr == HRESULT.S_OK)
            {
                result = new GetAsyncStepInfoResult(yieldOffsets, breakpointOffset, breakpointMethod);

                return hr;
            }

            fail:
            result = default(GetAsyncStepInfoResult);

            return hr;
        }

        #endregion
        #region HasCatchHandlerILOffset

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        public bool HasCatchHandlerILOffset()
        {
            bool pRetVal;
            TryHasCatchHandlerILOffset(out pRetVal).ThrowOnNotOK();

            return pRetVal;
        }

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryHasCatchHandlerILOffset(out bool pRetVal)
        {
            /*HRESULT HasCatchHandlerILOffset(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pRetVal);*/
            return Raw.HasCatchHandlerILOffset(out pRetVal);
        }

        #endregion
        #endregion
    }
}
