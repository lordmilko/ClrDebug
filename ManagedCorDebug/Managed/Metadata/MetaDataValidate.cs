using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to validate metadata signatures.
    /// </summary>
    public class MetaDataValidate : ComObject<IMetaDataValidate>
    {
        public MetaDataValidate(IMetaDataValidate raw) : base(raw)
        {
        }

        #region IMetaDataValidate
        #region ValidatorInit

        /// <summary>
        /// Sets a flag that specifies the type of the module in the current metadata scope, and registers the specified callback method for validation errors.
        /// </summary>
        /// <param name="dwModuleType">[in] A value of the <see cref="CorValidatorModuleType"/> enumeration that specifies the type of the module in the current metadata scope.</param>
        /// <param name="pUnk">[in] A pointer to an IUnknown instance that serves as a function callback for validation errors.</param>
        public void ValidatorInit(int dwModuleType, object pUnk)
        {
            HRESULT hr;

            if ((hr = TryValidatorInit(dwModuleType, pUnk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets a flag that specifies the type of the module in the current metadata scope, and registers the specified callback method for validation errors.
        /// </summary>
        /// <param name="dwModuleType">[in] A value of the <see cref="CorValidatorModuleType"/> enumeration that specifies the type of the module in the current metadata scope.</param>
        /// <param name="pUnk">[in] A pointer to an IUnknown instance that serves as a function callback for validation errors.</param>
        public HRESULT TryValidatorInit(int dwModuleType, object pUnk)
        {
            /*HRESULT ValidatorInit(int dwModuleType, [MarshalAs(UnmanagedType.Interface)] object pUnk);*/
            return Raw.ValidatorInit(dwModuleType, pUnk);
        }

        #endregion
        #region ValidateMetaData

        /// <summary>
        /// Validates the metadata signatures of the objects in the current metadata scope.
        /// </summary>
        public void ValidateMetaData()
        {
            HRESULT hr;

            if ((hr = TryValidateMetaData()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Validates the metadata signatures of the objects in the current metadata scope.
        /// </summary>
        public HRESULT TryValidateMetaData()
        {
            /*HRESULT ValidateMetaData();*/
            return Raw.ValidateMetaData();
        }

        #endregion
        #endregion
    }
}