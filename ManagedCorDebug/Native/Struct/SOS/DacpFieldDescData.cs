using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpFieldDescData
	{
		public CorElementType Type;
		public CorElementType sigType;
		public CLRDATA_ADDRESS MTOfType;
		public CLRDATA_ADDRESS ModuleOfType;
		public mdTypeDef TypeToken;
		public mdFieldDef mb;
		public CLRDATA_ADDRESS MTOfEnclosingClass;
		public int dwOffset;
		public int bIsThreadLocal;
		public int bIsContextLocal;
		public int bIsStatic;
		public CLRDATA_ADDRESS NextField;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetFieldDescData(addr, out this);
        }
    }
}
