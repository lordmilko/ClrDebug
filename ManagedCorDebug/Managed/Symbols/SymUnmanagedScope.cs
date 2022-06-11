using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class SymUnmanagedScope : ComObject<ISymUnmanagedScope>
    {
        public SymUnmanagedScope(ISymUnmanagedScope raw) : base(raw)
        {
        }

        #region ISymUnmanagedScope
        #region GetMethod

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

        public HRESULT TryGetMethod(ref ISymUnmanagedMethod pRetVal)
        {
            /*HRESULT GetMethod([Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedMethod pRetVal);*/
            return Raw.GetMethod(pRetVal);
        }

        #endregion
        #region GetParent

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

        public HRESULT TryGetParent(ref ISymUnmanagedScope pRetVal)
        {
            /*HRESULT GetParent([Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedScope pRetVal);*/
            return Raw.GetParent(pRetVal);
        }

        #endregion
        #region GetStartOffset

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

        public HRESULT TryGetStartOffset(out uint pRetVal)
        {
            /*HRESULT GetStartOffset([Out] out uint pRetVal);*/
            return Raw.GetStartOffset(out pRetVal);
        }

        #endregion
        #region GetEndOffset

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

        public HRESULT TryGetEndOffset(out uint pRetVal)
        {
            /*HRESULT GetEndOffset([Out] out uint pRetVal);*/
            return Raw.GetEndOffset(out pRetVal);
        }

        #endregion
        #region GetLocalCount

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

        public HRESULT TryGetLocalCount(out uint pRetVal)
        {
            /*HRESULT GetLocalCount([Out] out uint pRetVal);*/
            return Raw.GetLocalCount(out pRetVal);
        }

        #endregion
        #region GetChildren

        public GetChildrenResult GetChildren(uint cChildren)
        {
            HRESULT hr;
            GetChildrenResult result;

            if ((hr = TryGetChildren(cChildren, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

        public GetLocalsResult GetLocals(uint cLocals)
        {
            HRESULT hr;
            GetLocalsResult result;

            if ((hr = TryGetLocals(cLocals, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

        public HRESULT TryGetConstantCount(out uint pRetVal)
        {
            /*HRESULT GetConstantCount([Out] out uint pRetVal);*/
            return Raw2.GetConstantCount(out pRetVal);
        }

        #endregion
        #region GetConstants

        public GetConstantsResult GetConstants(uint cConstants)
        {
            HRESULT hr;
            GetConstantsResult result;

            if ((hr = TryGetConstants(cConstants, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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