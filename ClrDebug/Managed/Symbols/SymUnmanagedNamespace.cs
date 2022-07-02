using System.Linq;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Represents a namespace.
    /// </summary>
    public class SymUnmanagedNamespace : ComObject<ISymUnmanagedNamespace>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedNamespace"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedNamespace(ISymUnmanagedNamespace raw) : base(raw)
        {
        }

        #region ISymUnmanagedNamespace
        #region Name

        /// <summary>
        /// Gets the name of this namespace.
        /// </summary>
        public string Name
        {
            get
            {
                string szNameResult;
                TryGetName(out szNameResult).ThrowOnNotOK();

                return szNameResult;
            }
        }

        /// <summary>
        /// Gets the name of this namespace.
        /// </summary>
        /// <param name="szNameResult">[out] A pointer to a buffer that contains the namespace name.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, [Out] out int pcchName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
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
        #region Namespaces

        /// <summary>
        /// Gets the children of this namespace.
        /// </summary>
        public SymUnmanagedNamespace[] Namespaces
        {
            get
            {
                SymUnmanagedNamespace[] namespacesResult;
                TryGetNamespaces(out namespacesResult).ThrowOnNotOK();

                return namespacesResult;
            }
        }

        /// <summary>
        /// Gets the children of this namespace.
        /// </summary>
        /// <param name="namespacesResult">[out] A pointer to the buffer that contains the namespaces.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetNamespaces(out SymUnmanagedNamespace[] namespacesResult)
        {
            /*HRESULT GetNamespaces([In] int cNameSpaces, [Out] out int pcNameSpaces, [MarshalAs(UnmanagedType.LPArray), Out] ISymUnmanagedNamespace[] namespaces);*/
            int cNameSpaces = 0;
            int pcNameSpaces;
            ISymUnmanagedNamespace[] namespaces = null;
            HRESULT hr = Raw.GetNamespaces(cNameSpaces, out pcNameSpaces, namespaces);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cNameSpaces = pcNameSpaces;
            namespaces = new ISymUnmanagedNamespace[cNameSpaces];
            hr = Raw.GetNamespaces(cNameSpaces, out pcNameSpaces, namespaces);

            if (hr == HRESULT.S_OK)
            {
                namespacesResult = namespaces.Select(v => new SymUnmanagedNamespace(v)).ToArray();

                return hr;
            }

            fail:
            namespacesResult = default(SymUnmanagedNamespace[]);

            return hr;
        }

        #endregion
        #region Variables

        /// <summary>
        /// Returns all variables defined at global scope within this namespace.
        /// </summary>
        public SymUnmanagedVariable[] Variables
        {
            get
            {
                SymUnmanagedVariable[] pVarsResult;
                TryGetVariables(out pVarsResult).ThrowOnNotOK();

                return pVarsResult;
            }
        }

        /// <summary>
        /// Returns all variables defined at global scope within this namespace.
        /// </summary>
        /// <param name="pVarsResult">[out] A pointer to a buffer that contains the namespaces.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetVariables(out SymUnmanagedVariable[] pVarsResult)
        {
            /*HRESULT GetVariables([In] int cVars, [Out] out int pcVars, [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedVariable[] pVars);*/
            int cVars = 0;
            int pcVars;
            ISymUnmanagedVariable[] pVars = null;
            HRESULT hr = Raw.GetVariables(cVars, out pcVars, pVars);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cVars = pcVars;
            pVars = new ISymUnmanagedVariable[cVars];
            hr = Raw.GetVariables(cVars, out pcVars, pVars);

            if (hr == HRESULT.S_OK)
            {
                pVarsResult = pVars.Select(v => new SymUnmanagedVariable(v)).ToArray();

                return hr;
            }

            fail:
            pVarsResult = default(SymUnmanagedVariable[]);

            return hr;
        }

        #endregion
        #endregion
    }
}