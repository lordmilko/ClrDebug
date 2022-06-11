using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class MetaDataTables : ComObject<IMetaDataTables>
    {
        public MetaDataTables(IMetaDataTables raw) : base(raw)
        {
        }

        #region IMetaDataTables
        #region GetStringHeapSize

        public uint StringHeapSize
        {
            get
            {
                HRESULT hr;
                uint pcbStrings;

                if ((hr = TryGetStringHeapSize(out pcbStrings)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbStrings;
            }
        }

        public HRESULT TryGetStringHeapSize(out uint pcbStrings)
        {
            /*HRESULT GetStringHeapSize(out uint pcbStrings);*/
            return Raw.GetStringHeapSize(out pcbStrings);
        }

        #endregion
        #region GetBlobHeapSize

        public uint BlobHeapSize
        {
            get
            {
                HRESULT hr;
                uint pcbBlobs;

                if ((hr = TryGetBlobHeapSize(out pcbBlobs)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbBlobs;
            }
        }

        public HRESULT TryGetBlobHeapSize(out uint pcbBlobs)
        {
            /*HRESULT GetBlobHeapSize(out uint pcbBlobs);*/
            return Raw.GetBlobHeapSize(out pcbBlobs);
        }

        #endregion
        #region GetGuidHeapSize

        public uint GuidHeapSize
        {
            get
            {
                HRESULT hr;
                uint pcbGuids;

                if ((hr = TryGetGuidHeapSize(out pcbGuids)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbGuids;
            }
        }

        public HRESULT TryGetGuidHeapSize(out uint pcbGuids)
        {
            /*HRESULT GetGuidHeapSize(out uint pcbGuids);*/
            return Raw.GetGuidHeapSize(out pcbGuids);
        }

        #endregion
        #region GetUserStringHeapSize

        public uint UserStringHeapSize
        {
            get
            {
                HRESULT hr;
                uint pcbBlobs;

                if ((hr = TryGetUserStringHeapSize(out pcbBlobs)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbBlobs;
            }
        }

        public HRESULT TryGetUserStringHeapSize(out uint pcbBlobs)
        {
            /*HRESULT GetUserStringHeapSize(out uint pcbBlobs);*/
            return Raw.GetUserStringHeapSize(out pcbBlobs);
        }

        #endregion
        #region GetNumTables

        public uint NumTables
        {
            get
            {
                HRESULT hr;
                uint pcTables;

                if ((hr = TryGetNumTables(out pcTables)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcTables;
            }
        }

        public HRESULT TryGetNumTables(out uint pcTables)
        {
            /*HRESULT GetNumTables(out uint pcTables);*/
            return Raw.GetNumTables(out pcTables);
        }

        #endregion
        #region GetTableIndex

        public uint GetTableIndex(uint token)
        {
            HRESULT hr;
            uint pixTbl;

            if ((hr = TryGetTableIndex(token, out pixTbl)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pixTbl;
        }

        public HRESULT TryGetTableIndex(uint token, out uint pixTbl)
        {
            /*HRESULT GetTableIndex(uint token, out uint pixTbl);*/
            return Raw.GetTableIndex(token, out pixTbl);
        }

        #endregion
        #region GetTableInfo

        public GetTableInfoResult GetTableInfo(uint ixTbl, char[] ppName)
        {
            HRESULT hr;
            GetTableInfoResult result;

            if ((hr = TryGetTableInfo(ixTbl, ppName, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetTableInfo(uint ixTbl, char[] ppName, out GetTableInfoResult result)
        {
            /*HRESULT GetTableInfo(uint ixTbl, out uint pcbRow, out uint pcRows, out uint pcCols, out uint piKey, [MarshalAs(UnmanagedType.LPArray)] char[] ppName);*/
            uint pcbRow;
            uint pcRows;
            uint pcCols;
            uint piKey;
            HRESULT hr = Raw.GetTableInfo(ixTbl, out pcbRow, out pcRows, out pcCols, out piKey, ppName);

            if (hr == HRESULT.S_OK)
                result = new GetTableInfoResult(pcbRow, pcRows, pcCols, piKey);
            else
                result = default(GetTableInfoResult);

            return hr;
        }

        #endregion
        #region GetColumnInfo

        public GetColumnInfoResult GetColumnInfo(uint ixTbl, uint ixCol, char[] ppName)
        {
            HRESULT hr;
            GetColumnInfoResult result;

            if ((hr = TryGetColumnInfo(ixTbl, ixCol, ppName, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetColumnInfo(uint ixTbl, uint ixCol, char[] ppName, out GetColumnInfoResult result)
        {
            /*HRESULT GetColumnInfo(uint ixTbl, uint ixCol, out uint poCol, out uint pcbCol, out uint pType, [MarshalAs(UnmanagedType.LPArray)] char[] ppName);*/
            uint poCol;
            uint pcbCol;
            uint pType;
            HRESULT hr = Raw.GetColumnInfo(ixTbl, ixCol, out poCol, out pcbCol, out pType, ppName);

            if (hr == HRESULT.S_OK)
                result = new GetColumnInfoResult(poCol, pcbCol, pType);
            else
                result = default(GetColumnInfoResult);

            return hr;
        }

        #endregion
        #region GetCodedTokenInfo

        public uint GetCodedTokenInfo(uint ixCdTkn, uint[] ppTokens, char[] ppName)
        {
            HRESULT hr;
            uint pcTokens;

            if ((hr = TryGetCodedTokenInfo(ixCdTkn, out pcTokens, ppTokens, ppName)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pcTokens;
        }

        public HRESULT TryGetCodedTokenInfo(uint ixCdTkn, out uint pcTokens, uint[] ppTokens, char[] ppName)
        {
            /*HRESULT GetCodedTokenInfo(uint ixCdTkn, out uint pcTokens, [MarshalAs(UnmanagedType.LPArray)] uint[] ppTokens, [MarshalAs(UnmanagedType.LPArray)] char[] ppName);*/
            return Raw.GetCodedTokenInfo(ixCdTkn, out pcTokens, ppTokens, ppName);
        }

        #endregion
        #region GetRow

        public IntPtr GetRow(uint ixTbl, uint rid)
        {
            HRESULT hr;
            IntPtr ppRow;

            if ((hr = TryGetRow(ixTbl, rid, out ppRow)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppRow;
        }

        public HRESULT TryGetRow(uint ixTbl, uint rid, out IntPtr ppRow)
        {
            /*HRESULT GetRow(uint ixTbl, uint rid, out IntPtr ppRow);*/
            return Raw.GetRow(ixTbl, rid, out ppRow);
        }

        #endregion
        #region GetColumn

        public uint GetColumn(uint ixTbl, uint ixCol, uint rid)
        {
            HRESULT hr;
            uint pVal;

            if ((hr = TryGetColumn(ixTbl, ixCol, rid, out pVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pVal;
        }

        public HRESULT TryGetColumn(uint ixTbl, uint ixCol, uint rid, out uint pVal)
        {
            /*HRESULT GetColumn(uint ixTbl, uint ixCol, uint rid, out uint pVal);*/
            return Raw.GetColumn(ixTbl, ixCol, rid, out pVal);
        }

        #endregion
        #region GetString

        public void GetString(uint ixString, char[] ppString)
        {
            HRESULT hr;

            if ((hr = TryGetString(ixString, ppString)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryGetString(uint ixString, char[] ppString)
        {
            /*HRESULT GetString(uint ixString, [MarshalAs(UnmanagedType.LPArray)] char[] ppString);*/
            return Raw.GetString(ixString, ppString);
        }

        #endregion
        #region GetBlob

        public GetBlobResult GetBlob(uint ixBlob)
        {
            HRESULT hr;
            GetBlobResult result;

            if ((hr = TryGetBlob(ixBlob, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetBlob(uint ixBlob, out GetBlobResult result)
        {
            /*HRESULT GetBlob(uint ixBlob, out uint pcbData, out IntPtr ppData);*/
            uint pcbData;
            IntPtr ppData;
            HRESULT hr = Raw.GetBlob(ixBlob, out pcbData, out ppData);

            if (hr == HRESULT.S_OK)
                result = new GetBlobResult(pcbData, ppData);
            else
                result = default(GetBlobResult);

            return hr;
        }

        #endregion
        #region GetGuid

        public Guid GetGuid(uint ixGuid)
        {
            HRESULT hr;
            Guid ppGUID;

            if ((hr = TryGetGuid(ixGuid, out ppGUID)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppGUID;
        }

        public HRESULT TryGetGuid(uint ixGuid, out Guid ppGUID)
        {
            /*HRESULT GetGuid(uint ixGuid, out Guid ppGUID);*/
            return Raw.GetGuid(ixGuid, out ppGUID);
        }

        #endregion
        #region GetUserString

        public GetUserStringResult GetUserString(uint ixUserString)
        {
            HRESULT hr;
            GetUserStringResult result;

            if ((hr = TryGetUserString(ixUserString, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetUserString(uint ixUserString, out GetUserStringResult result)
        {
            /*HRESULT GetUserString(uint ixUserString, out uint pcbData, out IntPtr ppData);*/
            uint pcbData;
            IntPtr ppData;
            HRESULT hr = Raw.GetUserString(ixUserString, out pcbData, out ppData);

            if (hr == HRESULT.S_OK)
                result = new GetUserStringResult(pcbData, ppData);
            else
                result = default(GetUserStringResult);

            return hr;
        }

        #endregion
        #region GetNextString

        public uint GetNextString(uint ixString)
        {
            HRESULT hr;
            uint pNext;

            if ((hr = TryGetNextString(ixString, out pNext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pNext;
        }

        public HRESULT TryGetNextString(uint ixString, out uint pNext)
        {
            /*HRESULT GetNextString(uint ixString, out uint pNext);*/
            return Raw.GetNextString(ixString, out pNext);
        }

        #endregion
        #region GetNextBlob

        public uint GetNextBlob(uint ixBlob)
        {
            HRESULT hr;
            uint pNext;

            if ((hr = TryGetNextBlob(ixBlob, out pNext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pNext;
        }

        public HRESULT TryGetNextBlob(uint ixBlob, out uint pNext)
        {
            /*HRESULT GetNextBlob(uint ixBlob, out uint pNext);*/
            return Raw.GetNextBlob(ixBlob, out pNext);
        }

        #endregion
        #region GetNextGuid

        public uint GetNextGuid(uint ixGuid)
        {
            HRESULT hr;
            uint pNext;

            if ((hr = TryGetNextGuid(ixGuid, out pNext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pNext;
        }

        public HRESULT TryGetNextGuid(uint ixGuid, out uint pNext)
        {
            /*HRESULT GetNextGuid(uint ixGuid, out uint pNext);*/
            return Raw.GetNextGuid(ixGuid, out pNext);
        }

        #endregion
        #region GetNextUserString

        public uint GetNextUserString(uint ixUserString)
        {
            HRESULT hr;
            uint pNext;

            if ((hr = TryGetNextUserString(ixUserString, out pNext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pNext;
        }

        public HRESULT TryGetNextUserString(uint ixUserString, out uint pNext)
        {
            /*HRESULT GetNextUserString(uint ixUserString, out uint pNext);*/
            return Raw.GetNextUserString(ixUserString, out pNext);
        }

        #endregion
        #endregion
        #region IMetaDataTables2

        public IMetaDataTables2 Raw2 => (IMetaDataTables2) Raw;

        #region GetMetaDataStorage

        public GetMetaDataStorageResult MetaDataStorage
        {
            get
            {
                HRESULT hr;
                GetMetaDataStorageResult result;

                if ((hr = TryGetMetaDataStorage(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        public HRESULT TryGetMetaDataStorage(out GetMetaDataStorageResult result)
        {
            /*HRESULT GetMetaDataStorage(out IntPtr ppvMd, out uint pcbMd);*/
            IntPtr ppvMd;
            uint pcbMd;
            HRESULT hr = Raw2.GetMetaDataStorage(out ppvMd, out pcbMd);

            if (hr == HRESULT.S_OK)
                result = new GetMetaDataStorageResult(ppvMd, pcbMd);
            else
                result = default(GetMetaDataStorageResult);

            return hr;
        }

        #endregion
        #region GetMetaDataStreamInfo

        public GetMetaDataStreamInfoResult GetMetaDataStreamInfo(uint ix, char[] ppchName)
        {
            HRESULT hr;
            GetMetaDataStreamInfoResult result;

            if ((hr = TryGetMetaDataStreamInfo(ix, ppchName, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMetaDataStreamInfo(uint ix, char[] ppchName, out GetMetaDataStreamInfoResult result)
        {
            /*HRESULT GetMetaDataStreamInfo(uint ix, [MarshalAs(UnmanagedType.LPArray)] char[] ppchName, out IntPtr ppv, out uint pcb);*/
            IntPtr ppv;
            uint pcb;
            HRESULT hr = Raw2.GetMetaDataStreamInfo(ix, ppchName, out ppv, out pcb);

            if (hr == HRESULT.S_OK)
                result = new GetMetaDataStreamInfoResult(ppv, pcb);
            else
                result = default(GetMetaDataStreamInfoResult);

            return hr;
        }

        #endregion
        #endregion
    }
}