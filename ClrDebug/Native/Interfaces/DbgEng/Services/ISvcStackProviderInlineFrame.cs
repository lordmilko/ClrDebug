using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4D0BDD20-61CD-4F18-936A-7E9350B30966")]
    [ComImport]
    public interface ISvcStackProviderInlineFrame
    {
        /// <summary>
        /// Represents an inline stack frame within a physical frame.
        /// </summary>
        [PreserveSig]
        HRESULT GetUnderlyingFrame(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcStackProviderFrame ppFrame);

        /// <summary>
        /// Gets the inline depth of this particular stack frame.
        /// </summary>
        [PreserveSig]
        long GetInlineDepth();

        /// <summary>
        /// Gets the maximal inline depth of the stack at this particular inline frame's location. In other words, for a given @pc, if there are 3 nested inlne frames at this point, all three frames would return 3 for GetMaximalInlineDepth() and would return 3, 2, and 1 respectively (going through an unwind) for GetInlineDepth().
        /// </summary>
        [PreserveSig]
        long GetMaximalInlineDepth();
    }
}
