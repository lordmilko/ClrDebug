using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a means by which C++ mangled names can be demangled.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("31C02035-D414-4BE0-9FE9-CFA8C88B33E9")]
    [ComImport]
    public interface ISvcNameDemangler
    {
        /// <summary>
        /// Takes a (potentially) mangled name (e.g.: a C++ mangled name) and demangles it given a set of options. If this mangled name is not recognized, the demangler should return E_UNHANDLED_REQUEST_TYPE as it is often the case that multiple demanglers will be aggregated in one container.<para/>
        /// NOTE: The source language is often unspecified and will be SvcSourceLanguageUnknown. In addition, the machine architecture is often unspecified and will be GUID_NULL.<para/>
        /// These parameters are optional and provide hints to the demangler if present.
        /// </summary>
        [PreserveSig]
        HRESULT DemangleName(
            [In] SvcDemanglerFlags demangleFlags,
            [In] SvcSourceLanguage sourceLanguage,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid machineArch,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMangledName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDemangledName);
    }
}
