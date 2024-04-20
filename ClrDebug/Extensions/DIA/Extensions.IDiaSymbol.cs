using System;

namespace ClrDebug.DIA
{
    public static partial class DiaExtensions
    {
        /// <summary>
        /// Retrieves the value of a constant.
        /// </summary>
        /// <param name="symbol">The <see cref="DiaSymbol"/> to retrieve the value of.</param>
        /// <param name="pRetVal">[in, out] A VARIANT object that is filled in with the value of a constant.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns S_FALSE or an error code.</returns>
        /// <remarks>
        /// The supplied VARIANT must be initialized before it is passed to this method. For more information, see the example.
        /// </remarks>
        public static HRESULT get_value(this IDiaSymbol symbol, out object pRetVal)
        {
            DiaVariant raw;
#pragma warning disable CS0618 // Type or member is obsolete
            var hr = symbol.get_value(out raw);
#pragma warning restore CS0618 // Type or member is obsolete

            if (hr == HRESULT.S_OK)
            {
                pRetVal = raw.Value;
                raw.Free();
            }
            else
                pRetVal = default;

            return hr;
        }
    }
}
