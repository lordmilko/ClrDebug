using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("46329742-2733-41FA-A125-6EEF620998B1")]
    [ComImport]
    public interface ISvcStackProviderPartialPhysicalFrame
    {
        [PreserveSig]
        HRESULT GetInstructionPointer(
            [Out] out long instructionPointer);
        
        [PreserveSig]
        HRESULT GetStackPointer(
            [Out] out long stackPointer);
        
        [PreserveSig]
        HRESULT GetFramePointer(
            [Out] out long framePointer);
    }
}
