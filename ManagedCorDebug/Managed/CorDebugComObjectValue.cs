using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CorDebugComObjectValue : ComObject<ICorDebugComObjectValue>
    {
        public CorDebugComObjectValue(ICorDebugComObjectValue raw) : base(raw)
        {
        }

        #region ICorDebugComObjectValue
        #region GetCachedInterfaceTypes

        public CorDebugTypeEnum GetCachedInterfaceTypes(int bIInspectableOnly)
        {
            HRESULT hr;
            CorDebugTypeEnum ppInterfacesEnumResult;

            if ((hr = TryGetCachedInterfaceTypes(bIInspectableOnly, out ppInterfacesEnumResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppInterfacesEnumResult;
        }

        public HRESULT TryGetCachedInterfaceTypes(int bIInspectableOnly, out CorDebugTypeEnum ppInterfacesEnumResult)
        {
            /*HRESULT GetCachedInterfaceTypes([In] int bIInspectableOnly,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugTypeEnum ppInterfacesEnum);*/
            ICorDebugTypeEnum ppInterfacesEnum;
            HRESULT hr = Raw.GetCachedInterfaceTypes(bIInspectableOnly, out ppInterfacesEnum);

            if (hr == HRESULT.S_OK)
                ppInterfacesEnumResult = new CorDebugTypeEnum(ppInterfacesEnum);
            else
                ppInterfacesEnumResult = default(CorDebugTypeEnum);

            return hr;
        }

        #endregion
        #region GetCachedInterfacePointers

        public GetCachedInterfacePointersResult GetCachedInterfacePointers(int bIInspectableOnly, uint celt)
        {
            HRESULT hr;
            GetCachedInterfacePointersResult result;

            if ((hr = TryGetCachedInterfacePointers(bIInspectableOnly, celt, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetCachedInterfacePointers(int bIInspectableOnly, uint celt, out GetCachedInterfacePointersResult result)
        {
            /*HRESULT GetCachedInterfacePointers(
            [In] int bIInspectableOnly,
            [In] uint celt,
            out uint pceltFetched,
            out CORDB_ADDRESS[] ptrs);*/
            uint pceltFetched;
            CORDB_ADDRESS[] ptrs;
            HRESULT hr = Raw.GetCachedInterfacePointers(bIInspectableOnly, celt, out pceltFetched, out ptrs);

            if (hr == HRESULT.S_OK)
                result = new GetCachedInterfacePointersResult(pceltFetched, ptrs);
            else
                result = default(GetCachedInterfacePointersResult);

            return hr;
        }

        #endregion
        #endregion
    }
}