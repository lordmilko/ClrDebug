using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugArrayValue : CorDebugHeapValue
    {
        public CorDebugArrayValue(ICorDebugArrayValue raw) : base(raw)
        {
        }

        #region ICorDebugArrayValue

        public new ICorDebugArrayValue Raw => (ICorDebugArrayValue) base.Raw;

        #region GetElementType

        public CorElementType ElementType
        {
            get
            {
                HRESULT hr;
                CorElementType pType;

                if ((hr = TryGetElementType(out pType)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pType;
            }
        }

        public HRESULT TryGetElementType(out CorElementType pType)
        {
            /*HRESULT GetElementType(out CorElementType pType);*/
            return Raw.GetElementType(out pType);
        }

        #endregion
        #region GetRank

        public uint Rank
        {
            get
            {
                HRESULT hr;
                uint pnRank;

                if ((hr = TryGetRank(out pnRank)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnRank;
            }
        }

        public HRESULT TryGetRank(out uint pnRank)
        {
            /*HRESULT GetRank(out uint pnRank);*/
            return Raw.GetRank(out pnRank);
        }

        #endregion
        #region GetCount

        public uint Count
        {
            get
            {
                HRESULT hr;
                uint pnCount;

                if ((hr = TryGetCount(out pnCount)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pnCount;
            }
        }

        public HRESULT TryGetCount(out uint pnCount)
        {
            /*HRESULT GetCount(out uint pnCount);*/
            return Raw.GetCount(out pnCount);
        }

        #endregion
        #region GetDimensions

        public uint[] GetDimensions(uint cdim)
        {
            HRESULT hr;
            uint[] dimsResult;

            if ((hr = TryGetDimensions(cdim, out dimsResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return dimsResult;
        }

        public HRESULT TryGetDimensions(uint cdim, out uint[] dimsResult)
        {
            /*HRESULT GetDimensions([In] uint cdim, [MarshalAs(UnmanagedType.LPArray), Out] uint[] dims);*/
            uint[] dims = null;
            HRESULT hr = Raw.GetDimensions(cdim, dims);

            if (hr == HRESULT.S_OK)
                dimsResult = dims;
            else
                dimsResult = default(uint[]);

            return hr;
        }

        #endregion
        #region HasBaseIndicies

        public int HasBaseIndicies()
        {
            HRESULT hr;
            int pbHasBaseIndicies;

            if ((hr = TryHasBaseIndicies(out pbHasBaseIndicies)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbHasBaseIndicies;
        }

        public HRESULT TryHasBaseIndicies(out int pbHasBaseIndicies)
        {
            /*HRESULT HasBaseIndicies(out int pbHasBaseIndicies);*/
            return Raw.HasBaseIndicies(out pbHasBaseIndicies);
        }

        #endregion
        #region GetBaseIndicies

        public uint[] GetBaseIndicies(uint cdim)
        {
            HRESULT hr;
            uint[] indiciesResult;

            if ((hr = TryGetBaseIndicies(cdim, out indiciesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return indiciesResult;
        }

        public HRESULT TryGetBaseIndicies(uint cdim, out uint[] indiciesResult)
        {
            /*HRESULT GetBaseIndicies([In] uint cdim, [MarshalAs(UnmanagedType.LPArray), Out] uint[] indicies);*/
            uint[] indicies = null;
            HRESULT hr = Raw.GetBaseIndicies(cdim, indicies);

            if (hr == HRESULT.S_OK)
                indiciesResult = indicies;
            else
                indiciesResult = default(uint[]);

            return hr;
        }

        #endregion
        #region GetElement

        public CorDebugValue GetElement(uint cdim, uint indices)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetElement(cdim, indices, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetElement(uint cdim, uint indices, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetElement(
            [In] uint cdim,
            [MarshalAs(UnmanagedType.LPArray), In] uint indices,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetElement(cdim, indices, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetElementAtPosition

        public CorDebugValue GetElementAtPosition(uint nPosition)
        {
            HRESULT hr;
            CorDebugValue ppValueResult;

            if ((hr = TryGetElementAtPosition(nPosition, out ppValueResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppValueResult;
        }

        public HRESULT TryGetElementAtPosition(uint nPosition, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetElementAtPosition([In] uint nPosition, [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetElementAtPosition(nPosition, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
    }
}