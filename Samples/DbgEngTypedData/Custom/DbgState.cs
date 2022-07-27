using System;
using ClrDebug.DbgEng;

namespace DbgEngTypedData.Custom
{
    class DbgState
    {
        public DebugClient Client { get; }

        private IntPtr processHandle;

        public IntPtr ProcessHandle
        {
            get
            {
                if (processHandle == IntPtr.Zero)
                    processHandle = new IntPtr(Client.SystemObjects.CurrentProcessHandle);

                return processHandle;
            }
        }

        private WinDbgExtensionAPI windbgAPI;

        public WinDbgExtensionAPI WinDbgAPI
        {
            get
            {
                if (windbgAPI == null)
                    windbgAPI = Client.Control.GetWindbgExtensionApis();

                return windbgAPI;
            }
        }

        public DbgState(DebugClient client)
        {
            Client = client;
        }

        public static implicit operator DbgState(DebugClient client) => new DbgState(client);
    }
}
