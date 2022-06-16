using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameGetBlobFromImage"/> method.
    /// </summary>
    [DebuggerDisplay("pbBlob = {pbBlob}, pcbBlob = {pcbBlob}")]
    public struct StrongNameGetBlobFromImageResult
    {
        /// <summary>
        /// A buffer to contain the binary representation of the image.
        /// </summary>
        public IntPtr pbBlob { get; }

        /// <summary>
        /// The requested maximum size, in bytes, of pbBlob. Upon return, the actual size, in bytes, of pbBlob.
        /// </summary>
        public int pcbBlob { get; }

        public StrongNameGetBlobFromImageResult(IntPtr pbBlob, int pcbBlob)
        {
            this.pbBlob = pbBlob;
            this.pcbBlob = pcbBlob;
        }
    }
}