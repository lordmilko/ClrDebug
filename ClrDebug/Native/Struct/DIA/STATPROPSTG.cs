using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.TypeLib;

namespace ClrDebug.DIA
{
    [DebuggerDisplay("lpwstrName = {lpwstrName}, propid = {propid}, vt = {vt.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct STATPROPSTG
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpwstrName;
        public int propid;
        public VARENUM vt;
    }
}
