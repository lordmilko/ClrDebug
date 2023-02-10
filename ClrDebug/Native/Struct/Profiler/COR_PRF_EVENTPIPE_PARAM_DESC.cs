using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Describes the parameter name and type for an EventPipe event.
    /// </summary>
    /// <remarks>
    /// The COR_PRF_EVENTPIPE_PARAM_DESC structure is used by the <see cref="ICorProfilerInfo12.EventPipeDefineEvent"/>
    /// method to define the parameter types of the event being defined.
    /// </remarks>
    [ComConversionLoss]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_PRF_EVENTPIPE_PARAM_DESC
    {
        /// <summary>
        /// The type of the parameter.
        /// </summary>
        public COR_PRF_EVENTPIPE_PARAM_TYPE type;

        /// <summary>
        /// The element type if this parameter is an array type.
        /// </summary>
        public COR_PRF_EVENTPIPE_PARAM_TYPE elementType;

        /// <summary>
        /// A wide character string containing the name of the parameter.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string name;
    }
}
