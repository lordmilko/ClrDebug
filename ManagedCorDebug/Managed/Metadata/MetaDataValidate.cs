using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class MetaDataValidate : ComObject<IMetaDataValidate>
    {
        public MetaDataValidate(IMetaDataValidate raw) : base(raw)
        {
        }

        #region IMetaDataValidate
        #region ValidatorInit

        public void ValidatorInit(uint dwModuleType, object pUnk)
        {
            HRESULT hr;

            if ((hr = TryValidatorInit(dwModuleType, pUnk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryValidatorInit(uint dwModuleType, object pUnk)
        {
            /*HRESULT ValidatorInit(uint dwModuleType, [MarshalAs(UnmanagedType.Interface)] object pUnk);*/
            return Raw.ValidatorInit(dwModuleType, pUnk);
        }

        #endregion
        #region ValidateMetaData

        public void ValidateMetaData()
        {
            HRESULT hr;

            if ((hr = TryValidateMetaData()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryValidateMetaData()
        {
            /*HRESULT ValidateMetaData();*/
            return Raw.ValidateMetaData();
        }

        #endregion
        #endregion
    }
}