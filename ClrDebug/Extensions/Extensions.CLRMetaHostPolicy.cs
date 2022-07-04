using static ClrDebug.Extensions;
using static ClrDebug.Extensions.CLRCreateInstanceInterfaces;

namespace ClrDebug
{
    public partial class CLRMetaHostPolicy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRMetaHostPolicy"/> class from mscoree.
        /// </summary>
        public CLRMetaHostPolicy() : base(CreateInstance<ICLRMetaHostPolicy>(CLSID_CLRMetaHostPolicy))
        {
        }
    }
}
