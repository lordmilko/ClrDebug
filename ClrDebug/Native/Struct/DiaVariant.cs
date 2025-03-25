using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ClrDebug.TypeLib;

namespace ClrDebug
{
    //You can't use an ICustomMarshaler with a value type. This is a big issue for DIA as when it's not in COM mode, we need to free fake BSTR values using DiaFreeString().
    //Thus, we're unfortunately forced to return a literal VARIANT from DIA and handle the marshalling of it manually. Fortunately, this only applies to out parameters.
    //For in parameters, since we're the ones allocating the VARIANT, we're the one responsible for freeing it, so it doesn't matter if the CLR transmits a "real" BSTR into DIA.

    /// <summary>
    /// Represents a VARIANT value that is compatible with DIA's custom string marshalling rules.<para/>
    /// Any time you receive an instance of this type, you must manually call <see cref="DiaVariant.Free"/>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [DebuggerDisplay("{Value}")]
    public unsafe struct DiaVariant
    {
        //On x86, VARIANT is 16 bytes, while on x64 its 24 bytes.
        //A VARIANT consists of an 8 byte header followed by 2 pointers (tagBRECORD).
        //In order to get the correct alignment, we directly model the header and then
        //use two dummy values to expand the structure to the correct size. Properties
        //can then be used to pull the right value out of the structure

        public VARENUM vt;
        public ushort wReserved1;
        public ushort wReserved2;
        public ushort wReserved3;

        private IntPtr dummy1;
        private IntPtr dummy2;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public long llVal => (long)(long*)dummy1;               //V_I8          / VT_I8
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public int lVal => (int)(int*)dummy1;                 //V_I4          / VT_I4
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public byte bVal => (byte)(byte*)dummy1;                //V_UI1         / VT_UI1
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public short iVal => (short)(short*)dummy1;               //V_I2          / VT_I2
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public float fltVal
        {
            get
            {
                //V_R4          / VT_R4
                fixed (DiaVariant* p = &this)
                {
                    return *(float*) (&p->dummy1);
                }
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public double dblVal
        {
            get
            {
                //V_R8          / VT_R8
                fixed (DiaVariant* p = &this)
                {
                    return *(double*) (&p->dummy1);
                }
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public bool boolVal => ((int)(int*)dummy1) != 0;             //V_BOOL        / VT_BOOL
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public HRESULT scode;          //V_ERROR       / VT_ERROR
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public CY cyVal;               //V_CY          / VT_CY
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public DATE date;              //V_DATE        / VT_DATE
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public string bstrVal;           //V_BSTR        / VT_BSTR
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public IntPtr punkVal;         //V_UNKNOWN     / VT_UNKNOWN
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public IntPtr pdispVal;        //V_DISPATCH    / VT_DISPATCH
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public SAFEARRAY* parray;      //V_ARRAY       / VT_ARRAY
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public byte* pbVal;            //V_UI1REF      /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public short* piVal;           //V_I2REF       /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public int* plVal;             //V_I4REF       /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public long* pllVal;           //V_I8REF       /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public float* pfltVal;         //V_R4REF       /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public double* pdblVal;        //V_R8REF       /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public VARIANT_BOOL* pboolVal; //V_BOOLREF     /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public HRESULT* pscode;        //V_ERRORREF    /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public CY* pcyVal;             //V_CYREF       /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public DATE* pdate;            //V_DATEREF     /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public IntPtr* pbstrVal;       //V_BSTRREF     /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public IntPtr* ppunkVal;       //V_UNKNOWNREF  /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public IntPtr* ppdispVal;      //V_DISPATCHREF /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public SAFEARRAY** pparray;    //V_ARRAYREF    /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public VARIANT* pvarVal;       //V_VARIANTREF  /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public IntPtr byref;           //V_BYREF       /
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public sbyte cVal => (sbyte)(sbyte*)dummy1;               //V_I1          / VT_I1
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public ushort uiVal => (ushort)(ushort*)dummy1;             //V_UI2         / VT_UI2
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public uint ulVal => (uint)(uint*)dummy1;               //V_UI4         / VT_UI4
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public ulong ullVal => (ulong)(ulong*)dummy1;             //V_UI8         / VT_UI8
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public int intVal;             //V_INT         / VT_INT
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public uint uintVal;           //V_UINT        / VT_UINT
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public DECIMAL* pdecVal;       //V_DECIMALREF  /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public CHAR* pcVal;            //V_I1REF       /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public ushort* puiVal;         //V_UI2REF      /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public uint* pulVal;           //V_UI4REF      /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public ulong* pullVal;         //V_UI8REF      /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public int* pintVal;           //V_INTREF      /
        //[DebuggerBrowsable(DebuggerBrowsableState.Never)] public uint* puintVal;         //V_UINTREF     /

        //In the case of DECIMAL decVal, I think it's unioned into the start of the entire VARIANT, but we don't support that

        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public IntPtr pvRecord => dummy1; //V_RECORD
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public IRecordInfo pRecInfo => Extensions.GetObjectForIUnknown<IRecordInfo>(dummy2); //V_RECORDINFO

        public object Value
        {
            get
            {
                return vt switch
                {
                    VARENUM.VT_EMPTY => null,
                    VARENUM.VT_NULL => DBNull.Value,
                    VARENUM.VT_UI1 => bVal,
                    VARENUM.VT_UI2 => uiVal,
                    VARENUM.VT_UI4 => ulVal,
                    VARENUM.VT_UI8 => ullVal,
                    VARENUM.VT_I1 => cVal,
                    VARENUM.VT_I2 => iVal,
                    VARENUM.VT_I4 => lVal,
                    VARENUM.VT_I8 => llVal,
                    VARENUM.VT_R4 => fltVal,
                    VARENUM.VT_R8 => dblVal,
                    VARENUM.VT_BOOL => boolVal,
                    VARENUM.VT_BSTR => Extensions.DiaStringToManaged(dummy1),

#if GENERATED_MARSHALLING
                    VARENUM.VT_UNKNOWN => Extensions.DefaultMarshallingInstance.GetOrCreateObjectForComInstance(*(nint*)dummy1, CreateObjectFlags.None),
#else
                    VARENUM.VT_UNKNOWN => Marshal.GetObjectForIUnknown(dummy1),
#endif
                    _ => throw new NotImplementedException($"Marshalling objects for variants of type {vt} is not yet implemented.")
                };
            }
        }

        public void Free()
        {
            if (vt == VARENUM.VT_BSTR)
                Extensions.DiaFreeString(dummy1);
            else if (vt == VARENUM.VT_UNKNOWN)
            {
                var ptr = *(nint*) dummy1;

                if (ptr != IntPtr.Zero)
                    Marshal.Release(ptr);
            }

            vt = VARENUM.VT_EMPTY;
            dummy1 = IntPtr.Zero;
            dummy2 = IntPtr.Zero;
        }
    }
}
