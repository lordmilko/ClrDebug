using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    public partial class DebugClient
    {
        #region Advanced

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugAdvanced advanced;

        public DebugAdvanced Advanced
        {
            get
            {
                if (advanced == null)
                {
                    lock (lockObj)
                        advanced ??= new DebugAdvanced(Raw);
                }

                return advanced;
            }
        }

        #endregion
        #region ClientInternal

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugClientInternal clientInternal;

        public DebugClientInternal ClientInternal
        {
            get
            {
                if (clientInternal == null)
                {
                    lock (lockObj)
                        clientInternal ??= new DebugClientInternal(Raw);
                }

                return clientInternal;
            }
        }

        #endregion
        #region Control

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugControl control;

        public DebugControl Control
        {
            get
            {
                if (control == null)
                {
                    lock (lockObj)
                        control ??= new DebugControl(Raw);
                }

                return control;
            }
        }

        #endregion
        #region DataModelScripting

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugDataModelScripting dataModelScripting;

        public DebugDataModelScripting DataModelScripting
        {
            get
            {
                if (dataModelScripting == null)
                {
                    lock (lockObj)
                        dataModelScripting ??= new DebugDataModelScripting(Raw);
                }

                return dataModelScripting;
            }
        }

        #endregion
        #region DataSpaces

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugDataSpaces dataSpaces;

        public DebugDataSpaces DataSpaces
        {
            get
            {
                if (dataSpaces == null)
                {
                    lock (lockObj)
                        dataSpaces ??= new DebugDataSpaces(Raw);
                }

                return dataSpaces;
            }
        }

        #endregion
        #region DebugTargetCompositionBridge

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugTargetCompositionBridge debugTargetCompositionBridge;

        public DebugTargetCompositionBridge DebugTargetCompositionBridge
        {
            get
            {
                if (debugTargetCompositionBridge == null)
                {
                    lock (lockObj)
                        debugTargetCompositionBridge ??= new DebugTargetCompositionBridge(AsInterface<IDebugTargetCompositionBridge>());
                }

                return debugTargetCompositionBridge;
            }
        }

        #endregion
        #region HostDataModelAccess

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private HostDataModelAccess hostDataModelAccess;

        public HostDataModelAccess HostDataModelAccess
        {
            get
            {
                if (hostDataModelAccess == null)
                {
                    lock (lockObj)
                        hostDataModelAccess ??= new HostDataModelAccess(AsInterface<IHostDataModelAccess>());
                }

                return hostDataModelAccess;
            }
        }

        #endregion
        #region LinkableProcessServer

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugLinkableProcessServer linkableProcessServer;

        public DebugLinkableProcessServer LinkableProcessServer
        {
            get
            {
                if (linkableProcessServer == null)
                {
                    lock (lockObj)
                        linkableProcessServer ??= new DebugLinkableProcessServer(Raw);
                }

                return linkableProcessServer;
            }
        }

        #endregion
        #region ModelQuery

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugModelQuery modelQuery;

        public DebugModelQuery ModelQuery
        {
            get
            {
                if (modelQuery == null)
                {
                    lock (lockObj)
                        modelQuery ??= new DebugModelQuery(Raw);
                }

                return modelQuery;
            }
        }

        #endregion
        #region PlmClient

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugPlmClient plmClient;

        public DebugPlmClient PlmClient
        {
            get
            {
                if (plmClient == null)
                {
                    lock (lockObj)
                        plmClient ??= new DebugPlmClient(Raw);
                }

                return plmClient;
            }
        }

        #endregion
        #region Registers

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugRegisters registers;

        public DebugRegisters Registers
        {
            get
            {
                if (registers == null)
                {
                    lock (lockObj)
                        registers ??= new DebugRegisters(Raw);
                }

                return registers;
            }
        }

        #endregion
        #region ServiceProvider

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugServiceProvider serviceProvider;

        public DebugServiceProvider ServiceProvider
        {
            get
            {
                if (serviceProvider == null)
                {
                    lock (lockObj)
                        serviceProvider ??= new DebugServiceProvider(Raw);
                }

                return serviceProvider;
            }
        }

        #endregion
        #region Settings

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugSettings settings;

        public DebugSettings Settings
        {
            get
            {
                if (settings == null)
                {
                    lock (lockObj)
                        settings ??= new DebugSettings(Raw);
                }

                return settings;
            }
        }

        #endregion
        #region Symbols

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugSymbols symbols;

        public DebugSymbols Symbols
        {
            get
            {
                if (symbols == null)
                {
                    lock (lockObj)
                        symbols ??= new DebugSymbols(Raw);
                }

                return symbols;
            }
        }

        #endregion
        #region SystemObjects

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DebugSystemObjects systemObjects;

        public DebugSystemObjects SystemObjects
        {
            get
            {
                if (systemObjects == null)
                {
                    lock (lockObj)
                        systemObjects ??= new DebugSystemObjects(Raw);
                }

                return systemObjects;
            }
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            advanced?.Dispose();
            clientInternal?.Dispose();
            control?.Dispose();
            dataModelScripting?.Dispose();
            dataSpaces?.Dispose();

            if (debugTargetCompositionBridge != null)
                Marshal.FinalReleaseComObject(debugTargetCompositionBridge.Raw);

            if (hostDataModelAccess != null)
                Marshal.FinalReleaseComObject(hostDataModelAccess.Raw);

            linkableProcessServer?.Dispose();
            modelQuery?.Dispose();
            plmClient?.Dispose();
            registers?.Dispose();
            serviceProvider?.Dispose();
            settings?.Dispose();
            symbols?.Dispose();
            systemObjects?.Dispose();

            advanced = null;
            clientInternal = null;
            control = null;
            dataModelScripting = null;
            dataSpaces = null;
            debugTargetCompositionBridge = null;
            hostDataModelAccess = null;
            linkableProcessServer = null;
            modelQuery = null;
            plmClient = null;
            registers = null;
            serviceProvider = null;
            settings = null;
            symbols = null;
            systemObjects = null;

            base.Dispose(disposing);

#if DEBUG
            Debug.Assert(remainingRefs == 0, $"RCW leak has occurred in DebugClient {GetHashCode()}: object was disposed but COM RefCount was still {remainingRefs}");
#endif
        }
    }
}
