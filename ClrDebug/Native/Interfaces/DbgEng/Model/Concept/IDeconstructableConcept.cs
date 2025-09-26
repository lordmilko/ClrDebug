using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F798139E-1B2C-4077-8D87-9FA5D044F3EB")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDeconstructableConcept
    {
        [PreserveSig]
        HRESULT GetConstructableModelName(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.BStr)] out string constructableModelName);
        
        [PreserveSig]
        HRESULT GetConstructorArgumentCount(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out] out long argCount);
        
        [PreserveSig]
        HRESULT GetConstructorArguments(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In] long argCount,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] constructorArguments);
    }
}
