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
        #region GetAsyncStepInfoCount

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
        public void GetAsyncStepInfo(int cStepInfo, int yieldOffsets, int breakpointOffset, int breakpointMethod)
        {
            HRESULT hr;

            if ((hr = TryGetAsyncStepInfo(cStepInfo, yieldOffsets, breakpointOffset, breakpointMethod)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// See <see cref="SymUnmanagedAsyncMethodPropertiesWriter.DefineAsyncStepInfo"/>.
        /// </summary>
        /// <returns>Returns <see cref="HRESULT"/>.</returns>
        public HRESULT TryGetAsyncStepInfo(int cStepInfo, int yieldOffsets, int breakpointOffset, int breakpointMethod)
        {
            /*HRESULT GetAsyncStepInfo(
            [In] int cStepInfo,
            out int pcStepInfo,
            [In] ref int yieldOffsets,
            [In] ref int breakpointOffset,
            [In] ref int breakpointMethod);*/
            int pcStepInfo;

            return Raw.GetAsyncStepInfo(cStepInfo, out pcStepInfo, ref yieldOffsets, ref breakpointOffset, ref breakpointMethod);
        }

        #endregion
        #endregion
    }
}