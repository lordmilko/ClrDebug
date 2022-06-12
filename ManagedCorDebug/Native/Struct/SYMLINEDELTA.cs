using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides information to the symbol handler about methods that were moved as a result of edits.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct SYMLINEDELTA
    {
        /// <summary>
        /// The method's metadata token.
        /// </summary>
        public mdMethodDef mdMethod;

        /// <summary>
        /// The number of lines the method was moved.
        /// </summary>
        public int delta;
    }
}