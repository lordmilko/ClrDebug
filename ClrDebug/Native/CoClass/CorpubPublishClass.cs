using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.CoClass
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("047A9A40-657E-11D3-8D5B-00104B35E7EF")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComClass]
#endif
    public partial class CorpubPublishClass :
        ICorPublish,
        CorpubPublish,
        ICorPublishProcess,
        ICorPublishAppDomain,
        ICorPublishProcessEnum,
        ICorPublishAppDomainEnum
    {
        [PreserveSig]
        public virtual extern HRESULT EnumProcesses(
          [In] COR_PUB_ENUMPROCESS Type,
          [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishProcessEnum ppIEnum);

        [PreserveSig]
        public virtual extern HRESULT GetProcess([In] int pid, [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishProcess ppProcess);

        [PreserveSig]
        public virtual extern HRESULT IsManaged([Out, MarshalAs(UnmanagedType.Bool)] out bool pbManaged);

        [PreserveSig]
        public virtual extern HRESULT EnumAppDomains([Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishAppDomainEnum ppEnum);

        [PreserveSig]
        public virtual extern HRESULT GetProcessID([Out] out int pid);

        [PreserveSig]
        public virtual extern HRESULT GetDisplayName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2)] char[] szName);

        [PreserveSig]
        public virtual extern HRESULT GetID([Out] out int puId);

        [PreserveSig]
        public virtual extern HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2)] char[] szName);

        [PreserveSig]
        public virtual extern HRESULT Skip([In] int celt);

        [PreserveSig]
        public virtual extern HRESULT Reset();

        [PreserveSig]
        public virtual extern HRESULT Clone([Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishEnum ppEnum);

        [PreserveSig]
        public virtual extern HRESULT GetCount([Out] out int pcelt);

        [PreserveSig]
        public virtual extern HRESULT Next(
          [In] int celt,
          [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishProcess objects,
          [Out] out int pceltFetched);

        [PreserveSig]
        public virtual extern HRESULT ICorPublishAppDomainEnum_Skip([In] int celt);

        [PreserveSig]
        public virtual extern HRESULT ICorPublishAppDomainEnum_Reset();

        [PreserveSig]
        public virtual extern HRESULT ICorPublishAppDomainEnum_Clone([Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishEnum ppEnum);

        [PreserveSig]
        public virtual extern HRESULT ICorPublishAppDomainEnum_GetCount([Out] out int pcelt);

        [PreserveSig]
        public virtual extern HRESULT Next(
          [In] int celt,
          [Out, MarshalAs(UnmanagedType.Interface)] out ICorPublishAppDomain objects,
          [Out] out int pceltFetched);
    }
}
