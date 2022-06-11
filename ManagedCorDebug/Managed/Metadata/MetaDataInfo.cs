using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class MetaDataInfo : ComObject<IMetaDataInfo>
    {
        public MetaDataInfo(IMetaDataInfo raw) : base(raw)
        {
        }

        #region IMetaDataInfo
        #region GetFileMapping

        public GetFileMappingResult FileMapping
        {
            get
            {
                HRESULT hr;
                GetFileMappingResult result;

                if ((hr = TryGetFileMapping(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        public HRESULT TryGetFileMapping(out GetFileMappingResult result)
        {
            /*HRESULT GetFileMapping(
            [Out] IntPtr ppvData,
            [Out] out ulong pcbData,
            [Out] out CorFileMapping pdwMappingType);*/
            IntPtr ppvData = default(IntPtr);
            ulong pcbData;
            CorFileMapping pdwMappingType;
            HRESULT hr = Raw.GetFileMapping(ppvData, out pcbData, out pdwMappingType);

            if (hr == HRESULT.S_OK)
                result = new GetFileMappingResult(ppvData, pcbData, pdwMappingType);
            else
                result = default(GetFileMappingResult);

            return hr;
        }

        #endregion
        #endregion
    }
}