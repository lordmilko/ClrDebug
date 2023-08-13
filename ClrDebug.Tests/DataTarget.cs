using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.InteropServices.Marshalling;
#endif
using System.Threading;

namespace ClrDebug.Tests
{
    /// <summary>
    /// Represents a simple <see cref="ICLRDataTarget"/> for reading memory from a target process.
    /// </summary>
#if NET8_0_OR_GREATER
    [GeneratedComClass]
#endif
    partial class DataTarget : ICLRDataTarget
    {
        private Process process;

        public DataTarget(Process process)
        {
            this.process = process;
        }

        public HRESULT GetMachineType(out IMAGE_FILE_MACHINE machineType)
        {
            //This sample assumes Windows
            machineType = IntPtr.Size == 4 ? IMAGE_FILE_MACHINE.I386 : IMAGE_FILE_MACHINE.AMD64;
            return HRESULT.S_OK;
        }

        public HRESULT GetPointerSize(out int pointerSize)
        {
            pointerSize = IntPtr.Size;
            return HRESULT.S_OK;
        }

        //This method is called to get the base address of certain loaded modules in the target process, principally clr.dll
        public HRESULT GetImageBase(string imagePath, out CLRDATA_ADDRESS baseAddress)
        {
            //In .NET Core it's possible to dbgshim!RegisterForRuntimeStartup (with the catch-22 you already need to know
            //where your dbgshim.dll is). In .NET Framework however there is no such function, so our fallback strategy is to repeatedly poll to see when it's loaded

            ProcessModule module = null;

            for (var i = 0; i < 100; i++)
            {
                //Once Process.Modules have been retrieved, they'll be cached. As such we re-retrieve the Process each time to get the latest available set of modules
                module = Process.GetProcessById(process.Id).Modules.Cast<ProcessModule>().FirstOrDefault(m => StringComparer.OrdinalIgnoreCase.Equals(m.ModuleName, imagePath));

                if (module != null)
                    break;

                Thread.Sleep(50);
            }

            if (module == null)
            {
                baseAddress = 0;
                return HRESULT.E_FAIL;
            }

            baseAddress = module.BaseAddress.ToInt64();
            return HRESULT.S_OK;
        }

        public HRESULT ReadVirtual(CLRDATA_ADDRESS address, IntPtr buffer, int bytesRequested, out int bytesRead)
        {
            //ReadProcessMemory will fail if any part of the region to read does not have read access, which can commonly occur
            //when attempting to read across a page boundary. As such, memory requests must be "chunked" to be within each page,
            //which we do by gradually shifting the pointer of our buffer along until we've read everything we're after

            var pageSize = 0x1000;

            var totalRead = 0;

            HRESULT hr = HRESULT.S_OK;

            while (bytesRequested > 0)
            {
                //This bit of magic ensures we're not reading more than 1 page worth of data. I don't understand how this works
                //however Microsoft use it all the time so you know it's right
                var readSize = pageSize - (int)(address & (pageSize - 1));
                readSize = Math.Min(bytesRequested, readSize);

                var result = NativeMethods.ReadProcessMemory(
                    process.Handle,
                    address,
                    buffer,
                    readSize,
                    out bytesRead
                );

                if (!result)
                {
                    //Some methodtables' parents appear to point to an invalid memory address. When we read these invalid memory addresses,
                    //pass them back to the DAC and then are asked to read some actual data from these invalid locations, this will naturally fail with ERROR_PARTIAL_COPY,
                    //but really its a total failure
                    if (totalRead > 0)
                        hr = HRESULT.S_OK;
                    else
                        hr = (HRESULT)Marshal.GetHRForLastWin32Error();

                    break;
                }

                totalRead += bytesRead;
                address += bytesRead;
                buffer = new IntPtr(buffer.ToInt64() + bytesRead);
                bytesRequested -= bytesRead;
            }

            if (hr == HRESULT.S_OK)
                bytesRead = totalRead;
            else
                bytesRead = 0;

            return hr;
        }

        #region Not Implemented

        public HRESULT WriteVirtual(CLRDATA_ADDRESS address, IntPtr buffer, int bytesRequested, out int bytesWritten)
        {
            throw new NotImplementedException();
        }

        public HRESULT GetTLSValue(int threadID, int index, out CLRDATA_ADDRESS value)
        {
            throw new NotImplementedException();
        }

        public HRESULT SetTLSValue(int threadID, int index, CLRDATA_ADDRESS value)
        {
            throw new NotImplementedException();
        }

        public HRESULT GetCurrentThreadID(out int threadID)
        {
            throw new NotImplementedException();
        }

        public HRESULT GetThreadContext(int threadID, ContextFlags contextFlags, int contextSize, IntPtr context)
        {
            throw new NotImplementedException();
        }

        public HRESULT SetThreadContext(int threadID, int contextSize, IntPtr context)
        {
            throw new NotImplementedException();
        }

        public HRESULT Request(uint reqCode, int inBufferSize, IntPtr inBuffer, int outBufferSize, IntPtr outBuffer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
