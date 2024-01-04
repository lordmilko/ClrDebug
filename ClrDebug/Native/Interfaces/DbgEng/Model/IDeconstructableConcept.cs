using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F798139E-1B2C-4077-8D87-9FA5D044F3EB")]
    [ComImport]
    public interface IDeconstructableConcept
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
