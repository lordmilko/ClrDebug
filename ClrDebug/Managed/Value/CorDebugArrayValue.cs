namespace ClrDebug
{
    /// <summary>
    /// A subclass of <see cref="ICorDebugHeapValue"/> that represents a single-dimensional or multi-dimensional array.
    /// </summary>
    /// <remarks>
    /// <see cref="ICorDebugArrayValue"/> supports both single-dimensional and multi-dimensional arrays.
    /// </remarks>
    public class CorDebugArrayValue : CorDebugHeapValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugArrayValue"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugArrayValue(ICorDebugArrayValue raw) : base(raw)
        {
        }

        #region ICorDebugArrayValue

        public new ICorDebugArrayValue Raw => (ICorDebugArrayValue) base.Raw;

        #region ElementType

        /// <summary>
        /// Gets a value that indicates the simple type of the elements in the array.
        /// </summary>
        public CorElementType ElementType
        {
            get
            {
                CorElementType pType;
                TryGetElementType(out pType).ThrowOnNotOK();

                return pType;
            }
        }

        /// <summary>
        /// Gets a value that indicates the simple type of the elements in the array.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the <see cref="CorElementType"/> enumeration that indicates the type.</param>
        public HRESULT TryGetElementType(out CorElementType pType)
        {
            /*HRESULT GetElementType([Out] out CorElementType pType);*/
            return Raw.GetElementType(out pType);
        }

        #endregion
        #region Rank

        /// <summary>
        /// Gets the number of dimensions in the array.
        /// </summary>
        public int Rank
        {
            get
            {
                int pnRank;
                TryGetRank(out pnRank).ThrowOnNotOK();

                return pnRank;
            }
        }

        /// <summary>
        /// Gets the number of dimensions in the array.
        /// </summary>
        /// <param name="pnRank">[out] A pointer to the number of dimensions in this <see cref="ICorDebugArrayValue"/> object.</param>
        public HRESULT TryGetRank(out int pnRank)
        {
            /*HRESULT GetRank([Out] out int pnRank);*/
            return Raw.GetRank(out pnRank);
        }

        #endregion
        #region Count

        /// <summary>
        /// Gets the total number of elements in the array.
        /// </summary>
        public int Count
        {
            get
            {
                int pnCount;
                TryGetCount(out pnCount).ThrowOnNotOK();

                return pnCount;
            }
        }

        /// <summary>
        /// Gets the total number of elements in the array.
        /// </summary>
        /// <param name="pnCount">[out] A pointer to the total number of elements in the array.</param>
        public HRESULT TryGetCount(out int pnCount)
        {
            /*HRESULT GetCount([Out] out int pnCount);*/
            return Raw.GetCount(out pnCount);
        }

        #endregion
        #region GetDimensions

        /// <summary>
        /// Gets the number of elements in each dimension of this array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the dims array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <returns>[out] An array of integers, each of which specifies the number of elements in a dimension in this <see cref="ICorDebugArrayValue"/> object.</returns>
        public int[] GetDimensions(int cdim)
        {
            int[] dims;
            TryGetDimensions(cdim, out dims).ThrowOnNotOK();

            return dims;
        }

        /// <summary>
        /// Gets the number of elements in each dimension of this array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the dims array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="dims">[out] An array of integers, each of which specifies the number of elements in a dimension in this <see cref="ICorDebugArrayValue"/> object.</param>
        public HRESULT TryGetDimensions(int cdim, out int[] dims)
        {
            /*HRESULT GetDimensions([In] int cdim, [MarshalAs(UnmanagedType.LPArray), Out] int[] dims);*/
            dims = null;
            HRESULT hr = Raw.GetDimensions(cdim, dims);

            return hr;
        }

        #endregion
        #region HasBaseIndicies

        /// <summary>
        /// Gets a value that indicates whether any dimensions of this array have a base index of non-zero.
        /// </summary>
        /// <returns>[out] A pointer to a Boolean value that is true if one or more dimensions of this <see cref="ICorDebugArrayValue"/> object have a base index of non-zero; otherwise, the Boolean value is false.</returns>
        public bool HasBaseIndicies()
        {
            bool pbHasBaseIndicies;
            TryHasBaseIndicies(out pbHasBaseIndicies).ThrowOnNotOK();

            return pbHasBaseIndicies;
        }

        /// <summary>
        /// Gets a value that indicates whether any dimensions of this array have a base index of non-zero.
        /// </summary>
        /// <param name="pbHasBaseIndicies">[out] A pointer to a Boolean value that is true if one or more dimensions of this <see cref="ICorDebugArrayValue"/> object have a base index of non-zero; otherwise, the Boolean value is false.</param>
        public HRESULT TryHasBaseIndicies(out bool pbHasBaseIndicies)
        {
            /*HRESULT HasBaseIndicies([Out] out bool pbHasBaseIndicies);*/
            return Raw.HasBaseIndicies(out pbHasBaseIndicies);
        }

        #endregion
        #region GetBaseIndicies

        /// <summary>
        /// Gets the base index of each dimension in the array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the indicies array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <returns>[out] An array of integers, each of which is the base index (that is, the starting index) of a dimension of this <see cref="ICorDebugArrayValue"/> object.</returns>
        public int[] GetBaseIndicies(int cdim)
        {
            int[] indicies;
            TryGetBaseIndicies(cdim, out indicies).ThrowOnNotOK();

            return indicies;
        }

        /// <summary>
        /// Gets the base index of each dimension in the array.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the indicies array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="indicies">[out] An array of integers, each of which is the base index (that is, the starting index) of a dimension of this <see cref="ICorDebugArrayValue"/> object.</param>
        public HRESULT TryGetBaseIndicies(int cdim, out int[] indicies)
        {
            /*HRESULT GetBaseIndicies([In] int cdim, [MarshalAs(UnmanagedType.LPArray), Out] int[] indicies);*/
            indicies = null;
            HRESULT hr = Raw.GetBaseIndicies(cdim, indicies);

            return hr;
        }

        #endregion
        #region GetElement

        /// <summary>
        /// Gets the value of the given array element.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the indices array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="indices">[in] An array of index values, each of which specifies a position within a dimension of the <see cref="ICorDebugArrayValue"/> object.<para/>
        /// This value must not be null.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the specified element.</returns>
        public CorDebugValue GetElement(int cdim, int indices)
        {
            CorDebugValue ppValueResult;
            TryGetElement(cdim, indices, out ppValueResult).ThrowOnNotOK();

            return ppValueResult;
        }

        /// <summary>
        /// Gets the value of the given array element.
        /// </summary>
        /// <param name="cdim">[in] The number of dimensions of this <see cref="ICorDebugArrayValue"/> object. This value is also the size of the indices array because its size is equal to the number of dimensions of the <see cref="ICorDebugArrayValue"/> object.</param>
        /// <param name="indices">[in] An array of index values, each of which specifies a position within a dimension of the <see cref="ICorDebugArrayValue"/> object.<para/>
        /// This value must not be null.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the specified element.</param>
        public HRESULT TryGetElement(int cdim, int indices, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetElement(
            [In] int cdim,
            [MarshalAs(UnmanagedType.LPArray), In] int indices,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetElement(cdim, indices, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region GetElementAtPosition

        /// <summary>
        /// Gets the element at the given position, treating the array as a zero-based, single-dimensional array.
        /// </summary>
        /// <param name="nPosition">[in] The position of the element to be retrieved.</param>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the element.</returns>
        /// <remarks>
        /// The layout of a multi-dimension array follows the C++ style of array layout.
        /// </remarks>
        public CorDebugValue GetElementAtPosition(int nPosition)
        {
            CorDebugValue ppValueResult;
            TryGetElementAtPosition(nPosition, out ppValueResult).ThrowOnNotOK();

            return ppValueResult;
        }

        /// <summary>
        /// Gets the element at the given position, treating the array as a zero-based, single-dimensional array.
        /// </summary>
        /// <param name="nPosition">[in] The position of the element to be retrieved.</param>
        /// <param name="ppValueResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> object that represents the value of the element.</param>
        /// <remarks>
        /// The layout of a multi-dimension array follows the C++ style of array layout.
        /// </remarks>
        public HRESULT TryGetElementAtPosition(int nPosition, out CorDebugValue ppValueResult)
        {
            /*HRESULT GetElementAtPosition([In] int nPosition, [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.GetElementAtPosition(nPosition, out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #endregion
    }
}