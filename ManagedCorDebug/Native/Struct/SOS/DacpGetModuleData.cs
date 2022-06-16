using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpGetModuleData
	{
		public int IsDynamic;
		public int IsInMemory;
		public int IsFileLayout;
		public CLRDATA_ADDRESS PEAssembly;
		public CLRDATA_ADDRESS LoadedPEAddress;
		public long LoadedPESize;
		public CLRDATA_ADDRESS InMemoryPdbAddress;
		public long InMemoryPdbSize;

        public HRESULT Request(IXCLRDataModule pDataModule)
        {
            IntPtr outBuffer;

            var hr = pDataModule.Request(
                (uint) DACDATAMODULEPRIV_REQUEST.GET_MODULEDATA,
                0,
                IntPtr.Zero,
                Marshal.SizeOf(this),
                out outBuffer
            );

            if (hr == HRESULT.S_OK)
                Marshal.PtrToStructure(outBuffer, this);

            return hr;
        }
    }
}
