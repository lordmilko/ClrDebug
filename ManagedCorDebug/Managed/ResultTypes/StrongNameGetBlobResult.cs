using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.StrongNameGetBlob"/> method.
    /// </summary>
    public struct StrongNameGetBlobResult
    {
        /// <summary>
        /// [in] The buffer into which to load the executable file.
        /// </summary>
        public IntPtr pbBlob { get; }

        /// <summary>
        /// [in, out] The requested maximum size, in bytes, of pbBlob. Upon return, the actual size, in bytes, of pbBlob.
        /// </summary>
        public int pcbBlob { get; }

        public StrongNameGetBlobResult(IntPtr pbBlob, int pcbBlob)
        {
            this.pbBlob = pbBlob;
            this.pcbBlob = pcbBlob;
        }
    }
}