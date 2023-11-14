using System;
using System.Linq;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Allows you to read the persistent properties of a DIA property set.
    /// </summary>
    /// <remarks>
    /// Each property within a property set is identified by a property identifier (ID), a four-byte ULONG value unique
    /// to that set. The properties exposed through the IDiaPropertyStorage interface correspond to the properties available
    /// in the parent interface. For example, the properties of the IDiaSymbol interface can be accessed by name through
    /// the IDiaPropertyStorage interface (note, however, that even though the property may be accessible, it does not
    /// mean the property is valid for a particular IDiaSymbol object). Obtain this interface by calling the QueryInterface
    /// method on another interface. The following interfaces can be queried for the IDiaPropertyStorage interface:
    /// </remarks>
    public class DiaPropertyStorage : ComObject<IDiaPropertyStorage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaPropertyStorage"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaPropertyStorage(IDiaPropertyStorage raw) : base(raw)
        {
        }

        #region IDiaPropertyStorage
        #region ReadMultiple

        /// <summary>
        /// Reads specified properties from the current property set.
        /// </summary>
        /// <param name="cpspec">[in] Count of properties specified in the rgpspec array. If zero, the method returns no properties but does return S_OK as a success code.</param>
        /// <param name="rgpspec">[in] An array of properties to be read. Properties can be specified either by a property ID or by an optional string name.<para/>
        /// It is not necessary to specify properties in any particular order in the array. The array can contain duplicate properties, resulting in duplicate property values on return for simple properties.<para/>
        /// Non-simple properties should return access denied on an attempt to open them a second time. The array can contain a mixture of property IDs and string IDs.<para/>
        /// This array must have at least cpspec number of property values.</param>
        /// <returns>[in, out] An array of PROPVARIANT structures (in the Microsoft.VisualStudio.OLE.Interop namespace) to be filled in with values for each property.<para/>
        /// The array must be at least cpspec elements in size. The caller does not need to initialize the values in the array.</returns>
        /// <remarks>
        /// If a property was not found, the corresponding entry in the rgvar array contains a VARIANT with the type of VT_EMPTY.
        /// </remarks>
        public PROPVARIANT ReadMultiple(int cpspec, PROPSPEC[] rgpspec)
        {
            PROPVARIANT rgvar;
            TryReadMultiple(cpspec, rgpspec, out rgvar).ThrowOnNotOK();

            return rgvar;
        }

        /// <summary>
        /// Reads specified properties from the current property set.
        /// </summary>
        /// <param name="cpspec">[in] Count of properties specified in the rgpspec array. If zero, the method returns no properties but does return S_OK as a success code.</param>
        /// <param name="rgpspec">[in] An array of properties to be read. Properties can be specified either by a property ID or by an optional string name.<para/>
        /// It is not necessary to specify properties in any particular order in the array. The array can contain duplicate properties, resulting in duplicate property values on return for simple properties.<para/>
        /// Non-simple properties should return access denied on an attempt to open them a second time. The array can contain a mixture of property IDs and string IDs.<para/>
        /// This array must have at least cpspec number of property values.</param>
        /// <param name="rgvar">[in, out] An array of PROPVARIANT structures (in the Microsoft.VisualStudio.OLE.Interop namespace) to be filled in with values for each property.<para/>
        /// The array must be at least cpspec elements in size. The caller does not need to initialize the values in the array.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if one or more of the properties was not found. Otherwise returns an error code.</returns>
        /// <remarks>
        /// If a property was not found, the corresponding entry in the rgvar array contains a VARIANT with the type of VT_EMPTY.
        /// </remarks>
        public HRESULT TryReadMultiple(int cpspec, PROPSPEC[] rgpspec, out PROPVARIANT rgvar)
        {
            /*HRESULT ReadMultiple(
            [In] int cpspec,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPSPEC[] rgpspec,
            [Out] out PROPVARIANT rgvar);*/
            return Raw.ReadMultiple(cpspec, rgpspec, out rgvar);
        }

        #endregion
        #region ReadPropertyNames

        /// <summary>
        /// Retrieves corresponding string names for given property identifiers.
        /// </summary>
        /// <param name="cpropid">[in] Number of property ids in rgpropid.</param>
        /// <param name="rgpropid">[in] Array of property ids for which to get the names (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <returns>[in, out] Array of property names for the specified property ids. The array must be pre-allocated to hold the requested number of property names and must be able to hold at least cpropid``BSTR strings.</returns>
        /// <remarks>
        /// The returned property names must be freed (by calling the SysFreeString function) when they are no longer needed.
        /// </remarks>
        public string[] ReadPropertyNames(int cpropid, int[] rgpropid)
        {
            string[] rglpwstrName;
            TryReadPropertyNames(cpropid, rgpropid, out rglpwstrName).ThrowOnNotOK();

            return rglpwstrName;
        }

        /// <summary>
        /// Retrieves corresponding string names for given property identifiers.
        /// </summary>
        /// <param name="cpropid">[in] Number of property ids in rgpropid.</param>
        /// <param name="rgpropid">[in] Array of property ids for which to get the names (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <param name="rglpwstrName">[in, out] Array of property names for the specified property ids. The array must be pre-allocated to hold the requested number of property names and must be able to hold at least cpropid``BSTR strings.</param>
        /// <returns>If successful, returns S_OK; otherwise returns an error code.</returns>
        /// <remarks>
        /// The returned property names must be freed (by calling the SysFreeString function) when they are no longer needed.
        /// </remarks>
        public HRESULT TryReadPropertyNames(int cpropid, int[] rgpropid, out string[] rglpwstrName)
        {
            /*HRESULT ReadPropertyNames(
            [In] int cpropid,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] rgpropid,
            [In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.BStr, SizeParamIndex = 0)] string[] rglpwstrName);*/
            rglpwstrName = new string[cpropid];
            HRESULT hr = Raw.ReadPropertyNames(cpropid, rgpropid, rglpwstrName);

            return hr;
        }

        #endregion
        #region Enum

        /// <summary>
        /// Gets an enumerator for properties within this set.
        /// </summary>
        public STATPROPSTG[] Items => Enum().ToArray();

        /// <summary>
        /// Gets an enumerator for properties within this set.
        /// </summary>
        /// <returns>[out] Returns an IEnumSTATPROPSTG object (in the Microsoft.VisualStudio.OLE.Interop namespace) representing an enumeration of properties.</returns>
        public EnumSTATPROPSTG Enum()
        {
            EnumSTATPROPSTG ppenumResult;
            TryEnum(out ppenumResult).ThrowOnNotOK();

            return ppenumResult;
        }

        /// <summary>
        /// Gets an enumerator for properties within this set.
        /// </summary>
        /// <param name="ppenumResult">[out] Returns an IEnumSTATPROPSTG object (in the Microsoft.VisualStudio.OLE.Interop namespace) representing an enumeration of properties.</param>
        /// <returns>If successful, returns S_OK; otherwise returns an error code.</returns>
        public HRESULT TryEnum(out EnumSTATPROPSTG ppenumResult)
        {
            /*HRESULT Enum(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumSTATPROPSTG ppenum);*/
            IEnumSTATPROPSTG ppenum;
            HRESULT hr = Raw.Enum(out ppenum);

            if (hr == HRESULT.S_OK)
                ppenumResult = new EnumSTATPROPSTG(ppenum);
            else
                ppenumResult = default(EnumSTATPROPSTG);

            return hr;
        }

        #endregion
        #region ReadDWORD

        /// <summary>
        /// Reads DWORD values in a property set.
        /// </summary>
        /// <param name="id">[in] Identifier of the property to be read (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <returns>[out] Returns the property value.</returns>
        /// <remarks>
        /// A DWORD is defined by Windows as a 32-bit unsigned integer.
        /// </remarks>
        public int ReadDWORD(int id)
        {
            int pValue;
            TryReadDWORD(id, out pValue).ThrowOnNotOK();

            return pValue;
        }

        /// <summary>
        /// Reads DWORD values in a property set.
        /// </summary>
        /// <param name="id">[in] Identifier of the property to be read (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <param name="pValue">[out] Returns the property value.</param>
        /// <returns>If successful, returns S_OK; otherwise returns an error code. Returns E_INVALIDARG if the property is not of type DWORD.</returns>
        /// <remarks>
        /// A DWORD is defined by Windows as a 32-bit unsigned integer.
        /// </remarks>
        public HRESULT TryReadDWORD(int id, out int pValue)
        {
            /*HRESULT ReadDWORD(
            [In] int id,
            [Out] out int pValue);*/
            return Raw.ReadDWORD(id, out pValue);
        }

        #endregion
        #region ReadLONG

        /// <summary>
        /// Reads LONG values in a property set.
        /// </summary>
        /// <param name="id">[in] Identifier of the property to be read (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <returns>[out] Returns the property value.</returns>
        /// <remarks>
        /// A LONG is defined by Windows as a 32-bit signed integer.
        /// </remarks>
        public int ReadLONG(int id)
        {
            int pValue;
            TryReadLONG(id, out pValue).ThrowOnNotOK();

            return pValue;
        }

        /// <summary>
        /// Reads LONG values in a property set.
        /// </summary>
        /// <param name="id">[in] Identifier of the property to be read (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <param name="pValue">[out] Returns the property value.</param>
        /// <returns>If successful, returns S_OK; otherwise returns an error code. Returns E_INVALIDARG if the property is not of type LONG.</returns>
        /// <remarks>
        /// A LONG is defined by Windows as a 32-bit signed integer.
        /// </remarks>
        public HRESULT TryReadLONG(int id, out int pValue)
        {
            /*HRESULT ReadLONG(
            [In] int id,
            [Out] out int pValue);*/
            return Raw.ReadLONG(id, out pValue);
        }

        #endregion
        #region ReadBOOL

        /// <summary>
        /// Reads BOOL values in a property set.
        /// </summary>
        /// <param name="id">[in] Identifier of the property to be read (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <returns>[out] Returns the property value.</returns>
        /// <remarks>
        /// For consistent results, interpret the BOOL value so that nonzero values are TRUE and zero is FALSE.
        /// </remarks>
        public bool ReadBOOL(int id)
        {
            bool pValue;
            TryReadBOOL(id, out pValue).ThrowOnNotOK();

            return pValue;
        }

        /// <summary>
        /// Reads BOOL values in a property set.
        /// </summary>
        /// <param name="id">[in] Identifier of the property to be read (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <param name="pValue">[out] Returns the property value.</param>
        /// <returns>If successful, returns S_OK; otherwise returns an error code. Returns E_INVALIDARG if the property is not of type BOOL.</returns>
        /// <remarks>
        /// For consistent results, interpret the BOOL value so that nonzero values are TRUE and zero is FALSE.
        /// </remarks>
        public HRESULT TryReadBOOL(int id, out bool pValue)
        {
            /*HRESULT ReadBOOL(
            [In] int id,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pValue);*/
            return Raw.ReadBOOL(id, out pValue);
        }

        #endregion
        #region ReadULONGLONG

        /// <summary>
        /// Reads ULONGLONG values in a property set.
        /// </summary>
        /// <param name="id">[in] Identifier of the property to be read (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <returns>[out] Returns the property value.</returns>
        /// <remarks>
        /// A ULONGLONG is defined by Windows as a 64-bit unsigned integer.
        /// </remarks>
        public long ReadULONGLONG(int id)
        {
            long pValue;
            TryReadULONGLONG(id, out pValue).ThrowOnNotOK();

            return pValue;
        }

        /// <summary>
        /// Reads ULONGLONG values in a property set.
        /// </summary>
        /// <param name="id">[in] Identifier of the property to be read (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <param name="pValue">[out] Returns the property value.</param>
        /// <returns>If successful, returns S_OK; otherwise returns an error code. Returns E_INVALIDARG if the property is not of type ULONGLONG.</returns>
        /// <remarks>
        /// A ULONGLONG is defined by Windows as a 64-bit unsigned integer.
        /// </remarks>
        public HRESULT TryReadULONGLONG(int id, out long pValue)
        {
            /*HRESULT ReadULONGLONG(
            [In] int id,
            [Out] out long pValue);*/
            return Raw.ReadULONGLONG(id, out pValue);
        }

        #endregion
        #region ReadBSTR

        /// <summary>
        /// Reads BSTR values in a property set.
        /// </summary>
        /// <param name="id">[in] Identifier of the property to be read (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <returns>[out] Returns the property value.</returns>
        /// <remarks>
        /// A BSTR is defined by Windows as a zero-terminated wide character string.
        /// </remarks>
        public string ReadBSTR(int id)
        {
            string pValue;
            TryReadBSTR(id, out pValue).ThrowOnNotOK();

            return pValue;
        }

        /// <summary>
        /// Reads BSTR values in a property set.
        /// </summary>
        /// <param name="id">[in] Identifier of the property to be read (PROPID is defined in WTypes.h as a ULONG).</param>
        /// <param name="pValue">[out] Returns the property value.</param>
        /// <returns>If successful, returns S_OK; otherwise returns an error code. Returns E_INVALIDARG if the property is not of type BSTR.</returns>
        /// <remarks>
        /// A BSTR is defined by Windows as a zero-terminated wide character string.
        /// </remarks>
        public HRESULT TryReadBSTR(int id, out string pValue)
        {
            /*HRESULT ReadBSTR(
            [In] int id,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pValue);*/
            return Raw.ReadBSTR(id, out pValue);
        }

        #endregion
        #endregion
    }
}
