using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_EXECUTION_CONTEXT_TRANSLATION. Defines a means of translating from one context to another (e.g.: native to WoW, emulator to emulate, etc...).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("BE5E232C-1D4B-4983-A520-383DA865DA1C")]
    [ComImport]
    public interface ISvcContextTranslation
    {
        /// <summary>
        /// Gets a translated context record for the given execution unit (thread or core).
        /// </summary>
        [PreserveSig]
        HRESULT GetTranslatedContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit execUnit,
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext context);

        /// <summary>
        /// Sets a translated context record to the given execution unit (thread or core).
        /// </summary>
        [PreserveSig]
        HRESULT SetTranslatedContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit execUnit,
            [In] SvcContextFlags contextFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext context);
    }
}
