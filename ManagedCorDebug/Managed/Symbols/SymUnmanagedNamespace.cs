using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class SymUnmanagedNamespace : ComObject<ISymUnmanagedNamespace>
    {
        public SymUnmanagedNamespace(ISymUnmanagedNamespace raw) : base(raw)
        {
        }

        #region ISymUnmanagedNamespace
        #region GetName

        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw.GetName(cchName, out pcchName, szName);

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
        #region GetNamespaces

        public GetNamespacesResult GetNamespaces(uint cNameSpaces)
        {
            HRESULT hr;
            GetNamespacesResult result;

            if ((hr = TryGetNamespaces(cNameSpaces, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetNamespaces(uint cNameSpaces, out GetNamespacesResult result)
        {
            /*HRESULT GetNamespaces([In] uint cNameSpaces, out uint pcNameSpaces, [MarshalAs(UnmanagedType.Interface), Out]
            IntPtr namespaces);*/
            uint pcNameSpaces;
            IntPtr namespaces = default(IntPtr);
            HRESULT hr = Raw.GetNamespaces(cNameSpaces, out pcNameSpaces, namespaces);

            if (hr == HRESULT.S_OK)
                result = new GetNamespacesResult(pcNameSpaces, namespaces);
            else
                result = default(GetNamespacesResult);

            return hr;
        }

        #endregion
        #region GetVariables

        public GetVariablesResult GetVariables(uint cVars)
        {
            HRESULT hr;
            GetVariablesResult result;

            if ((hr = TryGetVariables(cVars, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetVariables(uint cVars, out GetVariablesResult result)
        {
            /*HRESULT GetVariables([In] uint cVars, out uint pcVars, [Out] IntPtr pVars);*/
            uint pcVars;
            IntPtr pVars = default(IntPtr);
            HRESULT hr = Raw.GetVariables(cVars, out pcVars, pVars);

            if (hr == HRESULT.S_OK)
                result = new GetVariablesResult(pcVars, pVars);
            else
                result = default(GetVariablesResult);

            return hr;
        }

        #endregion
        #endregion
    }
}