using System;

namespace ClrDebug.DbgEng
{
    public class SvcNameDemangler : ComObject<ISvcNameDemangler>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcNameDemangler"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcNameDemangler(ISvcNameDemangler raw) : base(raw)
        {
        }

        #region ISvcNameDemangler
        #region DemangleName

        public string DemangleName(SvcDemanglerFlags demangleFlags, SvcSourceLanguage sourceLanguage, Guid machineArch, string pwszMangledName)
        {
            string pDemangledName;
            TryDemangleName(demangleFlags, sourceLanguage, machineArch, pwszMangledName, out pDemangledName).ThrowDbgEngNotOK();

            return pDemangledName;
        }

        public HRESULT TryDemangleName(SvcDemanglerFlags demangleFlags, SvcSourceLanguage sourceLanguage, Guid machineArch, string pwszMangledName, out string pDemangledName)
        {
            /*HRESULT DemangleName(
            [In] SvcDemanglerFlags demangleFlags,
            [In] SvcSourceLanguage sourceLanguage,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid machineArch,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMangledName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDemangledName);*/
            return Raw.DemangleName(demangleFlags, sourceLanguage, machineArch, pwszMangledName, out pDemangledName);
        }

        #endregion
        #endregion
    }
}
