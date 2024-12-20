using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a way to describe how a compiler/optimizer has inlined functions at a particular location in the the module.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CB416186-14D7-4DED-8EC2-9B45CBF06845")]
    [ComImport]
    public interface ISvcSymbolSetInlineFrameResolution
    {
        /// <summary>
        /// For a given offset representing a code location within the image, return the depth of inlining at this particular offset.
        /// </summary>
        [PreserveSig]
        HRESULT GetInlineDepthAtOffset(
            [In] long moduleOffset,
            [Out] out long inlineDepth);

        /// <summary>
        /// For a given offset representing a code location within the image, return the N-th inline function at this particular offset.<para/>
        /// If there was nested inlining such as inlined_bat() { ... } inlined_bar() { noninlined_baz(); inlined_bat(); } foo() { inlined_bar(); } A call to GetInlineDepthAtOffset for an instruction in foo which was actually inlined from inlined_bat via inlined_bar would return 2.<para/>
        /// Similarly, GetInlinedFunctionAtOffset() passing an inlineDepth of 1: Would return inlined_bar 2: Would return inlined_bat This method returns a SvcSymbolInlinedFunction which represents the inlined function.
        /// </summary>
        [PreserveSig]
        HRESULT GetInlinedFunctionAtOffset(
            [In] long moduleOffset,
            [In] long inlineDepth,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol inlineFunction);
    }
}
