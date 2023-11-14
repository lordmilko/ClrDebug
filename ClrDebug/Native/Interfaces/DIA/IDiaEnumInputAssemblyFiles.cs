using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [Guid("1C7FF653-51F7-457E-8419-B20F57EF7E4D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IDiaEnumInputAssemblyFiles
    {
        [PreserveSig]
        HRESULT NewEnum(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumVARIANT pRetVal);

        [PreserveSig]
        HRESULT get_count(
            [Out] out int pRetVal);

        [PreserveSig]
        HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile file);

        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile rgelt,
            [Out] out int pceltFetched);

        [PreserveSig]
        HRESULT Skip(
            [In] int celt);

        [PreserveSig]
        HRESULT Reset();

        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumInputAssemblyFiles ppenum);
    }
}
