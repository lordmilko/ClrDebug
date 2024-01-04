using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B886A5F0-96CA-4086-B7EB-24458283C4C1")]
    [ComImport]
    public interface ISvcSymbolVariantInfo
    {
        [PreserveSig]
        HRESULT HasVariantMembers(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pHasVariantMembers);
        
        [PreserveSig]
        HRESULT IsDiscriminator(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsDiscriminator);
        
        [PreserveSig]
        HRESULT IsDiscriminated(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsDiscriminated,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppDiscriminator);
        
        [PreserveSig]
        HRESULT GetDiscriminatorValues(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pLowRange,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pHighRange);
        
        [PreserveSig]
        HRESULT EnumerateDiscriminatorValues(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolDiscriminatorValuesEnumerator ppEnum);
    }
}
