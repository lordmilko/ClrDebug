using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods for the storage and retrieval of metadata information in tables.
    /// </summary>
    [Guid("D8F579AB-402D-4b8e-82D9-5D63B1065C68")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IMetaDataTables
    {
        /// <summary>
        /// Gets the size, in bytes, of the string heap.
        /// </summary>
        /// <param name="pcbStrings">[out] A pointer to the size, in bytes, of the string heap.</param>
        [PreserveSig]
        HRESULT GetStringHeapSize([Out] out int pcbStrings);

        /// <summary>
        /// Gets the size, in bytes, of the binary large object (BLOB) heap.
        /// </summary>
        /// <param name="pcbBlobs">[out] A pointer to the size, in bytes, of the BLOB heap.</param>
        [PreserveSig]
        HRESULT GetBlobHeapSize([Out] out int pcbBlobs);

        /// <summary>
        /// Gets the size, in bytes, of the GUID heap.
        /// </summary>
        /// <param name="pcbGuids">[out] A pointer to the size, in bytes, of the GUID heap.</param>
        [PreserveSig]
        HRESULT GetGuidHeapSize([Out] out int pcbGuids);

        /// <summary>
        /// Gets the size, in bytes, of the user string heap.
        /// </summary>
        /// <param name="pcbBlobs">[out] A pointer to the size, in bytes, of the user string heap.</param>
        [PreserveSig]
        HRESULT GetUserStringHeapSize([Out] out int pcbBlobs);

        /// <summary>
        /// Gets the number of tables in the scope of the current <see cref="IMetaDataTables"/> instance.
        /// </summary>
        /// <param name="pcTables">[out] A pointer to the number of tables in the current instance scope.</param>
        [PreserveSig]
        HRESULT GetNumTables([Out] out int pcTables);

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
        [PreserveSig]
        HRESULT GetTableIndex([In] int token, [Out] out int pixTbl);

        /// <summary>
        /// Gets the name, row size, number of rows, number of columns, and key column index of the specified table.
        /// </summary>
        /// <param name="ixTbl">[in] The identifier of the table whose properties to return.</param>
        /// <param name="pcbRow">[out] A pointer to the size, in bytes, of a table row.</param>
        /// <param name="pcRows">[out] A pointer to the number of rows in the table.</param>
        /// <param name="pcCols">[out] A pointer to the number of columns in the table.</param>
        /// <param name="piKey">[out] A pointer to the index of the key column, or -1 if the table has no key column.</param>
        /// <param name="ppName">[out] A pointer to a pointer to the table name.</param>
        [PreserveSig]
        HRESULT GetTableInfo([In] int ixTbl, [Out] out int pcbRow, [Out] out int pcRows, [Out] out int pcCols, [Out] out int piKey, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder ppName);

        /// <summary>
        /// Gets data about the specified column in the specified table.
        /// </summary>
        /// <param name="ixTbl">[in] The index of the desired table.</param>
        /// <param name="ixCol">[in] The index of the desired column.</param>
        /// <param name="poCol">[out] A pointer to the offset of the column in the row.</param>
        /// <param name="pcbCol">[out] A pointer to the size, in bytes, of the column.</param>
        /// <param name="pType">[out] A pointer to the type of the values in the column.</param>
        /// <param name="ppName">[out] A pointer to a pointer to the column name.</param>
        /// <remarks>
        /// The returned column type falls within a range of values: Values that are stored in the heap (that is, IsHeapType
        /// == true) can be read using:
        /// </remarks>
        [PreserveSig]
        HRESULT GetColumnInfo([In] int ixTbl, [In] int ixCol, [Out] out int poCol, [Out] out int pcbCol, [Out] out int pType, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder ppName);

        /// <summary>
        /// Gets a pointer to an array of tokens associated with the specified row index.
        /// </summary>
        /// <param name="ixCdTkn">[in] The kind of coded token to return.</param>
        /// <param name="pcTokens">[out] A pointer to the length of ppTokens.</param>
        /// <param name="ppTokens">[out] A pointer to a pointer to an array that contains the list of returned tokens.</param>
        /// <param name="ppName">[out] A pointer to a pointer to the name of the token at ixCdTkn.</param>
        [PreserveSig]
        HRESULT GetCodedTokenInfo([In] int ixCdTkn, [Out] out int pcTokens, [Out, MarshalAs(UnmanagedType.LPArray)] int[] ppTokens, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder ppName);

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
        [PreserveSig]
        HRESULT GetRow([In] int ixTbl, [In] int rid, [Out] out IntPtr ppRow);

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
        [PreserveSig]
        HRESULT GetColumn([In] int ixTbl, [In] int ixCol, [In] int rid, [Out] out int pVal);

        /// <summary>
        /// Gets the string at the specified index from the table column in the current reference scope.
        /// </summary>
        /// <param name="ixString">[in] The index at which to start to search for the next value.</param>
        /// <param name="ppString">[out] A pointer to a pointer to the returned string value.</param>
        [PreserveSig]
        HRESULT GetString([In] int ixString, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder ppString);

        /// <summary>
        /// Gets a pointer to the binary large object (BLOB) at the specified column index.
        /// </summary>
        /// <param name="ixBlob">[in] The memory address from which to get ppData.</param>
        /// <param name="pcbData">[out] A pointer to the size, in bytes, of ppData.</param>
        /// <param name="ppData">[out] A pointer to a pointer to the binary data retrieved.</param>
        [PreserveSig]
        HRESULT GetBlob([In] int ixBlob, [Out] out int pcbData, [Out] out IntPtr ppData);

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
        [PreserveSig]
        HRESULT GetGuid([In] int ixGuid, [Out] out Guid ppGUID);

        /// <summary>
        /// Gets the hard-coded string at the specified index in the string column in the current scope.
        /// </summary>
        /// <param name="ixUserString">[in] The index value from which the hard-coded string will be retrieved.</param>
        /// <param name="pcbData">[out] A pointer to the size of ppData.</param>
        /// <param name="ppData">[out] A pointer to a pointer to the returned string.</param>
        [PreserveSig]
        HRESULT GetUserString([In] int ixUserString, [Out] out int pcbData, [Out] out IntPtr ppData);

        /// <summary>
        /// Gets the index of the next string in the current table column.
        /// </summary>
        /// <param name="ixString">[in] The index value from a string table column.</param>
        /// <param name="pNext">[out] A pointer to the index of the next string in the column.</param>
        [PreserveSig]
        HRESULT GetNextString([In] int ixString, [Out] out int pNext);

        /// <summary>
        /// Gets the index of the next binary large object (BLOB) in the table.
        /// </summary>
        /// <param name="ixBlob">[in] The index, as returned from a column of BLOBs.</param>
        /// <param name="pNext">[out] A pointer to the index of the next BLOB.</param>
        [PreserveSig]
        HRESULT GetNextBlob([In] int ixBlob, [Out] out int pNext);

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
        [PreserveSig]
        HRESULT GetNextGuid([In] int ixGuid, [Out] out int pNext);

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
        [PreserveSig]
        HRESULT GetNextUserString([In] int ixUserString, [Out] out int pNext);
    }
}