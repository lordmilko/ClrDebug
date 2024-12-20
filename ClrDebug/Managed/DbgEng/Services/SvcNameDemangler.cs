using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a means by which C++ mangled names can be demangled.
    /// </summary>
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

        /// <summary>
        /// Takes a (potentially) mangled name (e.g.: a C++ mangled name) and demangles it given a set of options. If this mangled name is not recognized, the demangler should return E_UNHANDLED_REQUEST_TYPE as it is often the case that multiple demanglers will be aggregated in one container.<para/>
        /// NOTE: The source language is often unspecified and will be SvcSourceLanguageUnknown. In addition, the machine architecture is often unspecified and will be GUID_NULL.<para/>
        /// These parameters are optional and provide hints to the demangler if present.
        /// </summary>
        public string DemangleName(SvcDemanglerFlags demangleFlags, SvcSourceLanguage sourceLanguage, Guid machineArch, string pwszMangledName)
        {
            string pDemangledName;
            TryDemangleName(demangleFlags, sourceLanguage, machineArch, pwszMangledName, out pDemangledName).ThrowDbgEngNotOK();

            return pDemangledName;
        }

        /// <summary>
        /// Takes a (potentially) mangled name (e.g.: a C++ mangled name) and demangles it given a set of options. If this mangled name is not recognized, the demangler should return E_UNHANDLED_REQUEST_TYPE as it is often the case that multiple demanglers will be aggregated in one container.<para/>
        /// NOTE: The source language is often unspecified and will be SvcSourceLanguageUnknown. In addition, the machine architecture is often unspecified and will be GUID_NULL.<para/>
        /// These parameters are optional and provide hints to the demangler if present.
        /// </summary>
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
