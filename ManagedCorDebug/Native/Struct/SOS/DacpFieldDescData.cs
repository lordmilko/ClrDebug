using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("Type = {Type.ToString(),nq}, sigType = {sigType.ToString(),nq}, MTOfType = {MTOfType.ToString(),nq}, ModuleOfType = {ModuleOfType.ToString(),nq}, TypeToken = {TypeToken.ToString(),nq}, mb = {mb.ToString(),nq}, MTOfEnclosingClass = {MTOfEnclosingClass.ToString(),nq}, dwOffset = {dwOffset}, bIsThreadLocal = {bIsThreadLocal}, bIsContextLocal = {bIsContextLocal}, bIsStatic = {bIsStatic}, NextField = {NextField.ToString(),nq}")]
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
        public bool bIsThreadLocal;
        public bool bIsContextLocal;
        public bool bIsStatic;
        public CLRDATA_ADDRESS NextField;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetFieldDescData(addr, out this);
        }
    }
}
