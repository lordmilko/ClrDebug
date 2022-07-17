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
    }
}
