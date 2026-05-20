namespace ClrDebug.DbgEng
{
    public class DebugModelQuery : ComObject<IDebugModelQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugModelQuery"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugModelQuery(IDebugModelQuery raw) : base(raw)
        {
        }

        #region IDebugModelQuery
        #region QueryModel

        public void QueryModel(string queryString, MODEL_QUERY flags, int recursionDepth, IDebugOutputStream stream)
        {
            TryQueryModel(queryString, flags, recursionDepth, stream).ThrowDbgEngNotOK();
        }

        public HRESULT TryQueryModel(string queryString, MODEL_QUERY flags, int recursionDepth, IDebugOutputStream stream)
        {
            /*HRESULT QueryModel(
            [MarshalAs(UnmanagedType.LPWStr), In] string queryString,
            [In] MODEL_QUERY flags,
            [In] int recursionDepth,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);*/
            return Raw.QueryModel(queryString, flags, recursionDepth, stream);
        }

        #endregion
        #region QueryModelForCompletion

        public void QueryModelForCompletion(string queryString, IDebugOutputStream stream)
        {
            TryQueryModelForCompletion(queryString, stream).ThrowDbgEngNotOK();
        }

        public HRESULT TryQueryModelForCompletion(string queryString, IDebugOutputStream stream)
        {
            /*HRESULT QueryModelForCompletion(
            [MarshalAs(UnmanagedType.LPWStr), In] string queryString,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);*/
            return Raw.QueryModelForCompletion(queryString, stream);
        }

        #endregion
        #region WriteModel

        public void WriteModel(string lvalueExpression, string rvalueExpression, MODEL_QUERY flags, int recursionDepth, IDebugOutputStream stream)
        {
            TryWriteModel(lvalueExpression, rvalueExpression, flags, recursionDepth, stream).ThrowDbgEngNotOK();
        }

        public HRESULT TryWriteModel(string lvalueExpression, string rvalueExpression, MODEL_QUERY flags, int recursionDepth, IDebugOutputStream stream)
        {
            /*HRESULT WriteModel(
            [MarshalAs(UnmanagedType.LPWStr), In] string lvalueExpression,
            [MarshalAs(UnmanagedType.LPWStr), In] string rvalueExpression,
            [In] MODEL_QUERY flags,
            [In] int recursionDepth,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);*/
            return Raw.WriteModel(lvalueExpression, rvalueExpression, flags, recursionDepth, stream);
        }

        #endregion
        #endregion
    }
}
