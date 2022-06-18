using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("ModulePtr = {ModulePtr.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpGetModuleAddress
    {
        public CLRDATA_ADDRESS ModulePtr;

        public HRESULT Request(IXCLRDataModule pDataModule)
        {
            var size = Marshal.SizeOf(this);
            IntPtr outBuffer = Marshal.AllocHGlobal(size);

            var hr = pDataModule.Request(
                (uint) DACDATAMODULEPRIV_REQUEST.GET_MODULEPTR,
                0,
                IntPtr.Zero,
                Marshal.SizeOf(this),
                outBuffer
            );

            if (hr == HRESULT.S_OK)
                this = Marshal.PtrToStructure<DacpGetModuleAddress>(outBuffer);

            Marshal.FreeHGlobal(outBuffer);

            return hr;
        }
    }
}
