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
            IntPtr outBuffer;

            var hr = dac.Request(
                (uint) DACSTACKPRIV_REQUEST.FRAME_DATA,
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
