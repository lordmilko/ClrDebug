using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Describes a component which is a conditional implementation of a particular service (e.g.: the disassembly service for the AMD64 architecture).<para/>
    /// Conditional services should only be used when the functionality of the service (as provided by its methods) never needs to be dynamic (e.g.: directing to one of several choices based on incoming arguments).
    /// </summary>
    [DebuggerDisplay("StructSize = {StructSize}, ServiceGuid = {ServiceGuid.ToString(),nq}, PrimaryCondition = {PrimaryCondition.ToString(),nq}, SecondaryCondition = {SecondaryCondition.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcConditionalServiceInformation
    {
        /// <summary>
        /// Always must be initialzed to sizeof(SvcConditionalServiceInformation).
        /// </summary>
        public int StructSize;

        /// <summary>
        /// The GUID of the service (DEBUG_SERVICE_*).
        /// </summary>
        public Guid ServiceGuid;

        /// <summary>
        /// A GUID identifying the primary condition (e.g.: an architecture GUID).
        /// </summary>
        public Guid PrimaryCondition;

        /// <summary>
        /// A GUID identifying any secondary condition (may be GUID_NULL).
        /// </summary>
        public Guid SecondaryCondition;
    }
}
