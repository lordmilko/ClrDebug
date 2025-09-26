using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1A9409F1-F0E0-4B48-9A4E-5783548FB57A")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IConstructableConcept
    {
        [PreserveSig]
        HRESULT CreateInstance(
            [In] long argCount,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IModelObject[] ppArguments,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppInstance);
    }
}
