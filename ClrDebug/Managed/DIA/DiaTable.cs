using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates a DIA data source table.
    /// </summary>
    /// <remarks>
    /// This interface implements the IEnumUnknown enumeration methods in the Microsoft.VisualStudio.OLE.Interop namespace.
    /// The IEnumUnknown enumeration interface is much more efficient for iterating over the table contents than the IDiaTable
    /// and IDiaTable methods. The interpretation of the IUnknown interface returned from either the IDiaTable::Item method
    /// or the Next method (in the Microsoft.VisualStudio.OLE.Interop namespace) is dependent on the type of table. For
    /// example, if the IDiaTable interface represents a list of injected sources, the IUnknown interface should be queried
    /// for the IDiaInjectedSource interface. Obtain this interface by calling the IDiaEnumTables or IDiaEnumTables methods.
    /// The following interfaces are implemented with the IDiaTable interface (that is, you can query the IDiaTable interface
    /// for one of the following interfaces):
    /// </remarks>
    public class DiaTable : EnumUnknown
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaTable"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaTable(IDiaTable raw) : base(raw)
        {
        }

        #region IDiaTable

        public new IDiaTable Raw => (IDiaTable) base.Raw;

        #region NewEnum

        /// <summary>
        /// Retrieves the <see cref="IEnumVARIANT"/> version of this enumerator.
        /// </summary>
        public EnumVARIANT NewEnum
        {
            get
            {
                EnumVARIANT pRetValResult;
                TryGetNewEnum(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IEnumVARIANT"/> version of this enumerator.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns the IUnknown interface that represents the <see cref="IEnumVARIANT"/> version of this enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetNewEnum(out EnumVARIANT pRetValResult)
        {
            /*HRESULT get__NewEnum(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumVARIANT pRetVal);*/
            IEnumVARIANT pRetVal;
            HRESULT hr = Raw.get__NewEnum(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new EnumVARIANT(pRetVal);
            else
                pRetValResult = default(EnumVARIANT);

            return hr;
        }

        #endregion
        #region Name

        /// <summary>
        /// Retrieves the name of the table.
        /// </summary>
        public string Name
        {
            get
            {
                string pRetVal;
                TryGetName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the name of the table.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the name of the table.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetName(out string pRetVal)
        {
            /*HRESULT get_name(
            [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(DiaStringMarshaller))] out string pRetVal);*/
            return Raw.get_name(out pRetVal);
        }

        #endregion
        #region Count

        /// <summary>
        /// Retrieves the number of items in the table.
        /// </summary>
        public int Count
        {
            get
            {
                int pRetVal;
                TryGetCount(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of items in the table.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of items in the table.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetCount(out int pRetVal)
        {
            /*HRESULT get_count(
            [Out] out int pRetVal);*/
            return Raw.get_count(out pRetVal);
        }

        #endregion
        #region Item

        /// <summary>
        /// Retrieves a reference to the specified entry in the table.
        /// </summary>
        /// <param name="index">[in] The index of the table entry in the range 0 to count-1, where count is returned by the IDiaTablemethod.</param>
        /// <returns>[out] Returns an IUnknown object that represents the specified table entry.</returns>
        /// <remarks>
        /// A table represents a collection of objects. Depending on those objects, the element parameter can be cast to the
        /// appropriate interface. For example, if a table contains IDiaSegment objects, then the element parameter can be
        /// cast to the IDiaSegment interface. It is a more common approach to call the QueryInterface method in the IDiaTable
        /// interface for the appropriate enumerator interface and use the enumerator's specific methods to access the table
        /// contents. See the IDiaEnumInjectedSources interface for an example.
        /// </remarks>
        public object Item(int index)
        {
            object element;
            TryItem(index, out element).ThrowOnNotOK();

            return element;
        }

        /// <summary>
        /// Retrieves a reference to the specified entry in the table.
        /// </summary>
        /// <param name="index">[in] The index of the table entry in the range 0 to count-1, where count is returned by the IDiaTablemethod.</param>
        /// <param name="element">[out] Returns an IUnknown object that represents the specified table entry.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// A table represents a collection of objects. Depending on those objects, the element parameter can be cast to the
        /// appropriate interface. For example, if a table contains IDiaSegment objects, then the element parameter can be
        /// cast to the IDiaSegment interface. It is a more common approach to call the QueryInterface method in the IDiaTable
        /// interface for the appropriate enumerator interface and use the enumerator's specific methods to access the table
        /// contents. See the IDiaEnumInjectedSources interface for an example.
        /// </remarks>
        public HRESULT TryItem(int index, out object element)
        {
            /*HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out object element);*/
            return Raw.Item(index, out element);
        }

        #endregion
        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
