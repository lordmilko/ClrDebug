#if !GENERATED_MARSHALLING

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ClrDebug.DIA;

namespace ClrDebug.CoClass
{
    /// <summary>
    /// An <see cref="IDiaDataSource"/> that does not use the system (COM) heap for allocating strings.<para/>
    ///
    /// A process may either make DiaSourceAlt objects or DiaSource objects, but not both.
    /// When using DiaSourceAlt all returned BSTR's are really LPCOLESTR and should not be
    /// used with other BSTR management routines, in particular they must be released using
    /// LocalFree( bstr )
    /// </summary>
    [Guid("91904831-49CA-4766-B95C-25397E2DD6DC")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class DiaSourceAltClass : IDiaDataSource, DiaSourceAlt
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT get_lastError(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT loadDataFromPdb([MarshalAs(UnmanagedType.LPWStr), In] string pdbPath);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT loadAndValidateDataFromPdb(
            [MarshalAs(UnmanagedType.LPWStr), In] string pdbPath,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid pcsig70,
            [In] int sig,
            [In] int age);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT loadDataForExe(
          [MarshalAs(UnmanagedType.LPWStr), In] string executable,
          [MarshalAs(UnmanagedType.LPWStr), In] string searchPath,
          [MarshalAs(UnmanagedType.Interface), In] object pCallback);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT loadDataFromIStream([MarshalAs(UnmanagedType.Interface), In] IStream pIStream);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT openSession([MarshalAs(UnmanagedType.Interface)] out IDiaSession ppSession);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT loadDataFromCodeViewInfo(
            [MarshalAs(UnmanagedType.LPWStr), In] string executable,
            [MarshalAs(UnmanagedType.LPWStr), In] string searchPath,
            [In] int cbCvInfo,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] pbCvInfo,
            [MarshalAs(UnmanagedType.Interface), In] object pCallback);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT loadDataFromMiscInfo(
            [MarshalAs(UnmanagedType.LPWStr), In] string executable,
            [MarshalAs(UnmanagedType.LPWStr), In] string searchPath,
            [In] int timeStampExe,
            [In] int timeStampDbg,
            [In] int sizeOfExe,
            [In] int cbMiscInfo,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] byte[] pbMiscInfo,
            [MarshalAs(UnmanagedType.Interface), In] object pCallback);
    }
}

#endif
