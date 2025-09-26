using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a lexical scope within code at a particular stack frame defined by its context record. An implementation of ISvcSymbolSetScopeFrame *MUST* QI for ISvcSymbolSetScope.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("58B61CE1-875D-421F-BA4F-B8FFF3DE0964")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcSymbolSetScopeFrame
    {
        /// <summary>
        /// Gets the context for the scope frame.
        /// </summary>
        [PreserveSig]
        HRESULT GetContext(
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext registerContext);
    }
}
