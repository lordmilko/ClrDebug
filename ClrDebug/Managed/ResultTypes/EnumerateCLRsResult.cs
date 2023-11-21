using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DbgShim.EnumerateCLRs"/> method.
    /// </summary>
    public unsafe struct EnumerateCLRsResult
    {
        public IntPtr HandleArrayOut { get; }

        public IntPtr StringArrayOut { get; }

        public int ArrayLengthOut { get; }

        private EnumerateCLRsResultItem[] items;

        public EnumerateCLRsResultItem[] Items
        {
            get
            {
                if (items == null)
                {
                    var list = new List<EnumerateCLRsResultItem>();

                    var handleArrayOutPtr = (IntPtr*)HandleArrayOut;
                    var stringArrayOutPtr = (IntPtr*)StringArrayOut;

                    for (var i = 0; i < ArrayLengthOut; i++)
                    {
                        list.Add(new EnumerateCLRsResultItem(
                            handleArrayOutPtr[i],
                            stringArrayOutPtr[i]
                        ));
                    }

                    items = list.ToArray();
                }

                return items;
            }
        }

        public EnumerateCLRsResult(IntPtr ppHandleArrayOut, IntPtr ppStringArrayOut, int pdwArrayLengthOut)
        {
            HandleArrayOut = ppHandleArrayOut;
            StringArrayOut = ppStringArrayOut;
            ArrayLengthOut = pdwArrayLengthOut;

            items = null;
        }
    }

    [DebuggerDisplay("Handle = {Handle.ToString(),nq}, Path = {Path}")]
    public struct EnumerateCLRsResultItem
    {
        public IntPtr Handle { get; }

        public string Path { get; }

        public EnumerateCLRsResultItem(IntPtr handle, IntPtr path)
        {
            Handle = handle;
            Path = Marshal.PtrToStringUni(path);
        }
    }
}
