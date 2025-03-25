using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ClrDebug.TTD
{
    public abstract unsafe class ErrorReporting : IDisposable
    {
        private bool disposed;

        private IntPtr vtbl;
        internal IntPtr This { get; private set; }

        protected ErrorReporting()
        {
            printError = PrintErrorInternal;
            vPrintError = VPrintErrorInternal;

            vtbl = Marshal.AllocHGlobal(Marshal.SizeOf<ErrorReportingVtbl>());

            var pVtbl = (ErrorReportingVtbl*) vtbl;

            pVtbl->PrintError = Marshal.GetFunctionPointerForDelegate(printError);
            pVtbl->VPrintError = Marshal.GetFunctionPointerForDelegate(vPrintError);

            This = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>());
            Marshal.WriteIntPtr(This, vtbl);
        }

        ~ErrorReporting()
        {
            Dispose();
        }

        #region PrintError

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void PrintErrorDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] ref string error);

        private PrintErrorDelegate printError;

        private void PrintErrorInternal(IntPtr @this, ref string error) =>
            PrintError(error);

        public abstract void PrintError(string error);

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void VPrintErrorDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string format,
            [In] IntPtr vaList);

        private VPrintErrorDelegate vPrintError;

        private void VPrintErrorInternal(IntPtr @this, string format, IntPtr vaList) =>
            VPrintError(format, vaList);

        public abstract void VPrintError(string format, IntPtr vaList);

        public void Dispose()
        {
            if (disposed)
                return;

            disposed = true;

            Marshal.FreeHGlobal(This);
            Marshal.FreeHGlobal(vtbl);
            This = default;
            vtbl = default;
        }
    }
}
