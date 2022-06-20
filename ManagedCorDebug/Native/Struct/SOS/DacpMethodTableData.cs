using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("bIsFree = {bIsFree}, Module = {Module.ToString(),nq}, Class = {Class.ToString(),nq}, ParentMethodTable = {ParentMethodTable.ToString(),nq}, wNumInterfaces = {wNumInterfaces}, wNumMethods = {wNumMethods}, wNumVtableSlots = {wNumVtableSlots}, wNumVirtuals = {wNumVirtuals}, BaseSize = {BaseSize}, ComponentSize = {ComponentSize}, cl = {cl.ToString(),nq}, dwAttrClass = {dwAttrClass}, bIsShared = {bIsShared}, bIsDynamic = {bIsDynamic}, bContainsPointers = {bContainsPointers}")]
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
        public CorTypeAttr dwAttrClass;
        public int bIsShared;
        public int bIsDynamic;
        public int bContainsPointers;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetMethodTableData(addr, out this);
        }
    }
}
