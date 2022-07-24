using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    public static partial class DbgEngExtensions
    {
        /// <summary>
        /// Gets a managed wrapper around the <see cref="WINDBG_EXTENSION_APIS"/> structure.<para/>
        /// The type of <see cref="WINDBG_EXTENSION_APIS"/> returned (64-bit or 32-bit) is determined by the bitness of the current process.<para/>
        /// To retrieve the <see cref="WINDBG_EXTENSION_APIS"/> structure directly, call either the <see cref="DebugControl.GetWindbgExtensionApis32"/> or <see cref="DebugControl.GetWindbgExtensionApis64"/> method.
        /// </summary>
        /// <param name="control">The <see cref="DebugControl"/> to use to retrieve the <see cref="WINDBG_EXTENSION_APIS"/> structure.</param>
        /// <returns>A managed wrapper around the <see cref="WINDBG_EXTENSION_APIS"/> structure.</returns>
        public static WinDbgExtensionAPI GetWindbgExtensionApis(this DebugControl control)
        {
            var raw = new WINDBG_EXTENSION_APIS
            {
                nSize = Marshal.SizeOf<WINDBG_EXTENSION_APIS>()
            };

            if (IntPtr.Size == 8)
                control.GetWindbgExtensionApis64(ref raw);
            else
                control.GetWindbgExtensionApis32(ref raw);

            return new WinDbgExtensionAPI(raw);
        }
    }
}
