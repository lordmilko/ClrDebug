using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a lexical scope within a method.
    /// </summary>
    public class SymUnmanagedScope : ComObject<ISymUnmanagedScope>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedScope"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedScope(ISymUnmanagedScope raw) : base(raw)
        {
        }

        #region ISymUnmanagedScope
        #region Method

        /// <summary>
        /// Gets the method that contains this scope.
        /// </summary>
        public ISymUnmanagedMethod Method
        {
            get
            {
                HRESULT hr;
                ISymUnmanagedMethod pRetVal = default(ISymUnmanagedMethod);

                if ((hr = TryGetMethod(ref pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the method that contains this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to the returned <see cref="ISymUnmanagedMethod"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetMethod(ref ISymUnmanagedMethod pRetVal)
        {
            /*HRESULT GetMethod([Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);*/
            return Raw.GetMethod(pRetVal);
        }

        #endregion
        #region Parent

        /// <summary>
        /// Gets the parent scope of this scope.
        /// </summary>
        public ISymUnmanagedScope Parent
        {
            get
            {
                HRESULT hr;
                ISymUnmanagedScope pRetVal = default(ISymUnmanagedScope);

                if ((hr = TryGetParent(ref pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the parent scope of this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to the returned <see cref="ISymUnmanagedScope"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetParent(ref ISymUnmanagedScope pRetVal)
        {
            /*HRESULT GetParent([Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedScope pRetVal);*/
            return Raw.GetParent(pRetVal);
        }

        #endregion
        #region StartOffset

        /// <summary>
        /// Gets the start offset for this scope.
        /// </summary>
        public int StartOffset
        {
            get
            {
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetStartOffset(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the start offset for this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that contains the starting offset.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetStartOffset(out int pRetVal)
        {
            /*HRESULT GetStartOffset([Out] out int pRetVal);*/
            return Raw.GetStartOffset(out pRetVal);
        }

        #endregion
        #region EndOffset

        /// <summary>
        /// Gets the end offset for this scope.
        /// </summary>
        public int EndOffset
        {
            get
            {
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetEndOffset(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the end offset for this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the end offset.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetEndOffset(out int pRetVal)
        {
            /*HRESULT GetEndOffset([Out] out int pRetVal);*/
            return Raw.GetEndOffset(out pRetVal);
        }

        #endregion
        #region LocalCount

        /// <summary>
        /// Gets a count of the local variables defined within this scope.
        /// </summary>
        public int LocalCount
        {
            get
            {
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetLocalCount(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets a count of the local variables defined within this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the count of local variables.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetLocalCount(out int pRetVal)
        {
            /*HRESULT GetLocalCount([Out] out int pRetVal);*/
            return Raw.GetLocalCount(out pRetVal);
        }

        #endregion
        #region GetChildren

        /// <summary>
        /// Gets the children of this scope.
        /// </summary>
        /// <param name="cChildren">[in] A ULONG32 that indicates the size of the children array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetChildrenResult GetChildren(int cChildren)
        {
            HRESULT hr;
            GetChildrenResult result;

            if ((hr = TryGetChildren(cChildren, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the children of this scope.
        /// </summary>
        /// <param name="cChildren">[in] A ULONG32 that indicates the size of the children array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetChildren(int cChildren, out GetChildrenResult result)
        {
            /*HRESULT GetChildren(
            [In] int cChildren,
            [Out] out int pcChildren,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedScope[] children);*/
            int pcChildren;
            ISymUnmanagedScope[] children = null;
            HRESULT hr = Raw.GetChildren(cChildren, out pcChildren, children);

            if (hr == HRESULT.S_OK)
                result = new GetChildrenResult(pcChildren, children);
            else
                result = default(GetChildrenResult);

            return hr;
        }

        #endregion
        #region GetLocals

        /// <summary>
        /// Gets the local variables defined within this scope.
        /// </summary>
        /// <param name="cLocals">[in] A ULONG32 that indicates the size of the locals array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetLocalsResult GetLocals(int cLocals)
        {
            HRESULT hr;
            GetLocalsResult result;

            if ((hr = TryGetLocals(cLocals, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the local variables defined within this scope.
        /// </summary>
        /// <param name="cLocals">[in] A ULONG32 that indicates the size of the locals array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetLocals(int cLocals, out GetLocalsResult result)
        {
            /*HRESULT GetLocals(
            [In] int cLocals,
            [Out] out int pcLocals,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedVariable[] locals);*/
            int pcLocals;
            ISymUnmanagedVariable[] locals = null;
            HRESULT hr = Raw.GetLocals(cLocals, out pcLocals, locals);

            if (hr == HRESULT.S_OK)
                result = new GetLocalsResult(pcLocals, locals);
            else
                result = default(GetLocalsResult);

            return hr;
        }

        #endregion
        #region GetNamespaces

        /// <summary>
        /// Gets the namespaces that are being used within this scope.
        /// </summary>
        /// <param name="cNameSpaces">[in] The size of the namespaces array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetNamespacesResult GetNamespaces(int cNameSpaces)
        {
            HRESULT hr;
            GetNamespacesResult result;

            if ((hr = TryGetNamespaces(cNameSpaces, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the namespaces that are being used within this scope.
        /// </summary>
        /// <param name="cNameSpaces">[in] The size of the namespaces array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetNamespaces(int cNameSpaces, out GetNamespacesResult result)
        {
            /*HRESULT GetNamespaces(
            [In] int cNameSpaces,
            [Out] out int pcNameSpaces,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedNamespace[] namespaces);*/
            int pcNameSpaces;
            ISymUnmanagedNamespace[] namespaces = null;
            HRESULT hr = Raw.GetNamespaces(cNameSpaces, out pcNameSpaces, namespaces);

            if (hr == HRESULT.S_OK)
                result = new GetNamespacesResult(pcNameSpaces, namespaces);
            else
                result = default(GetNamespacesResult);

            return hr;
        }

        #endregion
        #endregion
        #region ISymUnmanagedScope2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISymUnmanagedScope2 Raw2 => (ISymUnmanagedScope2) Raw;

        #region ConstantCount

        /// <summary>
        /// Gets a count of the constants defined within this scope.
        /// </summary>
        public int ConstantCount
        {
            get
            {
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetConstantCount(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets a count of the constants defined within this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the constants.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetConstantCount(out int pRetVal)
        {
            /*HRESULT GetConstantCount([Out] out int pRetVal);*/
            return Raw2.GetConstantCount(out pRetVal);
        }

        #endregion
        #region GetConstants

        /// <summary>
        /// Gets the local constants defined within this scope.
        /// </summary>
        /// <param name="cConstants">[in] The length of the buffer that the pcConstants parameter points to.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetConstantsResult GetConstants(int cConstants)
        {
            HRESULT hr;
            GetConstantsResult result;

            if ((hr = TryGetConstants(cConstants, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the local constants defined within this scope.
        /// </summary>
        /// <param name="cConstants">[in] The length of the buffer that the pcConstants parameter points to.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetConstants(int cConstants, out GetConstantsResult result)
        {
            /*HRESULT GetConstants([In] int cConstants, [Out] out int pcConstants, [MarshalAs(UnmanagedType.LPArray), Out] ISymUnmanagedConstant[] constants);*/
            int pcConstants;
            ISymUnmanagedConstant[] constants = null;
            HRESULT hr = Raw2.GetConstants(cConstants, out pcConstants, constants);

            if (hr == HRESULT.S_OK)
                result = new GetConstantsResult(pcConstants, constants);
            else
                result = default(GetConstantsResult);

            return hr;
        }

        #endregion
        #endregion
    }
}