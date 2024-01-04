using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugServiceLayer.GetServiceDependencies"/> method.
    /// </summary>
    [DebuggerDisplay("pHardDependencies = {pHardDependencies}, pNumHardDependencies = {pNumHardDependencies}, pSoftDependencies = {pSoftDependencies}, pNumSoftDependencies = {pNumSoftDependencies}")]
    public struct GetServiceDependenciesResult
    {
        public Guid[] pHardDependencies { get; }

        public long pNumHardDependencies { get; }

        public Guid[] pSoftDependencies { get; }

        public long pNumSoftDependencies { get; }

        public GetServiceDependenciesResult(Guid[] pHardDependencies, long pNumHardDependencies, Guid[] pSoftDependencies, long pNumSoftDependencies)
        {
            this.pHardDependencies = pHardDependencies;
            this.pNumHardDependencies = pNumHardDependencies;
            this.pSoftDependencies = pSoftDependencies;
            this.pNumSoftDependencies = pNumSoftDependencies;
        }
    }
}
