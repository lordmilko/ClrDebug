using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.DbgEng.Vtbl;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Supports the debug output stream.
    /// </summary>
    public unsafe class DebugOutputStream : RuntimeCallableWrapper
    {
        public static readonly Guid IID_IDebugOutputStream = new Guid("7782D8F2-2B85-4059-AB88-28CEDDCA1C80");

        #region Vtbl

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private new IDebugOutputStreamVtbl* Vtbl => (IDebugOutputStreamVtbl*) base.Vtbl;

        #endregion

        public DebugOutputStream(IntPtr raw) : base(raw, IID_IDebugOutputStream)
        {
        }

        public DebugOutputStream(IDebugOutputStream raw) : base(raw)
        {
        }

        #region IDebugOutputStream
        #region Write

        /// <summary>
        /// Writes to the debug output stream.
        /// </summary>
        /// <param name="text">[in] A pointer to a Unicode character string of content to write.</param>
        public void Write(string text)
        {
            TryWrite(text).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Writes to the debug output stream.
        /// </summary>
        /// <param name="text">[in] A pointer to a Unicode character string of content to write.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryWrite(string text)
        {
            InitDelegate(ref write, Vtbl->Write);

            /*HRESULT Write(
            [MarshalAs(UnmanagedType.LPWStr), In] string text);*/
            return write(Raw, text);
        }

        #endregion
        #endregion
        #region Cached Delegates
        #region IDebugOutputStream

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private WriteDelegate write;

        #endregion
        #endregion
        #region Delegates
        #region IDebugOutputStream

        private delegate HRESULT WriteDelegate(IntPtr self, [MarshalAs(UnmanagedType.LPWStr), In] string text);

        #endregion
        #endregion
    }
}
