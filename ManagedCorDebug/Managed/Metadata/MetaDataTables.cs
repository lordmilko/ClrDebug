using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods for the storage and retrieval of metadata information in tables.
    /// </summary>
    public class MetaDataTables : ComObject<IMetaDataTables>
    {
        public MetaDataTables(IMetaDataTables raw) : base(raw)
        {
        }

        #region IMetaDataTables
        #region GetStringHeapSize

        /// <summary>
        /// Gets the size, in bytes, of the string heap.
        /// </summary>
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

        /// <summary>
        /// Gets the size, in bytes, of the string heap.
        /// </summary>
        /// <param name="pcbStrings">[out] A pointer to the size, in bytes, of the string heap.</param>
        public HRESULT TryGetStringHeapSize(out uint pcbStrings)
        {
            /*HRESULT GetStringHeapSize(out uint pcbStrings);*/
            return Raw.GetStringHeapSize(out pcbStrings);
        }

        #endregion
        #region GetBlobHeapSize

        /// <summary>
        /// Gets the size, in bytes, of the binary large object (BLOB) heap.
        /// </summary>
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

        /// <summary>
        /// Gets the size, in bytes, of the binary large object (BLOB) heap.
        /// </summary>
        /// <param name="pcbBlobs">[out] A pointer to the size, in bytes, of the BLOB heap.</param>
        public HRESULT TryGetBlobHeapSize(out uint pcbBlobs)
        {
            /*HRESULT GetBlobHeapSize(out uint pcbBlobs);*/
            return Raw.GetBlobHeapSize(out pcbBlobs);
        }

        #endregion
        #region GetGuidHeapSize

        /// <summary>
        /// Gets the size, in bytes, of the GUID heap.
        /// </summary>
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

        /// <summary>
        /// Gets the size, in bytes, of the GUID heap.
        /// </summary>
        /// <param name="pcbGuids">[out] A pointer to the size, in bytes, of the GUID heap.</param>
        public HRESULT TryGetGuidHeapSize(out uint pcbGuids)
        {
            /*HRESULT GetGuidHeapSize(out uint pcbGuids);*/
            return Raw.GetGuidHeapSize(out pcbGuids);
        }

        #endregion
        #region GetUserStringHeapSize

        /// <summary>
        /// Gets the size, in bytes, of the user string heap.
        /// </summary>
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

        /// <summary>
        /// Gets the size, in bytes, of the user string heap.
        /// </summary>
        /// <param name="pcbBlobs">[out] A pointer to the size, in bytes, of the user string heap.</param>
        public HRESULT TryGetUserStringHeapSize(out uint pcbBlobs)
        {
            /*HRESULT GetUserStringHeapSize(out uint pcbBlobs);*/
            return Raw.GetUserStringHeapSize(out pcbBlobs);
        }

        #endregion
        #region GetNumTables

        /// <summary>
        /// Gets the number of tables in the scope of the current <see cref="IMetaDataTables"/> instance.
        /// </summary>
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

        /// <summary>
        /// Gets the number of tables in the scope of the current <see cref="IMetaDataTables"/> instance.
        /// </summary>
        /// <param name="pcTables">[out] A pointer to the number of tables in the current instance scope.</param>
        public HRESULT TryGetNumTables(out uint pcTables)
        {
            /*HRESULT GetNumTables(out uint pcTables);*/
            return Raw.GetNumTables(out pcTables);
        }

        #endregion
        #region GetTableIndex

        /// <summary>
        /// Gets the index for the table referenced by the specified token.
        /// </summary>
        /// <param name="token">[in] The token that references the table.</param>
        /// <returns>[out] A pointer to the returned index for the referenced table.</returns>
        /// <remarks>
        /// We do not recommend the use of this method, because it does not return consistent results. For information about
        /// the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata
        /// Definition and Semantics". The documentation is available online; see ECMA C# and Common Language Infrastructure
        /// Standards and Standard ECMA-335 - Common Language Infrastructure (CLI).
        /// </remarks>
        public uint GetTableIndex(uint token)
        {
            HRESULT hr;
            uint pixTbl;

            if ((hr = TryGetTableIndex(token, out pixTbl)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pixTbl;
        }

        /// <summary>
        /// Gets the index for the table referenced by the specified token.
        /// </summary>
        /// <param name="token">[in] The token that references the table.</param>
        /// <param name="pixTbl">[out] A pointer to the returned index for the referenced table.</param>
        /// <remarks>
        /// We do not recommend the use of this method, because it does not return consistent results. For information about
        /// the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata
        /// Definition and Semantics". The documentation is available online; see ECMA C# and Common Language Infrastructure
        /// Standards and Standard ECMA-335 - Common Language Infrastructure (CLI).
        /// </remarks>
        public HRESULT TryGetTableIndex(uint token, out uint pixTbl)
        {
            /*HRESULT GetTableIndex(uint token, out uint pixTbl);*/
            return Raw.GetTableIndex(token, out pixTbl);
        }

        #endregion
        #region GetTableInfo

        /// <summary>
        /// Gets the name, row size, number of rows, number of columns, and key column index of the specified table.
        /// </summary>
        /// <param name="ixTbl">[in] The identifier of the table whose properties to return.</param>
        /// <param name="ppName">[out] A pointer to a pointer to the table name.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetTableInfoResult GetTableInfo(uint ixTbl, char[] ppName)
        {
            HRESULT hr;
            GetTableInfoResult result;

            if ((hr = TryGetTableInfo(ixTbl, ppName, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the name, row size, number of rows, number of columns, and key column index of the specified table.
        /// </summary>
        /// <param name="ixTbl">[in] The identifier of the table whose properties to return.</param>
        /// <param name="ppName">[out] A pointer to a pointer to the table name.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
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

        /// <summary>
        /// Gets data about the specified column in the specified table.
        /// </summary>
        /// <param name="ixTbl">[in] The index of the desired table.</param>
        /// <param name="ixCol">[in] The index of the desired column.</param>
        /// <param name="ppName">[out] A pointer to a pointer to the column name.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The returned column type falls within a range of values: Values that are stored in the heap (that is, IsHeapType
        /// == true) can be read using:
        /// </remarks>
        public GetColumnInfoResult GetColumnInfo(uint ixTbl, uint ixCol, char[] ppName)
        {
            HRESULT hr;
            GetColumnInfoResult result;

            if ((hr = TryGetColumnInfo(ixTbl, ixCol, ppName, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets data about the specified column in the specified table.
        /// </summary>
        /// <param name="ixTbl">[in] The index of the desired table.</param>
        /// <param name="ixCol">[in] The index of the desired column.</param>
        /// <param name="ppName">[out] A pointer to a pointer to the column name.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The returned column type falls within a range of values: Values that are stored in the heap (that is, IsHeapType
        /// == true) can be read using:
        /// </remarks>
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

        /// <summary>
        /// Gets a pointer to an array of tokens associated with the specified row index.
        /// </summary>
        /// <param name="ixCdTkn">[in] The kind of coded token to return.</param>
        /// <param name="ppTokens">[out] A pointer to a pointer to an array that contains the list of returned tokens.</param>
        /// <param name="ppName">[out] A pointer to a pointer to the name of the token at ixCdTkn.</param>
        /// <returns>[out] A pointer to the length of ppTokens.</returns>
        public uint GetCodedTokenInfo(uint ixCdTkn, uint[] ppTokens, char[] ppName)
        {
            HRESULT hr;
            uint pcTokens;

            if ((hr = TryGetCodedTokenInfo(ixCdTkn, out pcTokens, ppTokens, ppName)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pcTokens;
        }

        /// <summary>
        /// Gets a pointer to an array of tokens associated with the specified row index.
        /// </summary>
        /// <param name="ixCdTkn">[in] The kind of coded token to return.</param>
        /// <param name="pcTokens">[out] A pointer to the length of ppTokens.</param>
        /// <param name="ppTokens">[out] A pointer to a pointer to an array that contains the list of returned tokens.</param>
        /// <param name="ppName">[out] A pointer to a pointer to the name of the token at ixCdTkn.</param>
        public HRESULT TryGetCodedTokenInfo(uint ixCdTkn, out uint pcTokens, uint[] ppTokens, char[] ppName)
        {
            /*HRESULT GetCodedTokenInfo(uint ixCdTkn, out uint pcTokens, [MarshalAs(UnmanagedType.LPArray)] uint[] ppTokens, [MarshalAs(UnmanagedType.LPArray)] char[] ppName);*/
            return Raw.GetCodedTokenInfo(ixCdTkn, out pcTokens, ppTokens, ppName);
        }

        #endregion
        #region GetRow

        /// <summary>
        /// Gets the row at the specified row index, in the table at the specified table index.
        /// </summary>
        /// <param name="ixTbl">[in] The index of the table from which the row will be retrieved.</param>
        /// <param name="rid">[in] The index of the row to get.</param>
        /// <returns>[out] A pointer to a pointer to the row.</returns>
        /// <remarks>
        /// We do not recommend the use of this method, because it does not return consistent results. For information about
        /// the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata
        /// Definition and Semantics". The documentation is available online; see ECMA C# and Common Language Infrastructure
        /// Standards and Standard ECMA-335 - Common Language Infrastructure (CLI).
        /// </remarks>
        public IntPtr GetRow(uint ixTbl, uint rid)
        {
            HRESULT hr;
            IntPtr ppRow;

            if ((hr = TryGetRow(ixTbl, rid, out ppRow)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppRow;
        }

        /// <summary>
        /// Gets the row at the specified row index, in the table at the specified table index.
        /// </summary>
        /// <param name="ixTbl">[in] The index of the table from which the row will be retrieved.</param>
        /// <param name="rid">[in] The index of the row to get.</param>
        /// <param name="ppRow">[out] A pointer to a pointer to the row.</param>
        /// <remarks>
        /// We do not recommend the use of this method, because it does not return consistent results. For information about
        /// the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata
        /// Definition and Semantics". The documentation is available online; see ECMA C# and Common Language Infrastructure
        /// Standards and Standard ECMA-335 - Common Language Infrastructure (CLI).
        /// </remarks>
        public HRESULT TryGetRow(uint ixTbl, uint rid, out IntPtr ppRow)
        {
            /*HRESULT GetRow(uint ixTbl, uint rid, out IntPtr ppRow);*/
            return Raw.GetRow(ixTbl, rid, out ppRow);
        }

        #endregion
        #region GetColumn

        /// <summary>
        /// Gets a pointer to the value contained in the cell of the specified column and row in the given table.
        /// </summary>
        /// <param name="ixTbl">[in] The index of the table.</param>
        /// <param name="ixCol">[in] The index of the column in the table.</param>
        /// <param name="rid">[in] The index of the row in the table.</param>
        /// <returns>[out] A pointer to the value in the cell.</returns>
        /// <remarks>
        /// The interpretation of the value returned through pVal depends on the column's type. The column type can be determined
        /// by calling <see cref="GetColumnInfo"/>.
        /// </remarks>
        public uint GetColumn(uint ixTbl, uint ixCol, uint rid)
        {
            HRESULT hr;
            uint pVal;

            if ((hr = TryGetColumn(ixTbl, ixCol, rid, out pVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pVal;
        }

        /// <summary>
        /// Gets a pointer to the value contained in the cell of the specified column and row in the given table.
        /// </summary>
        /// <param name="ixTbl">[in] The index of the table.</param>
        /// <param name="ixCol">[in] The index of the column in the table.</param>
        /// <param name="rid">[in] The index of the row in the table.</param>
        /// <param name="pVal">[out] A pointer to the value in the cell.</param>
        /// <remarks>
        /// The interpretation of the value returned through pVal depends on the column's type. The column type can be determined
        /// by calling <see cref="GetColumnInfo"/>.
        /// </remarks>
        public HRESULT TryGetColumn(uint ixTbl, uint ixCol, uint rid, out uint pVal)
        {
            /*HRESULT GetColumn(uint ixTbl, uint ixCol, uint rid, out uint pVal);*/
            return Raw.GetColumn(ixTbl, ixCol, rid, out pVal);
        }

        #endregion
        #region GetString

        /// <summary>
        /// Gets the string at the specified index from the table column in the current reference scope.
        /// </summary>
        /// <param name="ixString">[in] The index at which to start to search for the next value.</param>
        /// <param name="ppString">[out] A pointer to a pointer to the returned string value.</param>
        public void GetString(uint ixString, char[] ppString)
        {
            HRESULT hr;

            if ((hr = TryGetString(ixString, ppString)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Gets the string at the specified index from the table column in the current reference scope.
        /// </summary>
        /// <param name="ixString">[in] The index at which to start to search for the next value.</param>
        /// <param name="ppString">[out] A pointer to a pointer to the returned string value.</param>
        public HRESULT TryGetString(uint ixString, char[] ppString)
        {
            /*HRESULT GetString(uint ixString, [MarshalAs(UnmanagedType.LPArray)] char[] ppString);*/
            return Raw.GetString(ixString, ppString);
        }

        #endregion
        #region GetBlob

        /// <summary>
        /// Gets a pointer to the binary large object (BLOB) at the specified column index.
        /// </summary>
        /// <param name="ixBlob">[in] The memory address from which to get ppData.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetBlobResult GetBlob(uint ixBlob)
        {
            HRESULT hr;
            GetBlobResult result;

            if ((hr = TryGetBlob(ixBlob, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a pointer to the binary large object (BLOB) at the specified column index.
        /// </summary>
        /// <param name="ixBlob">[in] The memory address from which to get ppData.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
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

        /// <summary>
        /// Gets a GUID from the row at the specified index.
        /// </summary>
        /// <param name="ixGuid">[in] The index of the row from which to get the GUID.</param>
        /// <returns>[out] A pointer to a pointer to the GUID.</returns>
        /// <remarks>
        /// We do not recommend the use of this method, because it does not return consistent results. For information about
        /// the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata
        /// Definition and Semantics". The documentation is available online; see ECMA C# and Common Language Infrastructure
        /// Standards and Standard ECMA-335 - Common Language Infrastructure (CLI).
        /// </remarks>
        public Guid GetGuid(uint ixGuid)
        {
            HRESULT hr;
            Guid ppGUID;

            if ((hr = TryGetGuid(ixGuid, out ppGUID)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppGUID;
        }

        /// <summary>
        /// Gets a GUID from the row at the specified index.
        /// </summary>
        /// <param name="ixGuid">[in] The index of the row from which to get the GUID.</param>
        /// <param name="ppGUID">[out] A pointer to a pointer to the GUID.</param>
        /// <remarks>
        /// We do not recommend the use of this method, because it does not return consistent results. For information about
        /// the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata
        /// Definition and Semantics". The documentation is available online; see ECMA C# and Common Language Infrastructure
        /// Standards and Standard ECMA-335 - Common Language Infrastructure (CLI).
        /// </remarks>
        public HRESULT TryGetGuid(uint ixGuid, out Guid ppGUID)
        {
            /*HRESULT GetGuid(uint ixGuid, out Guid ppGUID);*/
            return Raw.GetGuid(ixGuid, out ppGUID);
        }

        #endregion
        #region GetUserString

        /// <summary>
        /// Gets the hard-coded string at the specified index in the string column in the current scope.
        /// </summary>
        /// <param name="ixUserString">[in] The index value from which the hard-coded string will be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetUserStringResult GetUserString(uint ixUserString)
        {
            HRESULT hr;
            GetUserStringResult result;

            if ((hr = TryGetUserString(ixUserString, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the hard-coded string at the specified index in the string column in the current scope.
        /// </summary>
        /// <param name="ixUserString">[in] The index value from which the hard-coded string will be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
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

        /// <summary>
        /// Gets the index of the next string in the current table column.
        /// </summary>
        /// <param name="ixString">[in] The index value from a string table column.</param>
        /// <returns>[out] A pointer to the index of the next string in the column.</returns>
        public uint GetNextString(uint ixString)
        {
            HRESULT hr;
            uint pNext;

            if ((hr = TryGetNextString(ixString, out pNext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pNext;
        }

        /// <summary>
        /// Gets the index of the next string in the current table column.
        /// </summary>
        /// <param name="ixString">[in] The index value from a string table column.</param>
        /// <param name="pNext">[out] A pointer to the index of the next string in the column.</param>
        public HRESULT TryGetNextString(uint ixString, out uint pNext)
        {
            /*HRESULT GetNextString(uint ixString, out uint pNext);*/
            return Raw.GetNextString(ixString, out pNext);
        }

        #endregion
        #region GetNextBlob

        /// <summary>
        /// Gets the index of the next binary large object (BLOB) in the table.
        /// </summary>
        /// <param name="ixBlob">[in] The index, as returned from a column of BLOBs.</param>
        /// <returns>[out] A pointer to the index of the next BLOB.</returns>
        public uint GetNextBlob(uint ixBlob)
        {
            HRESULT hr;
            uint pNext;

            if ((hr = TryGetNextBlob(ixBlob, out pNext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pNext;
        }

        /// <summary>
        /// Gets the index of the next binary large object (BLOB) in the table.
        /// </summary>
        /// <param name="ixBlob">[in] The index, as returned from a column of BLOBs.</param>
        /// <param name="pNext">[out] A pointer to the index of the next BLOB.</param>
        public HRESULT TryGetNextBlob(uint ixBlob, out uint pNext)
        {
            /*HRESULT GetNextBlob(uint ixBlob, out uint pNext);*/
            return Raw.GetNextBlob(ixBlob, out pNext);
        }

        #endregion
        #region GetNextGuid

        /// <summary>
        /// Gets the index of the next GUID value in the current table column.
        /// </summary>
        /// <param name="ixGuid">[in] The index value from a GUID table column.</param>
        /// <returns>[out] A pointer to the index of the next GUID value.</returns>
        /// <remarks>
        /// We do not recommend the use of this method, because it does not return consistent results. For information about
        /// the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata
        /// Definition and Semantics". The documentation is available online; see ECMA C# and Common Language Infrastructure
        /// Standards and Standard ECMA-335 - Common Language Infrastructure (CLI).
        /// </remarks>
        public uint GetNextGuid(uint ixGuid)
        {
            HRESULT hr;
            uint pNext;

            if ((hr = TryGetNextGuid(ixGuid, out pNext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pNext;
        }

        /// <summary>
        /// Gets the index of the next GUID value in the current table column.
        /// </summary>
        /// <param name="ixGuid">[in] The index value from a GUID table column.</param>
        /// <param name="pNext">[out] A pointer to the index of the next GUID value.</param>
        /// <remarks>
        /// We do not recommend the use of this method, because it does not return consistent results. For information about
        /// the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata
        /// Definition and Semantics". The documentation is available online; see ECMA C# and Common Language Infrastructure
        /// Standards and Standard ECMA-335 - Common Language Infrastructure (CLI).
        /// </remarks>
        public HRESULT TryGetNextGuid(uint ixGuid, out uint pNext)
        {
            /*HRESULT GetNextGuid(uint ixGuid, out uint pNext);*/
            return Raw.GetNextGuid(ixGuid, out pNext);
        }

        #endregion
        #region GetNextUserString

        /// <summary>
        /// Gets the index of the row that contains the next hard-coded string in the current table column.
        /// </summary>
        /// <param name="ixUserString">[in] An index value from the current string column.</param>
        /// <returns>[out] A pointer to the row index of the next string in the column.</returns>
        /// <remarks>
        /// We do not recommend the use of this method, because it does not return consistent results. For information about
        /// the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata
        /// Definition and Semantics". The documentation is available online; see ECMA C# and Common Language Infrastructure
        /// Standards and Standard ECMA-335 - Common Language Infrastructure (CLI).
        /// </remarks>
        public uint GetNextUserString(uint ixUserString)
        {
            HRESULT hr;
            uint pNext;

            if ((hr = TryGetNextUserString(ixUserString, out pNext)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pNext;
        }

        /// <summary>
        /// Gets the index of the row that contains the next hard-coded string in the current table column.
        /// </summary>
        /// <param name="ixUserString">[in] An index value from the current string column.</param>
        /// <param name="pNext">[out] A pointer to the row index of the next string in the column.</param>
        /// <remarks>
        /// We do not recommend the use of this method, because it does not return consistent results. For information about
        /// the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata
        /// Definition and Semantics". The documentation is available online; see ECMA C# and Common Language Infrastructure
        /// Standards and Standard ECMA-335 - Common Language Infrastructure (CLI).
        /// </remarks>
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

        /// <summary>
        /// Gets the size and contents of the metadata stored in the specified section.
        /// </summary>
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

        /// <summary>
        /// Gets the size and contents of the metadata stored in the specified section.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
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

        /// <summary>
        /// Gets the name, size, and contents of the metadata stream at the specified index.
        /// </summary>
        /// <param name="ix">[in] The index of the requested metadata stream.</param>
        /// <param name="ppchName">[out] A pointer to the name of the stream.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetMetaDataStreamInfoResult GetMetaDataStreamInfo(uint ix, char[] ppchName)
        {
            HRESULT hr;
            GetMetaDataStreamInfoResult result;

            if ((hr = TryGetMetaDataStreamInfo(ix, ppchName, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the name, size, and contents of the metadata stream at the specified index.
        /// </summary>
        /// <param name="ix">[in] The index of the requested metadata stream.</param>
        /// <param name="ppchName">[out] A pointer to the name of the stream.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
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