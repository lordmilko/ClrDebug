using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("31C02035-D414-4BE0-9FE9-CFA8C88B33E9")]
    [ComImport]
    public interface ISvcNameDemangler
    {
        [PreserveSig]
        HRESULT DemangleName(
            [In] SvcDemanglerFlags demangleFlags,
            [In] SvcSourceLanguage sourceLanguage,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid machineArch,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszMangledName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pDemangledName);
    }
}
