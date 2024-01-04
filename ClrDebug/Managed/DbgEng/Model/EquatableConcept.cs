namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Supports the ability to compare this object to another (of arbitrary type) for equality.
    /// </summary>
    public class EquatableConcept : ComObject<IEquatableConcept>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EquatableConcept"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public EquatableConcept(IEquatableConcept raw) : base(raw)
        {
        }

        #region IEquatableConcept
        #region AreObjectsEqual

        /// <summary>
        /// Compares this object to another (of arbitrary type) for equality. If the comparison cannot be performed, E_NOT_SET should be returned.<see cref="IEquatableConcept"/> is typically implemented by the object creators.<para/>
        /// To compare objects consider using <see cref="IModelObject"/>::IsEqualTo or <see cref="IModelObject"/>::Compare.
        /// </summary>
        /// <param name="contextObject">The object being compared.</param>
        /// <param name="otherObject">The other object (of arbitrary type) that contextObject is being compared to.</param>
        /// <returns>Returned Boolean indicating if the two objects are equal.</returns>
        /// <remarks>
        /// Generally speaking, you will implement (but not necessarily consume) <see cref="IEquatableConcept"/>. It can be
        /// easier to call <see cref="IModelObject"/>::IsEqualTo or <see cref="IModelObject"/>::Compare and let those methods
        /// manage the concept fetch.
        /// </remarks>
        public bool AreObjectsEqual(IModelObject contextObject, IModelObject otherObject)
        {
            bool isEqual;
            TryAreObjectsEqual(contextObject, otherObject, out isEqual).ThrowDbgEngNotOK();

            return isEqual;
        }

        /// <summary>
        /// Compares this object to another (of arbitrary type) for equality. If the comparison cannot be performed, E_NOT_SET should be returned.<see cref="IEquatableConcept"/> is typically implemented by the object creators.<para/>
        /// To compare objects consider using <see cref="IModelObject"/>::IsEqualTo or <see cref="IModelObject"/>::Compare.
        /// </summary>
        /// <param name="contextObject">The object being compared.</param>
        /// <param name="otherObject">The other object (of arbitrary type) that contextObject is being compared to.</param>
        /// <param name="isEqual">Returned Boolean indicating if the two objects are equal.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        /// <remarks>
        /// Generally speaking, you will implement (but not necessarily consume) <see cref="IEquatableConcept"/>. It can be
        /// easier to call <see cref="IModelObject"/>::IsEqualTo or <see cref="IModelObject"/>::Compare and let those methods
        /// manage the concept fetch.
        /// </remarks>
        public HRESULT TryAreObjectsEqual(IModelObject contextObject, IModelObject otherObject, out bool isEqual)
        {
            /*HRESULT AreObjectsEqual(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject otherObject,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isEqual);*/
            return Raw.AreObjectsEqual(contextObject, otherObject, out isEqual);
        }

        #endregion
        #endregion
    }
}
