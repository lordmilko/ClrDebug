using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E44474E7-99EC-40D5-9C94-7554EA45C4CF")]
    [ComImport]
    public interface IComponentStackUnwinderStackProviderInitializer
    {
        /// <summary>
        /// Initializes the stack provider. If 'provideInlineFrames' is set to true, the stack provider will directly look at symbols for each stack frame, ask about inline information at each call site, and insert inline frames into the frames provided.<para/>
        /// The default value for 'provideInlineFrames' without the initializer called is false. NOTE: The stack provider can only provide inline frames for symbol formats which are exposed through the use of a symbol provider.<para/>
        /// PDBs do not yet meet that classification.
        /// </summary>
        [PreserveSig]
        HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.U1)] bool provideInlineFrames);
    }
}
