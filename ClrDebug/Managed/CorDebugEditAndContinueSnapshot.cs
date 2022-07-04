using System;

namespace ClrDebug
{
    /// <summary>
    /// <see cref="ICorDebugEditAndContinueSnapshot"/> is obsolete. Do not use this interface.
    /// </summary>
    public class CorDebugEditAndContinueSnapshot : ComObject<ICorDebugEditAndContinueSnapshot>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugEditAndContinueSnapshot"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugEditAndContinueSnapshot(ICorDebugEditAndContinueSnapshot raw) : base(raw)
        {
        }

        #region ICorDebugEditAndContinueSnapshot
        #region Mvid

        /// <summary>
        /// GetMvid is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public Guid Mvid
        {
            get
            {
                Guid pMvid;
                TryGetMvid(out pMvid).ThrowOnNotOK();

                return pMvid;
            }
        }

        /// <summary>
        /// GetMvid is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryGetMvid(out Guid pMvid)
        {
            /*HRESULT GetMvid([Out] out Guid pMvid);*/
            return Raw.GetMvid(out pMvid);
        }

        #endregion
        #region RoDataRVA

        /// <summary>
        /// GetRoDataRVA is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public int RoDataRVA
        {
            get
            {
                int pRoDataRVA;
                TryGetRoDataRVA(out pRoDataRVA).ThrowOnNotOK();

                return pRoDataRVA;
            }
        }

        /// <summary>
        /// GetRoDataRVA is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryGetRoDataRVA(out int pRoDataRVA)
        {
            /*HRESULT GetRoDataRVA([Out] out int pRoDataRVA);*/
            return Raw.GetRoDataRVA(out pRoDataRVA);
        }

        #endregion
        #region RwDataRVA

        /// <summary>
        /// GetRwDataRVA is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public int RwDataRVA
        {
            get
            {
                int pRwDataRVA;
                TryGetRwDataRVA(out pRwDataRVA).ThrowOnNotOK();

                return pRwDataRVA;
            }
        }

        /// <summary>
        /// GetRwDataRVA is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryGetRwDataRVA(out int pRwDataRVA)
        {
            /*HRESULT GetRwDataRVA([Out] out int pRwDataRVA);*/
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
            Guid pMvid;
            TryCopyMetaData(pIStream, out pMvid).ThrowOnNotOK();

            return pMvid;
        }

        /// <summary>
        /// CopyMetaData is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryCopyMetaData(IStream pIStream, out Guid pMvid)
        {
            /*HRESULT CopyMetaData([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, [Out] out Guid pMvid);*/
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
            TrySetPEBytes(pIStream).ThrowOnNotOK();
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
        public void SetILMap(mdToken mdFunction, int cMapSize, COR_IL_MAP map)
        {
            TrySetILMap(mdFunction, cMapSize, map).ThrowOnNotOK();
        }

        /// <summary>
        /// SetILMap is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TrySetILMap(mdToken mdFunction, int cMapSize, COR_IL_MAP map)
        {
            /*HRESULT SetILMap([In] mdToken mdFunction, [In] int cMapSize, [In] ref COR_IL_MAP map);*/
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
            TrySetPESymbolBytes(pIStream).ThrowOnNotOK();
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
