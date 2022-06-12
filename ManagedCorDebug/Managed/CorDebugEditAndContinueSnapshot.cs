using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ManagedCorDebug
{
    /// <summary>
    /// <see cref="ICorDebugEditAndContinueSnapshot"/> is obsolete. Do not use this interface.
    /// </summary>
    public class CorDebugEditAndContinueSnapshot : ComObject<ICorDebugEditAndContinueSnapshot>
    {
        public CorDebugEditAndContinueSnapshot(ICorDebugEditAndContinueSnapshot raw) : base(raw)
        {
        }

        #region ICorDebugEditAndContinueSnapshot
        #region GetMvid

        /// <summary>
        /// GetMvid is obsolete. Do not call this method.
        /// </summary>
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

        /// <summary>
        /// GetMvid is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryGetMvid(out Guid pMvid)
        {
            /*HRESULT GetMvid(out Guid pMvid);*/
            return Raw.GetMvid(out pMvid);
        }

        #endregion
        #region GetRoDataRVA

        /// <summary>
        /// GetRoDataRVA is obsolete. Do not call this method.
        /// </summary>
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

        /// <summary>
        /// GetRoDataRVA is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryGetRoDataRVA(out uint pRoDataRVA)
        {
            /*HRESULT GetRoDataRVA(out uint pRoDataRVA);*/
            return Raw.GetRoDataRVA(out pRoDataRVA);
        }

        #endregion
        #region GetRwDataRVA

        /// <summary>
        /// GetRwDataRVA is obsolete. Do not call this method.
        /// </summary>
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

        /// <summary>
        /// GetRwDataRVA is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryGetRwDataRVA(out uint pRwDataRVA)
        {
            /*HRESULT GetRwDataRVA(out uint pRwDataRVA);*/
            return Raw.GetRwDataRVA(out pRwDataRVA);
        }

        #endregion
        #region CopyMetaData

        /// <summary>
        /// CopyMetaData is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public Guid CopyMetaData(IStream pIStream)
        {
            HRESULT hr;
            Guid pMvid;

            if ((hr = TryCopyMetaData(pIStream, out pMvid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pMvid;
        }

        /// <summary>
        /// CopyMetaData is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryCopyMetaData(IStream pIStream, out Guid pMvid)
        {
            /*HRESULT CopyMetaData([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, out Guid pMvid);*/
            return Raw.CopyMetaData(pIStream, out pMvid);
        }

        #endregion
        #region SetPEBytes

        /// <summary>
        /// SetPEBytes is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public void SetPEBytes(IStream pIStream)
        {
            HRESULT hr;

            if ((hr = TrySetPEBytes(pIStream)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// SetPEBytes is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TrySetPEBytes(IStream pIStream)
        {
            /*HRESULT SetPEBytes([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);*/
            return Raw.SetPEBytes(pIStream);
        }

        #endregion
        #region SetILMap

        /// <summary>
        /// SetILMap is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public void SetILMap(uint mdFunction, uint cMapSize, COR_IL_MAP map)
        {
            HRESULT hr;

            if ((hr = TrySetILMap(mdFunction, cMapSize, map)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// SetILMap is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TrySetILMap(uint mdFunction, uint cMapSize, COR_IL_MAP map)
        {
            /*HRESULT SetILMap([In] uint mdFunction, [In] uint cMapSize, [In] ref COR_IL_MAP map);*/
            return Raw.SetILMap(mdFunction, cMapSize, ref map);
        }

        #endregion
        #region SetPESymbolBytes

        /// <summary>
        /// SetPESymbolBytes is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public void SetPESymbolBytes(IStream pIStream)
        {
            HRESULT hr;

            if ((hr = TrySetPESymbolBytes(pIStream)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// SetPESymbolBytes is obsolete. Do not call this method.
        /// </summary>
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