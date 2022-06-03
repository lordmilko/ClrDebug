using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("9B2C54E4-119F-4D6F-B402-527603266D69")]
    [ComImport]
    public interface ICorDebugProcess7
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetWriteableMetadataUpdateMode(WriteableMetadataUpdateMode flags);
    }
}