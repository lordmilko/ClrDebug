using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that manage a value that is a reference to an object. (That is, this interface provides methods that manage a pointer.) This interface implements "ICorDebugValue".
    /// </summary>
    /// <remarks>
    /// The common language runtime (CLR) may do a garbage collection on objects when the debugged process is continued.
    /// The garbage collection may move objects around in memory. An <see cref="ICorDebugReferenceValue"/> will either cooperate with
    /// the garbage collection so that its information is updated after the garbage collection, or it will be invalidated
    /// implicitly before the garbage collection. The <see cref="ICorDebugReferenceValue"/> object may be implicitly invalidated after
    /// the debugged process has been continued. The derived "ICorDebugHandleValue" is not invalidated until it is explicitly
    /// released or exposed.
    /// </remarks>
    public abstract class CorDebugReferenceValue : CorDebugValue
    {
        public static CorDebugReferenceValue New(ICorDebugReferenceValue value)
        {
            if (value is ICorDebugHandleValue)
                return new CorDebugHandleValue((ICorDebugHandleValue) value);

            throw new NotImplementedException("Encountered an ICorDebugReferenceValue' interface of an unknown type. Cannot create wrapper type.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugReferenceValue"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected CorDebugReferenceValue(ICorDebugReferenceValue raw) : base(raw)
        {
        }

        #region ICorDebugReferenceValue

        public new ICorDebugReferenceValue Raw => (ICorDebugReferenceValue) base.Raw;

        #region IsNull

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugReferenceValue"/> is a null value, in which case the <see cref="ICorDebugReferenceValue"/> does not point to an object.
        /// </summary>
        public bool IsNull
        {
            get
            {
                bool pbNullResult;
                TryIsNull(out pbNullResult).ThrowOnNotOK();

                return pbNullResult;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this <see cref="ICorDebugReferenceValue"/> is a null value, in which case the <see cref="ICorDebugReferenceValue"/> does not point to an object.
        /// </summary>
        /// <param name="pbNullResult">[out] A pointer to a Boolean value that is true if this <see cref="ICorDebugReferenceValue"/> object is null; otherwise, pbNull is false.</param>
        public HRESULT TryIsNull(out bool pbNullResult)
        {
            /*HRESULT IsNull([Out] out int pbNull);*/
            int pbNull;
            HRESULT hr = Raw.IsNull(out pbNull);

            if (hr == HRESULT.S_OK)
                pbNullResult = pbNull == 1;
            else
                pbNullResult = default(bool);

            return hr;
        }

        #endregion
        #region Value

        /// <summary>
        /// Gets or sets the current memory address of the referenced object.
        /// </summary>
        public CORDB_ADDRESS Value
        {
            get
            {
                CORDB_ADDRESS pValue;
                TryGetValue(out pValue).ThrowOnNotOK();

                return pValue;
            }
            set
            {
                TrySetValue(value).ThrowOnNotOK();
            }
        }

        /// <summary>
        /// Gets the current memory address of the referenced object.
        /// </summary>
        /// <param name="pValue">[out] A pointer to a <see cref="CORDB_ADDRESS"/> value that specifies the address of the object to which this <see cref="ICorDebugReferenceValue"/> object points.</param>
        public HRESULT TryGetValue(out CORDB_ADDRESS pValue)
        {
            /*HRESULT GetValue([Out] out CORDB_ADDRESS pValue);*/
            return Raw.GetValue(out pValue);
        }

        /// <summary>
        /// Sets the specified memory address. That is, this method sets this <see cref="ICorDebugReferenceValue"/> to point to an object.
        /// </summary>
        /// <param name="value">[in] A <see cref="CORDB_ADDRESS"/> value that specifies the address of the object to which this <see cref="ICorDebugReferenceValue"/> points.</param>
        public HRESULT TrySetValue(CORDB_ADDRESS value)
        {
            /*HRESULT SetValue([In] CORDB_ADDRESS value);*/
            return Raw.SetValue(value);
        }

        #endregion
        #region Dereference

        /// <summary>
        /// Gets the object that is referenced.
        /// </summary>
        /// <returns>[out] A pointer to the address of an <see cref="ICorDebugValue"/> that represents the object to which this <see cref="ICorDebugReferenceValue"/> object points.</returns>
        /// <remarks>
        /// The <see cref="ICorDebugValue"/> object is valid only while its reference has not yet been disabled.
        /// </remarks>
        public CorDebugValue Dereference()
        {
            CorDebugValue ppValueResult;
            TryDereference(out ppValueResult).ThrowOnNotOK();

            return ppValueResult;
        }

        /// <summary>
        /// Gets the object that is referenced.
        /// </summary>
        /// <param name="ppValueResult">[out] A pointer to the address of an <see cref="ICorDebugValue"/> that represents the object to which this <see cref="ICorDebugReferenceValue"/> object points.</param>
        /// <remarks>
        /// The <see cref="ICorDebugValue"/> object is valid only while its reference has not yet been disabled.
        /// </remarks>
        public HRESULT TryDereference(out CorDebugValue ppValueResult)
        {
            /*HRESULT Dereference([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.Dereference(out ppValue);

            if (hr == HRESULT.S_OK)
                ppValueResult = CorDebugValue.New(ppValue);
            else
                ppValueResult = default(CorDebugValue);

            return hr;
        }

        #endregion
        #region DereferenceStrong

        /// <summary>
        /// DereferenceStrong is not implemented. Do not call this method.
        /// </summary>
        public CorDebugValue DereferenceStrong()
        {
            CorDebugValue ppValueResult;
            TryDereferenceStrong(out ppValueResult).ThrowOnNotOK();

            return ppValueResult;
        }

        /// <summary>
        /// DereferenceStrong is not implemented. Do not call this method.
        /// </summary>
        public HRESULT TryDereferenceStrong(out CorDebugValue ppValueResult)
        {
            /*HRESULT DereferenceStrong([Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppValue);*/
            ICorDebugValue ppValue;
            HRESULT hr = Raw.DereferenceStrong(out ppValue);

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