using System;
using System.Security.Cryptography;

namespace ManagedCorDebug
{
    public struct GetConstantsResult
    {
        public uint PcConstants { get; }

        public IntPtr Constants { get; }

        public GetConstantsResult(uint pcConstants, IntPtr constants)
        {
            PcConstants = pcConstants;
            Constants = constants;
        }
    }
}