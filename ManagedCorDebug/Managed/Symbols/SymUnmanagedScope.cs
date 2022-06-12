using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a lexical scope within a method.
    /// </summary>
    public class SymUnmanagedScope : ComObject<ISymUnmanagedScope>
    {
        public SymUnmanagedScope(ISymUnmanagedScope raw) : base(raw)
        {
        }

        #region ISymUnmanagedScope
        #region GetMethod

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
        #region GetParent

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
        #region GetStartOffset

        /// <summary>
        /// Gets the start offset for this scope.
        /// </summary>
        public uint StartOffset
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

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
        public HRESULT TryGetStartOffset(out uint pRetVal)
        {
            /*HRESULT GetStartOffset([Out] out uint pRetVal);*/
            return Raw.GetStartOffset(out pRetVal);
        }

        #endregion
        #region GetEndOffset

        /// <summary>
        /// Gets the end offset for this scope.
        /// </summary>
        public uint EndOffset
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

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
        public HRESULT TryGetEndOffset(out uint pRetVal)
        {
            /*HRESULT GetEndOffset([Out] out uint pRetVal);*/
            return Raw.GetEndOffset(out pRetVal);
        }

        #endregion
        #region GetLocalCount

        /// <summary>
        /// Gets a count of the local variables defined within this scope.
        /// </summary>
        public uint LocalCount
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

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
        public HRESULT TryGetLocalCount(out uint pRetVal)
        {
            /*HRESULT GetLocalCount([Out] out uint pRetVal);*/
            return Raw.GetLocalCount(out pRetVal);
        }

        #endregion
        #region GetChildren

        /// <summary>
        /// Gets the children of this scope.
        /// </summary>
        /// <param name="cChildren">[in] A ULONG32 that indicates the size of the children array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetChildrenResult GetChildren(uint cChildren)
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
        public HRESULT TryGetChildren(uint cChildren, out GetChildrenResult result)
        {
            /*HRESULT GetChildren(
            [In] uint cChildren,
            out uint pcChildren,
            [Out] IntPtr children);*/
            uint pcChildren;
            IntPtr children = default(IntPtr);
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
        public GetLocalsResult GetLocals(uint cLocals)
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
        public HRESULT TryGetLocals(uint cLocals, out GetLocalsResult result)
        {
            /*HRESULT GetLocals(
            [In] uint cLocals,
            out uint pcLocals,
            [Out] IntPtr locals);*/
            uint pcLocals;
            IntPtr locals = default(IntPtr);
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
        public GetNamespacesResult GetNamespaces(uint cNameSpaces)
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
        public HRESULT TryGetNamespaces(uint cNameSpaces, out GetNamespacesResult result)
        {
            /*HRESULT GetNamespaces(
            [In] uint cNameSpaces,
            out uint pcNameSpaces,
            [Out] IntPtr namespaces);*/
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
        #endregion
        #region ISymUnmanagedScope2

        public ISymUnmanagedScope2 Raw2 => (ISymUnmanagedScope2) Raw;

        #region GetConstantCount

        /// <summary>
        /// Gets a count of the constants defined within this scope.
        /// </summary>
        public uint ConstantCount
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

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
        public HRESULT TryGetConstantCount(out uint pRetVal)
        {
            /*HRESULT GetConstantCount([Out] out uint pRetVal);*/
            return Raw2.GetConstantCount(out pRetVal);
        }

        #endregion
        #region GetConstants

        /// <summary>
        /// Gets the local constants defined within this scope.
        /// </summary>
        /// <param name="cConstants">[in] The length of the buffer that the pcConstants parameter points to.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetConstantsResult GetConstants(uint cConstants)
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
        public HRESULT TryGetConstants(uint cConstants, out GetConstantsResult result)
        {
            /*HRESULT GetConstants([In] uint cConstants, out uint pcConstants, [MarshalAs(UnmanagedType.Interface), Out]
            IntPtr constants);*/
            uint pcConstants;
            IntPtr constants = default(IntPtr);
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