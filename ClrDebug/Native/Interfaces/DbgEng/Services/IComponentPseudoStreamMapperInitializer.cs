using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A325D2E2-39BB-48D9-875A-8DE64F62D282")]
    [ComImport]
    public interface IComponentPseudoStreamMapperInitializer
    {
        /// <summary>
        /// Initializes the component.
        /// </summary>
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcDebugSourceFile pUnderlyingFile);
    }
}
