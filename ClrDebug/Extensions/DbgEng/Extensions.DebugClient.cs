using System.Diagnostics;

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
                    advanced = new DebugAdvanced(Raw);

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
                    clientInternal = new DebugClientInternal(Raw);

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
                    control = new DebugControl(Raw);

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
                    dataModelScripting = new DebugDataModelScripting(Raw);

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
                    dataSpaces = new DebugDataSpaces(Raw);

                return dataSpaces;
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
                    hostDataModelAccess = new HostDataModelAccess(AsInterface<IHostDataModelAccess>());

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
                    linkableProcessServer = new DebugLinkableProcessServer(Raw);

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
                    modelQuery = new DebugModelQuery(Raw);

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
                    plmClient = new DebugPlmClient(Raw);

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
                    registers = new DebugRegisters(Raw);

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
                    serviceProvider = new DebugServiceProvider(Raw);

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
                    settings = new DebugSettings(Raw);

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
                    symbols = new DebugSymbols(Raw);

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
                    systemObjects = new DebugSystemObjects(Raw);

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
