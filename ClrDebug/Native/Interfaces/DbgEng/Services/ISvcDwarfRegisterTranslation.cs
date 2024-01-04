using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A61B284D-EC7D-4EE7-A3B0-99B59F171F9A")]
    [ComImport]
    public interface ISvcDwarfRegisterTranslation
    {
        [PreserveSig]
        HRESULT TranslateFromAbstractId(
            [In] SvcAbstractRegister abstractId,
            [Out] out int domainId);
        
        [PreserveSig]
        HRESULT TranslateTypicalCfa(
            [Out] out SvcSymbolLocation cfaLocation);
    }
}
