using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("AssemblyPtr = {AssemblyPtr.ToString(),nq}, ClassLoader = {ClassLoader.ToString(),nq}, ParentDomain = {ParentDomain.ToString(),nq}, BaseDomainPtr = {BaseDomainPtr.ToString(),nq}, AssemblySecDesc = {AssemblySecDesc.ToString(),nq}, isDynamic = {isDynamic}, ModuleCount = {ModuleCount}, LoadContext = {LoadContext}, isDomainNeutral = {isDomainNeutral}, dwLocationFlags = {dwLocationFlags}")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DacpAssemblyData
    {
        public CLRDATA_ADDRESS AssemblyPtr;
        public CLRDATA_ADDRESS ClassLoader;
        public CLRDATA_ADDRESS ParentDomain;
        public CLRDATA_ADDRESS BaseDomainPtr;
        public CLRDATA_ADDRESS AssemblySecDesc;
        public bool isDynamic;
        public int ModuleCount;
        public int LoadContext;
        public bool isDomainNeutral;
        public int dwLocationFlags;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr, CLRDATA_ADDRESS baseDomainPtr)
        {
            return sos.GetAssemblyData(baseDomainPtr, addr, out this);
        }

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return Request(sos, addr, default(CLRDATA_ADDRESS));
        }
    }
}
