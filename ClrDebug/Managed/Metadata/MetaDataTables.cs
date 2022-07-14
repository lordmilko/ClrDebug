using System;
using System.Diagnostics;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for the storage and retrieval of metadata information in tables.
    /// </summary>
    public class MetaDataTables : ComObject<IMetaDataTables>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaDataTables"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public MetaDataTables(IMetaDataTables raw) : base(raw)
        {
        }

        #region IMetaDataTables
        #region StringHeapSize

        /// <summary>
        /// Gets the size, in bytes, of the string heap.
        /// </summary>
        public int StringHeapSize
        {
            get
            {
                int pcbStrings;
                TryGetStringHeapSize(out pcbStrings).ThrowOnNotOK();

                return pcbStrings;
            }
        }

        /// <summary>
        /// Gets the size, in bytes, of the string heap.
        /// </summary>
        /// <param name="pcbStrings">[out] A pointer to the size, in bytes, of the string heap.</param>
        public HRESULT TryGetStringHeapSize(out int pcbStrings)
        {
            /*HRESULT GetStringHeapSize([Out] out int pcbStrings);*/
            return Raw.GetStringHeapSize(out pcbStrings);
        }

        #endregion
        #region BlobHeapSize

        /// <summary>
        /// Gets the size, in bytes, of the binary large object (BLOB) heap.
        /// </summary>
        public int BlobHeapSize
        {
            get
            {
                int pcbBlobs;
                TryGetBlobHeapSize(out pcbBlobs).ThrowOnNotOK();

                return pcbBlobs;
            }
        }

        /// <summary>
        /// Gets the size, in bytes, of the binary large object (BLOB) heap.
        /// </summary>
        /// <param name="pcbBlobs">[out] A pointer to the size, in bytes, of the BLOB heap.</param>
        public HRESULT TryGetBlobHeapSize(out int pcbBlobs)
        {
            /*HRESULT GetBlobHeapSize([Out] out int pcbBlobs);*/
            return Raw.GetBlobHeapSize(out pcbBlobs);
        }

        #endregion
        #region GuidHeapSize

        /// <summary>
        /// Gets the size, in bytes, of the GUID heap.
        /// </summary>
        public int GuidHeapSize
        {
            get
            {
                int pcbGuids;
                TryGetGuidHeapSize(out pcbGuids).ThrowOnNotOK();

                return pcbGuids;
            }
        }

        /// <summary>
        /// Gets the size, in bytes, of the GUID heap.
        /// </summary>
        /// <param name="pcbGuids">[out] A pointer to the size, in bytes, of the GUID heap.</param>
        public HRESULT TryGetGuidHeapSize(out int pcbGuids)
        {
            /*HRESULT GetGuidHeapSize([Out] out int pcbGuids);*/
            return Raw.GetGuidHeapSize(out pcbGuids);
        }

        #endregion
        #region UserStringHeapSize

        /// <summary>
        /// Gets the size, in bytes, of the user string heap.
        /// </summary>
        public int UserStringHeapSize
        {
            get
            {
                int pcbBlobs;
                TryGetUserStringHeapSize(out pcbBlobs).ThrowOnNotOK();

                return pcbBlobs;
            }
        }

        /// <summary>
        /// Gets the size, in bytes, of the user string heap.
        /// </summary>
        /// <param name="pcbBlobs">[out] A pointer to the size, in bytes, of the user string heap.</param>
        public HRESULT TryGetUserStringHeapSize(out int pcbBlobs)
        {
            /*HRESULT GetUserStringHeapSize([Out] out int pcbBlobs);*/
            return Raw.GetUserStringHeapSize(out pcbBlobs);
        }

        #endregion
        #region NumTables

        /// <summary>
        /// Gets the number of tables in the scope of the current <see cref="IMetaDataTables"/> instance.
        /// </summary>
        public int NumTables
        {
            get
            {
                int pcTables;
                TryGetNumTables(out pcTables).ThrowOnNotOK();

                return pcTables;
            }
        }

        /// <summary>
        /// Gets the number of tables in the scope of the current <see cref="IMetaDataTables"/> instance.
        /// </summary>
        /// <param name="pcTables">[out] A pointer to the number of tables in the current instance scope.</param>
        public HRESULT TryGetNumTables(out int pcTables)
        {
            /*HRESULT GetNumTables([Out] out int pcTables);*/
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
        public int GetTableIndex(int token)
        {
            int pixTbl;
            TryGetTableIndex(token, out pixTbl).ThrowOnNotOK();

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
        public HRESULT TryGetTableIndex(int token, out int pixTbl)
        {
            /*HRESULT GetTableIndex([In] int token, [Out] out int pixTbl);*/
            return Raw.GetTableIndex(token, out pixTbl);
        }

        #endregion
        #region GetTableInfo

        /// <summary>
        /// Gets the name, row size, number of rows, number of columns, and key column index of the specified table.
        /// </summary>
        /// <param name="ixTbl">[in] The identifier of the table whose properties to return.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetTableInfoResult GetTableInfo(int ixTbl)
        {
            GetTableInfoResult result;
            TryGetTableInfo(ixTbl, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the name, row size, number of rows, number of columns, and key column index of the specified table.
        /// </summary>
        /// <param name="ixTbl">[in] The identifier of the table whose properties to return.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetTableInfo(int ixTbl, out GetTableInfoResult result)
        {
            /*HRESULT GetTableInfo([In] int ixTbl, [Out] out int pcbRow, [Out] out int pcRows, [Out] out int pcCols, [Out] out int piKey, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder ppName);*/
            int pcbRow;
            int pcRows;
            int pcCols;
            int piKey;
            StringBuilder ppName = null;
            HRESULT hr = Raw.GetTableInfo(ixTbl, out pcbRow, out pcRows, out pcCols, out piKey, ppName);

            if (hr == HRESULT.S_OK)
                result = new GetTableInfoResult(pcbRow, pcRows, pcCols, piKey, ppName.ToString());
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
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The returned column type falls within a range of values: Values that are stored in the heap (that is, IsHeapType
        /// == true) can be read using:
        /// </remarks>
        public GetColumnInfoResult GetColumnInfo(int ixTbl, int ixCol)
        {
            GetColumnInfoResult result;
            TryGetColumnInfo(ixTbl, ixCol, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets data about the specified column in the specified table.
        /// </summary>
        /// <param name="ixTbl">[in] The index of the desired table.</param>
        /// <param name="ixCol">[in] The index of the desired column.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The returned column type falls within a range of values: Values that are stored in the heap (that is, IsHeapType
        /// == true) can be read using:
        /// </remarks>
        public HRESULT TryGetColumnInfo(int ixTbl, int ixCol, out GetColumnInfoResult result)
        {
            /*HRESULT GetColumnInfo([In] int ixTbl, [In] int ixCol, [Out] out int poCol, [Out] out int pcbCol, [Out] out int pType, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder ppName);*/
            int poCol;
            int pcbCol;
            int pType;
            StringBuilder ppName = null;
            HRESULT hr = Raw.GetColumnInfo(ixTbl, ixCol, out poCol, out pcbCol, out pType, ppName);

            if (hr == HRESULT.S_OK)
                result = new GetColumnInfoResult(poCol, pcbCol, pType, ppName.ToString());
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
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetCodedTokenInfoResult GetCodedTokenInfo(int ixCdTkn)
        {
            GetCodedTokenInfoResult result;
            TryGetCodedTokenInfo(ixCdTkn, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets a pointer to an array of tokens associated with the specified row index.
        /// </summary>
        /// <param name="ixCdTkn">[in] The kind of coded token to return.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetCodedTokenInfo(int ixCdTkn, out GetCodedTokenInfoResult result)
        {
            /*HRESULT GetCodedTokenInfo([In] int ixCdTkn, [Out] out int pcTokens, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] out int[] ppTokens, [Out, MarshalAs(UnmanagedType.LPWStr)] out StringBuilder ppName);*/
            int pcTokens;
            int[] ppTokens = new int[ixCdTkn];
            StringBuilder ppName = null;
            HRESULT hr = Raw.GetCodedTokenInfo(ixCdTkn, out pcTokens, out ppTokens, out ppName);

            if (hr == HRESULT.S_OK)
                result = new GetCodedTokenInfoResult(pcTokens, ppTokens, ppName.ToString());
            else
                result = default(GetCodedTokenInfoResult);

            return hr;
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
        public IntPtr GetRow(int ixTbl, int rid)
        {
            IntPtr ppRow;
            TryGetRow(ixTbl, rid, out ppRow).ThrowOnNotOK();

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
        public HRESULT TryGetRow(int ixTbl, int rid, out IntPtr ppRow)
        {
            /*HRESULT GetRow([In] int ixTbl, [In] int rid, [Out] out IntPtr ppRow);*/
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
        public int GetColumn(int ixTbl, int ixCol, int rid)
        {
            int pVal;
            TryGetColumn(ixTbl, ixCol, rid, out pVal).ThrowOnNotOK();

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
        public HRESULT TryGetColumn(int ixTbl, int ixCol, int rid, out int pVal)
        {
            /*HRESULT GetColumn([In] int ixTbl, [In] int ixCol, [In] int rid, [Out] out int pVal);*/
            return Raw.GetColumn(ixTbl, ixCol, rid, out pVal);
        }

        #endregion
        #region GetString

        /// <summary>
        /// Gets the string at the specified index from the table column in the current reference scope.
        /// </summary>
        /// <param name="ixString">[in] The index at which to start to search for the next value.</param>
        /// <returns>[out] A pointer to a pointer to the returned string value.</returns>
        public string GetString(int ixString)
        {
            string ppStringResult;
            TryGetString(ixString, out ppStringResult).ThrowOnNotOK();

            return ppStringResult;
        }

        /// <summary>
        /// Gets the string at the specified index from the table column in the current reference scope.
        /// </summary>
        /// <param name="ixString">[in] The index at which to start to search for the next value.</param>
        /// <param name="ppStringResult">[out] A pointer to a pointer to the returned string value.</param>
        public HRESULT TryGetString(int ixString, out string ppStringResult)
        {
            /*HRESULT GetString([In] int ixString, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder ppString);*/
            StringBuilder ppString = null;
            HRESULT hr = Raw.GetString(ixString, ppString);

            if (hr == HRESULT.S_OK)
                ppStringResult = ppString.ToString();
            else
                ppStringResult = default(string);

            return hr;
        }

        #endregion
        #region GetBlob

        /// <summary>
        /// Gets a pointer to the binary large object (BLOB) at the specified column index.
        /// </summary>
        /// <param name="ixBlob">[in] The memory address from which to get ppData.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetBlobResult GetBlob(int ixBlob)
        {
            GetBlobResult result;
            TryGetBlob(ixBlob, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets a pointer to the binary large object (BLOB) at the specified column index.
        /// </summary>
        /// <param name="ixBlob">[in] The memory address from which to get ppData.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetBlob(int ixBlob, out GetBlobResult result)
        {
            /*HRESULT GetBlob([In] int ixBlob, [Out] out int pcbData, [Out] out IntPtr ppData);*/
            int pcbData;
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
        public Guid GetGuid(int ixGuid)
        {
            Guid ppGUID;
            TryGetGuid(ixGuid, out ppGUID).ThrowOnNotOK();

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
        public HRESULT TryGetGuid(int ixGuid, out Guid ppGUID)
        {
            /*HRESULT GetGuid([In] int ixGuid, [Out] out Guid ppGUID);*/
            return Raw.GetGuid(ixGuid, out ppGUID);
        }

        #endregion
        #region GetUserString

        /// <summary>
        /// Gets the hard-coded string at the specified index in the string column in the current scope.
        /// </summary>
        /// <param name="ixUserString">[in] The index value from which the hard-coded string will be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetUserStringResult GetUserString(int ixUserString)
        {
            GetUserStringResult result;
            TryGetUserString(ixUserString, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the hard-coded string at the specified index in the string column in the current scope.
        /// </summary>
        /// <param name="ixUserString">[in] The index value from which the hard-coded string will be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetUserString(int ixUserString, out GetUserStringResult result)
        {
            /*HRESULT GetUserString([In] int ixUserString, [Out] out int pcbData, [Out] out IntPtr ppData);*/
            int pcbData;
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
        public int GetNextString(int ixString)
        {
            int pNext;
            TryGetNextString(ixString, out pNext).ThrowOnNotOK();

            return pNext;
        }

        /// <summary>
        /// Gets the index of the next string in the current table column.
        /// </summary>
        /// <param name="ixString">[in] The index value from a string table column.</param>
        /// <param name="pNext">[out] A pointer to the index of the next string in the column.</param>
        public HRESULT TryGetNextString(int ixString, out int pNext)
        {
            /*HRESULT GetNextString([In] int ixString, [Out] out int pNext);*/
            return Raw.GetNextString(ixString, out pNext);
        }

        #endregion
        #region GetNextBlob

        /// <summary>
        /// Gets the index of the next binary large object (BLOB) in the table.
        /// </summary>
        /// <param name="ixBlob">[in] The index, as returned from a column of BLOBs.</param>
        /// <returns>[out] A pointer to the index of the next BLOB.</returns>
        public int GetNextBlob(int ixBlob)
        {
            int pNext;
            TryGetNextBlob(ixBlob, out pNext).ThrowOnNotOK();

            return pNext;
        }

        /// <summary>
        /// Gets the index of the next binary large object (BLOB) in the table.
        /// </summary>
        /// <param name="ixBlob">[in] The index, as returned from a column of BLOBs.</param>
        /// <param name="pNext">[out] A pointer to the index of the next BLOB.</param>
        public HRESULT TryGetNextBlob(int ixBlob, out int pNext)
        {
            /*HRESULT GetNextBlob([In] int ixBlob, [Out] out int pNext);*/
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
        public int GetNextGuid(int ixGuid)
        {
            int pNext;
            TryGetNextGuid(ixGuid, out pNext).ThrowOnNotOK();

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
        public HRESULT TryGetNextGuid(int ixGuid, out int pNext)
        {
            /*HRESULT GetNextGuid([In] int ixGuid, [Out] out int pNext);*/
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
        public int GetNextUserString(int ixUserString)
        {
            int pNext;
            TryGetNextUserString(ixUserString, out pNext).ThrowOnNotOK();

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
        public HRESULT TryGetNextUserString(int ixUserString, out int pNext)
        {
            /*HRESULT GetNextUserString([In] int ixUserString, [Out] out int pNext);*/
            return Raw.GetNextUserString(ixUserString, out pNext);
        }

        #endregion
        #endregion
        #region IMetaDataTables2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IMetaDataTables2 Raw2 => (IMetaDataTables2) Raw;

        #region MetaDataStorage

        /// <summary>
        /// Gets the size and contents of the metadata stored in the specified section.
        /// </summary>
        public GetMetaDataStorageResult MetaDataStorage
        {
            get
            {
                GetMetaDataStorageResult result;
                TryGetMetaDataStorage(out result).ThrowOnNotOK();

                return result;
            }
        }

        /// <summary>
        /// Gets the size and contents of the metadata stored in the specified section.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetMetaDataStorage(out GetMetaDataStorageResult result)
        {
            /*HRESULT GetMetaDataStorage([Out] out IntPtr ppvMd, [Out] out int pcbMd);*/
            IntPtr ppvMd;
            int pcbMd;
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
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetMetaDataStreamInfoResult GetMetaDataStreamInfo(int ix)
        {
            GetMetaDataStreamInfoResult result;
            TryGetMetaDataStreamInfo(ix, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the name, size, and contents of the metadata stream at the specified index.
        /// </summary>
        /// <param name="ix">[in] The index of the requested metadata stream.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetMetaDataStreamInfo(int ix, out GetMetaDataStreamInfoResult result)
        {
            /*HRESULT GetMetaDataStreamInfo([In] int ix, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder ppchName, [Out] out IntPtr ppv, [Out] out int pcb);*/
            StringBuilder ppchName = null;
            IntPtr ppv;
            int pcb;
            HRESULT hr = Raw2.GetMetaDataStreamInfo(ix, ppchName, out ppv, out pcb);

            if (hr == HRESULT.S_OK)
                result = new GetMetaDataStreamInfoResult(ppchName.ToString(), ppv, pcb);
            else
                result = default(GetMetaDataStreamInfoResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
