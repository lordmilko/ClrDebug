using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpMethodTableCollectibleData
	{
		public CLRDATA_ADDRESS LoaderAllocatorObjectHandle;
		public int bCollectible;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            var pSOS6 = sos as ISOSDacInterface6;

            if (pSOS6 == null)
                return HRESULT.E_NOINTERFACE;

            return pSOS6.GetMethodTableCollectibleData(addr, out this);
        }
    }
}
