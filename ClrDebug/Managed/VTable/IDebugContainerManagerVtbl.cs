using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugContainerManagerVtbl
    {
        public readonly IntPtr CreateContainer;
        public readonly IntPtr OpenContainer;
        public readonly IntPtr CloseContainer;
        public readonly IntPtr GetOwner;
        public readonly IntPtr StartActivity;
        public readonly IntPtr StartProcessInContainer;
        public readonly IntPtr RunProcessInContainer;
        public readonly IntPtr MapFolderToContainer;
        public readonly IntPtr UnmapFolderFromContainer;
        public readonly IntPtr StopActivity;
        public readonly IntPtr EnumerateContainers;
    }
}
