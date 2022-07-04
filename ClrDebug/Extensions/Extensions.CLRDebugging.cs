using static ClrDebug.Extensions;
using static ClrDebug.Extensions.CLRCreateInstanceInterfaces;

namespace ClrDebug
{
    public partial class CLRDebugging
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRDebugging"/> class from mscoree.
        /// </summary>
        public CLRDebugging() : base(CreateInstance<ICLRDebugging>(CLSID_CLRDebugging))
        {
        }
    }
}
