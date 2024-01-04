using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("073DE56A-473E-4A8A-A059-DA7A185B2F90")]
    [ComImport]
    public interface ISvcSourceFile
    {
        [PreserveSig]
        long GetId();
        
        [PreserveSig]
        HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);
        
        [PreserveSig]
        HRESULT GetPath(
            [Out, MarshalAs(UnmanagedType.BStr)] out string path);
        
        [PreserveSig]
        long GetHashDataSize();
        
        [PreserveSig]
        HRESULT GetHashData(
            [In] long hashDataSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] pHashData,
            [Out] out SvcHashAlgorithm pHashAlgorithm);
        
        [PreserveSig]
        HRESULT GetCompilationUnits(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator cuEnumerator);
    }
}
