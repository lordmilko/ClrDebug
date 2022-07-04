using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Defines the container for a module address request.
    /// </summary>
    /// <remarks>
    /// This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define
    /// the structure as specified above, where CLRDATA_ADDRESS is a 64-bit unsigned integer.
    /// </remarks>
    [DebuggerDisplay("ModulePtr = {ModulePtr.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpGetModuleAddress
    {
        /// <summary>
        /// The pointer to the module.
        /// </summary>
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
