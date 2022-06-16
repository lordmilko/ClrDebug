using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpGCInterestingInfoData
    {
        private const int DAC_NUM_GC_DATA_POINTS = 9;
        private const int DAC_MAX_COMPACT_REASONS_COUNT = 11;
        private const int DAC_MAX_EXPAND_MECHANISMS_COUNT = 6;
        private const int DAC_MAX_GC_MECHANISM_BITS_COUNT = 2;
        private const int DAC_MAX_GLOBAL_GC_MECHANISMS_COUNT = 6;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DAC_NUM_GC_DATA_POINTS)]
		public long[] interestingDataPoints;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DAC_MAX_COMPACT_REASONS_COUNT)]
		public long[] compactReasons;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DAC_MAX_EXPAND_MECHANISMS_COUNT)]
        public long[] expandMechanisms;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DAC_MAX_GC_MECHANISM_BITS_COUNT)]
        public long[] bitMechanisms;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DAC_MAX_GLOBAL_GC_MECHANISMS_COUNT)]
        public long[] globalMechanisms;

        public HRESULT RequestGlobal(ISOSDacInterface sos)
        {
            var psos3 = sos as ISOSDacInterface3;

            if (psos3 == null)
                return HRESULT.E_NOINTERFACE;

            return psos3.GetGCGlobalMechanisms(globalMechanisms);
        }

        public HRESULT Request(ISOSDacInterface sos)
        {
            var psos3 = sos as ISOSDacInterface3;

            if (psos3 == null)
                return HRESULT.E_NOINTERFACE;

            return psos3.GetGCInterestingInfoStaticData(out this);
        }

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            var psos3 = sos as ISOSDacInterface3;

            if (psos3 == null)
                return HRESULT.E_NOINTERFACE;

            return psos3.GetGCInterestingInfoData(addr, out this);
        }
    }
}
