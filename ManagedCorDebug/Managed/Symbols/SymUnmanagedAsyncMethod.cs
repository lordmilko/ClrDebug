using System.Runtime.InteropServices;

namespace ManagedCorDebug
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
        #region KickoffMethod

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
        #region CatchHandlerILOffset

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        public int CatchHandlerILOffset
        {
            get
            {
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetCatchHandlerILOffset(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineCatchHandlerILOffset"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetCatchHandlerILOffset(out int pRetVal)
        {
            /*HRESULT GetCatchHandlerILOffset([Out] out int pRetVal);*/
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
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetAsyncStepInfoCount(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetAsyncStepInfoCount(out int pRetVal)
        {
            /*HRESULT GetAsyncStepInfoCount([Out] out int pRetVal);*/
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
        public GetAsyncStepInfoResult GetAsyncStepInfo(int cStepInfo)
        {
            HRESULT hr;
            GetAsyncStepInfoResult result;

            if ((hr = TryGetAsyncStepInfo(cStepInfo, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetAsyncStepInfo(int cStepInfo, out GetAsyncStepInfoResult result)
        {
            /*HRESULT GetAsyncStepInfo(
            [In] int cStepInfo,
            out int pcStepInfo,
            [In, Out] ref int[] yieldOffsets,
            [In, Out] ref int[] breakpointOffset,
            [In, Out] ref int[] breakpointMethod);*/
            int pcStepInfo;
            int[] yieldOffsets = default(int[]);
            int[] breakpointOffset = default(int[]);
            int[] breakpointMethod = default(int[]);
            HRESULT hr = Raw.GetAsyncStepInfo(cStepInfo, out pcStepInfo, ref yieldOffsets, ref breakpointOffset, ref breakpointMethod);

            if (hr == HRESULT.S_OK)
                result = new GetAsyncStepInfoResult(pcStepInfo, yieldOffsets, breakpointOffset, breakpointMethod);
            else
                result = default(GetAsyncStepInfoResult);

            return hr;
        }

        #endregion
        #endregion
    }
}