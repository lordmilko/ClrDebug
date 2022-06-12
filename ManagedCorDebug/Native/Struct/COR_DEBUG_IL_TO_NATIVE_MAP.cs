using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains the offsets that are used to map Microsoft intermediate language (MSIL) code to native code.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_DEBUG_IL_TO_NATIVE_MAP
    {
        /// <summary>
        /// The offset of the MSIL code.
        /// </summary>
        public int ilOffset;

        /// <summary>
        /// The offset of the start of the native code.
        /// </summary>
        public int nativeStartOffset;

        /// <summary>
        /// The offset of the end of the native code.
        /// </summary>
        public int nativeEndOffset;
    }
}