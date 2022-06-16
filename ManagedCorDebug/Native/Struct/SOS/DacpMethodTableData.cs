using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpMethodTableData
	{
		public int bIsFree;
		public CLRDATA_ADDRESS Module;
		public CLRDATA_ADDRESS Class;
		public CLRDATA_ADDRESS ParentMethodTable;
		public ushort wNumInterfaces;
		public ushort wNumMethods;
		public ushort wNumVtableSlots;
		public ushort wNumVirtuals;
		public int BaseSize;
		public int ComponentSize;
		public mdTypeDef cl;
		public int dwAttrClass;
		public int bIsShared;
		public int bIsDynamic;
		public int bContainsPointers;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetMethodTableData(addr, out this);
        }
    }
}
