using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataProcess.EnumAppDomain"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, appDomain = {appDomain}")]
    public struct EnumAppDomainResult
    {
        public IntPtr handle { get; }

        public XCLRDataAppDomain appDomain { get; }

        public EnumAppDomainResult(IntPtr handle, XCLRDataAppDomain appDomain)
        {
            this.handle = handle;
            this.appDomain = appDomain;
        }
    }
}