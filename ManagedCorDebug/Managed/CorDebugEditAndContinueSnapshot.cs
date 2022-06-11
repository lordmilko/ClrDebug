using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    public class CorDebugEditAndContinueSnapshot : ComObject<ICorDebugEditAndContinueSnapshot>
    {
        public CorDebugEditAndContinueSnapshot(ICorDebugEditAndContinueSnapshot raw) : base(raw)
        {
        }

        #region ICorDebugEditAndContinueSnapshot
        #region GetMvid

        [Obsolete]
        public Guid Mvid
        {
            get
            {
                HRESULT hr;
                Guid pMvid;

                if ((hr = TryGetMvid(out pMvid)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pMvid;
            }
        }

        [Obsolete]
        public HRESULT TryGetMvid(out Guid pMvid)
        {
            /*HRESULT GetMvid(out Guid pMvid);*/
            return Raw.GetMvid(out pMvid);
        }

        #endregion
        #region GetRoDataRVA

        [Obsolete]
        public uint RoDataRVA
        {
            get
            {
                HRESULT hr;
                uint pRoDataRVA;

                if ((hr = TryGetRoDataRVA(out pRoDataRVA)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRoDataRVA;
            }
        }

        [Obsolete]
        public HRESULT TryGetRoDataRVA(out uint pRoDataRVA)
        {
            /*HRESULT GetRoDataRVA(out uint pRoDataRVA);*/
            return Raw.GetRoDataRVA(out pRoDataRVA);
        }

        #endregion
        #region GetRwDataRVA

        [Obsolete]
        public uint RwDataRVA
        {
            get
            {
                HRESULT hr;
                uint pRwDataRVA;

                if ((hr = TryGetRwDataRVA(out pRwDataRVA)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRwDataRVA;
            }
        }

        [Obsolete]
        public HRESULT TryGetRwDataRVA(out uint pRwDataRVA)
        {
            /*HRESULT GetRwDataRVA(out uint pRwDataRVA);*/
            return Raw.GetRwDataRVA(out pRwDataRVA);
        }

        #endregion
        #region CopyMetaData

        [Obsolete]
        public Guid CopyMetaData(IStream pIStream)
        {
            HRESULT hr;
            Guid pMvid;

            if ((hr = TryCopyMetaData(pIStream, out pMvid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pMvid;
        }

        [Obsolete]
        public HRESULT TryCopyMetaData(IStream pIStream, out Guid pMvid)
        {
            /*HRESULT CopyMetaData([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, out Guid pMvid);*/
            return Raw.CopyMetaData(pIStream, out pMvid);
        }

        #endregion
        #region SetPEBytes

        [Obsolete]
        public void SetPEBytes(IStream pIStream)
        {
            HRESULT hr;

            if ((hr = TrySetPEBytes(pIStream)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TrySetPEBytes(IStream pIStream)
        {
            /*HRESULT SetPEBytes([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);*/
            return Raw.SetPEBytes(pIStream);
        }

        #endregion
        #region SetILMap

        [Obsolete]
        public void SetILMap(uint mdFunction, uint cMapSize, COR_IL_MAP map)
        {
            HRESULT hr;

            if ((hr = TrySetILMap(mdFunction, cMapSize, map)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TrySetILMap(uint mdFunction, uint cMapSize, COR_IL_MAP map)
        {
            /*HRESULT SetILMap([In] uint mdFunction, [In] uint cMapSize, [In] ref COR_IL_MAP map);*/
            return Raw.SetILMap(mdFunction, cMapSize, ref map);
        }

        #endregion
        #region SetPESymbolBytes

        [Obsolete]
        public void SetPESymbolBytes(IStream pIStream)
        {
            HRESULT hr;

            if ((hr = TrySetPESymbolBytes(pIStream)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        [Obsolete]
        public HRESULT TrySetPESymbolBytes(IStream pIStream)
        {
            /*HRESULT SetPESymbolBytes([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);*/
            return Raw.SetPESymbolBytes(pIStream);
        }

        #endregion
        #endregion
    }
}