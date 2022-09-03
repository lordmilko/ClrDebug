using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    [DebuggerDisplay("cCustData = {cCustData}, prgCustData = {prgCustData.ToString(),nq}")]
    public struct CUSTDATA
    {
        public int cCustData;

        //CUSTDATAITEM[]
        public IntPtr prgCustData;
    }
}
