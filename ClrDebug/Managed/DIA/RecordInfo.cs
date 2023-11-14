using System;
using ClrDebug.TypeLib;

namespace ClrDebug.DIA
{
    public class RecordInfo : ComObject<IRecordInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecordInfo"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public RecordInfo(IRecordInfo raw) : base(raw)
        {
        }

        #region IRecordInfo
        #region Guid

        public Guid Guid
        {
            get
            {
                Guid pguid;
                TryGetGuid(out pguid).ThrowOnNotOK();

                return pguid;
            }
        }

        public HRESULT TryGetGuid(out Guid pguid)
        {
            /*HRESULT GetGuid(
            [Out] out Guid pguid);*/
            return Raw.GetGuid(out pguid);
        }

        #endregion
        #region Name

        public string Name
        {
            get
            {
                string pbstrName;
                TryGetName(out pbstrName).ThrowOnNotOK();

                return pbstrName;
            }
        }

        public HRESULT TryGetName(out string pbstrName)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrName);*/
            return Raw.GetName(out pbstrName);
        }

        #endregion
        #region Size

        public int Size
        {
            get
            {
                int pcbSize;
                TryGetSize(out pcbSize).ThrowOnNotOK();

                return pcbSize;
            }
        }

        public HRESULT TryGetSize(out int pcbSize)
        {
            /*HRESULT GetSize(
            [Out] out int pcbSize);*/
            return Raw.GetSize(out pcbSize);
        }

        #endregion
        #region TypeInfo

        public TypeInfo TypeInfo
        {
            get
            {
                TypeInfo ppTypeInfoResult;
                TryGetTypeInfo(out ppTypeInfoResult).ThrowOnNotOK();

                return ppTypeInfoResult;
            }
        }

        public HRESULT TryGetTypeInfo(out TypeInfo ppTypeInfoResult)
        {
            /*HRESULT GetTypeInfo(
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeInfo ppTypeInfo);*/
            ITypeInfo ppTypeInfo;
            HRESULT hr = Raw.GetTypeInfo(out ppTypeInfo);

            if (hr == HRESULT.S_OK)
                ppTypeInfoResult = new TypeInfo(ppTypeInfo);
            else
                ppTypeInfoResult = default(TypeInfo);

            return hr;
        }

        #endregion
        #region RecordInit

        public void RecordInit(IntPtr pvNew)
        {
            TryRecordInit(pvNew).ThrowOnNotOK();
        }

        public HRESULT TryRecordInit(IntPtr pvNew)
        {
            /*HRESULT RecordInit(
            [Out] IntPtr pvNew);*/
            return Raw.RecordInit(pvNew);
        }

        #endregion
        #region RecordClear

        public void RecordClear(IntPtr pvExisting)
        {
            TryRecordClear(pvExisting).ThrowOnNotOK();
        }

        public HRESULT TryRecordClear(IntPtr pvExisting)
        {
            /*HRESULT RecordClear(
            [In] IntPtr pvExisting);*/
            return Raw.RecordClear(pvExisting);
        }

        #endregion
        #region RecordCopy

        public void RecordCopy(IntPtr pvExisting, IntPtr pvNew)
        {
            TryRecordCopy(pvExisting, pvNew).ThrowOnNotOK();
        }

        public HRESULT TryRecordCopy(IntPtr pvExisting, IntPtr pvNew)
        {
            /*HRESULT RecordCopy(
            [In] IntPtr pvExisting,
            [Out] IntPtr pvNew);*/
            return Raw.RecordCopy(pvExisting, pvNew);
        }

        #endregion
        #region GetField

        public object GetField(IntPtr pvData, string szFieldName)
        {
            object pvarField;
            TryGetField(pvData, szFieldName, out pvarField).ThrowOnNotOK();

            return pvarField;
        }

        public HRESULT TryGetField(IntPtr pvData, string szFieldName, out object pvarField)
        {
            /*HRESULT GetField(
            [In] IntPtr pvData,
            [MarshalAs(UnmanagedType.LPWStr), In] string szFieldName,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pvarField);*/
            return Raw.GetField(pvData, szFieldName, out pvarField);
        }

        #endregion
        #region GetFieldNoCopy

        public GetFieldNoCopyResult GetFieldNoCopy(IntPtr pvData, string szFieldName)
        {
            GetFieldNoCopyResult result;
            TryGetFieldNoCopy(pvData, szFieldName, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryGetFieldNoCopy(IntPtr pvData, string szFieldName, out GetFieldNoCopyResult result)
        {
            /*HRESULT GetFieldNoCopy(
            [In] IntPtr pvData,
            [MarshalAs(UnmanagedType.LPWStr), In] string szFieldName,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pvarField,
            [Out] out IntPtr ppvDataCArray);*/
            object pvarField;
            IntPtr ppvDataCArray;
            HRESULT hr = Raw.GetFieldNoCopy(pvData, szFieldName, out pvarField, out ppvDataCArray);

            if (hr == HRESULT.S_OK)
                result = new GetFieldNoCopyResult(pvarField, ppvDataCArray);
            else
                result = default(GetFieldNoCopyResult);

            return hr;
        }

        #endregion
        #region PutField

        public void PutField(int wFlags, IntPtr pvData, string szFieldName, object pvarField)
        {
            TryPutField(wFlags, pvData, szFieldName, pvarField).ThrowOnNotOK();
        }

        public HRESULT TryPutField(int wFlags, IntPtr pvData, string szFieldName, object pvarField)
        {
            /*HRESULT PutField(
            [In] int wFlags,
            [In, Out] IntPtr pvData,
            [MarshalAs(UnmanagedType.LPWStr), In] string szFieldName,
            [In, MarshalAs(UnmanagedType.Struct)] ref object pvarField);*/
            return Raw.PutField(wFlags, pvData, szFieldName, ref pvarField);
        }

        #endregion
        #region PutFieldNoCopy

        public void PutFieldNoCopy(int wFlags, IntPtr pvData, string szFieldName, object pvarField)
        {
            TryPutFieldNoCopy(wFlags, pvData, szFieldName, pvarField).ThrowOnNotOK();
        }

        public HRESULT TryPutFieldNoCopy(int wFlags, IntPtr pvData, string szFieldName, object pvarField)
        {
            /*HRESULT PutFieldNoCopy(
            [In] int wFlags,
            [In, Out] IntPtr pvData,
            [MarshalAs(UnmanagedType.LPWStr), In] string szFieldName,
            [In, MarshalAs(UnmanagedType.Struct)] ref object pvarField);*/
            return Raw.PutFieldNoCopy(wFlags, pvData, szFieldName, ref pvarField);
        }

        #endregion
        #region GetFieldNames

        public void GetFieldNames(ref int pcNames, string[] rgBstrNames)
        {
            TryGetFieldNames(ref pcNames, rgBstrNames).ThrowOnNotOK();
        }

        public HRESULT TryGetFieldNames(ref int pcNames, string[] rgBstrNames)
        {
            /*HRESULT GetFieldNames(
            [In, Out] ref int pcNames,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.BStr, SizeParamIndex = 0)] string[] rgBstrNames);*/
            return Raw.GetFieldNames(ref pcNames, rgBstrNames);
        }

        #endregion
        #region IsMatchingType

        public bool IsMatchingType(IRecordInfo pRecordInfo)
        {
            HRESULT hr = TryIsMatchingType(pRecordInfo);
            hr.ThrowOnFailed();

            return hr == HRESULT.S_OK;
        }

        public HRESULT TryIsMatchingType(IRecordInfo pRecordInfo)
        {
            /*HRESULT IsMatchingType(
            [MarshalAs(UnmanagedType.Interface), In] IRecordInfo pRecordInfo);*/
            return Raw.IsMatchingType(pRecordInfo);
        }

        #endregion
        #region RecordCreate

        public IntPtr RecordCreate()
        {
            /*IntPtr RecordCreate();*/
            return Raw.RecordCreate();
        }

        #endregion
        #region RecordCreateCopy

        public IntPtr RecordCreateCopy(IntPtr pvSource)
        {
            IntPtr ppvDest;
            TryRecordCreateCopy(pvSource, out ppvDest).ThrowOnNotOK();

            return ppvDest;
        }

        public HRESULT TryRecordCreateCopy(IntPtr pvSource, out IntPtr ppvDest)
        {
            /*HRESULT RecordCreateCopy(
            [In] IntPtr pvSource,
            [Out] out IntPtr ppvDest);*/
            return Raw.RecordCreateCopy(pvSource, out ppvDest);
        }

        #endregion
        #region RecordDestroy

        public void RecordDestroy(IntPtr pvRecord)
        {
            TryRecordDestroy(pvRecord).ThrowOnNotOK();
        }

        public HRESULT TryRecordDestroy(IntPtr pvRecord)
        {
            /*HRESULT RecordDestroy(
            [In] IntPtr pvRecord);*/
            return Raw.RecordDestroy(pvRecord);
        }

        #endregion
        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
