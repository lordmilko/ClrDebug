using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Returns certain attributes of the stack. This interface is optional on most frame types. It is mandatory on any generic frame and optional on other types.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("96CE81F7-C6B9-4665-B2E5-6EB229079091")]
    [ComImport]
    public interface ISvcStackProviderFrameAttributes
    {
        /// <summary>
        /// Gets the "textual representation" of this stack frame. The meaning of this can vary by stack provider. Conceptually, this is what a debugger would place in a "call stack" window representing this frame.<para/>
        /// Anyone who implements ISvcStackProviderFrameAttributes *MUST* implement GetFrameText.
        /// </summary>
        [PreserveSig]
        HRESULT GetFrameText(
            [Out, MarshalAs(UnmanagedType.BStr)] out string frameText);

        /// <summary>
        /// Gets the "source association" for this stack frame (e.g.: the source file, line number, and column number). This is an optional attribute.<para/>
        /// It is legal for any implementation to E_NOTIMPL this. The line number and column number are optional (albeit a column cannot be provided without a line).<para/>
        /// A client may legally return a value of zero for either of these indicating that it is not available or not relevant (e.g.: compiler generated code which does not necessarily map to a line of code may legally return 0 for the source line).
        /// </summary>
        [PreserveSig]
        HRESULT GetSourceAssociation(
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFile,
            [Out] out long sourceLine,
            [Out] out long sourceColumn);
    }
}
