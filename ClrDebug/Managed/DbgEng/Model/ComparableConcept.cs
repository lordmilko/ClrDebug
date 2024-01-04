namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Compares this object to another (of arbitrary type). If the comparison cannot be performed, E_NOT_SET should be returned.
    /// </summary>
    public class ComparableConcept : ComObject<IComparableConcept>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComparableConcept"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ComparableConcept(IComparableConcept raw) : base(raw)
        {
        }

        #region IComparableConcept
        #region CompareObjects

        /// <summary>
        /// Compares this object to another (of arbitrary type). If the comparison cannot be performed, E_NOT_SET should be returned.<para/>
        /// The return value passed in comparison result has the following meaning:
        /// </summary>
        /// <param name="contextObject">The object which is being compared. This should be the same object from which the comparable concept was acquired.</param>
        /// <param name="otherObject">The object to compare to.</param>
        /// <returns>The result of the comparison will be returned here. If the returned value is less than 0, contextObject is less than otherObject.<para/>
        /// If the returned value is zero, they are equal. If the returned value is greater than zero, contextObject is greater than otherObject.</returns>
        public int CompareObjects(IModelObject contextObject, IModelObject otherObject)
        {
            int comparisonResult;
            TryCompareObjects(contextObject, otherObject, out comparisonResult).ThrowDbgEngNotOK();

            return comparisonResult;
        }

        /// <summary>
        /// Compares this object to another (of arbitrary type). If the comparison cannot be performed, E_NOT_SET should be returned.<para/>
        /// The return value passed in comparison result has the following meaning:
        /// </summary>
        /// <param name="contextObject">The object which is being compared. This should be the same object from which the comparable concept was acquired.</param>
        /// <param name="otherObject">The object to compare to.</param>
        /// <param name="comparisonResult">The result of the comparison will be returned here. If the returned value is less than 0, contextObject is less than otherObject.<para/>
        /// If the returned value is zero, they are equal. If the returned value is greater than zero, contextObject is greater than otherObject.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryCompareObjects(IModelObject contextObject, IModelObject otherObject, out int comparisonResult)
        {
            /*HRESULT CompareObjects(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject otherObject,
            [Out] out int comparisonResult);*/
            return Raw.CompareObjects(contextObject, otherObject, out comparisonResult);
        }

        #endregion
        #endregion
    }
}
