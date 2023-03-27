using System;
using System.Collections.Generic;

namespace ClrDebug
{
    public static partial class Extensions
    {
        /// <summary>
        /// Enumerates the AppDomains in the current process.
        /// </summary>
        /// <typeparam name="T">The type of value the domains should be casted to, e.g. <see cref="AppDomain"/> or _AppDomain.</typeparam>
        /// <param name="corRuntimeHost">The <see cref="CorRuntimeHost"/> that should be used to enumerate AppDomains.</param>
        /// <returns>The AppDomains in the current process.</returns>
        public static T[] EnumDomains<T>(this CorRuntimeHost corRuntimeHost)
        {
            var results = new List<T>();

            var hEnum = corRuntimeHost.EnumDomains();

            try
            {
                while (corRuntimeHost.TryNextDomain(hEnum, out var appDomain).ThrowOnFailed() != HRESULT.S_FALSE)
                    results.Add((T) appDomain);

                return results.ToArray();
            }
            finally
            {
                corRuntimeHost.CloseEnum(hEnum);
            }
        }
    }
}
