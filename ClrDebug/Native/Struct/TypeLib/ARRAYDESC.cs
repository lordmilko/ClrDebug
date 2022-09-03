using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    [DebuggerDisplay("tdescElm = {tdescElm.ToString(),nq}, cDims = {cDims}, rgbounds = {rgbounds.ToString(),nq}")]
    public struct ARRAYDESC
    {
        public TYPEDESC tdescElm;
        public short cDims;

        //SAFEARRAYBOUND[]
        public IntPtr rgbounds;
    }
}
