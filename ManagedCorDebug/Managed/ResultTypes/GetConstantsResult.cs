using System;
using System.Security.Cryptography;

namespace ManagedCorDebug
{
    public struct GetConstantsResult
    {
        public int PcConstants { get; }

        public IntPtr Constants { get; }

        public GetConstantsResult(int pcConstants, IntPtr constants)
        {
            PcConstants = pcConstants;
            Constants = constants;
        }
    }
}