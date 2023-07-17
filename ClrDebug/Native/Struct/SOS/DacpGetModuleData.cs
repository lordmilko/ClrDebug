using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("IsDynamic = {IsDynamic}, IsInMemory = {IsInMemory}, IsFileLayout = {IsFileLayout}, PEAssembly = {PEAssembly.ToString(),nq}, LoadedPEAddress = {LoadedPEAddress.ToString(),nq}, LoadedPESize = {LoadedPESize}, InMemoryPdbAddress = {InMemoryPdbAddress.ToString(),nq}, InMemoryPdbSize = {InMemoryPdbSize}")]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DacpGetModuleData
    {
        public bool IsDynamic;
        public bool IsInMemory;
        public bool IsFileLayout;
        public CLRDATA_ADDRESS PEAssembly;
        public CLRDATA_ADDRESS LoadedPEAddress;
        public long LoadedPESize;
        public CLRDATA_ADDRESS InMemoryPdbAddress;
        public long InMemoryPdbSize;

        public HRESULT Request(IXCLRDataModule pDataModule)
        {
            var size = Marshal.SizeOf(this);
            IntPtr outBuffer = Marshal.AllocHGlobal(size);

            var hr = pDataModule.Request(
                (uint) DACDATAMODULEPRIV_REQUEST.GET_MODULEDATA,
                0,
                IntPtr.Zero,
                size,
                outBuffer
            );

            if (hr == HRESULT.S_OK)
                this = Marshal.PtrToStructure<DacpGetModuleData>(outBuffer);

            Marshal.FreeHGlobal(outBuffer);

            return hr;
        }
    }
}
