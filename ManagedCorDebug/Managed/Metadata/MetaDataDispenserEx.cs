using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ManagedCorDebug
{
    public class MetaDataDispenserEx : MetaDataDispenser
    {
        public MetaDataDispenserEx(IMetaDataDispenserEx raw) : base(raw)
        {
        }

        #region IMetaDataDispenserEx

        public new IMetaDataDispenserEx Raw => (IMetaDataDispenserEx) base.Raw;

        #region GetCORSystemDirectory

        public string CORSystemDirectory
        {
            get
            {
                HRESULT hr;
                string szBufferResult;

                if ((hr = TryGetCORSystemDirectory(out szBufferResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return szBufferResult;
            }
        }

        public HRESULT TryGetCORSystemDirectory(out string szBufferResult)
        {
            /*HRESULT GetCORSystemDirectory(
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] StringBuilder szBuffer,
            [In] uint cchBuffer,
            [Out] out uint pchBuffer);*/
            StringBuilder szBuffer = null;
            uint cchBuffer = 0;
            uint pchBuffer;
            HRESULT hr = Raw.GetCORSystemDirectory(szBuffer, cchBuffer, out pchBuffer);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchBuffer = pchBuffer;
            szBuffer = new StringBuilder((int) pchBuffer);
            hr = Raw.GetCORSystemDirectory(szBuffer, cchBuffer, out pchBuffer);

            if (hr == HRESULT.S_OK)
            {
                szBufferResult = szBuffer.ToString();

                return hr;
            }

            fail:
            szBufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetOption

        public void SetOption(Guid optionId, object pValue)
        {
            HRESULT hr;

            if ((hr = TrySetOption(optionId, pValue)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetOption(Guid optionId, object pValue)
        {
            /*HRESULT SetOption([In] Guid optionId, [In, MarshalAs(UnmanagedType.Struct)] object pValue);*/
            return Raw.SetOption(optionId, pValue);
        }

        #endregion
        #region GetOption

        public object GetOption(Guid optionId)
        {
            HRESULT hr;
            object pValue = default(object);

            if ((hr = TryGetOption(optionId, ref pValue)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pValue;
        }

        public HRESULT TryGetOption(Guid optionId, ref object pValue)
        {
            /*HRESULT GetOption([In] Guid optionId, [Out] object pValue);*/
            return Raw.GetOption(optionId, pValue);
        }

        #endregion
        #region OpenScopeOnITypeInfo

        public OpenScopeOnITypeInfoResult OpenScopeOnITypeInfo(ITypeInfo pITI, uint dwOpenFlags)
        {
            HRESULT hr;
            OpenScopeOnITypeInfoResult result;

            if ((hr = TryOpenScopeOnITypeInfo(pITI, dwOpenFlags, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryOpenScopeOnITypeInfo(ITypeInfo pITI, uint dwOpenFlags, out OpenScopeOnITypeInfoResult result)
        {
            /*HRESULT OpenScopeOnITypeInfo(
            [MarshalAs(UnmanagedType.Interface)] ITypeInfo pITI,
            uint dwOpenFlags,
            ref Guid riid,
            [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppIUnk
        );*/
            Guid riid = default(Guid);
            object ppIUnk;
            HRESULT hr = Raw.OpenScopeOnITypeInfo(pITI, dwOpenFlags, ref riid, out ppIUnk);

            if (hr == HRESULT.S_OK)
                result = new OpenScopeOnITypeInfoResult(riid, ppIUnk);
            else
                result = default(OpenScopeOnITypeInfoResult);

            return hr;
        }

        #endregion
        #region FindAssembly

        public string FindAssembly(string szAppBase, string szPrivateBin, string szGlobalBin, string szAssemblyName)
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryFindAssembly(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryFindAssembly(string szAppBase, string szPrivateBin, string szGlobalBin, string szAssemblyName, out string szNameResult)
        {
            /*HRESULT FindAssembly(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAppBase,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szPrivateBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szGlobalBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAssemblyName,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] StringBuilder szName,
            uint cchName,
            out uint pcName);*/
            StringBuilder szName = null;
            uint cchName = 0;
            uint pcName;
            HRESULT hr = Raw.FindAssembly(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szName, cchName, out pcName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcName;
            szName = new StringBuilder((int) pcName);
            hr = Raw.FindAssembly(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szName, cchName, out pcName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region FindAssemblyModule

        public string FindAssemblyModule(string szAppBase, string szPrivateBin, string szGlobalBin, string szAssemblyName, string szModuleName)
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryFindAssemblyModule(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szModuleName, out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryFindAssemblyModule(string szAppBase, string szPrivateBin, string szGlobalBin, string szAssemblyName, string szModuleName, out string szNameResult)
        {
            /*HRESULT FindAssemblyModule(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAppBase,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szPrivateBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szGlobalBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAssemblyName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szModuleName,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] StringBuilder szName,
            [In] uint cchName,
            [Out] out uint pcName);*/
            StringBuilder szName = null;
            uint cchName = 0;
            uint pcName;
            HRESULT hr = Raw.FindAssemblyModule(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szModuleName, szName, cchName, out pcName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcName;
            szName = new StringBuilder((int) pcName);
            hr = Raw.FindAssemblyModule(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szModuleName, szName, cchName, out pcName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}