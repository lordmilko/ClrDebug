using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("frameAddr = {frameAddr.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpFrameData
    {
        public CLRDATA_ADDRESS frameAddr;

        public HRESULT Request(IXCLRDataStackWalk dac)
        {
            var size = Marshal.SizeOf(this);
            IntPtr outBuffer = Marshal.AllocHGlobal(size);

            var hr = dac.Request(
                (uint) DACSTACKPRIV_REQUEST.FRAME_DATA,
                0,
                IntPtr.Zero,
                Marshal.SizeOf(this),
                ref outBuffer
            );

            if (hr == HRESULT.S_OK)
                Marshal.PtrToStructure(outBuffer, this);

            Marshal.FreeHGlobal(outBuffer);

            return hr;
        }
    }
}
