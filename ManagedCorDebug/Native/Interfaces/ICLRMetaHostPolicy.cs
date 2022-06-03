using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E2190695-77B2-492E-8E14-C4B3A7FDD593")]
    [ComImport]
    public interface ICLRMetaHostPolicy
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRequestedRuntime(
            [In] METAHOST_POLICY_FLAGS dwPolicyFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzBinary,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pCfgStream,
            [MarshalAs(UnmanagedType.LPWStr), In] [Out]
            StringBuilder pwzVersion,
            [In] [Out] ref uint pcchVersion,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzImageVersion,
            [In] [Out] ref uint pcchImageVersion,
            out METAHOST_CONFIG_FLAGS pdwConfigFlags,
            [In] ref Guid riid,
            [Out] out object ppRuntime);
    }
}