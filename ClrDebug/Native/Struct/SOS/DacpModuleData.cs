using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Defines a transport buffer for a module's runtime information.
    /// </summary>
    /// <remarks>
    /// This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define
    /// the structure as specified above.
    /// </remarks>
    [DebuggerDisplay("Address = {Address.ToString(),nq}, PEAssembly = {PEAssembly.ToString(),nq}, ilBase = {ilBase.ToString(),nq}, metadataStart = {metadataStart.ToString(),nq}, metadataSize = {metadataSize}, Assembly = {Assembly.ToString(),nq}, bIsReflection = {bIsReflection}, bIsPEFile = {bIsPEFile}, dwBaseClassIndex = {dwBaseClassIndex}, dwModuleID = {dwModuleID}, dwTransientFlags = {dwTransientFlags}, TypeDefToMethodTableMap = {TypeDefToMethodTableMap.ToString(),nq}, TypeRefToMethodTableMap = {TypeRefToMethodTableMap.ToString(),nq}, MethodDefToDescMap = {MethodDefToDescMap.ToString(),nq}, FieldDefToDescMap = {FieldDefToDescMap.ToString(),nq}, MemberRefToDescMap = {MemberRefToDescMap.ToString(),nq}, FileReferencesMap = {FileReferencesMap.ToString(),nq}, ManifestModuleReferencesMap = {ManifestModuleReferencesMap.ToString(),nq}, pLookupTableHeap = {pLookupTableHeap.ToString(),nq}, pThunkHeap = {pThunkHeap.ToString(),nq}, dwModuleIndex = {dwModuleIndex}")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DacpModuleData
    {
        /// <summary>
        /// Address of the module object.
        /// </summary>
        public CLRDATA_ADDRESS Address;
        public CLRDATA_ADDRESS PEAssembly;

        /// <summary>
        /// The address of the loaded image's base.
        /// </summary>
        public CLRDATA_ADDRESS ilBase;
        public CLRDATA_ADDRESS metadataStart;
        public long metadataSize;
        public CLRDATA_ADDRESS Assembly;
        public bool bIsReflection;
        public bool bIsPEFile;
        public long dwBaseClassIndex;
        public long dwModuleID;
        public DacpModuleDataTransientFlags dwTransientFlags;
        public CLRDATA_ADDRESS TypeDefToMethodTableMap;
        public CLRDATA_ADDRESS TypeRefToMethodTableMap;
        public CLRDATA_ADDRESS MethodDefToDescMap;
        public CLRDATA_ADDRESS FieldDefToDescMap;
        public CLRDATA_ADDRESS MemberRefToDescMap;
        public CLRDATA_ADDRESS FileReferencesMap;
        public CLRDATA_ADDRESS ManifestModuleReferencesMap;
        public CLRDATA_ADDRESS pLookupTableHeap;
        public CLRDATA_ADDRESS pThunkHeap;
        public long dwModuleIndex;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetModuleData(addr, out this);
        }
    }
}
