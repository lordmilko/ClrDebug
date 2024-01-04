using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    public unsafe class DebugModelQuery : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugModelQuery = new Guid("4E7B1C9E-9D91-4054-9B9F-DABE4277D1EC");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugModelQueryVtbl* Vtbl => (IDebugModelQueryVtbl*) base.Vtbl;

        #endregion

        public DebugModelQuery(IntPtr raw) : base(raw, IID_IDebugModelQuery)
        {
        }

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
            InitDelegate(ref queryModel, Vtbl->QueryModel);

            /*HRESULT QueryModel(
            [MarshalAs(UnmanagedType.LPWStr), In] string queryString,
            [In] MODEL_QUERY flags,
            [In] int recursionDepth,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);*/
            return queryModel(Raw, queryString, flags, recursionDepth, stream);
        }

        #endregion
        #region QueryModelForCompletion

        public void QueryModelForCompletion(string queryString, IDebugOutputStream stream)
        {
            TryQueryModelForCompletion(queryString, stream).ThrowDbgEngNotOK();
        }

        public HRESULT TryQueryModelForCompletion(string queryString, IDebugOutputStream stream)
        {
            InitDelegate(ref queryModelForCompletion, Vtbl->QueryModelForCompletion);

            /*HRESULT QueryModelForCompletion(
            [MarshalAs(UnmanagedType.LPWStr), In] string queryString,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);*/
            return queryModelForCompletion(Raw, queryString, stream);
        }

        #endregion
        #region WriteModel

        public void WriteModel(string lvalueExpression, string rvalueExpression, MODEL_QUERY flags, int recursionDepth, IDebugOutputStream stream)
        {
            TryWriteModel(lvalueExpression, rvalueExpression, flags, recursionDepth, stream).ThrowDbgEngNotOK();
        }

        public HRESULT TryWriteModel(string lvalueExpression, string rvalueExpression, MODEL_QUERY flags, int recursionDepth, IDebugOutputStream stream)
        {
            InitDelegate(ref writeModel, Vtbl->WriteModel);

            /*HRESULT WriteModel(
            [MarshalAs(UnmanagedType.LPWStr), In] string lvalueExpression,
            [MarshalAs(UnmanagedType.LPWStr), In] string rvalueExpression,
            [In] MODEL_QUERY flags,
            [In] int recursionDepth,
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);*/
            return writeModel(Raw, lvalueExpression, rvalueExpression, flags, recursionDepth, stream);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugModelQuery

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryModelDelegate queryModel;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryModelForCompletionDelegate queryModelForCompletion;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteModelDelegate writeModel;

        #endregion
        #endregion
        #region Delegates
        #region IDebugModelQuery

        private delegate HRESULT QueryModelDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string queryString, [In] MODEL_QUERY flags, [In] int recursionDepth, [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);
        private delegate HRESULT QueryModelForCompletionDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string queryString, [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);
        private delegate HRESULT WriteModelDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string lvalueExpression, [MarshalAs(UnmanagedType.LPWStr), In] string rvalueExpression, [In] MODEL_QUERY flags, [In] int recursionDepth, [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream stream);

        #endregion
        #endregion
    }
}
