namespace ClrDebug
{
    /// <summary>
    /// The STREAM_SEEK enumeration values specify the origin from which to calculate the new seek-pointer location.
    /// They are used for the dworigin parameter in the IStream::Seek method. The new seek position is calculated
    /// using this value and the dlibMove parameter.
    /// </summary>
    public enum STREAM_SEEK
    {
        /// <summary>
        /// The new seek pointer is an offset relative to the beginning of the stream. In this case, the dlibMove parameter is the new seek
        /// position relative to the beginning of the stream.
        /// </summary>
        STREAM_SEEK_SET = 0,

        /// <summary>
        /// The new seek pointer is an offset relative to the current seek pointer location. In this case, the dlibMove parameter is the signed
        /// displacement from the current seek position.
        /// </summary>
        STREAM_SEEK_CUR = 1,

        /// <summary>
        /// The new seek pointer is an offset relative to the end of the stream. In this case, the dlibMove parameter is the new seek position
        /// relative to the end of the stream.
        /// </summary>
        STREAM_SEEK_END = 2
    }
}
