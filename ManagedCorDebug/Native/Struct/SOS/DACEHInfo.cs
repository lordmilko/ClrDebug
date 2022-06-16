using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DACEHInfo
	{
		public EHClauseType clauseType;
		public CLRDATA_ADDRESS tryStartOffset;
		public CLRDATA_ADDRESS tryEndOffset;
		public CLRDATA_ADDRESS handlerStartOffset;
		public CLRDATA_ADDRESS handlerEndOffset;
		public int isDuplicateClause;
		public CLRDATA_ADDRESS filterOffset;
		public int isCatchAllHandler;
		public CLRDATA_ADDRESS moduleAddr;
		public CLRDATA_ADDRESS mtCatch;
		public mdToken tokCatch;
	}
}
