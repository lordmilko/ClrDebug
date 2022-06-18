﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("IsDynamic = {IsDynamic}, IsInMemory = {IsInMemory}, IsFileLayout = {IsFileLayout}, PEAssembly = {PEAssembly.ToString(),nq}, LoadedPEAddress = {LoadedPEAddress.ToString(),nq}, LoadedPESize = {LoadedPESize}, InMemoryPdbAddress = {InMemoryPdbAddress.ToString(),nq}, InMemoryPdbSize = {InMemoryPdbSize}")]
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
            var size = Marshal.SizeOf(this);
            IntPtr outBuffer = Marshal.AllocHGlobal(size);

            var hr = pDataModule.Request(
                (uint) DACDATAMODULEPRIV_REQUEST.GET_MODULEDATA,
                0,
                IntPtr.Zero,
                size,
                ref outBuffer
            );

            if (hr == HRESULT.S_OK)
                Marshal.PtrToStructure(outBuffer, this);

            Marshal.FreeHGlobal(outBuffer);

            return hr;
        }
    }
}
