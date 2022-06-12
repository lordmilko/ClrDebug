using System;

namespace ManagedCorDebug
{
    public struct GetMemberRefPropsResult
    {
        public mdToken Ptk { get; }

        public string SzMember { get; }

        public IntPtr PpvSigBlob { get; }

        public int PbSig { get; }

        public GetMemberRefPropsResult(mdToken ptk, string szMember, IntPtr ppvSigBlob, int pbSig)
        {
            Ptk = ptk;
            SzMember = szMember;
            PpvSigBlob = ppvSigBlob;
            PbSig = pbSig;
        }
    }
}