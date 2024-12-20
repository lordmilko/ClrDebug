using System;

namespace ClrDebug.TTD
{
#pragma warning disable CS0649
    internal struct ErrorReportingVtbl
    {
        public IntPtr Destructor;
        public IntPtr PrintError;
        public IntPtr VPrintError;
    }
#pragma warning restore CS0649
}
