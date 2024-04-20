using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    public static partial class DiaExtensions
    {
        /// <summary>
        /// Sets image headers to enable relative virtual address translation.
        /// </summary>
        /// <param name="diaAddressMap">The object on which this method operates.</param>
        /// <param name="pbData">[in] An array of IMAGE_SECTION_HEADER structures to be used as the image headers.</param>
        /// <param name="originalHeaders">[in] Set to FALSE if the image headers are from the new image, TRUE if they reflect the original image prior to an upgrade.<para/>
        /// Typically, this would be set to TRUE only in combination with calls to the IDiaAddressMap method.</param>
        /// <remarks>
        /// The IMAGE_SECTION_HEADER structure is declared in Winnt.h and represents the image section header format of the
        /// executable. Relative virtual address calculations depend upon the IMAGE_SECTION_HEADER values. Usually, the DIA
        /// retrieves these from the program database (.pdb) file. If these values are missing, the DIA is unable to calculate
        /// relative virtual addresses and the IDiaAddressMap method returns FALSE. The client must then call the IDiaAddressMap
        /// method to enable the relative virtual address calculations after providing the missing image headers from the image
        /// itself.
        /// </remarks>
        public static void SetImageHeaders(this DiaAddressMap diaAddressMap, IMAGE_SECTION_HEADER[] pbData, bool originalHeaders) =>
            TrySetImageHeaders(diaAddressMap, pbData, originalHeaders).ThrowOnNotOK();

        /// <summary>
        /// Sets image headers to enable relative virtual address translation.
        /// </summary>
        /// <param name="diaAddressMap">The object on which this method operates.</param>
        /// <param name="pbData">[in] An array of IMAGE_SECTION_HEADER structures to be used as the image headers.</param>
        /// <param name="originalHeaders">[in] Set to FALSE if the image headers are from the new image, TRUE if they reflect the original image prior to an upgrade.<para/>
        /// Typically, this would be set to TRUE only in combination with calls to the IDiaAddressMap method.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// The IMAGE_SECTION_HEADER structure is declared in Winnt.h and represents the image section header format of the
        /// executable. Relative virtual address calculations depend upon the IMAGE_SECTION_HEADER values. Usually, the DIA
        /// retrieves these from the program database (.pdb) file. If these values are missing, the DIA is unable to calculate
        /// relative virtual addresses and the IDiaAddressMap method returns FALSE. The client must then call the IDiaAddressMap
        /// method to enable the relative virtual address calculations after providing the missing image headers from the image
        /// itself.
        /// </remarks>
        public static unsafe HRESULT TrySetImageHeaders(this DiaAddressMap diaAddressMap, IMAGE_SECTION_HEADER[] pbData, bool originalHeaders)
        {
            if (pbData == null)
                return diaAddressMap.TrySetImageHeaders(0, IntPtr.Zero, originalHeaders);

            fixed (IMAGE_SECTION_HEADER* buffer = pbData)
            {
                return diaAddressMap.TrySetImageHeaders(pbData.Length * Marshal.SizeOf<IMAGE_SECTION_HEADER>(), (IntPtr)buffer, originalHeaders);
            }
        }
    }
}
