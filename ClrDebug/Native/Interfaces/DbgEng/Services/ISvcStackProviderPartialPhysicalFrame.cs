using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("46329742-2733-41FA-A125-6EEF620998B1")]
    [ComImport]
    public interface ISvcStackProviderPartialPhysicalFrame
    {
        /// <summary>
        /// Gets the instruction pointer for this partial physical frame. This is the *MINIMUM MUST* implement for a partial physical frame.<para/>
        /// All other Get* methods within ISvcStackProviderPartialPhysicalFrame may legally return E_NOT_SET.
        /// </summary>
        [PreserveSig]
        HRESULT GetInstructionPointer(
            [Out] out long instructionPointer);

        /// <summary>
        /// Gets the stack pointer for this partial physical frame. This may return E_NOT_SET indicating that there is no available stack pointer value for this partial frame.<para/>
        /// All users of a partial physical frame must be able to deal with such.
        /// </summary>
        [PreserveSig]
        HRESULT GetStackPointer(
            [Out] out long stackPointer);

        /// <summary>
        /// Gets the frame pointer for this partial physical frame. This may return E_NOT_SET indicating that there is no available frame pointer value for this partial frame.<para/>
        /// All users of a partial physical frame must be able to deal with such.
        /// </summary>
        [PreserveSig]
        HRESULT GetFramePointer(
            [Out] out long framePointer);
    }
}
